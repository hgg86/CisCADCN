using System.IO;

namespace Test1
{
    class CebadoTinta: TecnologiaCebado
    { 
        public CebadoTinta()
        {
            m_dTipoCebado = 7;
        }
        public override bool GenerarSubrutinaCebado(StreamWriter StreamFileCNC, MaquinaNormal M, int N)
        {
            StreamFileCNC.Write("IF [#503 NE 5] GOTO {0} (Tinta Macrojet)\n", N);  // No es marcado de tinta Macrojet
            if (M.m_SistemaTecoi.m_FanucGlobalVariables.m_dTipoAutomata == 1 ||  // Autómata 0i antiguo
                M.m_SistemaTecoi.m_FanucGlobalVariables.m_dTipoAutomata == 2)    // Autómata 30i antiguo
            {
                StreamFileCNC.Write("M53\n#140 = 0.001\nM53\n");
                StreamFileCNC.Write("WHILE [#140 EQ 0.001] DO 1\n");
                StreamFileCNC.Write("END 1\n");
                StreamFileCNC.Write("GOTO 999999\n");
                StreamFileCNC.Write("N{0} IF [#503 LT 3] GOTO 4 (Tinta sin cabezal)\n", N);    // No es marcado de tinta sin cabezal
                StreamFileCNC.Write("IF [#503 EQ 4] GOTO 4\n");
                StreamFileCNC.Write("G65 P1600\n"); // FanucSubrutinas->dHomeZ
                StreamFileCNC.Write("GOTO 999999\n");
                StreamFileCNC.Write("N4 M53\n");
            }
            StreamFileCNC.Write("N{0}\n", N);
            return (true);
        }
    }
}
