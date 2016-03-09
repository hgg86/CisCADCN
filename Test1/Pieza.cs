using System;
using System.Collections.Generic;

namespace Test1
{
    class Pieza
    {
        public List<Bloque> m_Bloques = null;
        public int m_dIndiceTrabajo;
        public double[] CotasPieza = new double[4];

        public Pieza()
        {
            m_Bloques = new List<Bloque>();
            m_Bloques.Add(new Bloque());
            CotasPieza[0] = CotasPieza[1] = CotasPieza[2] = CotasPieza[3] = 0.0;
        }
        public Pieza(int dNumBloques, List<Bloque> B)
        {
            m_Bloques = new List<Bloque>();
            m_Bloques = B;
        }
        public void TerminarPieza()
        {
            m_Bloques.RemoveAt(m_Bloques.Count - 1);  // Se debe eliminar el último siempre
            foreach (Bloque b in m_Bloques)
            {
                CotasPieza[0] = Math.Min(CotasPieza[0], b.CotasBloque[0]);
                CotasPieza[1] = Math.Min(CotasPieza[1], b.CotasBloque[1]);
                CotasPieza[2] = Math.Max(CotasPieza[2], b.CotasBloque[2]);
                CotasPieza[3] = Math.Max(CotasPieza[3], b.CotasBloque[3]);

            }
        }
    }
}
