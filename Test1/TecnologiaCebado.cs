using System.IO;

namespace Test1
{
    class TecnologiaCebado
    {
        public int m_dTipoCebado = -1;   // 0 Capacitivo, 1 Regulado, 2 Contacto, 3 Altura fija, 5 Laser, 6 Pisón, 
                                         // 7 Cebado Tinta, 8 Cebado Corte Láser
        public int[] m_OffsetX = new int[6];
        public int[] m_OffsetY = new int[6];
        public int[] m_OffsetZ = new int[6];    // Para el pisón
        public double[] m_Pendiente = new double[6];
        public double[] m_Independiente = new double[6];

        public virtual bool GenerarSubrutinaCebado(StreamWriter StreamFileCNC, MaquinaNormal M, int N)
        {
            return (true);
        }
    }
}
