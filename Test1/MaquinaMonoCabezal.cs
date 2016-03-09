using System;
using System.IO;

namespace Test1
{
    class MaquinaMonoCabezal : MaquinaLineal
    {
        public MaquinaMonoCabezal(int dMachinaIndex, String MachinaCode)
        {
            m_dMachinaIndex = dMachinaIndex;
            m_MachinaCode = MachinaCode;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StreamFileISO"></param>
        /// <param name="Bloq"></param>
        public override void Bloque2ISO(StreamWriter StreamFileISO, Bloque Bloq)
        {
            String Cadena;
            double x, y, z = 0.0;
            double A = 0.0;
            double B = 0.0;
            foreach (Entidad e in Bloq.m_Entidades)
            {
                if (!e.m_bDebeCortarse)
                    continue;
#region Entidades sin bisel
                if ((e.AngBiselIni == 0.0 && e.AngBiselFin == 0.0) ||   // Entidad sin bisel.
                    (m_EjesA.Count == 0 || m_EjesB.Count == 0))         // Máquina sin bisel
                {
                    if (m_FanucGlobalVariables.m_AnguloBiselActual != 0)    // Venía bisel, hay que quitarlo.
                    {
                        x = e.m_Inicio.m_lfx+m_Herramientas[0].m_lfOffset[0];
                        y = e.m_Inicio.m_lfy+m_Herramientas[0].m_lfOffset[1];
                        A = B = 0.0;
                        WikiWiki(StreamFileISO, 0, 0, A, B);
                    }
                    if (e.m_dTipoEntidad == 0)      // Punto: Perforación, mecanizado perforando
                        m_Herramientas[0].RealizarAccion();
                    if (e.m_dTipoEntidad == 2)      // Recta
                    {
                        x = e.m_Final.m_lfx+m_Herramientas[0].m_lfOffset[0];
                        y = e.m_Final.m_lfy+m_Herramientas[0].m_lfOffset[1];
                        StreamFileISO.Write(String.Format("G01 F{0} {1}{2} {3}{4}\n",
                            Bloq.m_VelCorte*60, m_EjesX[0].m_NombreEjeISO, x.ToString("0.000"), 
                            m_EjesY[0].m_NombreEjeISO, y.ToString("0.000")));
                    }
                    else if (e.m_dTipoEntidad == 4)  // Circunferencia
                    {
                        if (e.m_lfAngulo > 0)
                            Cadena = "G02 ";
                        else
                            Cadena = "G03 ";
                        double i = e.m_Centro.m_lfx - e.m_Inicio.m_lfx;
                        double j = e.m_Centro.m_lfy - e.m_Inicio.m_lfy;
                        Cadena += String.Format("F{0} I{1} J{2}\n",
                            Bloq.m_VelCorte*60,
                            //m_EjesX[0].m_dIndiceEje,
                            //m_EjesY[0].m_dIndiceEje,
                            i.ToString("0.000"), j.ToString("0.000"));
                            //e.m_Centro.m_lfx-e.m_Inicio.m_lfx,
                            //e.m_Centro.m_lfy-e.m_Inicio.m_lfy);
                        StreamFileISO.Write(Cadena);
                    }
                    else if (e.m_dTipoEntidad == 5)  // Arco
                    {
                        if (e.m_lfAngulo > 0)
                            Cadena = "G03 ";
                        else
                            Cadena = "G02 ";
                        x = e.m_Final.m_lfx + m_Herramientas[0].m_lfOffset[0];
                        y = e.m_Final.m_lfy + m_Herramientas[0].m_lfOffset[1];
                        double i = e.m_Centro.m_lfx - e.m_Inicio.m_lfx;
                        double j = e.m_Centro.m_lfy - e.m_Inicio.m_lfy;
                        Cadena += String.Format("F{0} {1}{2} {3}{4} I{5} J{6}\n",
                            Bloq.m_VelCorte * 60,
                            m_EjesX[0].m_NombreEjeISO, x.ToString ("0.000"), 
                            m_EjesY[0].m_NombreEjeISO, y.ToString ("0.000"),
                            i.ToString("0.000"), j.ToString("0.000"));
                            //e.m_Centro.m_lfx-e.m_Inicio.m_lfx,
                            //e.m_Centro.m_lfy-e.m_Inicio.m_lfy);
                        StreamFileISO.Write(Cadena);
                    }
                }

#endregion
#region Entidad con bisel
#region Gestion de A y B
                else if (e.AngBiselIni != 0.0 || e.AngBiselFin != 0.0 ||    // Existe bisel
                    e.dTipoBisel == 2 || e.dTipoBisel == 3)                 // No debe calcularse bisel y es cte.
                {
                    x = e.m_Inicio.m_lfx+m_Herramientas[0].m_lfOffset[0];
                    y = e.m_Inicio.m_lfy+m_Herramientas[0].m_lfOffset[1];
                    z = 0.0;
                    A = B = 0.0;
                    switch (e.dTipoBisel)
                    {
                        case 0: // Bisel transversal.
                            e.CalcularAngulosBiselTransversal(e.AngBiselIni, ref A, ref B, ref x, ref y, ref z);
                            break;
                        case 1: // longitudinal: 
                            e.CalcularAngulosBiselLongitudinal(e.AngBiselIni, ref A, ref B, ref x, ref y, ref z);
                            break;
                        case 2: // Mantener bisel 
                            A = m_EjesA[0].m_lfPosicion;
                            B = m_EjesB[0].m_lfPosicion;
                            break;
                        case 3: // Definido por A y B (mantener bisel)
                            A = e.m_AForzado;
                            B = e.m_BForzado;
                            break;
                    }
                    if (Math.Abs(A-m_EjesA[0].m_lfPosicion) > e.m_FanucGlobalVariables.DIF_BISEL ||
                        Math.Abs(B-m_EjesB[0].m_lfPosicion) > e.m_FanucGlobalVariables.DIF_BISEL)
                        WikiWiki(StreamFileISO, 0, 0, A, B);
#endregion
#region Entidad con bisel constante
                    if (e.AngBiselIni == e.AngBiselFin)                     // Ángulo constante. Tiramos de TCP.
                    {
                        ActivarRTCP(StreamFileISO, true);
                        if (e.m_dTipoEntidad == 0 || e.m_dTipoEntidad == 2)      // Punto o Recta
                        {
                            x = e.m_Final.m_lfx+m_Herramientas[0].m_lfOffset[0];
                            y = e.m_Final.m_lfy+m_Herramientas[0].m_lfOffset[1];
                            StreamFileISO.Write(String.Format("G01 F{0} {1}={2} {3}={4} {5}={6} {7}={8}\n",
                                Bloq.m_VelCorte*60, m_EjesX[0].m_NombreEje, x.ToString("0.000"), 
                                m_EjesY[0].m_NombreEje, y.ToString("0.000"),
                                m_EjesA[0].m_NombreEje, A.ToString("0.000"), 
                                m_EjesB[0].m_NombreEje, B.ToString("0.000")));
                        }
                        else if (e.m_dTipoEntidad == 4)  // Circunferencia
                        {
                            if (e.m_lfAngulo > 0)
                                Cadena = "G02 ";
                            else
                                Cadena = "G03 ";
                            double I = e.m_Centro.m_lfx-e.m_Inicio.m_lfx;
                            double J = e.m_Centro.m_lfy-e.m_Inicio.m_lfy;
                            Cadena += String.Format("F{0} I{1} J{2} {3}=0 {4}=0\n",
                                Bloq.m_VelCorte * 60,
                                m_EjesX[0].m_NombreEje,
                                m_EjesY[0].m_NombreEje,
                                I.ToString ("0.000"),
                                J.ToString ("0.000"),
                                m_EjesA[0].m_NombreEje,
                                m_EjesB[0].m_NombreEje);
                            StreamFileISO.Write(Cadena);
                        }
                        else if (e.m_dTipoEntidad == 5)  // Arco
                        {
                            if (e.m_lfAngulo > 0)
                                Cadena = "G03 ";
                            else
                                Cadena = "G02 ";
                            e.CalcularAngulosBiselTransversal(e.AngBiselFin, ref A, ref B, ref x, ref y, ref z);
                            x = e.m_Final.m_lfx + m_Herramientas[0].m_lfOffset[0];
                            y = e.m_Final.m_lfy + m_Herramientas[0].m_lfOffset[1];
                            double I = e.m_Centro.m_lfx - e.m_Inicio.m_lfx;
                            double J = e.m_Centro.m_lfy - e.m_Inicio.m_lfy;
                            Cadena += String.Format("F{0} {1}={2} {3}={4} I{5} J{6} {7}={8} {9}={10}\n",
                                Bloq.m_VelCorte * 60,
                                m_EjesX[0].m_NombreEje, x.ToString("0.000"), 
                                m_EjesY[0].m_NombreEje, y.ToString("0.000"),
                                I.ToString("0.000"),
                                J.ToString("0.000"),
                                m_EjesA[0].m_NombreEje, A.ToString("0.000"),
                                m_EjesB[0].m_NombreEje, B.ToString("0.000"));
                            StreamFileISO.Write(Cadena);
                        }
                    }
#endregion
#region Entidad con bisel variable
                    else
                    {
                        ActivarRTCP(StreamFileISO, true);
                        if (e.m_dTipoEntidad == 0 || e.m_dTipoEntidad == 2)      // Punto o Recta
                        {
                            x = e.m_Final.m_lfx+m_Herramientas[0].m_lfOffset[0];
                            y = e.m_Final.m_lfy+m_Herramientas[0].m_lfOffset[1];
                            double z0 = -m_FanucGlobalVariables.m_lfFocalBiselCorteActual*
                                Math.Cos(m_EjesA[0].m_lfPosicion) * Math.Cos(m_EjesB[0].m_lfPosicion);
                            StreamFileISO.Write(String.Format("G01 F{0} {1}={2} {3}={4} {5}={6} {7}={8} G91{9}={10}G90\n",
                                Bloq.m_VelCorte*60, m_EjesX[0].m_NombreEje, x, m_EjesY[0].m_NombreEje, y,
                                m_EjesA[0].m_NombreEje, A, m_EjesB[0].m_NombreEje, B,
                                m_EjesZ[0].m_NombreEje, z0 - z));
                        }
                        else if (e.m_dTipoEntidad == 4 || e.m_dTipoEntidad == 5)  // Circunferencia o Arco
                        {
                            double z0 = -m_FanucGlobalVariables.m_lfFocalBiselCorteActual*
                                Math.Cos(m_EjesA[0].m_lfPosicion)*Math.Cos(m_EjesB[0].m_lfPosicion);
                            double PasoAngulo = m_FanucGlobalVariables.SEGMENTACION/e.m_lfRadio*Math.Sign(e.m_lfAngulo);
                            if (e.m_lfRadio < 10)
                                PasoAngulo /= 10.0;
                            else if (e.m_lfRadio > 10000)
                                PasoAngulo *= 10.0;
                            int n = (int)(e.m_lfAngulo/PasoAngulo);
                            double x0 = x;
                            double y0 = y;
                            double A0 = A;
                            double B0 = B;
                            double Axy = e.m_lfAng0;
                            double VelocidadBisel = 0.0;
                            double VelocidadOriginal = e.m_Bloque.FanucVelocidadNominalBisel(0.0);
                            double Ab;
                            for (int i = 0; i < n; i++)
                            {
                                Axy += PasoAngulo;
                                if (i == n-1)
                                    Axy = e.m_lfAng1; 
                                double X = Math.Cos(Axy);
                                double Y = Math.Sin(Axy);
                                x = X;
                                y = Y;
                                Ab = Math.PI/180.0*(e.AngBiselFin-e.AngBiselIni)*(Axy-e.m_lfAng0)/(e.m_lfAng0-e.m_lfAng0)+
                                    Math.PI/180.0*(e.AngBiselIni);
                                Ab = Math.Abs(Ab);
			        		    double Velocidad = e.m_Bloque.FanucVelocidadNominalBisel (180.0*Math.PI*Ab);
                                switch (e.dTipoBisel)
                                {
                                    case 0: // Bisel transversal.
                                        e.CalcularAngulosBiselTransversal(e.AngBiselIni, Axy, PasoAngulo, 
                                            ref A, ref B, ref x, ref y, ref z);
                                        break;
                                    case 1: // longitudinal: 
                                        e.CalcularAngulosBiselLongitudinal(e.AngBiselIni, Axy, PasoAngulo, 
                                            ref A, ref B, ref x, ref y, ref z);
                                        break;
                                }
                                double Lglobal = Math.Sqrt((x-x0)*(x-x0)+(y-y0)*(x-y0)+
                                    ((A-A0)*(A-A0)+(B-B0)*(B-B0))*32400.0/(Math.PI*Math.PI));
                                VelocidadBisel = Velocidad*Lglobal/m_FanucGlobalVariables.SEGMENTACION;
						        if (m_FanucGeneral.u.bExisteXPrima != 0)
                                    StreamFileISO.Write(String.Format("G01 {0}={1} {2}={3} {4}={5} {6}={7} F{8}\n",
                                        m_EjesX[0].m_NombreEje, X, m_EjesY[0].m_NombreEje, Y,
                                        m_EjesA[0].m_NombreEje, 180.0/Math.PI*A,
                                        m_EjesB[0].m_NombreEje, 180.0/Math.PI*B, VelocidadOriginal*60.0));
						        else
                                    StreamFileISO.Write(String.Format("G01 {0}={1} {2}={3} G91{4}={5}G90 {6}={7} {8}={9} F{10}\n",
                                        m_EjesX[0].m_NombreEje, X, m_EjesY[0].m_dIndiceEje + 1, Y,
                                        m_EjesZ[0].m_NombreEje, z0-z,
                                        m_EjesA[0].m_NombreEje, 180.0/Math.PI*A,
                                        m_EjesB[0].m_NombreEje, 180.0/Math.PI*B, VelocidadOriginal*60.0));
                                z0 = z;
                                x0 = x;
                                y0 = y;
                                A0 = A;
        					    B0 = B;
                            }
                        }

                    }
                }
#endregion
#endregion
            }
        }
        public override bool EscribirSubrutina_AlturaVacio(StreamWriter StreamFileCNC, int N)
        {
            int dNoTecnologiaCebado = N;
            StreamFileCNC.Write("IF [#1 NE {0}] GOTO {1} (Máquina {0})\n", m_dMachinaIndex, N);
            if (m_FanucGlobalVariables.m_dTipoAutomata == 1 ||  // Autómata 0i antiguo
                m_FanucGlobalVariables.m_dTipoAutomata == 2)    // Autómata 30i antiguo
            {
                StreamFileCNC.Write("M53\n#500=0.008\nM53\n");
                m_Herramientas[0].EscribirPrepararAlturaVacio(StreamFileCNC);
                if (m_EjesA.Count > 0)  // Existe Bisel ene eje i-esimo
                {
                    StreamFileCNC.Write("G91{0}0.001G90\n", m_EjesZ[0].m_NombreEjeISO);
                    StreamFileCNC.Write("G40G49\n");
                    StreamFileCNC.Write("G43.4H01P1\n");
                    StreamFileCNC.Write("F{0} {1}0.0 {2}0.0 \n", m_EjesA[0].m_NombreEjeISO, m_EjesB[0].m_NombreEjeISO,
                        m_EjesA[0].m_lfVelocidadManual*60.0);
                    StreamFileCNC.Write("G49\n");
                    StreamFileCNC.Write("GOTO {0}\n", N+m_EjesZ.Count); // Solamente se hace del maestro
                }
                StreamFileCNC.Write("IF [#519 EQ 1] GOTO {0}\n", N+1);   // Flag de altura home: Se hace Home
                StreamFileCNC.Write("M11\nM53\n");
                foreach (EjeMaquina E in m_EjesY)
                    StreamFileCNC.Write("G92.1{0}0.0(Reset Eje Y{0})\n", E.m_NombreEjeISO);
                StreamFileCNC.Write("G00 ");
                foreach (EjeMaquina E in m_EjesZ)
                    StreamFileCNC.Write("{0}0.0)\n", E.m_NombreEjeISO);
                StreamFileCNC.Write("M10\nM53\n");
                StreamFileCNC.Write("GOTO {0}\n", N+50);

                StreamFileCNC.Write("N{0} G91\n", N+2);  // Flag altura home: Se hace altura vacío
                StreamFileCNC.Write("M10\nM53\n");
                StreamFileCNC.Write("G01 F{0}{1}#520\n", m_EjesZ[0].m_lfVelocidadVacio * 60, m_EjesZ[0].m_NombreEjeISO);
                StreamFileCNC.Write("GOTO {0}\n", N+50);

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
