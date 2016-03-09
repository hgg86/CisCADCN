using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Test1
{
    class Segmento:Entidad
    {
        #region Definición de variables

        public double m_lfa;
        public double m_lfb;

        #endregion

        public Segmento()
        {
            m_Inicio = new Punto(0.0, 0.0);
            m_Final = new Punto(1.0, 1.0);
            m_lfa = 0;
            m_lfLongitud = 0;
            m_lfb = 0;
            m_dTipoEntidad = 2;
            m_VectorRecta[0] = 1.0;
            m_VectorRecta[1] = 0.0;
            m_Axy = 0.0;
            CalcularLimites();
        }
        public Segmento(Punto p0, Punto p1)
        {
            m_Inicio = new Punto(p0);
            m_Final = new Punto(p1);
            if (m_Final.m_lfx == m_Inicio.m_lfx)
                m_lfa = 0;
            else
                m_lfa = Math.Atan2(m_Final.m_lfy - m_Inicio.m_lfy, m_Final.m_lfx - m_Inicio.m_lfx);
            m_lfLongitud = this.Modulo();
            m_lfb = m_Inicio.m_lfy - m_lfa * m_Inicio.m_lfx;
            m_dTipoEntidad = 2;
            m_VectorRecta[0] = (this.m_Inicio.m_lfx-this.m_Final.m_lfx)/m_lfLongitud;
            m_VectorRecta[1] = (this.m_Inicio.m_lfy-this.m_Final.m_lfy)/m_lfLongitud;
            m_Axy = Math.Atan2(m_VectorRecta[1], m_VectorRecta[0]);
            m_Axy = m_Axy < 0 ? m_Axy+2*Math.PI : m_Axy;
            CalcularLimites();
        }
        public void CalcularLimites()
        {
            CotasEntidad[0] = Math.Min(m_Inicio.m_lfx, m_Final.m_lfx);
            CotasEntidad[1] = Math.Min(m_Inicio.m_lfy, m_Final.m_lfy);
            CotasEntidad[2] = Math.Max(m_Inicio.m_lfx, m_Final.m_lfx);
            CotasEntidad[3] = Math.Max(m_Inicio.m_lfy, m_Final.m_lfy);
        }
        public Segmento(Punto p)
        {
            m_Inicio = new Punto(0.0, 0.0);
            m_Final = new Punto(p);
            if (m_Final.m_lfx == m_Inicio.m_lfx)
                m_lfa = 0;
            else
                m_lfa = Math.Atan2(m_Final.m_lfy - m_Inicio.m_lfy, m_Final.m_lfx - m_Inicio.m_lfx);
            m_lfLongitud = this.Modulo();
            m_lfb = m_Inicio.m_lfy - m_lfa * m_Inicio.m_lfx;
            m_dTipoEntidad = 2;
        }
        public double Modulo()
        {
            return Math.Sqrt((this.m_Inicio.m_lfx-this.m_Final.m_lfx)*(this.m_Inicio.m_lfx- this.m_Final.m_lfx) +
                    (this.m_Inicio.m_lfy-this.m_Final.m_lfy)*(this.m_Inicio.m_lfy-this.m_Final.m_lfy));
        }
        public double Distancia(Punto P)
        {
            return ((m_lfa*P.m_lfx+m_lfb)/(m_lfa*m_lfa+m_lfb*m_lfb));
        }
        public int CorteRectas (Segmento S, Punto P)
        {
            if (m_lfa == S.m_lfa)   // Son paralelas
                return (0);
            P.m_lfx = (S.m_lfb - m_lfb) / (m_lfa - S.m_lfa);
            P.m_lfy = m_lfa * P.m_lfx + m_lfa;
            return (1);
        }
        public int CorteArco(Arco Arco, Punto P0, Punto P1)
        {
            if (Distancia(Arco.m_Centro) > Arco.m_lfRadio)
                return (0);

            double a = 1 + m_lfa * m_lfa;
            double b = 2*(m_lfa*(m_lfb-Arco.m_Centro.m_lfy))-Arco.m_Centro.m_lfx;
            double c = Arco.m_Centro.m_lfx*Arco.m_Centro.m_lfx+
                (m_lfb*m_lfb-Arco.m_Centro.m_lfy*Arco.m_Centro.m_lfy)-Arco.m_lfRadio*Arco.m_lfRadio;
            if (a == 0)
            {
                if (b == 0)
                    return (0);
                P0.m_lfx = -c/b;
                P0.m_lfy = m_lfa*P0.m_lfx+m_lfb;
                return (1);
            }
            double Raiz = b*b-4*a*c;
            if (Raiz < 0)
                return (0);
            
            Raiz = Math.Sqrt (Raiz);
            P0.m_lfx = (-b+Raiz)/(2*a);
            P0.m_lfy = m_lfa*P0.m_lfx+m_lfb;
            P1.m_lfx = (-b-Raiz)/(2*a);
            P1.m_lfy = m_lfa*P1.m_lfx+m_lfb;
            int n = 0;
            if (!Arco.PuntoEnArco (P0))
                P1 = P0;
            else
                ++n;
            if (!Arco.PuntoEnArco (P1))
                return (n);

            return (++n);
        }
        public int CorteCircunferencia(Arco Arco, Punto P0, Punto P1)
        {
            if (Distancia(Arco.m_Centro) > Arco.m_lfRadio)
                return (0);
            
            double a = 1 + m_lfa * m_lfa;
            double b = 2 * (m_lfa * (m_lfb - Arco.m_Centro.m_lfy)) - Arco.m_Centro.m_lfx;
            double c = Arco.m_Centro.m_lfx * Arco.m_Centro.m_lfx +
                (m_lfb * m_lfb - Arco.m_Centro.m_lfy * Arco.m_Centro.m_lfy) - Arco.m_lfRadio * Arco.m_lfRadio;
            if (a == 0)
            {
                if (b == 0)
                    return (0);
                P0.m_lfx = -c / b;
                P0.m_lfy = m_lfa * P0.m_lfx + m_lfb;
                return (1);
            }
            double Raiz = b * b - 4 * a * c;
            if (Raiz < 0)
                return (0);

            Raiz = Math.Sqrt(Raiz);
            P0.m_lfx = (-b + Raiz) / (2 * a);
            P0.m_lfy = m_lfa * P0.m_lfx + m_lfb;
            P1.m_lfx = (-b - Raiz) / (2 * a);
            P1.m_lfy = m_lfa * P1.m_lfx + m_lfb;
            return (2);
        }
        public override Punto PuntoInicial()
        {
            return (m_Inicio);
        }
        public override Punto PuntoFinal()
        {
            return (m_Final);
        }
        public override bool CalcularAngulosBiselTransversal(double AnguloBisel, ref double A, ref double B,
            ref double x, ref double y, ref double z)
        {
            double Vx = -m_VectorRecta[1];
            double Vy = m_VectorRecta[0];
            double X0 = x;
            double Y0 = y;
            if (AnguloBisel < 0)
            {
                Vx = m_VectorRecta[1];
                Vy = -m_VectorRecta[0];
            }
            double Mxy = m_FanucGlobalVariables.m_lfFocalBiselCorteActual*Math.Sin(AnguloBisel);
            x = Mxy*Math.Cos(m_Axy);
            y = Mxy*Math.Sin(m_Axy);
            z = -m_FanucGlobalVariables.m_lfFocalBiselCorteActual*Math.Cos(AnguloBisel);
            if (m_FanucGlobalVariables.dGiroAnguloBisel == 0)
            {
                y = -y;
                x = -x;
                B = Math.Asin(x /m_FanucGlobalVariables.m_lfFocalBiselCorteActual);
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
        public override bool CalcularAngulosBiselLongitudinal(double AnguloBisel, ref double A, ref double B,
                    ref double x, ref double y, ref double z)
        {
            double Vx = m_VectorRecta[0];
            double Vy = m_VectorRecta[1];
            double X0 = x;
            double Y0 = y;
            if (AnguloBisel < 0)
            {
                Vx = -m_VectorRecta[0];
                Vy = -m_VectorRecta[1];
            }
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
            if (Math.Abs(Math.Cos(AnguloBisel) - Math.Cos(A) * Math.Cos(B)) > 0.001)
                return (false);

            return (true);
        }
    }
}
