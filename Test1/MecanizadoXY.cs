using System.Collections.Generic;
using System.IO;

namespace Test1
{
    class MecanizadoXY : Herramienta
    {
        public MecanizadoXY()
        {
            m_dTipoHerramienta = 6;
        }
        public MecanizadoXY(List<EjeMaquina> Ejes, Herramienta MiHerramienta)
        {
        }
        public override bool EscribirPrepararAlturaVacio(StreamWriter StreamFileCNC)
        {
            if (m_FanucGlobalVariables.m_dTipoAutomata == 1 ||  // Autómata 0i antiguo
                m_FanucGlobalVariables.m_dTipoAutomata == 2)    // Autómata 30i antiguo
            {
                StreamFileCNC.Write("M5\n");                            // Apagar Spindle primer cabezal
                StreamFileCNC.Write("M65\n");	                        // Apagar Spindle Segundo cabezal
            }
            return (true);
        }
    }
}
