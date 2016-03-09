using System;
using System.IO;

namespace Test1
{
    class CebadoPison:TecnologiaCebado
    {
        public CebadoPison()
        {
            m_dTipoCebado = 6;

            m_Pendiente[0] = 0.00683;
            m_Pendiente[1] = 0.00683;
            m_Independiente[0] = 5.97221;
            m_Independiente[1] = 5.97221;
        }
        public override bool GenerarSubrutinaCebado(StreamWriter StreamFileCNC, MaquinaNormal M, int N)
        {
            int dNoTecnologiaCebado = N;

            StreamFileCNC.Write("IF [#505 NE 0.006] GOTO {0} (6 Cebado Pison)\n", dNoTecnologiaCebado);
            if (M.m_SistemaTecoi.m_FanucGlobalVariables.m_dTipoAutomata == 1 ||  // Autómata 0i antiguo
                M.m_SistemaTecoi.m_FanucGlobalVariables.m_dTipoAutomata == 2)    // Autómata 30i antiguo
            {
                StreamFileCNC.Write("M53\n#500 = 0\nM53\n");
                StreamFileCNC.Write("IF [#124 EQ 0] GOTO {0}\n", N+1);   
                StreamFileCNC.Write("G10L52\n");
                StreamFileCNC.Write("N8312 P{0} R0 (Quitar mirror- Param 8312 Eje Y2)\n", 
                    M.m_EjesY[1].m_dIndiceEje+1);
                StreamFileCNC.Write("G11\n");
                StreamFileCNC.Write("N{0} ", N+1);
                if (M.m_SistemaTecoi.m_FanucGlobalVariables.m_bExisteSegundoCanalAutomata)  // Si Existe segundo canal autómata
                {
                    StreamFileCNC.Write("IF [[#501 AND 1] NE 1] GOTO {0}\n", N+2);   // El primer cabezal no está involucrado
                    StreamFileCNC.Write("IF [#7 EQ 2] GOTO {0} (Si cerca saltamos {0})\n", N+2);   // Argumento 'D'. No hace falta medir porque vale la anterior.
                    StreamFileCNC.Write("G00 G91 {0}{1:+0;-0} {2}{3:+0;-0} G90\n",
                        M.m_EjesX[0].m_NombreEjeISO, m_OffsetX[1],
                        M.m_EjesY[0].m_NombreEjeISO, m_OffsetY[1]);
                    StreamFileCNC.Write("M85 (Bajar Pison)\n");
                    StreamFileCNC.Write("M53\n");
                    StreamFileCNC.Write("#145 = {0}*#141{1:+0;-0}\n", m_Pendiente[0], m_Independiente[0]);
                    StreamFileCNC.Write("#150 = {0}*#146{1:+0;-0}\n", m_Pendiente[1], m_Independiente[1]);
                    StreamFileCNC.Write("M53\n");
                    StreamFileCNC.Write("M86 (Subir Pison)\n");
                    StreamFileCNC.Write("G00 G91 {0}{1:+0;-0} {2}{3:+0;-0} G90\n",
                        M.m_EjesX[0].m_NombreEjeISO, -m_OffsetX[1],
                        M.m_EjesY[0].m_NombreEjeISO, -m_OffsetY[1]);
                    StreamFileCNC.Write("N{0} #4 = #145{1:+0;-0}-#507\n", N+4, m_OffsetZ[0]); 
                    StreamFileCNC.Write("IF [[#501 AND 2] NE 2] GOTO {0]}\n", N+3);   // Si Segundo cabezal no es esclavo, me salto el M54
                    StreamFileCNC.Write("#{0} = #150{1:+0;-0}-#507\n", 20000000+100, m_OffsetZ[1]);
                    StreamFileCNC.Write("M53\nM54\nM53\n"); // Cebado segundo canal
                    StreamFileCNC.Write("N{0} G01 F[#522*60] {1}-#4\n", N+3, M.m_EjesZ[0].m_NombreEjeISO);
                    StreamFileCNC.Write("GOTO {0}\n", dNoTecnologiaCebado);
                    StreamFileCNC.Write("N162 IF [#3 EQ 1] GOTO 149 (Si cerca saltamos 149)\n");   // Solamente segundo cabezal.
                    StreamFileCNC.Write("G00 G91 {0}{1:+0;-0} {2}{3:+0;-0} G90\n",
                        M.m_EjesX[0].m_NombreEjeISO, m_OffsetX[1],
                        M.m_EjesY[1].m_NombreEjeISO, m_OffsetY[1]);
                    StreamFileCNC.Write("M85 (Bajar Pison)\n");
                    StreamFileCNC.Write("M53\n");
                    StreamFileCNC.Write("#150 = {0}*#146{1:+0;-0}\n", m_Pendiente[1], m_Independiente[1]);
                    StreamFileCNC.Write("M53\n");
                    StreamFileCNC.Write("M86 (Subir Pison)\n");
                    StreamFileCNC.Write("G00 G91 {0}{1:+0;-0} {2}{3:+0;-0} G90\n",
                        M.m_EjesX[0].m_NombreEjeISO, -m_OffsetX[1],
                        M.m_EjesY[1].m_NombreEjeISO, -m_OffsetY[1]);
                    StreamFileCNC.Write("N149 #{0} = #150{1:+0;-0}-#507\n", 20000000+100, m_OffsetZ[1]); // FanucGeneral3->OffsetZCebadoPison2,
                    StreamFileCNC.Write("M53\nM54\nM53\n"); // Cebado segundo canal
                }
                else
                {
                    StreamFileCNC.Write("IF [#7 NE 2] GOTO {0} (No medida. Esta cerca)\n", N+4);  // Argumento 'D'. No hace falta medir porque vale la anterior.
                    StreamFileCNC.Write("#4 = #145{0:+0;-0}-#507\n", m_OffsetZ[0]);
                    StreamFileCNC.Write("#5 = #150{0:+0;-0}-#507\nM53\n", m_OffsetZ[1]);
                    StreamFileCNC.Write("IF [#8 NE 3] GOTO {0} (cabezal 1 y 2)\n", N+2);          // cabezal 1 y 2
                    StreamFileCNC.Write("G01 F[#522*60] {0}-#4 {1}-#5\n", 
                        M.m_EjesZ[0].m_NombreEjeISO, M.m_EjesZ[1].m_NombreEjeISO);
                    StreamFileCNC.Write("GOTO {0}\n", dNoTecnologiaCebado);
                    StreamFileCNC.Write("N{0]} IF [#8 NE 1] GOTO 51 (Solo Cabezal 1)\n", N+2);     // Solo cabezal 1
                    StreamFileCNC.Write("G01 F[#522*60] {0}-#4\n", M.m_EjesZ[0].m_NombreEjeISO);
                    StreamFileCNC.Write("GOTO {0}\n", dNoTecnologiaCebado);
                    StreamFileCNC.Write("N51 G01 F[#522*60] {0}-#5\n", M.m_EjesZ[1].m_NombreEjeISO);
                    StreamFileCNC.Write("GOTO {0}\n", dNoTecnologiaCebado);
                    StreamFileCNC.Write("N{0} IF [#8 EQ 2] GOTO {0} (cabezal 1 es maestro)\n", N+4, N+5);   // cabezal 1 y 2
                    StreamFileCNC.Write("G00 G91 {0}{1} {2}{3} G90\n",
                        M.m_EjesX[0].m_NombreEjeISO, m_OffsetX[0],
                        M.m_EjesY[0].m_NombreEjeISO, m_OffsetY[0]);
                    StreamFileCNC.Write("GOTO {0}\n", N+3);
                    StreamFileCNC.Write("N{0} G00 G91 {0}{1} {2}{3} G90\n", N+5,
                        M.m_EjesX[0].m_NombreEjeISO, m_OffsetX[1],
                        M.m_EjesY[1].m_NombreEjeISO, m_OffsetY[1]);
                    StreamFileCNC.Write("N{0} M85 (Bajar Pison)\n", N+3);
                    StreamFileCNC.Write("#145 = {0}*#141{1:+0;-0}\n", m_Pendiente[0], m_Independiente[0]);
                    StreamFileCNC.Write("#4 = #145-{0}-#507\n", Math.Abs(m_OffsetZ[0]));
                    StreamFileCNC.Write("#150 = {0}*#146{1:+0;-0}\n", m_Pendiente[1], m_Independiente[1]);
                    StreamFileCNC.Write("#5 = #150{0:+0;-0}-#507\n", Math.Abs(m_OffsetZ[1]));
                    StreamFileCNC.Write("M86 (Subir Pison)\n");

                    StreamFileCNC.Write("IF [#8 EQ 2] GOTO {0} (cabezal 1 es maestro)\n", N+6);   // cabezal 1 y 2
                    StreamFileCNC.Write("G00 G91 {0}{1} {2}{3} G90\n",
                        M.m_EjesX[0].m_NombreEjeISO, -m_OffsetX[0],
                        M.m_EjesY[0].m_NombreEjeISO, -m_OffsetY[0]);
                    StreamFileCNC.Write("GOTO {0}\n", N+7);
                    StreamFileCNC.Write("N{0} G00 G91 {0}{1} {2}{3} G90\n", N+6,
                        M.m_EjesX[0].m_NombreEjeISO, -m_OffsetX[0],
                        M.m_EjesY[1].m_NombreEjeISO, -m_OffsetY[0]);

                    StreamFileCNC.Write("N{0} IF [#8 NE 3] GOTO 60 (cabezal 1 y 2)\n", N+7);   // cabezal 1 y 2
                    StreamFileCNC.Write("G01 F[#522*60] {0}-#4 {1}-#5\n",
                         M.m_EjesZ[0].m_NombreEjeISO, M.m_EjesZ[1].m_NombreEjeISO);
                    StreamFileCNC.Write("GOTO {0}\n", dNoTecnologiaCebado);
                    StreamFileCNC.Write("N60 IF [#8 NE 1] GOTO 61 (Solo Cabezal 1)\n"); // Solo cabezal 1
                    StreamFileCNC.Write("G01 F[#522*60] {0}-#4\n", M.m_EjesZ[0].m_NombreEjeISO);
                    StreamFileCNC.Write("GOTO 999999\n");
                    StreamFileCNC.Write("N61 G01 F[#522*60] {0}-#5\n", M.m_EjesZ[1].m_NombreEjeISO);
                }
                StreamFileCNC.Write("IF [#124 EQ 0] GOTO 999998\n");
                StreamFileCNC.Write("G10L52\n");
                StreamFileCNC.Write("N8312 P{0} R100 (Poner mirror- Param 8312 Eje Y2)\n", M.m_EjesY[1].m_dIndiceEje+1);
                StreamFileCNC.Write("G11\n");
                StreamFileCNC.Write("N999998\n");
            }
            StreamFileCNC.Write("N{0}\n", dNoTecnologiaCebado);
            return (true);
        }
    }
}
