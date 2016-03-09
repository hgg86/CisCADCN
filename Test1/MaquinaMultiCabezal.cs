using System;
using System.IO;

namespace Test1
{
    class MaquinaMultiCabezal : MaquinaLineal
    {
        private MaquinaMonoCabezal m_MaquinaMonoCabezal = null;

        private bool[] m_MaestroEsclavo = new bool[6];
        private bool[] m_bEsMirror = new bool[6];
        private short[] GeneralEsclavos = new short[6]; 
        private short m_dIndiceMaestro = 0;
        public double[] m_lfSeparacionCabezales = new double[6];
        private short GeneralNumEsclavos = 0;

        public MaquinaMultiCabezal(int dMachinaIndex, String MachinaCode)
        {
            m_dMachinaIndex = dMachinaIndex;
            m_MachinaCode = MachinaCode;
            m_MaquinaMonoCabezal = new MaquinaMonoCabezal(m_dMachinaIndex, m_MachinaCode);
        }
        public void MaestrosEclavos(bool[] bEstadoCabezales, bool[] bEsMirror, double[] SepracionCabezales)
        {
            for (int i = 0; i < 6; i++)
            {
                m_MaestroEsclavo[i] = bEstadoCabezales[i];
                m_bEsMirror[i] = bEsMirror[i];
                m_lfSeparacionCabezales[i] = SepracionCabezales[i];
            }
        }
        private void ComponerMaquinaMaquinaMonoCabezal ()
        {
            m_MaquinaMonoCabezal.m_EjesX.Clear();
            m_MaquinaMonoCabezal.m_EjesY.Clear();
            m_MaquinaMonoCabezal.m_EjesZ.Clear();
            m_MaquinaMonoCabezal.m_EjesA.Clear();
            m_MaquinaMonoCabezal.m_EjesB.Clear();
            int i;
            for (i = 0; i < 6; i++)
                if (m_MaestroEsclavo[i])
                    break;
            m_MaquinaMonoCabezal.m_EjesX.Add(m_EjesX[i]);
            m_MaquinaMonoCabezal.m_EjesY.Add(m_EjesY[i]);
            if (m_EjesZ.Count > 0)
                m_MaquinaMonoCabezal.m_EjesZ.Add(m_EjesZ[i]);
            if (m_EjesA.Count > 0 || m_EjesB.Count > 0)
            {
                m_MaquinaMonoCabezal.m_EjesA.Add(m_EjesY[i]);
                m_MaquinaMonoCabezal.m_EjesB.Add(m_EjesB[i]);
            }
        }
        public override void Bloque2ISO(StreamWriter StreamFileISO, Bloque Bloq)
        {
            ComponerMaquinaMaquinaMonoCabezal();
            m_MaquinaMonoCabezal.Bloque2ISO(StreamFileISO, Bloq);
        }
        public override void EstablecerMaestroEsclavoEnVivo (Bloque Bloq)
        {
            //short i;
            //for (i = 0; i < m_EjesY.Count; i++)
            //{
            //    if (m_MaestroEsclavo[i])
            //        break;

            //    m_SistemaTecoi.FanucActivarMirrorMulticabezal((short)m_EjesY[i].m_dIndiceEje, false);
            //    m_SistemaTecoi.FanucActivarEsclavoMulticabezal((short)m_EjesY[i].m_dIndiceEje, false, (short)0);  // No importa el master ahora
            //    if (m_FanucGeneral.u.bExisteBevel != 0 && m_FanucGeneral.u.dNumeroEjesV > i)
            //    {
            //        m_SistemaTecoi.FanucActivarEsclavoMulticabezal((short)m_EjesA[i].m_dIndiceEje, false, 0); // No importa el master ahora
            //        m_SistemaTecoi.FanucActivarEsclavoMulticabezal((short)m_EjesB[i].m_dIndiceEje, false, (short)0); // No importa el master ahora
            //    }
            //}

            //m_dIndiceMaestro = i;
            //m_SistemaTecoi.FanucPonerEjeMaestro(this, m_dIndiceMaestro); // Índice en los ejes Y

            //bool bAlgunEsclavo = false;
            //m_SistemaTecoi.EscribirMacro(501, (float)(1 << i));
            //++i;
            //for (; i < m_EjesY.Count; i++)
            //{
            //    m_SistemaTecoi.FanucActivarEsclavoMulticabezal((short)m_EjesY[i].m_dIndiceEje, m_MaestroEsclavo[i], 
            //        (short)m_EjesY[m_dIndiceMaestro].m_dIndiceEje);
            //    m_SistemaTecoi.FanucActivarMirrorMulticabezal((short)m_EjesY[i].m_dIndiceEje, m_bEsMirror[i]);
            //    bAlgunEsclavo |= m_bEsMirror[i];
            //    if (m_FanucGeneral.u.bExisteBevel != 0 && m_FanucGeneral.u.dNumeroEjesV > i)
            //    {
            //        m_SistemaTecoi.FanucActivarEsclavoMulticabezal((short)m_EjesA[i].m_dIndiceEje, m_MaestroEsclavo[i], 
            //            (short)m_EjesA[m_dIndiceMaestro].m_dIndiceEje);
            //        m_SistemaTecoi.FanucActivarEsclavoMulticabezal((short)m_EjesB[i].m_dIndiceEje, m_MaestroEsclavo[i],
            //            (short)m_EjesB[m_dIndiceMaestro].m_dIndiceEje);
            //        m_SistemaTecoi.FanucActivarMirrorMulticabezal((short)m_EjesA[i].m_dIndiceEje, m_bEsMirror[i]);
            //        m_SistemaTecoi.FanucActivarMirrorMulticabezal((short)m_EjesB[i].m_dIndiceEje, m_bEsMirror[i]);
            //    }
            //}
            //m_SistemaTecoi.FanucEscribirMarcaMulticabezales(bAlgunEsclavo);

            //GeneralNumEsclavos = 0;
            //for (i = 0; i < m_EjesY.Count; i++)
            //{
            //    m_SistemaTecoi.FanucActivarCabezal(i, m_MaestroEsclavo[i]);
            //    if (i > m_dIndiceMaestro  && m_MaestroEsclavo[i])
            //        GeneralEsclavos[GeneralNumEsclavos++] = i;
            //}

            //if (m_FanucGeneral.u.dTipoControl > 0)
            //{
            //    for (i = 0; i < m_EjesY.Count; i++)
            //        m_SistemaTecoi.EscribirParametroTipoEjeY (m_EjesY[i], m_dIndiceMaestro);
            //    for (i = 0; i < m_EjesZ.Count; i++)
            //        m_SistemaTecoi.EscribirParametroTipoEjeZ (m_EjesZ[i], m_dIndiceMaestro);
            //    if (m_FanucGeneral.u.bExisteBevel != 0)
            //        m_SistemaTecoi.EscribirParametroTipoEjeBisel (m_EjesA[m_dIndiceMaestro], 
            //                m_EjesB[m_dIndiceMaestro]);
            //}
        }
        public override void PosicionadoBloque(StreamWriter StreamFileISO, Bloque Bloq)
        {

            StreamFileISO.Write(String.Format("#100 = 100 (Quitar Esclavos)\nM53\n"));    // Esperando que se quite multicabezal.
            StreamFileISO.Write(String.Format("WHILE [#100 EQ 100] DO 1\nEND 1\n"));    // Esperando que se quite multicabezal.
            foreach (Entidad e in Bloq.m_Entidades)
            {
                if (!e.m_bDebeCortarse)
                    continue;
#region Movimiento eje X
                StreamFileISO.Write(String.Format("G00 {0}={1} ",
                    m_EjesX[0].m_NombreEje, e.m_Inicio.m_lfx+m_Herramientas[m_dIndiceMaestro].m_lfOffset[0]));
#endregion
#region Apartar ejes antes del Maestro
                short i;
                for (i = 0; i < m_EjesY.Count; i++)
                {
                    if (m_MaestroEsclavo[i])
                        break;
                    StreamFileISO.Write(String.Format("{0}=0 ", m_EjesY[i].m_NombreEje));
                }
#endregion
#region Colocar el Maestro
                StreamFileISO.Write(String.Format("{0}={1} ", m_EjesY[i].m_NombreEje, 
                    e.m_Inicio.m_lfy+m_Herramientas[m_dIndiceMaestro].m_lfOffset[1]));
#endregion
#region Colocar Ejes esclavos
                ++i;
                for (; i < m_EjesY.Count; i++)
                {
                    if (!m_MaestroEsclavo[i])
                        break;
                    StreamFileISO.Write(String.Format("{0}={1} ", m_EjesY[i].m_NombreEje, m_lfSeparacionCabezales[i]));
                }
#endregion
#region Apartar ejes del final
                for (; i < m_EjesY.Count; i++)
                {
                    if (!m_MaestroEsclavo[i])
                        break;
                    StreamFileISO.Write(String.Format("{0}={1} ", m_EjesY[i].m_NombreEje, m_EjesY[i].m_lfLimiteSuperior));
                }
#endregion
                break;
            }
            StreamFileISO.Write(String.Format("#100 = 101 (Volver a poner maestro/esclavos)\nM53\n"));    // Esperando que se vuelva a poner multicabezal.
            StreamFileISO.Write(String.Format("WHILE [#100 EQ 101] DO 1\nEND 1\n"));    // Esperando que se quite multicabezal.
        }
        public override bool EscribirSubrutina_AlturaVacio(StreamWriter StreamFileCNC, int N)
        {
            int i;
            int dNoTecnologiaCebado = N;
            StreamFileCNC.Write("IF [#1 NE {0}] GOTO {1} (Máquina {0})\n", m_dMachinaIndex, N);
            if (m_FanucGlobalVariables.m_dTipoAutomata == 1 ||  // Autómata 0i antiguo
                m_FanucGlobalVariables.m_dTipoAutomata == 2)    // Autómata 30i antiguo
            {
                StreamFileCNC.Write("M53\n#500=0.008\nM53\n");
                foreach (Herramienta H in m_Herramientas)
                    H.EscribirPrepararAlturaVacio(StreamFileCNC);
                for (i = 0; i < m_EjesZ.Count; i++)   // Solamente WikiWiki al eje maestro
                {
                    if (i > 0)
                        StreamFileCNC.Write("N{0} ", N+i);
                    StreamFileCNC.Write("IF [[#501 AND {0}] NE {0}] GOTO {1} (Cabezal {2})\n", 1 << i, N+i+1, i+1);
                    m_Herramientas[i].EscribirPrepararAlturaVacio(StreamFileCNC);
                    if (m_EjesA.Count >= i)  // Existe Bisel ene eje i-esimo
                    {
                        StreamFileCNC.Write("G91{0}0.001G90\n", m_EjesZ[i].m_NombreEjeISO);
                        StreamFileCNC.Write("G40G49\n");
                        StreamFileCNC.Write("G43.4H01P1\n");
                        StreamFileCNC.Write("F{0} {1}0.0 {2}0.0 \n", m_EjesA[i].m_NombreEjeISO, m_EjesB[i].m_NombreEjeISO, 
                            m_EjesA[0].m_lfVelocidadManual * 60.0);
                        StreamFileCNC.Write("G49\n");
                        StreamFileCNC.Write("GOTO {0}\n", N+m_EjesZ.Count); // Solamente se hace del maestro
                    }
                }
                StreamFileCNC.Write("N{0} IF [#519 EQ 1] GOTO {1}\n", N+i, N+i+1);   // Flag de altura home: Se hace Home
                StreamFileCNC.Write("M11\nM53\n");
                foreach (EjeMaquina E in m_EjesY)
                    StreamFileCNC.Write("G92.1{0}0.0(Reset Eje Y{0})\n", E.m_NombreEjeISO);
                StreamFileCNC.Write("G00 ");
                foreach (EjeMaquina E in m_EjesZ)
                    StreamFileCNC.Write("{0}0.0)\n", E.m_NombreEjeISO);
                StreamFileCNC.Write("M10\nM53\n");
                StreamFileCNC.Write("GOTO {0}\n", N+50);

                StreamFileCNC.Write("N{0} G91\n", N+i+1);  // Flag altura home: Se hace altura vacío
                for (i = 0; i < m_EjesZ.Count; i++)        // Subir todos los ejes activos a altura vacío
                {
                    if (i > 0)
                        StreamFileCNC.Write("N{0} ", N+10+i);
                    StreamFileCNC.Write("IF [[#501 AND {0}] NE {0}] GOTO {1} (Cabezal {2})\n", 1 << i, N+10+i+1, i+1);
                    StreamFileCNC.Write("M10\nM53\n");
                    StreamFileCNC.Write("G01 F{0}{1}#520\n", m_EjesZ[i].m_lfVelocidadVacio*60, m_EjesZ[i].m_NombreEjeISO);
                    StreamFileCNC.Write("GOTO {0}\n", N+50);
                }

                StreamFileCNC.Write("N{0} G90\n", N+50);  // Preparar para salida de subrutina.
                StreamFileCNC.Write("M53\n#500=0.009\nM53\n");

                //StreamFileCNC.Write("IF [#%d EQ 0] GOTO 4\n", FanucVariablesMacros->dEnableLimpieza);
                //StreamFileCNC.Write("IF [#%d LT #%d] GOTO 4\n", FanucVariablesMacros->dLimpiezaContador,
                //    FanucVariablesMacros->dLimpiezaCuentaInicial);
                //StreamFileCNC.Write("G65 P%d A0\n", FanucSubrutinas->dLimpiezaCabezales);
                //if (FanucGeneral->dTipoMaquina == 3 && FanucGeneral->dNumeroEjesZ > 0)
                //    fprintf(fp, "G65 P%d A1\n", FanucSubrutinas->dLimpiezaCabezales);
                //StreamFileCNC.Write("#%d = 0\n", FanucVariablesMacros->dLimpiezaContador);
                //StreamFileCNC.Write("N4 M53\n");

                StreamFileCNC.Write("GOTO 1000000\n");  // Fin subrutina máquina actual
            }
            StreamFileCNC.Write("N{0}\n", N);
            return (true);
        }
    }
}
