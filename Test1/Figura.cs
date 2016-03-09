using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test1
{
    class Figura
    {
        public List<Bloque> m_Bloques;
        public int m_dIndiceTrabajo;
        public double[] CotasFigura = new double[4];

        public Figura()
        {
            m_Bloques = new List<Bloque>();
            m_Bloques.Add(new Bloque());
            CotasFigura[0] = CotasFigura[1] = CotasFigura[2] = CotasFigura[3] = 0.0;
        }
        public Figura(int dNumBloques, List<Bloque> B)
        {
            m_Bloques = new List<Bloque>();
            m_Bloques = B;
        }
        public void TerminarFigura()
        {
            m_Bloques.RemoveAt(m_Bloques.Count - 1);  // Se debe eliminar el último siempre
            foreach (Bloque b in m_Bloques)
            {
                CotasFigura[0] = Math.Min(CotasFigura[0], b.CotasBloque[0]);
                CotasFigura[1] = Math.Min(CotasFigura[1], b.CotasBloque[1]);
                CotasFigura[2] = Math.Max(CotasFigura[2], b.CotasBloque[2]);
                CotasFigura[3] = Math.Max(CotasFigura[3], b.CotasBloque[3]);

            }
        }
    }
}
