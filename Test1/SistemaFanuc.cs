using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Xml.Linq;
using System.Xml;
using System.Text.RegularExpressions;
using System.Net;
using System.Diagnostics;

namespace Test1
{
    public class ThreadDNC
    {
        #region Definición de variables
        public StreamReader m_ReaderDNC;
        public volatile bool m_bEnabled;
        public ushort m_dMiManipulador;
        #endregion

        public void ThreadProc() 
        {
            if (!m_bEnabled)
                return;
            using (m_ReaderDNC)
            {
                String Cadena = m_ReaderDNC.ReadLine();
                if (m_ReaderDNC.Peek() == -1)
                {
                    m_ReaderDNC.Close();
                    m_bEnabled = false;
                    return;
                }
                String Linea = String.Copy(Cadena);
                Int32 len = Linea.Count();
                Int32 n;
                while (len > 0)
                {
                    n = len;
                    Focas1.focas_ret ret = (Focas1.focas_ret)Focas1.cnc_download3 (m_dMiManipulador, ref n, Linea);
                    if (ret == (Focas1.focas_ret)Focas1.focas_ret.EW_BUFFER)
                        continue;
                    if (ret == Focas1.EW_OK)
                    {
                        Linea += n;
                        len -= n;
                    }
                    else
                    {
                        m_ReaderDNC.Close();
                        m_bEnabled = false;
                        return;
                    }
                }
            }
        }
    }

    class SistemaFanuc:SistemaTecoi
    {
        #region Definición de variables

        int FANUC_RETARDO = 200;
        int FANUC_RETARDO_MANUAL = 20;

        protected ushort m_dMiManipulador;
        protected Focas1.ODBST cncStatus = new Focas1.ODBST();
        protected Focas1.ODBAHIS alarmHis = new Focas1.ODBAHIS();
        protected Focas1.IODBPSD_1 prmDataNoAxis = new Focas1.IODBPSD_1();
        //protected Focas1.IODBPSD_3 prmData = new Focas1.IODBPSD_3();
        protected Focas1.ODBERR err = new Focas1.ODBERR();
        protected Focas1.ODBAXIS EjesAbsolutas = new Focas1.ODBAXIS();
        protected Focas1.ODBAXIS EjesRelativas = new Focas1.ODBAXIS();
        protected Focas1.ODBACT ActualFeed = new Focas1.ODBACT();
        protected Focas1.IODBPMC0 Buffer = new Focas1.IODBPMC0();
        protected Focas1.IODBPMC1 Buffer1 = new Focas1.IODBPMC1();
        protected Focas1.IODBPMC2 Buffer2 = new Focas1.IODBPMC2();
        protected Focas1.ODBM BufferMacro = new Focas1.ODBM();

        private short m_TipoDireccion;
        private short m_TipoDato;
        private ushort m_DireccionInicio;
        private ushort m_DireccionFin;
        private ushort m_Tamano;


        ThreadDNC m_MiDNC;
        Thread m_ThreadDNC;
        StreamReader m_ReaderDNC;

        protected Focas1.focas_ret ret;
        
        #endregion

        public SistemaFanuc()
        {
            m_bParadaEmergencia = false;
            m_MiDNC = new ThreadDNC();
            m_MiDNC.m_bEnabled = false;
            m_ThreadDNC = new Thread(new ThreadStart(m_MiDNC.ThreadProc));
        }
        ~SistemaFanuc()
        {
            m_MiDNC = null;
            m_ThreadDNC = null;
            GC.Collect();
        }

        public override bool ConectarAutomata(int dNodo = 0)
        {
            ret = (Focas1.focas_ret)Focas1.cnc_allclibhndl2 (dNodo, out m_dMiManipulador);
            m_bConectadoAutomata = ret == Focas1.focas_ret.EW_OK;
            LeerConfiguracionAutomata();
            m_dNumeroEjesSistema = LeerNumeroEjes();
            m_MiDNC.m_dMiManipulador = m_dMiManipulador;
            FanucActivarKey();
            FanucModoMDI();
            return (m_bConectadoAutomata);
        }
        public override bool ConectarAutomata(String IpAddress, ushort dPuerto)
        {
            ret = (Focas1.focas_ret)Focas1.cnc_allclibhndl3 (IpAddress, dPuerto, 5, out m_dMiManipulador);
            m_bConectadoAutomata = ret == Focas1.focas_ret.EW_OK;
            LeerConfiguracionAutomata();
            m_dNumeroEjesSistema = LeerNumeroEjes();
            m_MiDNC.m_dMiManipulador = m_dMiManipulador;
            FanucActivarKey();
            FanucModoMDI();
            return (m_bConectadoAutomata);
        }
        public override void LecturaPosicionesEjes ()
        {
            foreach (EjeMaquina x in m_EjeMaquina)
            {
                if (x.m_dTipoEje == 1)  // Es un eje lineal
                {
                    if (x.m_dCodigoEje != 2)    // No es eje Z
                    {
                        ushort Direccion = (ushort)(7398+4*x.m_dNumEje);
                        ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, 5, 0,
                            Direccion, (ushort)(Direccion+3), 12, Buffer2);
                        x.m_lfPosicion = Buffer2.ldata[0]*0.001;
                    }
                    else   // Es un eje lineal
                    {
                        ret = (Focas1.focas_ret)Focas1.cnc_machine(m_dMiManipulador, (short)(x.m_dNumEje+1),
                            8, EjesAbsolutas);
                        x.m_lfPosicion = EjesAbsolutas.data[0]*0.001;
                    }
                }
                else
                {
                    ret = (Focas1.focas_ret)Focas1.cnc_relative(m_dMiManipulador, (short)(x.m_dNumEje+1), 
                        8, EjesAbsolutas);
                    x.m_lfPosicion = EjesAbsolutas.data[0]*0.001;
                }
            }
        }
        public override bool Salir()
        {
            ret = Focas1.focas_ret.EW_OK;
            if (m_bConectadoAutomata)
                ret = (Focas1.focas_ret)Focas1.cnc_freelibhndl (m_dMiManipulador);
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public virtual int LeerNumeroEjes ()
        {
            int i;
            ret = (Focas1.focas_ret)Focas1.cnc_absolute(m_dMiManipulador, -1, 4+4*Focas1.ALL_AXES, EjesAbsolutas);
            if (ret == Focas1.focas_ret.EW_OK)
                return (-1);
            for (i = 0; i < Focas1.ALL_AXES; i++)
                if (EjesAbsolutas.type < 0)
                    break;
            return (i);
        }
        public virtual bool FanucActivarKey () 
        {
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)5, (short)0,
                (ushort)1005, (ushort)1005, (ushort)9, Buffer);
            Buffer.cdata[0] |= 0x80;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public virtual bool FanucDesactivarKey()
        {
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)5, (short)0,
                (ushort)1005, (ushort)1005, (ushort)9, Buffer);
            Buffer.cdata[0] |= 0x7F;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public virtual bool FanucPararProgramaActivo()
        {
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)5, (short)0,
                (ushort)1006, (ushort)1006, (ushort)9, Buffer);
            Buffer.cdata[0] = 1;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
            Buffer.cdata[0] = 0;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public virtual bool FanucReset()
        {
            if (!FanucSetaPulsada())
                return (true);
            byte by_valor = 4;

            int i = 0;
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)5, (short)0,
                (ushort)1006, (ushort)1006, (ushort)9, Buffer);
            Buffer.cdata[0] |= (byte)by_valor;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
            Buffer.cdata[0] &= (byte)(~by_valor);
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO);


            for (i = 0; i < 400; i++)   // 8 segundos
            {
                ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, 1, 0,
                    1, 1, 9, Buffer);
                if (m_FanucGlobalVariables.dNumeroAlarmas > 0)	// 13AGO2015 Ruben dice que Cuando hay una alarma se confirma con la F1.0
                {
                    if ((Buffer.cdata[0] & (byte)1) == 0)
                        break;
                }
                if (((Buffer.cdata[0] >> 1) & (byte)1) == 0)
                    break;
                Thread.Sleep(FANUC_RETARDO_MANUAL);
            }

            ret = (Focas1.focas_ret)Focas1.cnc_wrmacro(m_dMiManipulador, 1000, 10, 1, 0);
            ret = (Focas1.focas_ret)Focas1.cnc_wrmacro(m_dMiManipulador, 1001, 10, 1, 0);
            ret = (Focas1.focas_ret)Focas1.cnc_wrmacro(m_dMiManipulador, 1002, 10, 1, 0);
            ret = (Focas1.focas_ret)Focas1.cnc_wrmacro(m_dMiManipulador, 1100, 10, 0, 0);
            ret = (Focas1.focas_ret)Focas1.cnc_wrmacro(m_dMiManipulador, 1101, 10, 0, 0);
            ret = (Focas1.focas_ret)Focas1.cnc_wrmacro(m_dMiManipulador, 1102, 10, 0, 0);

            if (i < 400)
                return (true);
            return false;
        }
        public void FanucBorrarFicheroActivo (int dNumPrograma)
        {
            ret = (Focas1.focas_ret)Focas1.cnc_search (m_dMiManipulador, 4321);
            if (ret == Focas1.focas_ret.EW_OK)	// No existe fichero dummy
            {
        	    String FicheroDummy = "\nO4321\nM30\n%%\n";
		        ret = (Focas1.focas_ret)Focas1.cnc_dwnend (m_dMiManipulador);
		        ret = (Focas1.focas_ret)Focas1.cnc_dwnstart (m_dMiManipulador);
	            ret = (Focas1.focas_ret)Focas1.cnc_download (m_dMiManipulador, FicheroDummy, (short)FicheroDummy.Length);
	            ret = (Focas1.focas_ret)Focas1.cnc_dwnend (m_dMiManipulador);
	            ret = (Focas1.focas_ret)Focas1.cnc_search (m_dMiManipulador, 4321);
            }
            ret = (Focas1.focas_ret)Focas1.cnc_delete(m_dMiManipulador, (short)dNumPrograma);
            Thread.Sleep(FANUC_RETARDO);
        }
        public virtual bool FanucEsperaReset()
        {
            m_TipoDireccion = 5;
            m_TipoDato = 0;
            m_DireccionInicio = 1006;
            m_DireccionFin = 1006;
            m_Tamano = 9;

            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, m_TipoDireccion, m_TipoDato,
                m_DireccionInicio, m_DireccionFin, m_Tamano, Buffer);
            return (Buffer.cdata[0] == 4);
        }
        public virtual bool FanucSetaPulsada ()
        {
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)5, (short)0,
                (ushort)2018, (ushort)2018, (ushort)9, Buffer);
            return ((Buffer.cdata[0] & (byte)0x01) == (byte)0x01);
        }
        public virtual bool FanucModoEdit()
        {
            bool b_EsEdit = false;

            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)5, (short)0,
                (ushort)1004, (ushort)1004, (ushort)9, Buffer);
            Buffer.cdata[0] = 2;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
            Buffer.cdata[0] = 0;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)9, (short)0,
                (ushort)3, (ushort)3, (ushort)9, Buffer);
                
            b_EsEdit = ((Buffer.cdata[0] >> 6) & 1) == 1;
            return (b_EsEdit);
        }
        public virtual bool FanucModoMem()
        {
            bool b_EsMem = false;

            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)1, (short)0,
                (ushort)3, (ushort)3, (ushort)9, Buffer);

            for (int i = 0; i < 10; i++)
            {

                m_TipoDireccion = 5;
                m_DireccionInicio = 1004;
                m_DireccionFin = 1004;
                ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)5, (short)0,
                    (ushort)1004, (ushort)1004, (ushort)9, Buffer);
                Buffer.cdata[0] = 1;
                ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
                Thread.Sleep(FANUC_RETARDO);
                Buffer.cdata[0] = 0;
                ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
                Thread.Sleep(FANUC_RETARDO);
                ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)1, (short)0,
                    (ushort)3, (ushort)3, (ushort)9, Buffer);
                b_EsMem = ((Buffer.cdata[0] >> 4) & 1) == 1;
            }
            return (b_EsMem);
        }
        public virtual bool FanucModoMDI()
        {
            byte by_valor = 4;
            bool b_EsMDI = false;

            for (int i = 0; i < 10; i++)
            {
                ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)5, (short)0,
                    (ushort)1004, (ushort)1004, (ushort)9, Buffer);
                Buffer.cdata[0] |= by_valor;
                ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
                Thread.Sleep(FANUC_RETARDO);
                Buffer.cdata[0] &= (byte)(~by_valor);
                ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
                Thread.Sleep(FANUC_RETARDO);
                ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)1, (short)0,
                    (ushort)3, (ushort)3, (ushort)9, Buffer);

                b_EsMDI = ((Buffer.cdata[0] >> 3) & 1) == 1;
            }
            return (b_EsMDI);

        }
        public virtual bool FanucModoJOG()
        {
            byte by_valor = 0x20;
            bool b_EsJOG = false;

            m_bParadaEmergencia = false;

            for (int i = 0; i < 10; i++)
            {

                m_TipoDireccion = 5;
                m_DireccionInicio = 1006;
                m_DireccionFin = 1006;
                ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)5, (short)0,
                    (ushort)1006, (ushort)1006, (ushort)9, Buffer);
                Buffer.cdata[0] |= by_valor;
                ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
                Thread.Sleep(FANUC_RETARDO);
                Buffer.cdata[0] &= (byte)(~(int)by_valor);
                ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
                Thread.Sleep(FANUC_RETARDO);
                m_TipoDireccion = 1;
                m_DireccionInicio = 3;
                m_DireccionFin = 3;
                ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)1, (short)0,
                    (ushort)3, (ushort)3, (ushort)9, Buffer);
                b_EsJOG = ((Buffer.cdata[0] >> 2) & 1) == 1;
            }

            return (b_EsJOG);
        }
        public virtual void FanucKeyCycleStart()
        {
            byte by_valor = 2;
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)5, (short)0,
                (ushort)1006, (ushort)1006, (ushort)9, Buffer);
            Buffer.cdata[0] |= by_valor;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
            Buffer.cdata[0] &= (byte)(~(int)by_valor);
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
        }
        public virtual void FanucKeyCycleStop()
        {
            byte by_valor = 1;
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)5, (short)0,
                (ushort)1006, (ushort)1006, (ushort)9, Buffer);
            Buffer.cdata[0] = by_valor;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
            by_valor = 0;
            Buffer.cdata[0] = by_valor;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
        }
        public virtual bool IsBitSet (byte value, ushort bitNumber)
        {
            return ((value & (1 << bitNumber)) != 0);
        }
        public override bool EnviarProgramaThread(String Nombre, short dNumPrograma)
        {
            FanucPararProgramaActivo();
            FanucModoEdit();
            FanucPararProgramaActivo();
            FanucBorrarFicheroActivo(dNumPrograma);
            FanucReset();
            ret = (Focas1.focas_ret)Focas1.cnc_wrmacro(m_dMiManipulador, 542, 10, 0, 0);
            if (m_ReaderDNC != null)
                m_ReaderDNC.Close();
            m_ReaderDNC = new StreamReader(Nombre);
            ret = (Focas1.focas_ret)Focas1.cnc_dwnstart3(m_dMiManipulador, 0);
            if (ret == Focas1.EW_OK)
            {
                Thread.Sleep(FANUC_RETARDO);
                m_MiDNC.m_dMiManipulador = m_dMiManipulador;
                m_MiDNC.m_ReaderDNC = m_ReaderDNC;
                m_MiDNC.m_bEnabled = false;
                m_ThreadDNC.Abort();
                m_ThreadDNC.Join();
                m_MiDNC.m_bEnabled = true;
                m_ThreadDNC.Start();
                while (!m_ThreadDNC.IsAlive);
            }
            return (true);
        }
        public override bool EnviarPrograma(String Nombre, short prog_number)
        {
            int len, n, last_nl, send_chars = 0, max_length = 1024;
            string next = "", line = "\n", r_line;

            max_length = 256;

            ret = (Focas1.focas_ret)Focas1.cnc_delete (m_dMiManipulador, prog_number);

            ret = (Focas1.focas_ret)Focas1.cnc_dwnstart3 (m_dMiManipulador, 0);
            if (ret != Focas1.EW_OK)
                return (false);
            len = line.Length;
            ret = (Focas1.focas_ret)Focas1.cnc_download3 (m_dMiManipulador, ref len, line);
            if (ret != Focas1.EW_OK)
                return (false);

            using (StreamReader reader = new StreamReader(Nombre))
            {
                var flen = new System.IO.FileInfo(Nombre).Length;
                while ((r_line = reader.ReadLine()) != null)
                {
                    line = next + r_line + "\n";
                    len = line.Length;
                    while ((len < max_length) && ((r_line = reader.ReadLine()) != null))
                    {
                        line = line + r_line + "\n";
                        len = line.Length;
                    }
                    if (len > max_length)
                    {
                        last_nl = line.LastIndexOf ('\n', max_length);
                        next = line.Substring(last_nl);
                        line = line.Remove(last_nl);
                        len = line.Length;
                    }
                    else
                        next = "";
                    while (len > 0)
                    {
                        n = len;
                        ret = (Focas1.focas_ret)Focas1.cnc_download3 (m_dMiManipulador, ref n, line);
                        if (ret == (Focas1.focas_ret)Focas1.focas_ret.EW_BUFFER) 
                            continue;
                        if (ret == Focas1.EW_OK)
                        {
                            line += n;
                            send_chars += n;
                            len -= n;
                        }
                        if (ret != Focas1.EW_OK) 
                        { 
                            Focas1.cnc_getdtailerr(m_dMiManipulador, err); 
                            break; 
                        }
                    }
                    for (int i = 0; i < 1500; i++) 
                    { 
                        line = " "; 
                        line += i; 
                    }
                }
            }
            ret = (Focas1.focas_ret)Focas1.cnc_dwnend3 (m_dMiManipulador);
            if (ret != Focas1.EW_OK)
                return (false);
            return (true);
        }
        public override bool GenerarFicheroISO(Trabajo Work, string Fichero)
        {
            StreamWriter StreamFileISO = new StreamWriter(Fichero);
            StreamFileISO.Write("O1234\n");
            StreamFileISO.Write("G90\n");
            foreach (Pieza f in Work.m_Piezas)
            { 
                foreach (Bloque b in f.m_Bloques)
                {
                   if (!b.m_bEsMovimientoCorte)
                        continue;
                    foreach (MaquinaNormal m in m_Maquinas)
                    {
                        if (b.m_MachinaCode == m.m_MachinaCode)
                        {
                            m.PosicionadoBloque(StreamFileISO, b);
                            m.PrepararProcesadoBloque(StreamFileISO, b);
                            m.Bloque2ISO(StreamFileISO, b);
                            m.PrepararSalidaProcesadoCorte(StreamFileISO, b);
                            break;
                        }
                    }
                }
            }
            StreamFileISO.Write("M30\n");
            StreamFileISO.Write("%\n");
            StreamFileISO.Close();

            return (true);
        }
        public override bool GenerarSubrutinas(String Fichero)
        {
            int n = 1;
            StreamWriter StreamFileCNC = new StreamWriter(Fichero);
            if (StreamFileCNC == null)
                return (false);

//
//  -- Encender Herramienta
//

            StreamFileCNC.Write("O1500\n"); 
            foreach (Herramienta h in m_Herramientas)
            {
                h.EscribirSubrutina_EncenderHerramienta(StreamFileCNC, n);
                n += 50;
            }
            StreamFileCNC.Write("N1000000 M99\n");
            StreamFileCNC.Write("M30\n");
            StreamFileCNC.Write("%\n\n");

//
//  -- Apagar Herramienta
//

            n = 1;
            StreamFileCNC.Write("O1501\n");
            foreach (Herramienta h in m_Herramientas)
            {
                h.EscribirSubrutina_ApagarHerramienta(StreamFileCNC, n);
                n += 50;
            }
            StreamFileCNC.Write("N1000000 M99\n");
            StreamFileCNC.Write("M30\n");
            StreamFileCNC.Write("%\n");

//
//  -- Subrutina de altura de cebado.
//

            n = 1;
            StreamFileCNC.Write("O1502\n");
            foreach (Herramienta h in m_Herramientas)
            {
                h.EscribirSubrutina_AlturaCebado(StreamFileCNC, n);
                n += 100;
            }
            StreamFileCNC.Write("N1000000 M99\n");
            StreamFileCNC.Write("M30\n");
            StreamFileCNC.Write("%\n\n");

//
//  -- Subrutina de primera altura de corte.
//

            n = 1;
            StreamFileCNC.Write("O1503\n");
            foreach (Herramienta h in m_Herramientas)
            {
                h.EscribirSubrutina_AlturaCorte1(StreamFileCNC, n);
                n += 100;
            }
            StreamFileCNC.Write("N1000000 M99\n");
            StreamFileCNC.Write("M30\n");
            StreamFileCNC.Write("%\n\n");

//
//  -- Subrutina de segunda altura de corte.
//

            n = 1;
            StreamFileCNC.Write("O1504\n");
            foreach (Herramienta h in m_Herramientas)
            {
                h.EscribirSubrutina_AlturaCorte2(StreamFileCNC, n);
                n += 100;
            }
            StreamFileCNC.Write("N1000000 M99\n");
            StreamFileCNC.Write("M30\n");
            StreamFileCNC.Write("%\n\n"); 

//
//  -- Subrutina de altura de vacío.
 //

            n = 1;
            StreamFileCNC.Write("O1505\n");
            foreach (Herramienta h in m_Herramientas)
            {
                h.EscribirSubrutina_AlturaVacio(StreamFileCNC, n);
                n += 50;
            }
            
            StreamFileCNC.Write("N1000000 M99\n");
            StreamFileCNC.Write("M30\n");
            StreamFileCNC.Write("%\n\n");

            StreamFileCNC.Close();
            return (true);
        }
        public override bool EnviarSubrutinas(String Fichero, bool bMem, bool bUser)
        {
            StreamReader StreamFileCNC = new StreamReader(Fichero);
            if (StreamFileCNC == null)
                return (false);

            String linea;
            int n;
            short dNumeroPrograma;

            FanucActivarKey ();
            FanucPararProgramaActivo ();
	        FanucReset ();

	        FanucModoEdit ();
	        prmDataNoAxis.datano = 20;
	        prmDataNoAxis.type = 0;

	        ret = (Focas1.focas_ret)Focas1.cnc_rdparam (m_dMiManipulador, 20, 0, 5, prmDataNoAxis);
	        prmDataNoAxis.cdata = 4;
	        Thread.Sleep(FANUC_RETARDO);
            ret = (Focas1.focas_ret)Focas1.cnc_wrparam (m_dMiManipulador, 5, prmDataNoAxis);

//
//      -- Siempre se envía las subrutinas al CNC en directorio nuevo.
//

	        char []CarpetaOriginalRutinas = new char[256];
            ret = (Focas1.focas_ret)Focas1.cnc_rdpdf_curdir(m_dMiManipulador, 1, CarpetaOriginalRutinas);
            ret = (Focas1.focas_ret)Focas1.cnc_wrpdf_curdir(m_dMiManipulador, 1, "//CNC_MEM/MTB1/");
            ret = (Focas1.focas_ret)Focas1.cnc_delall(m_dMiManipulador);
	        FanucModoEdit ();
            ret = (Focas1.focas_ret)Focas1.cnc_delall(m_dMiManipulador);

            if (bMem)
            {
                prmDataNoAxis.datano = 20;
                prmDataNoAxis.type = 0;
                ret = (Focas1.focas_ret)Focas1.cnc_rdparam(m_dMiManipulador, 20, 0, 5, prmDataNoAxis);
                prmDataNoAxis.cdata = 4;
                Thread.Sleep(FANUC_RETARDO);
                ret = (Focas1.focas_ret)Focas1.cnc_wrparam(m_dMiManipulador, 5, prmDataNoAxis);
                StreamFileCNC.BaseStream.Seek(0, SeekOrigin.Begin);
                while (!StreamFileCNC.EndOfStream) 
                {

//
//	-- Buscamos número de programa
//

                    do
                    {
                            while ((linea = StreamFileCNC.ReadLine()) == null) 
                                break;
                    } while (linea[0] != 'O');
                    if (StreamFileCNC.EndOfStream)
                            break;
                    dNumeroPrograma = Convert.ToInt16(linea.Substring(1));
                    FanucModoEdit ();

                    ret = (Focas1.focas_ret)Focas1.cnc_dwnstart4(m_dMiManipulador, 0, "//CNC_MEM/MTB1/");
                    linea = String.Format ("\nO{0:0000}\n", dNumeroPrograma);
                    while (linea[0] != '%')
                    {
                        n = linea.Length;
                        ret = (Focas1.focas_ret)Focas1.cnc_download4(m_dMiManipulador, ref n, linea);
                        if (ret == Focas1.focas_ret.EW_HANDLE)
                        {
                            StreamFileCNC.Close();
                            return (false);
                        }
                        if (n < linea.Length)
		    	        {
                            Thread.Sleep(150);
                            linea = linea.Substring(n);
                            n = linea.Length;
                            ret = (Focas1.focas_ret)Focas1.cnc_download4(m_dMiManipulador, ref n, linea);
                        }
                        if (ret == Focas1.focas_ret.EW_BUFFER)
                            continue;
                        if (ret == Focas1.focas_ret.EW_OK)
                        {
                            if ((linea = StreamFileCNC.ReadLine()) == null) 
                                break;
                            n = linea.Length;
                        }
                        if (ret == Focas1.focas_ret.EW_OK)
                        {
                            ret = (Focas1.focas_ret)Focas1.cnc_getdtailerr(m_dMiManipulador, err);
                            break;
                        }
                    }
                    n = 1;

                    ret = (Focas1.focas_ret)Focas1.cnc_download4(m_dMiManipulador, ref n, linea);
                    ret = (Focas1.focas_ret)Focas1.cnc_dwnend4(m_dMiManipulador);
                }
            }

//
//      -- Siempre se envías las subrutinas al CNC (por los programas MDI).
//

	        FanucModoEdit ();
            ret = (Focas1.focas_ret)Focas1.cnc_wrpdf_curdir(m_dMiManipulador, 1, "//CNC_MEM/USER/PATH1/");
            ret = (Focas1.focas_ret)Focas1.cnc_delall(m_dMiManipulador);
            if (bUser)
            {
                FanucModoEdit ();
                StreamFileCNC.BaseStream.Seek(0, SeekOrigin.Begin);
                while (!StreamFileCNC.EndOfStream)
                {
                    do
                    {
                        while ((linea = StreamFileCNC.ReadLine()) == null)
                            break;
                    } while (linea[0] != 'O');
                    if (StreamFileCNC.EndOfStream)
                        break;
                    dNumeroPrograma = Convert.ToInt16(linea + 1);
                    FanucModoEdit();

                    ret = (Focas1.focas_ret)Focas1.cnc_dwnstart3(m_dMiManipulador, 0);
                    linea = String.Format("\nO{0:0000}\n", dNumeroPrograma);
                    while (linea[0] != '%')
                    {
                        n = linea.Length;
                        ret = (Focas1.focas_ret)Focas1.cnc_download3 (m_dMiManipulador, ref n, linea);
    			        if (n < linea.Length)
	    		        {
                            Thread.Sleep(150);
                            linea = linea.Substring(n);
                            n = linea.Length;
                            ret = (Focas1.focas_ret)Focas1.cnc_download3 (m_dMiManipulador, ref n, linea);
    			        }
                        if (ret == Focas1.focas_ret.EW_HANDLE)
                        {
                            StreamFileCNC.Close();
                            return (false);
                        }
                        if (ret == Focas1.focas_ret.EW_BUFFER)
                            continue;
                        if (ret == Focas1.focas_ret.EW_OK)
                        {
                            if ((linea = StreamFileCNC.ReadLine()) == null) 
                                break;
                            n = linea.Length;
                        }
                        if (ret != Focas1.focas_ret.EW_OK)
                            break;
                    }
                    n = 1;

                    ret = (Focas1.focas_ret)Focas1.cnc_download3 (m_dMiManipulador, ref n, linea);
                    ret = (Focas1.focas_ret)Focas1.cnc_dwnend3 (m_dMiManipulador);
                }

	            StreamFileCNC.Close ();
            }

    	    ret = (Focas1.focas_ret)Focas1.cnc_wrpdf_curdir (m_dMiManipulador, 1, CarpetaOriginalRutinas);
            prmDataNoAxis.datano = 3457;
	        prmDataNoAxis.type = 0;
	        ret = (Focas1.focas_ret)Focas1.cnc_rdparam (m_dMiManipulador, 20, 0, 5, prmDataNoAxis);
            prmDataNoAxis.cdata = 0x8B;
	        ret = (Focas1.focas_ret)Focas1.cnc_wrparam (m_dMiManipulador, 5, prmDataNoAxis);

            prmDataNoAxis.datano = 20;
       	    prmDataNoAxis.type = 0;
            ret = (Focas1.focas_ret)Focas1.cnc_rdparam (m_dMiManipulador, 20, 0, 5, prmDataNoAxis);
            /*
            if (FanucGeneral->bEnviarDataServer)
        	    prmDataNoAxis.cdata = 5;
            else
        	    prmDataNoAxis.cdata = 15;
            */
            Thread.Sleep(FANUC_RETARDO);
            ret = (Focas1.focas_ret)Focas1.cnc_wrparam (m_dMiManipulador, 5, prmDataNoAxis);

            return (true);
        }
        public override bool LeerConfiguracionAutomata()
        {
            UInt16 TamanoBuffer;
            UInt16 Tamano = 10240;
            byte[] bytes = new byte[Tamano]; 
            UInt16 m = 0;
            byte[] DatosBytes = FanucGeneral.getBytes();
            do
            {
                TamanoBuffer = Math.Min((UInt16)255, Tamano);
                ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, 9, 0, m, (UInt16)(m+TamanoBuffer),
                    (UInt16)(TamanoBuffer + 9), Buffer);
                if (ret != (Focas1.focas_ret)Focas1.EW_OK)
                    break;
                Array.Copy(Buffer.cdata, TamanoBuffer, bytes, m, TamanoBuffer);
                Tamano -= TamanoBuffer;
                m += TamanoBuffer;
                Thread.Sleep(FANUC_RETARDO_MANUAL);
            } while (Tamano > 0);

            LeerConfiguracionAutomataMemoryStream(bytes);

            return (Tamano > 0);
        }
        public override bool LeerConfiguracionAutomata(String Fichero)
        {
            FileStream file = new FileStream(Fichero, FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[file.Length];
            file.Read(bytes, 0, (int)file.Length);
            LeerConfiguracionAutomataMemoryStream (bytes);
            file.Close();
            return (true);
        }
        public bool LeerConfiguracionAutomataMemoryStream(byte[] Memoria)
        {
            LeerFanucGeneral(Memoria);
            LeerFanucCarenados(Memoria);
            LeerFanucCompuertas(Memoria);
            LeerFanucEjesX(Memoria);
            LeerFanucEjesY(Memoria);
            LeerFanucEjesZ(Memoria);
            LeerFanucEjesV(Memoria);
            LeerFanucEjesW(Memoria);
            LeerFanucPlasmaSoplete(Memoria);
            LeerFanucVariablesMacros(Memoria);
            LeerFanucSubrutinas(Memoria);
            LeerFanucGeneral2(Memoria);
            LeerFanucGeneral3(Memoria);
            return (true);
        }
        public bool LeerFanucGeneral(byte[] Memoria) //  -- Leer Fanuc General D1100 - D1450 --> 350
        {
            byte[] DatosBytes = new byte[FanucGeneral.TamanoArray()];
            Array.Copy(Memoria, 1100, DatosBytes, 0, DatosBytes.Length);
            FanucGeneral.fromBytes(DatosBytes);
            return (true);
        }
        public bool LeerFanucCarenados(byte[] Memoria) //  -- Leer Fanuc Carenados D1450 - D1600 --> 4x30
        {
            for (int i = 0; i < MAX_CARENADOS; i++)
            {
                byte[] DatosBytes = FanucCarenados[i].getBytes();
                int Inicio = 1450+i*30;
                Array.Copy(Memoria, Inicio, DatosBytes, 0, DatosBytes.Length);
                FanucCarenados[i].fromBytes(DatosBytes);
            }
            return (true);
        }
        public bool LeerFanucCompuertas(byte[] Memoria) //  -- Leer Fanuc Compuertas D16000 - D2000 --> 48x8
        {
            for (int i = 0; i < MAX_COMPUERTAS; i++)
            {
                byte[] DatosBytes = FanucCompuertas[i].getBytes();
                int Inicio = 1600+i*8;
                Array.Copy(Memoria, Inicio, DatosBytes, 0, DatosBytes.Length);
                FanucCompuertas[i].fromBytes(DatosBytes);
            }
            return (true);
        }
        public bool LeerFanucEjesX(byte[] Memoria) //  -- Leer Fanuc Ejes X D2000 - D2200 --> 2x100
        {
            for (int i = 0; i < MAX_EJES_X; i++)
            {
                byte[] DatosBytes = FanucEjeX[i].getBytes();
                int Inicio = 2000+i*100;
                Array.Copy(Memoria, Inicio, DatosBytes, 0, DatosBytes.Length);
                FanucEjeX[i].fromBytes(DatosBytes);
            }
            return (true);
        }
        public bool LeerFanucEjesY(byte[] Memoria) //  -- Leer Fanuc Ejes Y D2000 - D2800 --> 6x100
        {
            for (int i = 0; i < MAX_EJES_Y; i++)
            {
                byte[] DatosBytes = FanucEjeY[i].getBytes();
                int Inicio = 2200+i*100;
                Array.Copy(Memoria, Inicio, DatosBytes, 0, DatosBytes.Length);
                FanucEjeY[i].fromBytes(DatosBytes);
            }
            return (true);
        }
        public bool LeerFanucEjesZ(byte[] Memoria) //  -- Leer Fanuc Ejes Z D2800 - D3400 --> 6x100
        {
            for (int i = 0; i < MAX_EJES_Z; i++)
            {
                byte[] DatosBytes = FanucEjeZ[i].getBytes();
                int Inicio = 2800+i*100;
                Array.Copy(Memoria, Inicio, DatosBytes, 0, DatosBytes.Length);
                FanucEjeZ[i].fromBytes(DatosBytes);
            }
            return (true);
        }
        public bool LeerFanucEjesV(byte[] Memoria) //  -- Leer Fanuc Ejes A D3400 - D4000 --> 6x100
        {
            for (int i = 0; i < MAX_EJES_V; i++)
            {
                byte[] DatosBytes = FanucEjeV[i].getBytes();
                int Inicio = 3400+i*100;
                Array.Copy(Memoria, Inicio, DatosBytes, 0, DatosBytes.Length);
                FanucEjeV[i].fromBytes(DatosBytes);
            }
            return (true);
        }
        public bool LeerFanucEjesW(byte[] Memoria) //  -- Leer Fanuc Ejes B D4000 - D4600 --> 6x100
        {
            for (int i = 0; i < MAX_EJES_W; i++)
            {
                byte[] DatosBytes = FanucEjeW[i].getBytes();
                int Inicio = 4000+i*100;
                Array.Copy(Memoria, Inicio, DatosBytes, 0, DatosBytes.Length);
                FanucEjeW[i].fromBytes(DatosBytes);
            }
            return (true);
        }
        public bool LeerFanucPlasmaSoplete(byte[] Memoria) //  -- Leer Fanuc Plasma/Soplete D4600 - D6000 --> 6x250
        {
            for (int i = 0; i < MAX_PLASMA_SOPLETE; i++)
            {
                byte[] DatosBytes = FanucPlasmaSoplete[i].getBytes();
                int Inicio = 4600+i*250;
                Array.Copy(Memoria, Inicio, DatosBytes, 0, DatosBytes.Length);
                FanucPlasmaSoplete[i].fromBytes(DatosBytes);
            }
            return (true);
        }
        public bool LeerFanucVariablesMacros(byte[] Memoria) //  -- Leer Fanuc Variables Macro D6300 - D6400
        {
            byte[] DatosBytes = FanucVariablesMacros.getBytes();
            Array.Copy(Memoria, 6300, DatosBytes, 0, DatosBytes.Length);
            FanucVariablesMacros.fromBytes(DatosBytes);
            return (true);
        }
        public bool LeerFanucSubrutinas(byte[] Memoria) //  -- Leer Fanuc Subroutinas D6400 - D6600
        {
            byte[] DatosBytes = FanucSubrutinas.getBytes();
            Array.Copy(Memoria, 6400, DatosBytes, 0, DatosBytes.Length);
            FanucSubrutinas.fromBytes(DatosBytes);
            return (true);
        }
        public bool LeerFanucGeneral2(byte[] Memoria) //  -- Leer Fanuc General2 D6600 - 7000
        {
            byte[] DatosBytes = FanucGeneral2.getBytes();
            Array.Copy(Memoria, 6600, DatosBytes, 0, DatosBytes.Length);
            FanucGeneral2.fromBytes(DatosBytes);
            return (true);
        }
        public bool LeerFanucGeneral3(byte[] Memoria) //  -- Leer Fanuc General3 D3700 - 4000
        {
            byte[] DatosBytes = FanucGeneral3.getBytes();
            Array.Copy(Memoria, 3700, DatosBytes, 0, DatosBytes.Length);
            FanucGeneral3.fromBytes(DatosBytes);
            return (true);
        }
        public override bool EscribirConfiguracionAutomata()
        {
            UInt16 Tamano = 10240;
            byte[] Memoria = new byte[Tamano];

            EscribirFanucGeneral(Memoria);
            EscribirFanucCarenados(Memoria);
            EscribirFanucCompuertas(Memoria);
            EscribirFanucEjesX(Memoria);
            EscribirFanucEjesY(Memoria);
            EscribirFanucEjesZ(Memoria);
            EscribirFanucEjesV(Memoria);
            EscribirFanucEjesW(Memoria);
            EscribirFanucPlasmaSoplete(Memoria);
            EscribirFanucVariablesMacros(Memoria);
            EscribirFanucSubrutinas(Memoria);
            EscribirFanucGeneral2(Memoria);
            EscribirFanucGeneral3(Memoria);

            EscribirConfiguracionAutomataMemoryStream(Memoria);

            return (true);
        }
        public override bool EscribirConfiguracionAutomata(String Fichero)
        {
            UInt16 Tamano = 10240;
            byte[] Memoria = new byte[Tamano];

            EscribirFanucGeneral(Memoria);
            EscribirFanucCarenados(Memoria);
            EscribirFanucCompuertas(Memoria);
            EscribirFanucEjesX(Memoria);
            EscribirFanucEjesY(Memoria);
            EscribirFanucEjesZ(Memoria);
            EscribirFanucEjesV(Memoria);
            EscribirFanucEjesW(Memoria);
            EscribirFanucPlasmaSoplete(Memoria);
            EscribirFanucVariablesMacros(Memoria);
            EscribirFanucSubrutinas(Memoria);
            EscribirFanucGeneral2(Memoria);
            EscribirFanucGeneral3(Memoria);

            FileStream file = new FileStream(Fichero, FileMode.Open, FileAccess.Write);
            file.Write(Memoria, 0, (int)file.Length);
            file.Close();

            EscribirConfiguracionAutomataMemoryStream(Memoria);

            return (true);
        }
        public bool EscribirConfiguracionAutomataMemoryStream(byte[] bytes)
        {
            short TamanoBuffer;
            short Tamano = 10240;
            short m = 0;
            byte[] DatosBytes = FanucGeneral.getBytes();
            Buffer.type_a = 9;  // Tipo de memoria: D.
            Buffer.type_d = 0;  // Tamaño del dato: 1 byte
            do
            {
                TamanoBuffer = (short)Math.Min((short)255, Tamano);
                Buffer.datano_s = m;
                Buffer.datano_e = TamanoBuffer;
                ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (UInt16)(TamanoBuffer+9), Buffer);
                if (ret != (Focas1.focas_ret)Focas1.EW_OK)
                    return (false);
                Array.Copy(Buffer.cdata, TamanoBuffer, bytes, m, TamanoBuffer);
                Tamano -= TamanoBuffer;
                m += TamanoBuffer;
                Thread.Sleep(FANUC_RETARDO_MANUAL);
            } while (m_Tamano > 0);

            return (true);
        }
        public bool EscribirFanucGeneral(byte[] Memoria) //  -- Escribir Fanuc General D1100 - D1450 --> 350
        {
            byte[] DatosBytes = FanucGeneral.getBytes();
            Array.Copy(DatosBytes, 0, Memoria, 1100, DatosBytes.Length);
            return (true);
        }
        public bool EscribirFanucCarenados(byte[] Memoria) //  -- Escribir Fanuc Carenados D1450 - D1600 --> 4x30
        {
            for (int i = 0; i < MAX_CARENADOS; i++)
            {
                byte[] DatosBytes = FanucCarenados[i].getBytes();
                int Inicio = 1450+i*30;
                Array.Copy(DatosBytes, 0, Memoria, Inicio, DatosBytes.Length);
            }
            return (true);
        }
        public bool EscribirFanucCompuertas(byte[] Memoria) //  -- Escribir Fanuc Compuertas D16000 - D2000 --> 48x8
        {
            for (int i = 0; i < MAX_COMPUERTAS; i++)
            {
                byte[] DatosBytes = FanucCompuertas[i].getBytes();
                int Inicio = 1600 + i * 8;
                Array.Copy(DatosBytes, 0, Memoria, Inicio, DatosBytes.Length);
            }
            return (true);
        }
        public bool EscribirFanucEjesX(byte[] Memoria) //  -- EscribirFanuc Ejes X  D2000 - D2200 --> 2x16
        {
            for (int i = 0; i < MAX_EJES_X; i++)
            {
                byte[] DatosBytes = FanucEjeX[i].getBytes();
                int Inicio = 2000+i* 00;
                Array.Copy(DatosBytes, 0, Memoria, Inicio, DatosBytes.Length);
            }
            return (true);
        }
        public bool EscribirFanucEjesY(byte[] Memoria) //  -- Escribir Fanuc Ejes Y D2000 - D2800 --> 6x100
        {
            for (int i = 0; i < MAX_EJES_Y; i++)
            {
                byte[] DatosBytes = FanucEjeY[i].getBytes();
                int Inicio = 2200+i*100;
                Array.Copy(DatosBytes, 0, Memoria, Inicio, DatosBytes.Length);
            }
            return (true);
        }
        public bool EscribirFanucEjesZ(byte[] Memoria) //  -- Escribir Fanuc Ejes Z D2800 - D3400 --> 6x100
        {
            for (int i = 0; i < MAX_EJES_Z; i++)
            {
                byte[] DatosBytes = FanucEjeZ[i].getBytes();
                int Inicio = 2800+i*100;
                Array.Copy(DatosBytes, 0, Memoria, Inicio, DatosBytes.Length);
            }
            return (true);
        }
        public bool EscribirFanucEjesV(byte[] Memoria) //  -- Escribir Fanuc Ejes A D3400 - D4000 --> 6x100
        {
            for (int i = 0; i < MAX_EJES_V; i++)
            {
                byte[] DatosBytes = FanucEjeV[i].getBytes();
                int Inicio = 3400+i*100;
                Array.Copy(DatosBytes, 0, Memoria, Inicio, DatosBytes.Length);
            }
            return (true);
        }
        public bool EscribirFanucEjesW(byte[] Memoria) //  -- Escribir Fanuc Ejes B D4000 - D4600 --> 6x100
        {
            for (int i = 0; i < MAX_EJES_W; i++)
            {
                byte[] DatosBytes = FanucEjeW[i].getBytes();
                int Inicio = 4000+i*100;
                Array.Copy(DatosBytes, 0, Memoria, Inicio, DatosBytes.Length);
            }
            return (true);
        }
        public bool EscribirFanucPlasmaSoplete(byte[] Memoria) //  -- Escribir Fanuc Plasma/Soplete D4600 - D6000 --> 6x250
        {
            for (int i = 0; i < MAX_PLASMA_SOPLETE; i++)
            {
                byte[] DatosBytes = FanucPlasmaSoplete[i].getBytes();
                int Inicio = 4600+i*250;
                Array.Copy(DatosBytes, 0, Memoria, Inicio, DatosBytes.Length);
            }
            return (true);
        }
        public bool EscribirFanucVariablesMacros(byte[] Memoria) //  -- Escribir Fanuc Variabels Macro D6300 - D6400
        {
            byte[] DatosBytes = FanucVariablesMacros.getBytes();
            Array.Copy(DatosBytes, 0, Memoria, 6300, DatosBytes.Length);
            return (true);
        }
        public bool EscribirFanucSubrutinas(byte[] Memoria) //  -- Escribir Fanuc Subroutinas D6400 - D6600
        {
            byte[] DatosBytes = FanucSubrutinas.getBytes();
            Array.Copy(DatosBytes, 0, Memoria, 6400, DatosBytes.Length);
            return (true);
        }
        public bool EscribirFanucGeneral2(byte[] Memoria) //  -- Escribir Fanuc General2 D6600 - 7000
        {
            byte[] DatosBytes = FanucGeneral2.getBytes();
            Array.Copy(DatosBytes, 0, Memoria, 6600, DatosBytes.Length);
            return (true);
        }
        public bool EscribirFanucGeneral3(byte[] Memoria) //  -- Escribir Fanuc General2 D3700 - 4000
        {
            byte[] DatosBytes = FanucGeneral3.getBytes();
            Array.Copy(DatosBytes, 0, Memoria, 3700, DatosBytes.Length);
            return (true);
        }
        public override bool FanucActivarMirrorMulticabezal(short dIndiceEje, bool bActivo)
        {
            LeerParametro_IODBPSD_1 ((short)8312, dIndiceEje, (short)6);
            prmDataNoAxis.idata = (short)(bActivo ? 100 : 0);
            EscribirParametro_IODBPSD_1 ((short)6);
            return (true);
        }
        public override bool FanucActivarEsclavoMulticabezal(short dIndiceEje, bool bActivar, short dEjeIndiceMaster)
        {

//
//	-- Valor G138 de sincronización.
//

            ushort Direccion = (ushort)(138+1000*(dIndiceEje/8));
            LeerMemoriaAutomata ((short)0, Direccion, Direccion);
            byte Valor  = (byte)(1 << dIndiceEje%8);
            if (bActivar)
		        Buffer.cdata[0] |= Valor;
            else
		        Buffer.cdata[0] &= (byte)(~Valor);
	        EscribirMemoriaAutomata (Direccion, Direccion);
        
            Direccion = (ushort)(140+1000*(dIndiceEje/8));
	        Buffer.datano_s = (short)Direccion;
	        Buffer.datano_e = (short)Direccion;
	        EscribirMemoriaAutomata (Direccion, Direccion);

//
//	-- Activar variables de tipo macro correspondientes.
//

            float Valor_float = (float)0.0;
            LeerMacro((short)501, ref Valor_float);
            int i;
            for (i = 0; i < MAX_EJES_Y; i++)
        	    if (m_EjeMaquina[i].m_dIndiceEje == dIndiceEje)
                    	break;
            if (i < MAX_EJES_Y)
            {
		        ushort Valor_ushort = (ushort)Valor_float;
        	    if (bActivar)
	        	    Valor_ushort |= (ushort)(1 << i);
	            else
		            Valor_ushort &= (ushort)(~(1 << i));
                EscribirMacro(501, (float)(Valor_ushort));
            }
            return (true);
        }
        public override bool FanucPonerEjeMaestro(MaquinaMultiCabezal Maquina, short dIndiceEje)
        {
	        FanucActivarKey ();
            FanucModoMDI ();
            ushort Direccion = (ushort)(8138+1000*(Maquina.m_EjesY[dIndiceEje].m_dNumEje/8));
            LeerMemoriaAutomata ((short)9, Direccion, Direccion);
            Buffer.cdata[0] &= (byte)(~(1 << Maquina.m_EjesY[dIndiceEje].m_dNumEje%8));
            EscribirMemoriaAutomata (Direccion, Direccion);
	        Direccion = (ushort)(140+1000*(Maquina.m_EjesY[dIndiceEje].m_dNumEje/8));
            LeerMemoriaAutomata ((short)9, Direccion, Direccion);
            EscribirMemoriaAutomata (Direccion, Direccion);
            if (Maquina.m_EjesA.Count > 0)
            {
                Direccion = (ushort)(138+1000*(Maquina.m_EjesA[dIndiceEje].m_dNumEje/8));
                LeerMemoriaAutomata ((short)9, Direccion, Direccion);
                Buffer.cdata[0] &= (byte)(~(1 << Maquina.m_EjesA[dIndiceEje].m_dNumEje%8));
                EscribirMemoriaAutomata (Direccion, Direccion);
	            Direccion = (ushort)(140+1000*(Maquina.m_EjesA[dIndiceEje].m_dNumEje/8));
                LeerMemoriaAutomata ((short)9, Direccion, Direccion);
                EscribirMemoriaAutomata (Direccion, Direccion);

                Direccion = (ushort)(138+1000*(Maquina.m_EjesB[dIndiceEje].m_dNumEje/8));
                LeerMemoriaAutomata ((short)9, Direccion, Direccion);
                Buffer.cdata[0] &= (byte)(~(1 << Maquina.m_EjesB[dIndiceEje].m_dNumEje%8));
                EscribirMemoriaAutomata (Direccion, Direccion);
	            Direccion = (ushort)(140+1000*(Maquina.m_EjesB[dIndiceEje].m_dNumEje/8));
                LeerMemoriaAutomata ((short)9, Direccion, Direccion);
                EscribirMemoriaAutomata (Direccion, Direccion);
            }
            return (true);
        }
        public override bool FanucEscribirMarcaMulticabezales(bool bAlgunEsclavo)
        {
            LeerMemoriaAutomata (5, 2023, 2023);
            byte Valor = 0x01 << 7;
            if (bAlgunEsclavo)
		        Buffer.cdata[0] |= Valor;
            else
                Buffer.cdata[0] &= (byte)(~Valor);
            return (EscribirMemoriaAutomata(2023, 2023));
        }
        public override bool FanucActivarCabezal(int dCabezal, bool bActivar)
        {
            LeerMemoriaAutomata (5, 2005, 2005);
            byte Valor = (byte)(1 << (dCabezal+1));
            if (bActivar)
        	    Buffer.cdata[0] |= Valor;
            else
                Buffer.cdata[0] &= (byte)(~Valor);
            return (EscribirMemoriaAutomata(2025, 2025));
        }
        public override bool LeerMacro(short dIndiceMacro, ref float Valor)
        {
            int ValorEntero = (int)(Valor*1000);
            ret = (Focas1.focas_ret)Focas1.cnc_rdmacro(m_dMiManipulador, dIndiceMacro, (short)10, BufferMacro);
            Valor = BufferMacro.mcr_val;
            for (short i = 0; i < BufferMacro.dec_val; i++)
                Valor *= (float)0.1;
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public override bool EscribirMacro(short dIndiceMacro, float Valor)
        {
            int ValorEntero = (int)(Valor * 1000);
            ret = (Focas1.focas_ret)Focas1.cnc_wrmacro(m_dMiManipulador, dIndiceMacro, 10, ValorEntero, 3);
            Thread.Sleep(FANUC_RETARDO);
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public bool LeerParametro_IODBPSD_1(short dIndiceParametro, short m_dEje, short Tamano)
        {
            ret = (Focas1.focas_ret)Focas1.cnc_rdparam(m_dMiManipulador, dIndiceParametro, (short)(m_dEje+1),
                Tamano, prmDataNoAxis);
            Thread.Sleep(FANUC_RETARDO);
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public bool EscribirParametro_IODBPSD_1(short Tamano)
        {
            ret = (Focas1.focas_ret)Focas1.cnc_wrparam(m_dMiManipulador, Tamano, prmDataNoAxis);
            Thread.Sleep(FANUC_RETARDO);
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public override bool LeerMemoriaAutomata(short dTipoDato, ushort dInicio, ushort dFin)
        {
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)1, m_TipoDato,
                dInicio, dFin, (ushort)(dFin-dInicio+9), Buffer);
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public override bool EscribirMemoriaAutomata(ushort dInicio, ushort dFin)
        {
            Thread.Sleep(FANUC_RETARDO);
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)(dFin-dInicio+9), Buffer);
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public override bool EscribirParametroTipoEjeY(EjeMaquina Eje, int dIndiceMaestro)
        {
            if (Eje.m_dTipoEje == 1)	// Es un tubo
                prmDataNoAxis.cdata = 0;
            else if (Eje.m_dIndiceEje == dIndiceMaestro)
			    prmDataNoAxis.cdata = 2;
            else
                prmDataNoAxis.cdata = 6;
            LeerParametro_IODBPSD_1((short)1022, (short)(Eje.m_dIndiceEje), (short)5);
            return (EscribirParametro_IODBPSD_1(5));
        }
        public override bool EscribirParametroTipoEjeZ(EjeMaquina Eje, int dIndiceMaestro)
        {
            if (Eje.m_dIndiceEje == dIndiceMaestro)
                prmDataNoAxis.cdata = 3;
            else
                prmDataNoAxis.cdata = 7;
            LeerParametro_IODBPSD_1((short)1022, (short)(Eje.m_dIndiceEje), (short)5);
            return (EscribirParametro_IODBPSD_1(5));
        }
        public override bool EscribirParametroTipoEjeBisel(EjeMaquina EjeA, EjeMaquina EjeB)
        {
            LeerParametro_IODBPSD_1((short)19681, (short)(EjeA.m_dIndiceEje), (short)5);
            EscribirParametro_IODBPSD_1(5);
            LeerParametro_IODBPSD_1((short)19686, (short)(EjeB.m_dIndiceEje), (short)5);
            return (EscribirParametro_IODBPSD_1(5));
        }
    }
}
