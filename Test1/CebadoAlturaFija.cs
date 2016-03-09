using System.IO;

namespace Test1
{
    class CebadoAlturaFija:TecnologiaCebado
    {
        public CebadoAlturaFija()
        {
            m_dTipoCebado = 3;
        }
        public override bool GenerarSubrutinaCebado(StreamWriter StreamFileCNC, MaquinaNormal M, int N)
        {
            int i;
            int j;
            int n;
            int dIndiceLinea = 0;
            int dNoTecnologiaCebado = N;
            int dLineaMaestros = N+1;
            StreamFileCNC.Write("IF [#505 NE 0.003] GOTO {0} (3 Altura fija)\n", dNoTecnologiaCebado);
            if (M.m_SistemaTecoi.m_FanucGlobalVariables.m_dTipoAutomata == 1 ||  // Autómata 0i antiguo
                M.m_SistemaTecoi.m_FanucGlobalVariables.m_dTipoAutomata == 2)    // Autómata 30i antiguo
            {
                for (i = 0; i < M.m_EjesZ.Count; i++)
                {
                    StreamFileCNC.Write("N{0} IF [[#501 AND {1}] NE {1}] GOTO {2}\n", dLineaMaestros, 1 << i, dLineaMaestros+1);
                    ++dLineaMaestros;
                    for (j = M.m_EjesZ.Count-1; j > i; j--)
                    {
                        dIndiceLinea = 20+M.m_EjesZ.Count-1-j;
                        StreamFileCNC.Write("IF [[#501 AND {0}] NE {0}] GOTO {1}\n", 1 << j, N+1+dIndiceLinea);
                    }
                    StreamFileCNC.Write("IF [[#501 AND {0}] NE {0}] GOTO {1}\n", 1 << i, N+20);
                    StreamFileCNC.Write("G01 F[#506*60] ");
                    StreamFileCNC.Write("{0}#509\n", M.m_EjesZ[i].m_NombreEjeISO);
                    StreamFileCNC.Write("GOTO 999999\n");
                    for (j = M.m_EjesZ.Count - 1; j > i; j--)
                    {
                        dIndiceLinea = 20 + M.m_EjesZ.Count-1-j;
                        StreamFileCNC.Write("N{0} G01 F[#506*60] ", N+1+dIndiceLinea);
                        for (n = i; n <= j; n++)
                            StreamFileCNC.Write("{0}#509 ", M.m_EjesZ[n].m_NombreEjeISO);
                        StreamFileCNC.Write("\nGOTO 999999\n");
                    }
                    StreamFileCNC.Write("N{0}\n", N+20);
                    N += 20;
                }
                StreamFileCNC.Write("N{0}\n", dLineaMaestros);
            }
            StreamFileCNC.Write("N{0}\n", dNoTecnologiaCebado);
            return (true);
        }
    }
}
