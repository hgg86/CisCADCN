using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Test1
{
    class Trabajo
    {
        #region Definición de variables

        public List<Pieza> m_Piezas;
        public int m_dIndiceTrabajo;
        public double[] CotasTrabajo = new double[4];
        public string m_NombreFichero;
        public double m_RotacionActual = 0.0;
        public double m_TraslacionX = 0.0;
        public double m_TraslacionY = 0.0;
        public int m_NumeroEntidades;
        #endregion

        public Trabajo()
        {
            m_Piezas = new List<Pieza>();
            CotasTrabajo[0] = CotasTrabajo[1] = CotasTrabajo[2] = CotasTrabajo[3] = 0.0;
        }
        public Trabajo(int dNumBloques, List<Pieza> F)
        {
            m_Piezas = new List<Pieza>();
            m_Piezas = F;
            m_dIndiceTrabajo = 0;
            TerminarTrabajo();
        }
        public Trabajo(List<Pieza> F, int dIndiceTrabajo)
        {
            m_Piezas = new List<Pieza>();
            m_Piezas = F;
            m_dIndiceTrabajo = dIndiceTrabajo;
            TerminarTrabajo();
        }
        public void TerminarTrabajo()
        {
            m_NumeroEntidades = 0;
            foreach (Pieza f in m_Piezas)
            { 
                f.m_dIndiceTrabajo = m_dIndiceTrabajo;
                CotasTrabajo[0] = Math.Min(CotasTrabajo[0], f.CotasPieza[0]);
                CotasTrabajo[1] = Math.Min(CotasTrabajo[1], f.CotasPieza[1]);
                CotasTrabajo[2] = Math.Max(CotasTrabajo[2], f.CotasPieza[2]);
                CotasTrabajo[3] = Math.Max(CotasTrabajo[3], f.CotasPieza[3]);
                foreach (Bloque B in f.m_Bloques)
                    m_NumeroEntidades += B.m_Entidades.Count;
            }

        }
        public bool LeerFichero(string Fichero, string MachinaCodeByDefault)
        {
            int dNumBloques = 0;
            
            if (!File.Exists(Fichero))
                return (false);
            m_NombreFichero = Fichero;
            string Extension = Path.GetExtension(Fichero).ToUpper();
            int dTipoFichero = Extension == ".CIS" ? 0 : 2;
            if (dTipoFichero > 1)
            {
                var directoryFullPath = Path.GetDirectoryName(Fichero); 
                String NewFile = directoryFullPath + "\\temp.cis";
                ConvertirFormato(Fichero, NewFile);
                Fichero = NewFile;
            }
            VaciarTrabajo();
            StreamReader file = new StreamReader(Fichero);
            string line;
            string[] Words;
            string whitespace = " ";
            Entidad E;
            double VelocidadCorte = 0.0;
            VaciarTrabajo(); 
            Punto P0 = new Punto(0, 0);
            Punto P1 = new Punto(0, 0);
            int dNumPiezas = 0;
            while ((line = file.ReadLine()) != null)
            {
                if (line == "")
                    continue;
                line = Regex.Replace(line, @"\s+", " ");
                Words = Regex.Split(line, whitespace);
                if (Words.Length == 0)
                    continue;
                if (line[0] == 'F') // comienzo o fin de Pieza
                {
                    if (line[4] == 'I') // Inicio de Pieza
                    {
                        m_Piezas.Add(new Pieza());
                        dNumBloques = 0;
                        continue;
                    }
                    else                // Fin de Pieza
                    {
                        m_Piezas[dNumPiezas].TerminarPieza();
                        ++dNumPiezas;
                        continue;
                    }
                }
                if (line[0] == 'O')
                {
                    if (line[1] == 'N') // Encendido (ON)
                    {
                        m_Piezas[dNumPiezas].m_Bloques[dNumBloques].m_bEsMovimientoCorte = false;
                    }
                    else                // Apagado (OFF)
                    { 
                        m_Piezas[dNumPiezas].m_Bloques[dNumBloques].m_bEsMovimientoCorte = true;
                    }
                    m_Piezas[dNumPiezas].m_Bloques[dNumBloques].TerminarBloque();
                    m_Piezas[dNumPiezas].m_Bloques.Add(new Bloque());
                    ++dNumBloques;
                    for (int i = 0; i < 6; i++)
                    {
                        m_Piezas[dNumPiezas].m_Bloques[dNumBloques].m_bEsMirror[i] = false;
                        m_Piezas[dNumPiezas].m_Bloques[dNumBloques].m_MaestroEsclavo[i] = false;
                        m_Piezas[dNumPiezas].m_Bloques[dNumBloques].m_lfSeparacionCabezales[i] = 0.0;
                    }
                }
                else if (line[0] == 'L') // Es una línea
                {
                    m_Piezas[dNumPiezas].m_Bloques[dNumBloques].m_VelCorte = VelocidadCorte;
                    P1 = new Punto(Convert.ToDouble(Words[1]), Convert.ToDouble(Words[2]));
                    E = new Segmento(P0, P1);
                    m_Piezas[dNumPiezas].m_Bloques[dNumBloques].Append(E);
                    P0 = new Punto(P1);
                }
                else if (line[0] == 'A') // Es un arco
                {
                    m_Piezas[dNumPiezas].m_Bloques[dNumBloques].m_VelCorte = VelocidadCorte;
                    P1 = new Punto(Convert.ToDouble(Words[1]), Convert.ToDouble(Words[2]));
                    double Angulo = Convert.ToDouble(Words[3]);
                    E = new Arco(P1, P0, Angulo);
                    double R = P1.Distancia(P0);
                    Angulo = Math.PI / 180 * Angulo + Math.Atan2(P0.m_lfy - P1.m_lfy, P0.m_lfx - P1.m_lfx);
                    m_Piezas[dNumPiezas].m_Bloques[dNumBloques].Append(E);
                    P0 = new Punto(P1.m_lfx + R * Math.Cos(Angulo), P1.m_lfy + R * Math.Sin(Angulo));
                }
                else if (line[0] == 'C') // Es una circunferencia
                {
                    m_Piezas[dNumPiezas].m_Bloques[dNumBloques].m_VelCorte = VelocidadCorte;
                    P1 = new Punto(Convert.ToDouble(Words[1]), Convert.ToDouble(Words[2]));
                    E = new Circunferencia(P1, P1.Distancia(P0));
                    E.PuntoEntradaCircunferencia(P0);
                    m_Piezas[dNumPiezas].m_Bloques[dNumBloques].Append(E);
                    P0 = new Punto(P0);
                }
               else  if (line[0] == 'M')    // Tipo de Máquina
                {
                    if (line[1] == 'A')     // Machine
                        m_Piezas[dNumPiezas].m_Bloques[dNumBloques].m_MachinaCode = Words[1].Substring(1, Words[1].Length - 2);
                    else     // Mirror master/Slave. (else if line[1] == 'I' ---> MIRROR)
                    {
                        for (int i = 1; i < Words.Length; i++)
                            m_Piezas[dNumPiezas].m_Bloques[dNumBloques].m_bEsMirror[i - 1] = Convert.ToBoolean(Words[i]);
                    }
                }
                else if (line[0] == 'V')    // Velocidad de la entidad/bloque
                {
                    VelocidadCorte = Convert.ToDouble(Words[1]);
                    m_Piezas[dNumPiezas].m_Bloques[dNumBloques].m_VelCorte = VelocidadCorte;
                }
                else if (line[0] == 'E')    // Habilitaciones dera master/slave.
                {
                    for (int i = 1; i < Words.Length; i++)
                        m_Piezas[dNumPiezas].m_Bloques[dNumBloques].m_MaestroEsclavo[i - 1] = Convert.ToBoolean(Words[i]);
                }
                else if (line[0] == 'S')    // Separaciones master/slave.
                {
                    for (int i = 1; i < Words.Length; i++)
                        m_Piezas[dNumPiezas].m_Bloques[dNumBloques].m_lfSeparacionCabezales[i - 1] = Convert.ToDouble(Words[i]);
                }
            }
            file.Close();
            foreach (Pieza f in m_Piezas)
            {
                foreach (Bloque b in f.m_Bloques)
                {
                    if (b.m_MachinaCode != null)
                        continue;
                    b.m_MachinaCode = MachinaCodeByDefault;
                }
            }
            foreach (Pieza f in m_Piezas)
            {
                for (int b = 0; b < f.m_Bloques.Count; b++)
                {
                    if (!f.m_Bloques[b].m_bEsMovimientoCorte)
                    {
                        f.m_Bloques[b].m_Entidades.Clear();
                        f.m_Bloques.RemoveAt(b);
                    }
                }
            }
            TerminarTrabajo();
            return (true);
        }
        private bool ConvertirFormato(string Fichero, string NewFile)
        {
            if (!File.Exists(Fichero))
                return (false);
            System.IO.StreamReader fileMNT = new System.IO.StreamReader(Fichero);
            System.IO.StreamWriter fileCIS = new System.IO.StreamWriter(NewFile);
            string line;
            string[] Words;
            string whitespace = " ";
            line = string.Format("FIG_INI");
            fileCIS.WriteLine(line);
            while ((line = fileMNT.ReadLine()) != null)
            {
                line = line.Replace(',', ' ');
                line = Regex.Replace(line, @"\s+", " ");
                Words = Regex.Split(line, whitespace);
                if (Words.Length < 2)
                    continue;

                if (Words[0] == "VECTORA[0")
                {
                    line = string.Format("LINE {0:0.000} {1:0.000}", Words[3], Words[4]);
                    fileCIS.WriteLine(line);
                }
                else if (Words[0] == "CIRCLEA[0")
                {
                    if (Math.Abs(Convert.ToDouble(Words[5])) == 360.0)
                        line = string.Format("CIRCLE {0:0.000} {1:0.000}", Words[3], Words[4]);
                    else
                        line = string.Format("ARC {0:0.000} {1:0.000} {2:0.000}", Words[3], Words[4], Words[5]);
                    fileCIS.WriteLine(line);
                }
                else if (Words[1] == "PLASMA_ON")
                    fileCIS.WriteLine("ON");
                else if (Words[1] == "PLASMA_OFF")
                    fileCIS.WriteLine("OFF");
            }
            line = string.Format("FIG_FIN");
            fileCIS.WriteLine(line);
            fileCIS.Close();
            fileMNT.Close();

            return (true);
        }
        private bool VaciarTrabajo()
        {
            foreach (Pieza f in m_Piezas)
            {
                foreach (Bloque b in f.m_Bloques)
                {
                    b.m_Entidades.Clear();
                }
                f.m_Bloques.Clear();
            }
            return (true);
        }
    }
}
