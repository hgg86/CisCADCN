using System.IO;

namespace Test1
{
    class CebadoCapacitivo:TecnologiaCebado
    {
        public CebadoCapacitivo()
        {
            m_dTipoCebado = 0;
        }
        public override bool GenerarSubrutinaCebado(StreamWriter StreamFileCNC, MaquinaNormal M, int N)
        {
            StreamFileCNC.Write("IF [#505 NE 0] GOTO {0} (0 Cebado Capacitivo)\n", N);  // No es marcado de tinta Macrojet
            if (M.m_SistemaTecoi.m_FanucGlobalVariables.m_dTipoAutomata == 1 ||  // Autómata 0i antiguo
                M.m_SistemaTecoi.m_FanucGlobalVariables.m_dTipoAutomata == 2)    // Autómata 30i antiguo
            {
                StreamFileCNC.Write("M14\nG92.1Z0\nG31 F[#522*60] {0}{1}\n", M.m_EjesZ[0].m_NombreEjeISO,
                    M.m_EjesZ[0].m_lfLimiteInferior+10.0);
                StreamFileCNC.Write("M53\n");
                StreamFileCNC.Write("GOTO 9999990\n");
            }
            StreamFileCNC.Write("N{0}\n", N);
            return (true);
        }


    }
}
