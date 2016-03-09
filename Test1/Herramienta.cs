using System;
using System.IO;
using System.Xml;

namespace Test1
{
    class Herramienta
    {
        #region Definición de variables
        public int m_dIndiceHerramienta;
        public String m_NombreHerramienta;
        public int m_dTipoHerramienta;  // 0 Plasma sin consola, , 1 Oxicorte Sin Consola, 2 Hypertherm, 3 Kjellberg,
                                        // 4 LaserTrumpf, 5 Mec. Perforacion, 6 Mec. XY, 7 REA Ink, 8 Macrojet Ink, 9: Granete
                                        // 10 Marcador SISMA, 
        public double[] m_lfOffset = new double[2];
        public double m_VelocidadBajada;
        public double m_VelocidadSubida;
        public double m_VelocidadRegulacion;
        public String m_FicheroCalidades;
        public int m_dEjeZAsociado = -1;
        public EjeMaquina m_EjeZ = null;

        public FanucVariablesGlobales m_FanucGlobalVariables = null;
        #endregion

        public virtual bool LeerConfiguracion(String Fichero)
        {
            string xmlText = File.ReadAllText(Fichero);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlText);
            String Clave = "TECOISYSTEM/TOOL_"+m_dIndiceHerramienta.ToString();

            XmlNodeList oXmlNodeList = doc.SelectNodes(Clave);
            foreach (XmlNode x in oXmlNodeList)
            {
                m_NombreHerramienta = x.Attributes["NombreHerramienta"].Value;
                m_VelocidadBajada = Convert.ToInt32(x.Attributes["VelocidadBajada"].Value);
                m_VelocidadSubida = Convert.ToInt32(x.Attributes["VelocidadSubida"].Value);
                m_VelocidadRegulacion = Convert.ToInt32(x.Attributes["VelocidadRegulacion"].Value);
                m_FicheroCalidades = x.Attributes["FicheroCalidades"].Value;
                m_lfOffset[0] = Convert.ToDouble(x.Attributes["OffsetX"].Value);
                m_lfOffset[1] = Convert.ToDouble(x.Attributes["OffsetY"].Value);
                m_dEjeZAsociado = Convert.ToInt32(x.Attributes["EjeZAsociado"].Value);
            }
            return (true);
        }

        public virtual void EscribirEncenderHerramienta(StreamWriter StreamFileISO)
        {
            String Cadena = String.Format("G65 P1500 A{0}\n", m_dIndiceHerramienta);
            StreamFileISO.Write(Cadena);
        }
        public virtual void EscribirApagarHerramienta(StreamWriter StreamFileISO)
        {
            String Cadena = String.Format("G65 P1501 A{0}\n", m_dTipoHerramienta);
            StreamFileISO.Write(Cadena);
        }
        public virtual void EscribirAlturaPostCebado(StreamWriter StreamFileISO)
        {
            String Cadena = String.Format("G65 P1504 A{0}\n", m_dIndiceHerramienta);
            StreamFileISO.Write(Cadena);
        }
        public virtual void EscribirAlturaCorte(StreamWriter StreamFileISO)
        {
        }

        public virtual bool EscribirSubrutina_EncenderHerramienta(StreamWriter StreamFileCNC, int N)
        {
            return (true);
        }
        public virtual bool EscribirSubrutina_ApagarHerramienta(StreamWriter StreamFileCNC, int N)
        {
            return (true);
        }
        public virtual bool EscribirSubrutina_AlturaCebado(StreamWriter StreamFileCNC, int N)
        {
            return (true);
        }
        public virtual bool EscribirSubrutina_AlturaPostCebado(StreamWriter StreamFileCNC, int N)
        {
            return (true);
        }
        public virtual bool EscribirSubrutina_AlturaCorte(StreamWriter StreamFileCNC, int N)
        {
            return (true);
        }
        public virtual bool EscribirPrepararAlturaVacio(StreamWriter StreamFileCNC)
        {
            return (true);
        }

        public virtual bool RealizarAccion ()
        {
            return (true);
        }
        public virtual bool PrepararAccion(StreamWriter StreamFileISO, int[] Parametros, bool[] bEstados)
        {
            return (true);
        }

    }
}
