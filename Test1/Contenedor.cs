using System;
using System.Collections.Generic;

namespace Test1
{
    class Contenedor
    {
        public EjeMaquina m_EjeTorreta;
        public List<Herramienta> m_HerramientasTotales = new List<Herramienta>();
        public List<Herramienta> m_Herramientas = new List<Herramienta>();
        public Contenedor (EjeMaquina EjeTorreta, List<Herramienta> Todas)
        {
            foreach (Herramienta h in Todas)
            {
                if (h.m_dTipoHerramienta == 6 || h.m_dTipoHerramienta == 5) // Es de mecanizado
                    m_HerramientasTotales.Add(h);
            }
            m_EjeTorreta = EjeTorreta;
        }
        public Contenedor(EjeMaquina EjeTorreta, List<Herramienta> Todas, List<Herramienta> HerramientaEnTorreta)
        {
            foreach (Herramienta h in Todas)
            {
                if (h.m_dTipoHerramienta == 6 || h.m_dTipoHerramienta == 5) // Es de mecanizado
                    m_HerramientasTotales.Add(h);
                m_Herramientas = HerramientaEnTorreta;
            }
            m_EjeTorreta = EjeTorreta;
        }
    }
}
