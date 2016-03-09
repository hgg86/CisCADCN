using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Test1
{
    class Arco:Entidad
    {
        public const double ERROR_FIGURA = 0.1;

        public Arco(Punto C, double Radio, double A0, double A1)
        {
            m_Centro = new Punto(C);
            m_lfRadio = Radio;
            m_lfAng0 = A0;
            m_lfAng1 = A1;
            while (A0 < 0 || A1 < 0)
            {
                A0 += 2*Math.PI;
                A1 += 2*Math.PI;
            }
            m_lfAngulo = A1-A0;
            m_lfLongitud = m_lfAngulo*m_lfRadio/(2*Math.PI);
            m_Inicio = new Punto(C.m_lfx+Math.Cos(m_lfAng0), C.m_lfy+Math.Sin(m_lfAng0));
            m_Final = new Punto(C.m_lfx+Math.Cos(m_lfAng1), C.m_lfy+Math.Sin(m_lfAng1));
            m_dTipoEntidad = 5;
            CalcularLimites();
        }
        public Arco(Punto C, Punto P, double Angulo)
        {
            m_Centro = new Punto(C);
            m_lfRadio = C.Distancia(P);
            m_lfAng0 = 180 / Math.PI * Math.Atan2(P.m_lfy - C.m_lfy, P.m_lfx - C.m_lfx);
            m_lfAng1 = m_lfAng0 + Angulo;
            m_lfAngulo = Angulo;

            m_lfLongitud = m_lfAngulo * m_lfRadio / (2 * Math.PI);
            m_Inicio = new Punto(P.m_lfx, P.m_lfy);
            m_Final = new Punto(C.m_lfx + m_lfRadio * Math.Cos(Math.PI / 180 * m_lfAng1),
                C.m_lfy + m_lfRadio * Math.Sin(Math.PI / 180 * m_lfAng1));
            m_dTipoEntidad = 5;
            CalcularLimites();
        }
        public void CalcularLimites()
        {
            double[] Angulos = {0.0, 0.5*Math.PI, Math.PI, 1.5*Math.PI};
            CotasEntidad[0] = Math.Min(m_Inicio.m_lfx, m_Final.m_lfx);
            CotasEntidad[1] = Math.Min(m_Inicio.m_lfy, m_Final.m_lfy);
            CotasEntidad[2] = Math.Max(m_Inicio.m_lfx, m_Final.m_lfx);
            CotasEntidad[3] = Math.Max(m_Inicio.m_lfy, m_Final.m_lfy);
            double a0 = m_lfAng0*Math.PI/180;
            double a1 = m_lfAng1*Math.PI/180;
            if (m_lfAng0 < m_lfAng1)    // Sentido antihorario
            {
                for (int i = 0; i < 4; i++)
                {
                    if (Angulos[i] > a0 && Angulos[i] < a1)
                    {
                        double x = m_Centro.m_lfx+m_lfRadio*Math.Cos(Angulos[i]);
                        double y = m_Centro.m_lfy+m_lfRadio*Math.Sin(Angulos[i]);
                        CotasEntidad[0] = Math.Min(CotasEntidad[0], x);
                        CotasEntidad[1] = Math.Min(CotasEntidad[1], y);
                        CotasEntidad[2] = Math.Max(CotasEntidad[2], x);
                        CotasEntidad[3] = Math.Max(CotasEntidad[3], y);
                    }
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (Angulos[i] > m_lfAng1 && Angulos[i] < m_lfAng0)
                    {
                        double x = m_Centro.m_lfx+m_lfRadio*Math.Cos(Angulos[i]);
                        double y = m_Centro.m_lfy+m_lfRadio*Math.Sin(Angulos[i]);
                        CotasEntidad[0] = Math.Min(CotasEntidad[0], x);
                        CotasEntidad[1] = Math.Min(CotasEntidad[1], y);
                        CotasEntidad[2] = Math.Max(CotasEntidad[2], x);
                        CotasEntidad[3] = Math.Max(CotasEntidad[3], y);
                    }
                }
            }
        }
        public bool PuntoEnArco(Punto P)
        {
            if (Math.Abs(m_Centro.Distancia(P) - m_lfRadio) > 0.1 * m_lfRadio)
                return (false);
            if (Math.Abs(m_Inicio.Distancia(P)) < ERROR_FIGURA ||
                Math.Abs(m_Final.Distancia(P)) < ERROR_FIGURA)
                return (true);

            double A1 = m_lfRadio * (Math.Cos(m_lfAng1) - Math.Cos(m_lfAng0));
            double A2 = m_lfRadio * (Math.Sin(m_lfAng1) - Math.Sin(m_lfAng0));
            double B1 = P.m_lfx - (m_Centro.m_lfx + m_lfRadio * Math.Cos(m_lfAng0));
            double B2 = P.m_lfy - (m_Centro.m_lfy + m_lfRadio * Math.Sin(m_lfAng0));

            if (A1 * B2 - A2 * B1 <= 0)	// Está dentro del arco
                return (true);
            return (false);
        }
        public int CorteSegmento(Segmento S, Punto P0, Punto P1)
        {
            return (S.CorteArco(this, P0, P1));
        }
        public int CorteArco(Arco Arc, Punto P0, Punto P1)
        {
            Punto Centro1 = new Punto(m_Centro);
            Punto Centro2 = new Punto(Arc.m_Centro);
            Circunferencia C1 = new Circunferencia(Centro1, m_lfRadio);
            Circunferencia C2 = new Circunferencia(Centro2, Arc.m_lfRadio);
            C1.CorteCircunferencia(C2, P0, P1);
            int n = 0;
            if (!PuntoEnArco(P0))
                P1 = P0;
            else
                ++n;
            if (!PuntoEnArco(P1))
                return (n);
            return (++n);
        }
        public int CorteCircunferencia(Circunferencia Circ, Punto P0, Punto P1)
        {
            Punto Centro = new Punto(m_Centro);
            Circunferencia C = new Circunferencia(Centro, m_lfRadio);
            Circ.CorteCircunferencia(C, P0, P1);
            int n = 0;
            if (!PuntoEnArco(P0))
                P1 = P0;
            else
                ++n;
            if (!PuntoEnArco(P1))
                return (n);
            return (++n);
        }
        public override Punto PuntoInicial()
        {
            return (m_Inicio);
        }
        public override Punto PuntoFinal()
        {
            return (m_Final);
        }
        public override Punto PuntoCentro()
        {
            return (m_Centro);
        }
        public override double LeerRadio()
        {
            return (m_lfRadio);
        }
        public override double LeerAnguloInicial()
        {
            return (m_lfAng0);
        }
        public override double LeerAnguloArco()
        {
            return (m_lfAngulo);
        }
        public override bool CalcularAngulosBiselTransversal(double AnguloBisel, double Angulo, double IncAngulo,
            ref double A, ref double B, ref double x, ref double y, ref double z)
        {
            double Vx = -(Math.Sin(Angulo+IncAngulo)-Math.Sin(Angulo)); // Vector transversal.
            double Vy = Math.Cos(Angulo+IncAngulo)-Math.Cos(Angulo);
            double X0 = x;
            double Y0 = y;
            if (AnguloBisel < 0)
            {
                double Aux = Vx;
                Vx = Vy;
                Vy = -Aux;
            }
            double Modulo = Math.Sqrt(Vx*Vx+Vy*Vy);
            Vx /= Modulo;
            Vy /= Modulo;
            double Mxy = m_FanucGlobalVariables.m_lfFocalBiselCorteActual*Math.Sin(AnguloBisel);
            x = Mxy * Math.Cos(m_Axy);
            y = Mxy * Math.Sin(m_Axy);
            z = -m_FanucGlobalVariables.m_lfFocalBiselCorteActual*Math.Cos(AnguloBisel);
            if (m_FanucGlobalVariables.dGiroAnguloBisel == 0)
            {
                y = -y;
                x = -x;
                B = Math.Asin(x/m_FanucGlobalVariables.m_lfFocalBiselCorteActual);
                A = Math.Asin(y/(-m_FanucGlobalVariables.m_lfFocalBiselCorteActual*Math.Cos(B)));
            }
            else if (m_FanucGlobalVariables.dGiroAnguloBisel == 90)
            {
                y = -y;
                A = Math.Asin(-y/m_FanucGlobalVariables.m_lfFocalBiselCorteActual);
                B = Math.Asin(x/(-m_FanucGlobalVariables.m_lfFocalBiselCorteActual*Math.Cos(A)));
            }
            x += X0;
            y += Y0;
            if (Math.Abs(Math.Cos(AnguloBisel)-Math.Cos(A)*Math.Cos(B)) > 0.001)
                return (false);

            return (true);
        }
        public override bool CalcularAngulosBiselLongitudinal(double AnguloBisel, double Angulo, double IncAngulo,
            ref double A, ref double B, ref double x, ref double y, ref double z)
        {
            double Vy = Math.Sin(Angulo+IncAngulo)-Math.Sin(Angulo);  
            double Vx = Math.Cos(Angulo+IncAngulo)-Math.Cos(Angulo);
            double X0 = x;
            double Y0 = y;
            if (AnguloBisel < 0)
            {
                Vx = -Vx;
                Vy = -Vy;
            }
            double Modulo = Math.Sqrt(Vx*Vx+Vy*Vy);
            Vx /= Modulo;
            Vy /= Modulo;
            double Mxy = m_FanucGlobalVariables.m_lfFocalBiselCorteActual*Math.Sin(AnguloBisel);
            x = Mxy*Math.Cos(m_Axy);
            y = Mxy*Math.Sin(m_Axy);
            z = -m_FanucGlobalVariables.m_lfFocalBiselCorteActual*Math.Cos(AnguloBisel);
            if (m_FanucGlobalVariables.dGiroAnguloBisel == 0)
            {
                y = -y;
                x = -x;
                B = Math.Asin(x/m_FanucGlobalVariables.m_lfFocalBiselCorteActual);
                A = Math.Asin(y/(-m_FanucGlobalVariables.m_lfFocalBiselCorteActual*Math.Cos(B)));
            }
            else if (m_FanucGlobalVariables.dGiroAnguloBisel == 90)
            {
                y = -y;
                A = Math.Asin(-y/m_FanucGlobalVariables.m_lfFocalBiselCorteActual);
                B = Math.Asin(x/(-m_FanucGlobalVariables.m_lfFocalBiselCorteActual*Math.Cos(A)));
            }
            x += X0;
            y += Y0;
            if (Math.Abs(Math.Cos(AnguloBisel)-Math.Cos(A)*Math.Cos(B)) > 0.001)
                return (false);

            return (true);
        }
    }
}
