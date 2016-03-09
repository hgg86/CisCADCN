using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test1
{
    class PlasmaKelljberg : Herramienta
    {
        public PlasmaKelljberg()
        {
            m_dTipoHerramienta = 3;
        }
        public override bool EscribirSubrutina_EncenderHerramienta(StreamWriter StreamFileCNC, int N)
        {
            if (m_FanucGlobalVariables.m_dTipoAutomata == 1 ||  // Autómata 0i antiguo
                m_FanucGlobalVariables.m_dTipoAutomata == 2)    // Autómata 30i antiguo
            {
                StreamFileCNC.Write("M53\n#500 = 0.013\n");

                StreamFileCNC.Write("IF [#1 NE {0}] GOTO {1}\n", m_dIndiceHerramienta, N);
                StreamFileCNC.Write("IF [#1 EQ #123] THEN GOTO {0}\n", N+1);
                StreamFileCNC.Write("WHILE [#123 NE #1] DO 1\n");
                StreamFileCNC.Write("END 1\n");
                StreamFileCNC.Write("N{0}\n", N+1);
                StreamFileCNC.Write("IF [#524 EQ 0] GOTO {0} (Recorrido Prueba)\n", N+2);
                StreamFileCNC.Write("#1104 = 1 (ACTIVA ORDEN EN F54.4)\n");
                StreamFileCNC.Write("WHILE [#1004 EQ 0] DO 1 (ESPERA A CONFIRMACION EN G54.4)\n");
                StreamFileCNC.Write("END 1\n");
                StreamFileCNC.Write("N{0} #1104 = 0\n", N+2);
                StreamFileCNC.Write("#500 = 0.014\n");
                StreamFileCNC.Write("#529 = 529+1\n");                 // Contador arranques plasma
                StreamFileCNC.Write("IF [#537 EQ 0] GOTO 1000000\n");  // dEnableLimpieza
                StreamFileCNC.Write("#536 = #536+1\n");                // dLimpiezaContador,
                StreamFileCNC.Write("G05.1Q1\n");
                StreamFileCNC.Write("GOTO 1000000\n");
            }
            StreamFileCNC.Write("N{0}\n", N);

            return (true);
        }
        public override bool EscribirSubrutina_ApagarHerramienta(StreamWriter StreamFileCNC, int N)
        {
            StreamFileCNC.Write("IF [#1 NE {0}] GOTO {1}\n", m_dIndiceHerramienta, N);
            if (m_FanucGlobalVariables.m_dTipoAutomata == 1 ||  // Autómata 0i antiguo
                m_FanucGlobalVariables.m_dTipoAutomata == 2)    // Autómata 30i antiguo
            {
                StreamFileCNC.Write("M53\n#500 = 0.023\n");
                StreamFileCNC.Write("#1108 = 1 (ACTIVA ORDEN EN F55.0)\n");
                StreamFileCNC.Write("WHILE [#1008 EQ 0] DO 1 (ESPERA A CONFIRMACION EN G55.0)\n");
                StreamFileCNC.Write("END 1\n");
                StreamFileCNC.Write("#1108 = 0\n");
                StreamFileCNC.Write("M53\n");
                StreamFileCNC.Write("#500=0.024\n");
            }
            StreamFileCNC.Write("N{0}\n", N);

            return (true);
        }
    }
}
