using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test1
{
    class EntidadPunto:Entidad
    {
        public EntidadPunto()
        {
            m_Inicio = new Punto(0, 0);
            m_Final = new Punto(0, 0);
            m_lfLongitud = 0.0;
            CotasEntidad[0] = CotasEntidad[2] = m_Inicio.m_lfx;
            CotasEntidad[1] = CotasEntidad[3] = m_Inicio.m_lfy;
        }
        public EntidadPunto(Punto p)
        {
            m_Inicio = new Punto(p);
            m_Final = m_Inicio;
            m_lfLongitud = 0.0;
            CotasEntidad[0] = CotasEntidad[2] = m_Inicio.m_lfx;
            CotasEntidad[1] = CotasEntidad[3] = m_Inicio.m_lfy;
        }
        public override Punto PuntoInicial()
        {
            return (m_Inicio);
        }
        public override Punto PuntoFinal()
        {
            return (m_Inicio);
        }
    }
}
