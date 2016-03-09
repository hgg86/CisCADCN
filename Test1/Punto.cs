using System;
using System.Collections.Generic;
using System.Text;

namespace Test1
{
    class Punto
    {
        public double m_lfx;
        public double m_lfy;
        public int m_dColor;

        public Punto (Punto P)
        {
            m_lfx = P.m_lfx;
            m_lfy = P.m_lfy;
            m_dColor = P.m_dColor;
        }
        public Punto(double x, double y, int c)
        {
            m_lfx = x;
            m_lfy = y;
            m_dColor = c;
        }
        public Punto(double x, double y)
        {
            m_lfx = x;
            m_lfy = y;
            m_dColor = 0;
        }
        public static bool operator ==(Punto P, Punto Q)
        {
            return (Math.Abs(P.m_lfx-Q.m_lfx) < 0.01 && Math.Abs(P.m_lfy-Q.m_lfy) < 0.01);
        }
        public static bool operator !=(Punto P, Punto Q)
        {
            return (Math.Abs(P.m_lfx - Q.m_lfx) > 0.01 || Math.Abs(P.m_lfy - Q.m_lfy) > 0.01);
//          return P.m_lfx != Q.m_lfx || P.m_lfy != Q.m_lfy;
        }
        public static Punto operator ++(Punto p)
        {
            Punto q = new Punto(p.m_lfx, p.m_lfy);
            q.m_lfx = p.m_lfx + 1;
            q.m_lfy = p.m_lfy + 1;
            return (q);
        }
        public double Distancia(Punto P)
        {
            return Math.Sqrt((m_lfx - P.m_lfx) * (m_lfx - P.m_lfx) +
                    (m_lfy - P.m_lfy) * (m_lfy - P.m_lfy));
        }
        public double Modulo()
        {
            return Math.Sqrt(m_lfx * m_lfy + m_lfy * m_lfy);
        }
    }
}
