using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;

namespace Test1
{
    class MaquinaNormal
    {
        public string m_TipoMaquina;
        public int m_dMachinaIndex;
        public String m_MachinaCode;
        public String m_NombreMaquina;
        public List<EjeMaquina> m_EjesX;
        public List<EjeMaquina> m_EjesY;
        public List<EjeMaquina> m_EjesZ;
        public List<EjeMaquina> m_EjesA;
        public List<EjeMaquina> m_EjesB;
        public List<Herramienta> m_Herramientas;
        public List<Contenedor> m_Torretas;
        public bool m_bExisteTorreta;
        public bool[] m_bTecnologiasCebado = new bool[100];
        public bool m_bExisteZControladoAutomata = false;

        public FanucVariablesGlobales m_FanucGlobalVariables = null;
        public StructFanucGeneral m_FanucGeneral = null;
        public StructFanucGeneral2 m_FanucGeneral2 = null;
        public StructFanucSubrutinas m_FanucSubrutinas = null;
        public SistemaTecoi m_SistemaTecoi = null;

        public MaquinaNormal()
        {
            m_EjesX = new List<EjeMaquina>();
            m_EjesY = new List<EjeMaquina>();
            m_EjesZ = new List<EjeMaquina>();
            m_EjesA = new List<EjeMaquina>();
            m_EjesB = new List<EjeMaquina>();
            m_Herramientas = new List<Herramienta>();
        }
        public MaquinaNormal(int dMachinaIndex, string MachinaCode)
        {
            m_dMachinaIndex = dMachinaIndex;
            m_MachinaCode = MachinaCode;
        }
        public void ComponerMaquina(List<EjeMaquina> Ejes, List<Contenedor> Torretas)
        {
            foreach (EjeMaquina m in Ejes)
            {
                switch (m.m_dCodigoEje)
                {
                    case 0: // Eje X
                        m_EjesX.Add(m);
                        break;
                    case 1: // Eje Y
                        m_EjesY.Add(m);
                        break;
                    case 2: // Eje Z
                        m_EjesZ.Add(m);
                        break;
                    case 3: // Eje A
                        m_EjesA.Add(m);
                        break;
                    case 4: // Eje B
                        m_EjesB.Add(m);
                        break;
                }
            }
            m_Torretas = Torretas;
            m_bExisteTorreta = true;
        }
        public void ComponerMaquina(List<EjeMaquina> Ejes, List<Herramienta> MisHerramientas)
        {
            foreach (EjeMaquina m in Ejes)
            {
                switch (m.m_dCodigoEje)
                {
                    case 0: // Eje X
                        m_EjesX.Add(m);
                        break;
                    case 1: // Eje Y
                        m_EjesY.Add(m);
                        break;
                    case 2: // Eje Z
                        m_EjesZ.Add(m);
                        break;
                    case 3: // Eje A
                        m_EjesA.Add(m);
                        break;
                    case 4: // Eje B
                        m_EjesB.Add(m);
                        break;
                }
            }
            foreach (Herramienta h in MisHerramientas)
                m_Herramientas.Add(h);
            m_bExisteTorreta = false;
        }

        public virtual void ActivarEjesMovimiento(int bActivoEjeX, int bActivoEjeY)
        {
            int i = 0;
            for (i = 0; i < m_EjesX.Count; i++)
                m_EjesX[i].m_bEjeEactivo = ((bActivoEjeX >> i) & 1) == 1;
            for (i = 0; i < m_EjesY.Count; i++)
                m_EjesY[i].m_bEjeEactivo = ((bActivoEjeY >> i) & 1) == 1;
        }
        public virtual int LeerEjesActivosX()
        {
            int bActivoEjeX = 0;
            int i = 0;
            for (i = 0; i < m_EjesX.Count; i++)
                bActivoEjeX = m_EjesX[i].m_bEjeEactivo ? bActivoEjeX | (1 << i) : bActivoEjeX;
            return (bActivoEjeX);
        }
        public virtual int LeerEjesActivosY()
        {
            int bActivoEjeY = 0;
            int i = 0;
            for (i = 0; i < m_EjesY.Count; i++)
                bActivoEjeY = m_EjesY[i].m_bEjeEactivo ? bActivoEjeY | (1 << i) : bActivoEjeY;
            return (bActivoEjeY);
        }
        public virtual bool LeerConfiguracion(String Fichero, List<EjeMaquina> Ejes,
            List<Herramienta> Herramientas)
        {
            string xmlText = File.ReadAllText(Fichero);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlText);
            String Clave = "TECOISYSTEM/VIRTUAL_MACHINE_" + m_dMachinaIndex.ToString();
            XmlNodeList oXmlNodeList = doc.SelectNodes(Clave + "/NombreMaquina");
            foreach (XmlNode x in oXmlNodeList)
                m_NombreMaquina = x.Attributes["NombreMaquina"].Value;

            //
            //  -- Ejes de la máquina virtual.
            //

            oXmlNodeList = doc.SelectNodes(Clave + "/EjeX");
            foreach (XmlNode x in oXmlNodeList)
                m_EjesX.Add(Ejes.ElementAt(Convert.ToInt32(x.Attributes["EjeX"].Value)));

            oXmlNodeList = doc.SelectNodes(Clave + "/EjeX1");
            foreach (XmlNode x in oXmlNodeList)
                m_EjesX.Add(Ejes[Convert.ToInt32(x.Attributes["EjeX1"].Value)]);

            oXmlNodeList = doc.SelectNodes(Clave + "/EjeY");
            foreach (XmlNode x in oXmlNodeList)
                m_EjesY.Add(Ejes[Convert.ToInt32(x.Attributes["EjeY"].Value)]);
            for (int i = 2; i < 6; i++)
            {
                oXmlNodeList = doc.SelectNodes(Clave + "/EjeY" + i.ToString());
                foreach (XmlNode x in oXmlNodeList)
                    m_EjesY.Add(Ejes[Convert.ToInt32(x.Attributes["EjeY" + i.ToString()].Value)]);
            }

            oXmlNodeList = doc.SelectNodes(Clave + "/EjeZ");
            foreach (XmlNode x in oXmlNodeList)
                m_EjesZ.Add(Ejes[Convert.ToInt32(x.Attributes["EjeZ"].Value)]);
            m_bExisteZControladoAutomata = m_EjesZ[0].m_bEjeControladoAutomata;
            for (int i = 2; i < 6; i++)
            {
                oXmlNodeList = doc.SelectNodes(Clave + "/EjeZ" + i.ToString());
                foreach (XmlNode x in oXmlNodeList)
                {
                    m_EjesZ.Add(Ejes[Convert.ToInt32(x.Attributes["EjeZ" + i.ToString()].Value)]);
                    m_bExisteZControladoAutomata |= m_EjesZ[m_EjesZ.Count-1].m_bEjeControladoAutomata;
                }
            }

            oXmlNodeList = doc.SelectNodes(Clave + "/EjeA");
            foreach (XmlNode x in oXmlNodeList)
                m_EjesA.Add(Ejes[Convert.ToInt32(x.Attributes["EjeA"].Value)]);
            for (int i = 2; i < 6; i++)
            {
                oXmlNodeList = doc.SelectNodes(Clave + "/EjeA" + i.ToString());
                foreach (XmlNode x in oXmlNodeList)
                    m_EjesA.Add(Ejes[Convert.ToInt32(x.Attributes["EjeA" + i.ToString()].Value)]);
            }

            oXmlNodeList = doc.SelectNodes(Clave + "/EjeB");
            foreach (XmlNode x in oXmlNodeList)
                m_EjesB.Add(Ejes[Convert.ToInt32(x.Attributes["EjeB"].Value)]);
            for (int i = 2; i < 6; i++)
            {
                oXmlNodeList = doc.SelectNodes(Clave + "/EjeB" + i.ToString());
                foreach (XmlNode x in oXmlNodeList)
                    m_EjesB.Add(Ejes[Convert.ToInt32(x.Attributes["EjeB" + i.ToString()].Value)]);
            }

            //
            //  -- Herramnienta de la máquina virtual.
            //

            oXmlNodeList = doc.SelectNodes(Clave + "/Herramientas");
            foreach (XmlNode x in oXmlNodeList)
                m_Herramientas.Add(Herramientas[Convert.ToInt32(x.Attributes["Herramienta"].Value)]);

            //
            //  -- Cebador permitidos de la máquina virtual.
            //

            for (int i = 0; i < 100; i++)
                m_bTecnologiasCebado[i] = false;
            oXmlNodeList = doc.SelectNodes(Clave + "/CEBADO");
            foreach (XmlNode x in oXmlNodeList)
                m_bTecnologiasCebado[Convert.ToInt32(x.Attributes["CebadoIndex"].Value)] = true;

            return (true);
        }
        public virtual void PosicionadoBloque(StreamWriter StreamFileISO, Bloque Bloq)
        {
            foreach (Entidad e in Bloq.m_Entidades)
            {
                if (!e.m_bDebeCortarse)
                    continue;
                StreamFileISO.Write(String.Format("G00 {0}{1} {2}{3}\n",
                    m_EjesX[0].m_NombreEjeISO, e.m_Inicio.m_lfx + m_Herramientas[0].m_lfOffset[0],
                    m_EjesY[0].m_NombreEjeISO, e.m_Inicio.m_lfy + m_Herramientas[0].m_lfOffset[1]));
                break;  // Encontramos la primera del bloque.
            }
        }
        public virtual void PrepararProcesadoBloque(StreamWriter StreamFileISO, Bloque Bloq)
        {
            int[] Parametros = new int[7];
            bool[] bEstado = new bool[6];
            foreach (Entidad e in Bloq.m_Entidades)
            {
                if (!e.m_bDebeCortarse)
                    continue;
                //ActivarRegulacionEjeZ(StreamFileISO, true);
                Parametros[0] = 1;
                Parametros[1] = e.dIndiceMecanizado > 999 ? e.dIndiceMecanizado - 1000 : e.dIndiceMecanizado;
                bEstado[0] = e.dIndiceMecanizado < 1000;
                m_Herramientas[0].PrepararAccion(StreamFileISO, Parametros, bEstado);
                m_Herramientas[0].EscribirEncenderHerramienta(StreamFileISO);
                EscribirCebadoHerramienta(StreamFileISO);
                m_Herramientas[0].EscribirAlturaPostCebado(StreamFileISO);
                m_Herramientas[0].EscribirAlturaCorte(StreamFileISO);
                break;  // Encontramos la primera del bloque.
            }
        }
        public virtual void Bloque2ISO(StreamWriter StreamFileISO, Bloque Bloq)
        {
            m_Herramientas[0].EscribirApagarHerramienta(StreamFileISO);
            EscribirAlturaVacio(StreamFileISO);
        }
        public virtual void PrepararSalidaProcesadoCorte(StreamWriter StreamFileISO, Bloque Bloq)
        {
        }
        public void WikiWiki(StreamWriter StreamFileISO, int dIndiceEjeA, int dIndiceEjeB, double A, double B)
        {
            m_SistemaTecoi.WikiWiki(StreamFileISO, dIndiceEjeA, dIndiceEjeB, A, B);
        }
        public void ActivarRegulacionEjeZ(StreamWriter StreamFileISO, bool bActivar)
        {
            m_SistemaTecoi.ActivarRegulacionEjeZ(StreamFileISO, bActivar);
        }
        public void ActivarRTCP(StreamWriter StreamFileISO, bool bActivar)
        {
            m_SistemaTecoi.ActivarRTCP(StreamFileISO, bActivar);
        }
        public virtual void EstablecerMaestroEsclavoEnVivo(Bloque Bloq)
        {
        }

        public virtual bool EscribirSubrutina_AlturaVacio(StreamWriter StreamFileCNC, int N)
        {
            return (true);
        }
        public virtual void EscribirCebadoHerramienta(StreamWriter StreamFileISO)
        {
            string Cadena = string.Format("G65 P1502 A{0} C{1}\n", m_dMachinaIndex, 1);  // Se debe cebar siempre
            StreamFileISO.Write(Cadena);
        }
        public virtual void EscribirAlturaVacio(StreamWriter StreamFileISO)
        {
            string Cadena = string.Format("G65 P1505 A{0}\n", m_dMachinaIndex);
            StreamFileISO.Write(Cadena);
        }

    }
}
