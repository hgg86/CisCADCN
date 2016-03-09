using System.IO;

namespace Test1
{
    class CebadoLaserCorte:TecnologiaCebado
    {
        public CebadoLaserCorte()
        {
            m_dTipoCebado = 8;
        }
        public override bool GenerarSubrutinaCebado(StreamWriter StreamFileCNC, MaquinaNormal M, int N)
        {
            int dNoTecnologiaCebado = N;
            StreamFileCNC.Write("IF [#503 NE 5] GOTO {0} (Tinta Macrojet)\n", dNoTecnologiaCebado);  // No es marcado de tinta Macrojet
            if (M.m_SistemaTecoi.m_FanucGlobalVariables.m_dTipoAutomata == 1 ||  // Autómata 0i antiguo
                M.m_SistemaTecoi.m_FanucGlobalVariables.m_dTipoAutomata == 2)    // Autómata 30i antiguo
            {
                StreamFileCNC.Write("M53\nM10\n");  
                StreamFileCNC.Write("IF [#3 EQ -1] GOTO {0}\n", dNoTecnologiaCebado);    // No cebar
                StreamFileCNC.Write("M14\nM53\n#%500 = 0.326\n");
                StreamFileCNC.Write("M53\n");
                StreamFileCNC.Write("IF[#19EQ10]GOTO {0}\n", N+1);
                StreamFileCNC.Write("G92.1{0}0\n", M.m_EjesZ[0].m_NombreEjeISO);
                if (M.m_SistemaTecoi.m_FanucGlobalVariables.m_bExisteAlturaFanuc)
                    StreamFileCNC.Write("G31 F[#857] {0}{1}\n", M.m_EjesZ[0].m_NombreEjeISO, M.m_EjesZ[0].m_lfLimiteInferior+10.0);
                StreamFileCNC.Write("GOTO {0}\n", N+2);
                StreamFileCNC.Write("G92.1{0}0\n", M.m_EjesZ[0].m_NombreEjeISO);
                if (M.m_SistemaTecoi.m_FanucGlobalVariables.m_bExisteAlturaFanuc)
                    StreamFileCNC.Write("G31 F[#857] {0}{1}\n", M.m_EjesZ[1].m_NombreEjeISO, M.m_EjesZ[1].m_lfLimiteInferior+10.0);
                StreamFileCNC.Write("GOTO {0}\n", N+2);
                StreamFileCNC.Write("N{0} G92.1{1}0\n", N+1, M.m_EjesZ[0].m_NombreEjeISO);
                StreamFileCNC.Write("M53\n");               
                StreamFileCNC.Write("G92.1{0}2=0\n", M.m_EjesZ[1].m_NombreEjeISO);
                StreamFileCNC.Write("M53\n");
                StreamFileCNC.Write("G31 F[#857*2] {0}{1} {2}{3}\n",
                    M.m_EjesZ[0].m_NombreEjeISO, M.m_EjesZ[0].m_lfLimiteInferior+10.0,
                    M.m_EjesZ[1].m_NombreEjeISO, M.m_EjesZ[1].m_lfLimiteInferior+10.0);
                StreamFileCNC.Write("N{0} ", N+2);
                if (M.m_SistemaTecoi.m_FanucGlobalVariables.bEjeVirtualActivo)
                    StreamFileCNC.Write("M53\nM132\nM53\nM130\nM53\n");   
                StreamFileCNC.Write("M53\nM11\n#1100 = 1 (ACTIVA ORDEN EN F54.0)\n");
                StreamFileCNC.Write("WHILE [#1000 EQ 0] DO 1 (ESPERA A CONFIRMACION EN G54.0)\n");
                StreamFileCNC.Write("END 1\n");
                StreamFileCNC.Write("#1100 = 0\n");
                StreamFileCNC.Write("#500 = 0.327\n");
                StreamFileCNC.Write("M53\n");
                StreamFileCNC.Write("G05.1Q1\n");
            }
            StreamFileCNC.Write("N{0}\n", dNoTecnologiaCebado);
            return (true);
        }
    }
}
