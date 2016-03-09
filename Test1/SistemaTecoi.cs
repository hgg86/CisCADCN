using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.Net;

namespace Test1
{
    class FanucVariablesGlobales
    {
        /*
                AICC 

                Es un modo de Fanuc para procesamiento de alta velocidad sin pérdida de precisión en el corte. 
                Consume muchos recursos y se pone el corte y control de ejes en prioridad máxima:
                Activación: G05.1 Q1 Es necesario que antes de esta orden se haya escrito en algún momento G40 G49.
                Desactivación: G05.1 Q1
                Ojo, no se puede activar si ya está activo. Si se hace Fanuc hace cosas raras.

                Rotary Tool Control Point (RTCP)

                Se utiliza para rotar la herramienta de tal manera que la punta de la misma no se mueve. 
                Es lo que llamamos vulgarmente "wiki-wiki".
                Activación: G43.4 H0P1
                Desactivación: G49
                Ojo, no se puede activar si ya está activo. Si se hace Fanuc hace cosas raras.

                M10 y M11: Regulación de altura mientras se corta. 

                Se utilizan las subrutinas M10 y M11.
                M10: No permite regulación.
                M11: Permite regulación en altura.
                Se puede llamar repetidamente y no pasaría nada.

                TCP: 

                Se activa con la orden G43.4H01

        */

        public bool m_bAICC_Activo = false;
        public bool m_bRTCP_Activo = false;
        public bool m_M10_Activo = false;
        public int dNumCabezalesMecanizado = 0;
        public Int16 dIndiceRealTimeMacro = 0;
        public bool bPlanoXYPrimaActivo = false;
        public double m_AnguloBiselActual = 0.0;
        public double m_lfFocalBiselCorteActual = 300.0;
        public double DIF_BISEL = 0.5;      // En grados
        public double SEGMENTACION = 0.1;   // Segmentación para biseles variables
        public int dNumeroAlarmas;
        public double dGiroAnguloBisel;
        public string IPDataServer;
        public int m_dTipoAutomata = 0;     // No hay automata
        public bool bEjeVirtualActivo = false;
        public int m_dFondoEscalaLaserCebado;
        public int m_dMinDistanciaLaserCebado;
        public int m_OffsetZCebadoLaser;
        public bool m_bExisteSegundoCanalAutomata;
        public bool m_bExisteAlturaFanuc;
    }
    class ServerSocket
    {
        #region Definición de variables
        public Thread m_ThreadServidor = null;
        private volatile bool m_bTerminarThreadServidor = false;
        public int m_dPuerto = 11000;
        private TcpListener myList;
        private List<Socket> MySocketList = new List<Socket>();
        public List<string> MySocketStrings = new List<string>();

        public delegate bool MiDelegateCallbackServer(int dSocketIndex, string buffer);
        public MiDelegateCallbackServer ProcesarServerSocket;
        #endregion

        ~ServerSocket()
        {
            Cerrar();
            foreach (Socket s in MySocketList)
                s.Close();
            myList.Stop();
        }
        public bool IniciarServer(int dPuerto)
        {
            m_dPuerto = dPuerto;
            try
            {
                myList = new TcpListener(IPAddress.Any, m_dPuerto);
                myList.Start();
            }
            catch (SocketException ex)
            {
                return (false);
            }
            m_ThreadServidor = new Thread(new ThreadStart(ThreadProcStartListening));
            m_ThreadServidor.Start();
            return (true);
        }
        public void Cerrar()
        {
            if (m_ThreadServidor != null)
            {
                m_bTerminarThreadServidor = true;
                m_ThreadServidor.Abort();
                while (m_ThreadServidor.IsAlive) ;
                m_ThreadServidor = null;
            }
        }
        public void CerrarSocket(int dIndex)
        {
            MySocketList[dIndex].Close();
            MySocketList.RemoveAt(dIndex);
            MySocketStrings.RemoveAt(dIndex);
        }
        public void ThreadProcStartListening()
        {
            byte[] buffer = new byte[2048];
            ASCIIEncoding asen = new ASCIIEncoding();
            int n = 0;

            while (!m_bTerminarThreadServidor)
            {
                if (myList.Pending())
                {
                    Socket NewSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    NewSocket = myList.AcceptSocket();
                    MySocketList.Add(NewSocket);
                    MySocketStrings.Add(string.Empty);
                }
                for (int i = 0; i < MySocketList.Count; i++)
                {
                    if (MySocketList[i].Available > 0)
                    {
                        n = MySocketList[i].Receive(buffer);
                        buffer[n] = 0;
                        MySocketStrings[i] = Encoding.ASCII.GetString(buffer);
                        ProcesarServerSocket(i, MySocketStrings[i]);
                        for (n = 0; n < MySocketList.Count; n++)    // Reenviárselo al resto de clientes.
                        {
                            if (i == n)
                                continue;
                            MySocketList[n].Send(asen.GetBytes(MySocketStrings[i]));
                        }
                    }
                }
            }
        }
        public void EnviarDatos(int dSocketIndex, string Cadena)
        {
            ASCIIEncoding asen = new ASCIIEncoding();
            MySocketList[dSocketIndex].Send(asen.GetBytes(Cadena));
        }
        public bool ReenviarForma2Clientes(string Cadena)
        {
            ASCIIEncoding asen = new ASCIIEncoding();
            for (int n = 0; n < MySocketList.Count; n++)    // Reenviárselo a todos los clientes
                MySocketList[n].Send(asen.GetBytes(Cadena));
            return (true);
        }
    }
    class Usuarios
    {
        #region Definición de variables
        public string m_NombreUsuario = String.Empty;
        public string m_ClaveAcceso = String.Empty;
        protected int m_dNivelPrivilegio = 0;
        #endregion

        public Usuarios(string CodigoAcceso, string ClaveUsuario)
        {
            m_NombreUsuario = CodigoAcceso;
            m_ClaveAcceso = ClaveUsuario;
            m_dNivelPrivilegio = int.Parse(CodigoAcceso.Substring(0, 2));    // Nivel de privilegio
        }
    }

    class SistemaTecoi
    {
        #region Definición de variables

        protected string m_VersionCisCADCNX = "001.000";

        int m_dPuertoGUI = 11000;
        protected ServerSocket m_ServidorSocket = new ServerSocket();
        protected List<Usuarios> m_Usuarios = new List<Usuarios>();

        public bool m_bConectadoAutomata;
        public int m_dNumeroEjesSistema;
        public bool m_bParadaEmergencia= false;
        public bool m_bExisteColision = false;

        public List<Trabajo> m_Work = new List<Trabajo>();

        public List<MaquinaNormal> m_Maquinas = new List<MaquinaNormal>();
        public int MaquinaPorDefecto = 0;
        public List<Herramienta> m_Herramientas = new List<Herramienta>();
        public List<EjeMaquina> m_EjeMaquina = new List<EjeMaquina>();
        public List<Herramienta> m_Contenedores = new List<Herramienta>();
        public FanucVariablesGlobales m_FanucGlobalVariables = new FanucVariablesGlobales();
        public List<TecnologiaCebado> m_TecnologiasCebado = new List<TecnologiaCebado>();

        public string m_AlarmasMensages = string.Empty;
        protected volatile bool m_bAlarmarReady = false;
        public float m_EstadoPrograma;

        public delegate bool MiDelegateCallbackServerForma(int dSocketIndex, string buffer);    // Comunicación con la forma
        public MiDelegateCallbackServerForma ProcesarServerSocketForma;

        #endregion

        public SistemaTecoi()
        {
            m_ServidorSocket.IniciarServer(m_dPuertoGUI);
            m_ServidorSocket.ProcesarServerSocket = ProcesarServerSocket;
        }
        ~SistemaTecoi()
        {
            m_ServidorSocket.Cerrar();
            GC.Collect();
        }
        
        public bool ProcesarServerSocket(int dIndiceSocket, string buffer)
        {
            if (buffer.Length < 46)
                return (false);
            string Cabecera = buffer.Substring(0, 7);
            if (Cabecera != "#TECOI#")
                return (false);
            string Version = buffer.Substring(7, 7);
            int dNivelPrivilegio = int.Parse(buffer.Substring(14, 2));      // Nivel de privilegio
            string CodigoAcceso = buffer.Substring(14, 16);                  // Clave completa - incluye Nivel de privilegio
            int Comando = int.Parse(buffer.Substring(30, 8));
            int dNumDatos = int.Parse(buffer.Substring(38, 8));
            string Datos = buffer.Substring(46, dNumDatos);
            string RespuestaServer = string.Empty;

            switch (Comando)
            {
                case 0:     // Iniciar sesión
                    m_Usuarios.Add(new Usuarios(CodigoAcceso, GenerarClaveUSuario(CodigoAcceso)));
                    int dIndiceUsuario = m_Usuarios.Count-1;
                    RespuestaServer = Cabecera+Version+m_Usuarios[dIndiceUsuario].m_ClaveAcceso+
                        "000006"+m_VersionCisCADCNX;
                    m_ServidorSocket.EnviarDatos(dIndiceSocket, RespuestaServer);
                    break;
                case 1:     // Cerrar sesión
                    int i = 0;
                    foreach (Usuarios u in m_Usuarios)
                    {
                        if (u.m_ClaveAcceso == CodigoAcceso)
                        {
                            RespuestaServer = Cabecera+Version+u.m_ClaveAcceso+"000002OK";
                            m_ServidorSocket.EnviarDatos(dIndiceSocket, RespuestaServer);
                            Thread.Sleep(1);   // Dejar tiempo a la comunicación antes de cerrar
                            m_ServidorSocket.CerrarSocket(i);
                            break;
                        }
                        ++i;
                    }
                    break;
                case 10:     // Abrir trabajo nuevo
                    Trabajo W = new Trabajo();
                    if (!W.LeerFichero(Datos, m_Maquinas[MaquinaPorDefecto].m_MachinaCode))
                        break;
                    m_Work.Add(W);
                    AsignarTrabajo(W);
                    ProcesarServerSocketForma(dIndiceSocket, buffer);
                    break;
                case 11:     // Procesar trabajo
                    ProcesarServerSocketForma(dIndiceSocket, buffer);
                    break;
            }
            buffer = RespuestaServer;
            return (true);
        }
        private string GenerarEstadoMaquinaXML(int dIndiceTrabajo)
        {
            string Cadena = "<? xml version = \"1.0\" encoding = \"UTF-8\" ?>";
            Cadena += "< TECOISYSTEM >";
            Cadena += "< AXES >";
            for (int i = 0; i < m_EjeMaquina.Count; i++)
                Cadena += "< AXE AxeIndex = \"" +i+"\" AxePosition = \""+m_EjeMaquina[i].m_lfPosicion+"\" />";
            Cadena += "</ AXES >";
            Cadena += "< VARIABLES_GENERALES >";
            Cadena += "< ESTADO_PROGRAMA Valor = \""+(int)m_EstadoPrograma+"\" />";
            Cadena += "< ESTADO_SETA Valor = \""+ m_bParadaEmergencia+"\" />";
            Cadena += "< ESTADO_COLISION Valor = \""+m_bExisteColision+"\" />";
            Cadena += "< INDICE_MAQUINA_ACTIVA Valor = \""+MaquinaPorDefecto+"\" />";
            Cadena += "< CORTE TiempoTotalCorte = \"00:00:00\""+
                "Porcentaje = \""+0 +"\"" +
                "EntidadesTotales = \""+m_Work[dIndiceTrabajo].m_NumeroEntidades+"\"" +
                "TecnologiaCebado = \""+0 + "\"" +
                "/>";
            Cadena += "< VARIABLES_GENERALES >";
            Cadena += "< ALARMAS >";
            string[] result = m_AlarmasMensages.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in result)
                Cadena += "< ALARMA Cadena = \""+s+"\" />";
            Cadena += "</ ALARMAS >";
            Cadena += "</ TECOISYSTEM >";

            return (Cadena);
        }

        private string GenerarClaveUSuario (string ClaveAcceso)
        {
            return ("119Xc2344FrwqtZz");
            //byte[] n = Encoding.ASCII.GetBytes(ClaveAcceso);
            //for (int i = 0; i < ClaveAcceso.Length; i++)
            //{

            //}
            ////n[i] = (byte)((n[i]^196+7) & 0x7F);
            //string Cadena = Encoding.ASCII.GetString(n, 0, n.Length);
            //return (Cadena);
        }
        public bool ReenviarForma2Clientes (string Cadena)
        {
            return (m_ServidorSocket.ReenviarForma2Clientes(Cadena));
        }

        public bool LeerDefinicionSistema(string Fichero)
        {
            string xmlText = File.ReadAllText(Fichero);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlText);
           
            #region  Lectura de los ejes del sistema
            if (m_EjeMaquina.Count > 0)
                m_EjeMaquina.Clear();
            XmlNodeList oXmlNodeList = doc.SelectNodes("TECOISYSTEM/AXES/AXE");
            foreach (XmlNode x in oXmlNodeList)
            {
                EjeMaquina MiEje;
                int dAxeIndex = Convert.ToInt32(x.Attributes["AxeIndex"].Value);
                int dAxeType = Convert.ToInt32(x.Attributes["AxeType"].Value);
                if (dAxeType == 1)  // Eje lineal
                    MiEje = new EjeLineal(dAxeIndex);
                else if (dAxeType == 2)  // Eje rotatorio
                    MiEje = new EjeRotatorio(dAxeIndex);
                else                    // Eje Bisel
                    MiEje = new EjeBisel(dAxeIndex);
                m_EjeMaquina.Add(MiEje);
            }
            foreach (EjeMaquina Eje in m_EjeMaquina)
            {
                Eje.LeerConfiguracion(Fichero);
                if (Eje.m_dTipoEje == 2)
                    ++m_FanucGlobalVariables.dNumCabezalesMecanizado;
            }
            #endregion
            #region Lectura Tecnologias de Cebado
            if (m_TecnologiasCebado.Count > 0)
                m_TecnologiasCebado.Clear();
            oXmlNodeList = doc.SelectNodes("TECOISYSTEM/TECNOLOGIAS_CEBADO/CEBADO");
            foreach (XmlNode x in oXmlNodeList)
            {
                TecnologiaCebado Cebado;
                int dCebadoIndex = Convert.ToInt32(x.Attributes["CebadoIndex"].Value);
                if (dCebadoIndex == 0)  // Cebado Capacitivo
                    Cebado = new CebadoCapacitivo();
                else if (dCebadoIndex == 1)  // Cebado Regulado
                    Cebado = new CebadoCapacitivo();
                else if (dCebadoIndex == 2)  // Cebado Contacto
                    Cebado = new CebadoContacto();
                else if (dCebadoIndex == 3)  // Cebado Altura Fija
                    Cebado = new CebadoAlturaFija();
                else if (dCebadoIndex == 5)  // Cebado Laser
                    Cebado = new CebadoLaser();
                else                        // 6 - Cebado Pisón
                    Cebado = new CebadoPison();
                m_TecnologiasCebado.Add(Cebado);
            }
            #endregion
            #region Lectura de las herramientas
            if (m_Herramientas.Count > 0)
                m_Herramientas.Clear();
            oXmlNodeList = doc.SelectNodes("TECOISYSTEM/TOOLS/TOOL");
            foreach (XmlNode x in oXmlNodeList)
            {
                Herramienta MiHerramienta = new Herramienta();
                int dToolNumber = Convert.ToInt32(x.Attributes["ToolNumber"].Value);
                int dToolType = Convert.ToInt32(x.Attributes["ToolType"].Value);
                if (dToolType == 0)             // Plasma sin consola
                    MiHerramienta = new PlasmaSinConsola(dToolNumber);
                else if (dToolType == 1)        // Oxicorte sin consola
                    MiHerramienta = new OxicorteSinConsola();
                else if (dToolType == 2)        // Plasma Hyperterm
                    MiHerramienta = new PlasmaHyperterm();
                else if (dToolType == 3)        // Plasma Kjellberg
                    MiHerramienta = new PlasmaKelljberg();
                else if (dToolType == 4)        // Láser Trumpf
                    MiHerramienta = new LaserTrumpf();
                else if (dToolType == 5)        // Mecanizado solamente de Perforacion
                    MiHerramienta = new MecanizadoPerforacion();
                else if (dToolType == 6)        // Mecanizado con movimiento XY
                    MiHerramienta = new MecanizadoXY();
                else if (dToolType == 7)        // Marcado tinta REAInk
                    MiHerramienta = new REAInk();
                else if (dToolType == 8)        // Marcado Macrojet
                    MiHerramienta = new MacrojetInk();
                else                            // Granete
                    MiHerramienta = new Granete();

                MiHerramienta.m_dIndiceHerramienta = dToolNumber;
                MiHerramienta.m_FanucGlobalVariables = m_FanucGlobalVariables;
                m_Herramientas.Add(MiHerramienta);
            }
            foreach (Herramienta MiHerramienta in m_Herramientas)
            {
                MiHerramienta.LeerConfiguracion(Fichero);
                MiHerramienta.m_EjeZ = m_EjeMaquina[MiHerramienta.m_dEjeZAsociado];
            }
        #endregion
            #region Lectura de las máquinas virtuales
            if (m_Maquinas.Count > 0)
                m_Maquinas.Clear();
            oXmlNodeList = doc.SelectNodes("TECOISYSTEM/VIRTUAL_MACHINES/VIRTUAL_MACHINE");
            string[] Words;
            foreach (XmlNode x in oXmlNodeList)
            {
                MaquinaNormal MiMaquina;
                string CodigoMaquina = x.Attributes["VirtualMachineCode"].Value;
                int MachinaIndex = Convert.ToInt32(x.Attributes["MachinaIndex"].Value);
                Words = Regex.Split(CodigoMaquina, "-");
                int dTipoMaquina1 = Convert.ToInt32(Words[0]);
                int dTipoMaquina2 = Convert.ToInt32(Words[1]);
                int dTipoHerramienta = Convert.ToInt32(Words[2]);
                int dIdentificadorMaquina = Convert.ToInt32(Words[3]);
                if (dTipoMaquina1 == 0)  // Máquina lineal
                {
                    if (dTipoMaquina2 == 0)
                        MiMaquina = new MaquinaMonoCabezal(MachinaIndex, CodigoMaquina);
                    else if (dTipoMaquina2 == 1)
                        MiMaquina = new MaquinaMultiCabezal(MachinaIndex, CodigoMaquina);
                    else
                        MiMaquina = new MaquinaTRF();
                }
                else                      // Máquina Circular
                {
                    if (dTipoMaquina2 == 0)
                        MiMaquina = new MaquinaTuboRedondo();
                    else
                        MiMaquina = new MaquinaTuboPoligonal();
                }
                MiMaquina.m_SistemaTecoi = this;
                MiMaquina.m_FanucGlobalVariables = m_FanucGlobalVariables;
                m_Maquinas.Add(MiMaquina);
            }
            foreach (MaquinaNormal MiMaquina in m_Maquinas)
            {
                MiMaquina.LeerConfiguracion(Fichero, m_EjeMaquina, m_Herramientas);
            }
            #endregion
            #region Calculo de variables generales del sistema
            m_FanucGlobalVariables.dNumCabezalesMecanizado = 0;
            #endregion
            ActualizarVariablesSistemaTecoi();
            return (true);
        }
        protected virtual void ActualizarVariablesSistemaTecoi()
        {
        }
        public void AsignarTrabajo(Trabajo Work)
        {
            foreach (Pieza f in Work.m_Piezas)
            {
                foreach (Bloque b in f.m_Bloques)
                {
                    foreach (Entidad e in b.m_Entidades)
                    {
                        e.m_FanucGlobalVariables = this.m_FanucGlobalVariables;
                    }
                }
            }
        }
        public void LeerAlarmas(ref string Alarmas)
        {
            if (!m_bConectadoAutomata)
                return;
            int i;
            for (i = 0; i < 100 && m_bAlarmarReady; i++)
                Thread.Sleep(1);
            for (i = 0; i < 100 && !m_bAlarmarReady; i++) 
                Thread.Sleep(1);
            if (i == 100)
                m_bAlarmarReady = true;
            //while (m_bAlarmarReady == true) ;
            //while (m_bAlarmarReady == false);
            Alarmas = m_AlarmasMensages;
        }
        public virtual void LecturaPosicionesEjes(out double X, out double Y, out double Z)
        {
            X = m_Maquinas[MaquinaPorDefecto].m_EjesX[0].m_lfPosicion;
            Y = m_Maquinas[MaquinaPorDefecto].m_EjesY[0].m_lfPosicion;
            Z = m_Maquinas[MaquinaPorDefecto].m_EjesZ[0].m_lfPosicion;
        }
        public virtual bool Salir()
        {
            return (true);
        }
        public virtual bool ConectarAutomata(int dNodo = 0)
        {
            m_bConectadoAutomata = false;
            return (m_bConectadoAutomata);
        }
        public virtual bool ConectarAutomata(string IpAddress, ushort dPuerto)
        {
            m_bConectadoAutomata = false;
            return (m_bConectadoAutomata);
        }
        public virtual bool EnviarPrograma(string Nombre, short prog_number)
        {
            return (true);
        }
        public virtual bool GenerarFicheroISO(Trabajo Work, string Fichero)
        {
            return (true);
        }
        public virtual bool GenerarSubrutinas(string Fichero)
        {
            return (true);
        }
        public virtual bool EnviarSubrutinas(string Fichero, bool bMem, bool bUser)
        {
            return (true);
        }
        public virtual bool LeerConfiguracionAutomata()
        {
            return (true);
        }
        public virtual bool LeerConfiguracionAutomata(string Fichero)
        {
            return (true);
        }
        public virtual bool EscribirConfiguracionAutomata()
        {
            return (true);
        }
        public virtual bool EscribirConfiguracionAutomata(string Fichero)
        {
            return (true);
        }
        public virtual bool LeerMemoriaAutomata(short dTipoDato, ushort dInicio, ushort dFin)
        {
            return (true);
        }
        public virtual bool EscribirMemoriaAutomata(ushort dInicio, ushort dFin)
        {
            return (true);
        }
        public virtual bool EscribirParametroTipoEjeY(EjeMaquina Eje, int dIndiceMaestro)
        {
            return (true);
        }
        public virtual bool EscribirParametroTipoEjeZ(EjeMaquina Eje, int dIndiceMaestro)
        {
            return (true);
        }
        public virtual bool EscribirParametroTipoEjeBisel(EjeMaquina EjeA, EjeMaquina EjeB)
        {
            return (true);
        }
        public virtual string GetNombreMaquina()
        {
            return (null);
        }
        public virtual void ActivarRegulacionEjeZ(StreamWriter StreamFileISO, bool bActivar)
        {
        }
        public virtual void ActivarRTCP(StreamWriter StreamFileISO, bool bActivar)
        {

        }
        public virtual void WikiWiki(StreamWriter StreamFileISO, int dIndiceEjeA, int dIndiceEjeB, double A, double B)
        {

        }
        public int LeerEstadoAutomata ()
        {
            return ((int)(m_EstadoPrograma*1000));
        }
    }
}
