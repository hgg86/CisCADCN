using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace Test1
{
    class MecanizadoPerforacion : Herramienta
    {
#region Variables de la herramienta
        private const int NUM_HERRAMIENTAS_CABEZAL = 6;
        public int[] m_dHerramientaActual = new int[NUM_HERRAMIENTAS_CABEZAL];
        public bool[] m_dHerramientaAutomatica = new bool[NUM_HERRAMIENTAS_CABEZAL];
#endregion
        public MecanizadoPerforacion()
        {
            m_dTipoHerramienta = 5;
        }
        public MecanizadoPerforacion(List<EjeMaquina> Ejes, Herramienta MiHerramienta)
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
        public override bool RealizarAccion()
        {
            return (true);
        }
        public override bool PrepararAccion(StreamWriter StreamFileISO, int[] Parametros, bool[] bEstados)
        {
            for (int i = 0; i < Parametros[0]; i++)
            {
                StreamFileISO.Write(String.Format("G65 P1502 A{0} B{1} C{2}\n",
                    i, Parametros[i+1], bEstados[i]));
                m_dHerramientaActual[i] = Parametros[i+1];
            }
            return (true);
        }
    }
}
