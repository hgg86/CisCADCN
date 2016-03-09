using System.IO;

namespace Test1
{
    class CebadoLaser:TecnologiaCebado
    {
        public CebadoLaser()
        {
            m_dTipoCebado = 5;
        }
        public override bool GenerarSubrutinaCebado(StreamWriter StreamFileCNC, MaquinaNormal M, int N)
        {
            int dNoTecnologiaCebado = N;

            StreamFileCNC.Write("IF [#505 NE 0.005] GOTO {0} (2 Cebado Laser)\n", dNoTecnologiaCebado);
            if (M.m_SistemaTecoi.m_FanucGlobalVariables.m_dTipoAutomata == 1 ||  // Autómata 0i antiguo
                M.m_SistemaTecoi.m_FanucGlobalVariables.m_dTipoAutomata == 2)    // Autómata 30i antiguo
            {
                StreamFileCNC.Write("M53\n#500 = 0\nM53\n");
                StreamFileCNC.Write("IF [#7 EQ 2] GOTO {0}\n", N+1);  // Argumento 'D' == 2 Están suficientemente cerca como para no tener que hacer medidas
                StreamFileCNC.Write("G00 G91 {0}#142 {1}#143 G90\n",
                    M.m_EjesX[0].m_NombreEjeISO, M.m_EjesY[0].m_NombreEjeISO);
                StreamFileCNC.Write("M53\nG04 P500\nM53\n");
                StreamFileCNC.Write("#145 = %d*#141/32768\n", 
                    M.m_SistemaTecoi.m_FanucGlobalVariables.m_dFondoEscalaLaserCebado);  
                StreamFileCNC.Write("#145 = %d-#145\n", M.m_SistemaTecoi.m_FanucGlobalVariables.m_dFondoEscalaLaserCebado+
                    M.m_SistemaTecoi.m_FanucGlobalVariables.m_dMinDistanciaLaserCebado);  
                StreamFileCNC.Write("N{0} #4 = #145-%d-#507\nM53\n", N+1, 
                    M.m_SistemaTecoi.m_FanucGlobalVariables.m_OffsetZCebadoLaser);
                StreamFileCNC.Write("IF [#7 EQ 2] GOTO 40\n");
                StreamFileCNC.Write("G00 G91 {0}[-#142] {1}[-#143] G90\n", 
                    M.m_EjesX[0].m_NombreEjeISO, M.m_EjesY[0].m_NombreEjeISO);
                StreamFileCNC.Write("N40 G01 F[#522*60] {0}[-#4]\n", M.m_EjesZ[0].m_NombreEjeISO);
                StreamFileCNC.Write("M53\nGOTO 999999\n");
            }
            StreamFileCNC.Write("N{0}\n", dNoTecnologiaCebado);
            return (true);
        }
    }
}
