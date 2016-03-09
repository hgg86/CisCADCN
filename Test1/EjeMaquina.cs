using System;
using System.IO;
using System.Xml;

namespace Test1
{
    class EjeMaquina
    {
        #region Definición de variables
        public int m_dIndiceEje;
        public int m_dTipoEje;      // 1: lineal, 2: rotatorio, 3: bisel
        public int m_dCodigoEje;    // 0: Eje X, 1: Eje Y, 2: Eje Z, 3: Eje A, 4: Eje B.
        public int m_dNumEje;
        public bool m_bEjeControladoAutomata = false;
        public double m_lfVelocidadVacio;
        public double m_lfVelocidadCorte;
        public double m_lfVelocidadManual;
        public double m_Aceleracion;
        public double m_Deceleracion;
        public string m_NombreEje;
        public bool m_bEjeEactivo;
        public double m_lfPosicion;     // Posición actual del eje.
        public double m_lfPosicion_ISO; // Utilizado para generar fichero salida
        public double m_lfLimiteInferior;
        public double m_lfLimiteSuperior;
        public string m_NombreEjeISO;
        #endregion

        public EjeMaquina()
        {
            m_dTipoEje = 0;
            m_dNumEje = 0;
            m_lfVelocidadVacio = 1000;
            m_lfVelocidadCorte = 100;
            m_lfVelocidadManual = 100;
            m_bEjeEactivo = false;
            m_NombreEjeISO = "";
        }
        public EjeMaquina(int dTipoMaquina, int dNumEje)
        {
            m_dTipoEje = dTipoMaquina;
            m_dNumEje = dNumEje;
            m_lfVelocidadVacio = 1000;
            m_lfVelocidadCorte = 100;
            m_lfVelocidadManual = 100;
            m_bEjeEactivo = false;
            m_NombreEjeISO = "";
        }
        public EjeMaquina(int dTipoMaquina, int dNumEje, double VelVacio, double VelCorte, double VelManual)
        {
            m_dTipoEje = dTipoMaquina;
            m_dNumEje = dNumEje;
            m_lfVelocidadVacio = VelVacio;
            m_lfVelocidadCorte = VelCorte;
            m_lfVelocidadManual = VelManual;
            m_bEjeEactivo = false;
            m_NombreEjeISO = "";
        }
        public bool EscribirConfiguracion (String Fichero)
        {
            return (true);
        }
        public bool LeerConfiguracion(String Fichero)
        {
            string xmlText = File.ReadAllText(Fichero); 
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlText);
            String Clave = "TECOISYSTEM/AXE_" + m_dIndiceEje.ToString();

            XmlNodeList oXmlNodeList = doc.SelectNodes(Clave);
            foreach (XmlNode x in oXmlNodeList)
            {
                m_dNumEje = Convert.ToInt32(x.Attributes["NumeroEje"].Value);
                m_dTipoEje = Convert.ToInt32(x.Attributes["TipoEje"].Value);
                m_NombreEje = x.Attributes["NombreEje"].Value;
                m_dCodigoEje = Convert.ToInt32(x.Attributes["CodigoEje"].Value);
                m_lfVelocidadVacio = Convert.ToInt32(x.Attributes["VelocidadVacio"].Value);
                m_lfVelocidadCorte = Convert.ToInt32 (x.Attributes["VelocidadCorte"].Value);
                m_lfVelocidadManual = Convert.ToInt32 (x.Attributes["VelocidadManual"].Value);
                m_Aceleracion = Convert.ToInt32 (x.Attributes["Aceleracion"].Value);
                m_Deceleracion = Convert.ToInt32 (x.Attributes["Deceleracion"].Value);
                m_NombreEjeISO = m_NombreEje.Substring(0, 1);
                if (m_NombreEje.Length > 1)
                {
                    int n = Convert.ToInt32(m_NombreEje.Substring(1, m_NombreEje.Length-1));
                    //if (n > 1)
                        m_NombreEjeISO += n+"=";
                }
            }

            return (true);
        }
    }
}
