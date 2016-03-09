using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Test1
{
    class Circunferencia:Entidad
    {
        private bool m_bSentido;

        public Circunferencia(Punto C, double Radio)
        {
            m_Centro = new Punto(C);
            m_lfRadio = Radio;
            m_bSentido = true;
            m_lfLongitud = 2 * Math.PI * m_lfRadio;
            m_Inicio = new Punto(0, 0);
            m_Final = new Punto(0, 0);
            m_dTipoEntidad = 4;
            CalcularLimites();
        }
        public Circunferencia(double Radio)
        {
            m_Centro = new Punto(0.0, 0.0);
            m_lfRadio = Radio;
            m_bSentido = true;
            m_lfLongitud = 2 * Math.PI * m_lfRadio;
            m_Inicio = new Punto(0, 0);
            m_Final = new Punto(0, 0);
            m_dTipoEntidad = 4;
            CalcularLimites();
        }
        public Circunferencia(Punto C, double Radio, bool bSentido)
        {
            m_Centro = new Punto(C);
            m_lfRadio = Radio;
            m_bSentido = bSentido;
            m_lfLongitud = 2 * Math.PI * m_lfRadio;
            m_Inicio = new Punto(0, 0);
            m_Final = new Punto(0, 0);
            m_dTipoEntidad = 4;
            CalcularLimites();
        }
        public override void PuntoEntradaCircunferencia(Punto P)
        {
            m_Inicio = new Punto(P);
            m_Final = new Punto(P);
        }
        public void CalcularLimites()
        {
            CotasEntidad[0] = m_Centro.m_lfx-m_lfRadio;
            CotasEntidad[1] = m_Centro.m_lfy-m_lfRadio;
            CotasEntidad[2] = m_Centro.m_lfx+m_lfRadio; 
            CotasEntidad[3] = m_Centro.m_lfy-m_lfRadio;
        }
        public int CorteCircunferencia(Circunferencia Circ, Punto P0, Punto P1)
        {
            if (m_Centro.Distancia(Circ.m_Centro) > m_lfRadio + Circ.m_lfRadio)
                return (0);
            double A = 2 * (Circ.m_Centro.m_lfx - m_Centro.m_lfx);
            double B = (Circ.m_Centro.m_lfy - m_Centro.m_lfy) * (Circ.m_Centro.m_lfy - m_Centro.m_lfy) -
                +Circ.m_lfRadio * Circ.m_lfRadio -
                m_lfRadio - m_lfRadio;
            double a = 4 * (Circ.m_Centro.m_lfx - m_Centro.m_lfx) + A;
            double b = 1 * A * B;
            double c = B * B - 4 * (Circ.m_Centro.m_lfx - m_Centro.m_lfx) * Circ.m_lfRadio * Circ.m_lfRadio;
            if (a == 0)
            {
                if (b == 0)
                    return (0);
                P0.m_lfy = c / b + Circ.m_Centro.m_lfy;
                P0.m_lfx = Math.Sqrt(Circ.m_lfRadio * Circ.m_lfRadio - P0.m_lfy * P0.m_lfy) +
                    Circ.m_Centro.m_lfx;
                P1.m_lfy = P0.m_lfy;
                P0.m_lfx = -Math.Sqrt(Circ.m_lfRadio * Circ.m_lfRadio - P0.m_lfy * P0.m_lfy) +
                    Circ.m_Centro.m_lfx;
                return (2);
            }
            double Raiz = b * b - 4 * a * c;
            if (Raiz < 0)
                return (0);
            Raiz = Math.Sqrt(Raiz);
            double Y = (-b + Raiz) / (2 * a);
            P0.m_lfy = Y + Circ.m_Centro.m_lfy;
            P0.m_lfx = Math.Sqrt(Circ.m_lfRadio * Circ.m_lfRadio - Y * Y) +
                Circ.m_Centro.m_lfx;
            Y = (-b - Raiz) / (2 * a);
            P1.m_lfy = Y + Circ.m_Centro.m_lfy;
            P0.m_lfx = -Math.Sqrt(Circ.m_lfRadio * Circ.m_lfRadio - Y * Y) +
                Circ.m_Centro.m_lfx;
            if (P0 == P1)
                return (1);
            return (2);
        }
        public override Punto PuntoInicial()
        {
            return (m_Inicio);
        }
        public override Punto PuntoFinal()
        {
            return (m_Inicio);
        }
        public override Punto PuntoCentro()
        {
            return (m_Centro);
        }
        public override double LeerRadio()
        {
            return (m_lfRadio);
        }
        public override bool CalcularAngulosBiselTransversal(double AnguloBisel, double Angulo, double IncAngulo,
            ref double A, ref double B, ref double x, ref double y, ref double z)
        {
            double Vx = -(Math.Sin(Angulo + IncAngulo) - Math.Sin(Angulo)); // Vector transversal.
            double Vy = Math.Cos(Angulo + IncAngulo) - Math.Cos(Angulo);
            double X0 = x;
            double Y0 = y;
            if (AnguloBisel < 0)
            {
                double Aux = Vx;
                Vx = Vy;
                Vy = -Aux;
            }
            double Modulo = Math.Sqrt(Vx * Vx + Vy * Vy);
            Vx /= Modulo;
            Vy /= Modulo;
            double Mxy = m_FanucGlobalVariables.m_lfFocalBiselCorteActual * Math.Sin(AnguloBisel);
            x = Mxy * Math.Cos(m_Axy);
            y = Mxy * Math.Sin(m_Axy);
            z = -m_FanucGlobalVariables.m_lfFocalBiselCorteActual * Math.Cos(AnguloBisel);
            if (m_FanucGlobalVariables.dGiroAnguloBisel == 0)
            {
                y = -y;
                x = -x;
                B = Math.Asin(x / m_FanucGlobalVariables.m_lfFocalBiselCorteActual);
                A = Math.Asin(y / (-m_FanucGlobalVariables.m_lfFocalBiselCorteActual * Math.Cos(B)));
            }
            else if (m_FanucGlobalVariables.dGiroAnguloBisel == 90)
            {
                y = -y;
                A = Math.Asin(-y / m_FanucGlobalVariables.m_lfFocalBiselCorteActual);
                B = Math.Asin(x / (-m_FanucGlobalVariables.m_lfFocalBiselCorteActual * Math.Cos(A)));
            }
            x += X0;
            y += Y0;
            if (Math.Abs(Math.Cos(AnguloBisel) - Math.Cos(A) * Math.Cos(B)) > 0.001)
                return (false);

            return (true);
        }
        public override bool CalcularAngulosBiselLongitudinal(double AnguloBisel, double Angulo, double IncAngulo,
            ref double A, ref double B, ref double x, ref double y, ref double z)
        {
            double Vy = Math.Sin(Angulo + IncAngulo) - Math.Sin(Angulo);
            double Vx = Math.Cos(Angulo + IncAngulo) - Math.Cos(Angulo);
            double X0 = x;
            double Y0 = y;
            if (AnguloBisel < 0)
            {
                Vx = -Vx;
                Vy = -Vy;
            }
            double Modulo = Math.Sqrt(Vx * Vx + Vy * Vy);
            Vx /= Modulo;
            Vy /= Modulo;
            double Mxy = m_FanucGlobalVariables.m_lfFocalBiselCorteActual * Math.Sin(AnguloBisel);
            x = Mxy * Math.Cos(m_Axy);
            y = Mxy * Math.Sin(m_Axy);
            z = -m_FanucGlobalVariables.m_lfFocalBiselCorteActual * Math.Cos(AnguloBisel);
            if (m_FanucGlobalVariables.dGiroAnguloBisel == 0)
            {
                y = -y;
                x = -x;
                B = Math.Asin(x / m_FanucGlobalVariables.m_lfFocalBiselCorteActual);
                A = Math.Asin(y / (-m_FanucGlobalVariables.m_lfFocalBiselCorteActual * Math.Cos(B)));
            }
            else if (m_FanucGlobalVariables.dGiroAnguloBisel == 90)
            {
                y = -y;
                A = Math.Asin(-y / m_FanucGlobalVariables.m_lfFocalBiselCorteActual);
                B = Math.Asin(x / (-m_FanucGlobalVariables.m_lfFocalBiselCorteActual * Math.Cos(A)));
            }
            x += X0;
            y += Y0;
            if (Math.Abs(Math.Cos(AnguloBisel) - Math.Cos(A) * Math.Cos(B)) > 0.001)
                return (false);

            return (true);
        }
    }
}
