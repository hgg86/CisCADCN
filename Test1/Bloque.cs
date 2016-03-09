using System;
using System.Collections.Generic;
using System.Text;

namespace Test1
{
    class Bloque
    {
        #region Definición de variables
        public String m_MachinaCode;    // Máquina que va a hacer el corte
        public List<Entidad> m_Entidades = null;
        public bool m_bEsMovimientoCorte;
        public Punto m_PuntoInicio;
        public Punto m_PuntoFinal;
        public bool m_bPiezaCerrada;
        public double m_VelEntrada;
        public double m_VelCorte;
        public double m_AlturaVacio;
        private const int dNumBiseles = 11;
        private double[] VelBisel = new double[dNumBiseles];
        private double[] AngBisel = new double[dNumBiseles];
        public double[] CotasBloque = new double[4];

        public bool[] m_MaestroEsclavo = new bool[6];
        public bool[] m_bEsMirror = new bool[6];
        public short[] GeneralEsclavos = new short[6];
        public double[] m_lfSeparacionCabezales = new double[6];

        #endregion

        public Bloque()
        {
            m_Entidades = new List<Entidad>();
            m_bEsMovimientoCorte = false;
            CotasBloque[0] = CotasBloque[1] = CotasBloque[2] = CotasBloque[3] = 0.0;
        }
        public Bloque(List<Entidad> E)
        {
            m_Entidades = new List<Entidad>(E);
            foreach (Entidad e in E)
                e.m_Bloque = this;
            m_bEsMovimientoCorte = false;
            TerminarBloque();
        }
        public Bloque(List<Entidad> E, bool bCorte)
        {
            m_Entidades = new List<Entidad>(E);
            foreach (Entidad e in E)
                e.m_Bloque = this;
            m_bEsMovimientoCorte = bCorte;
            TerminarBloque();
        }
        public void TerminarBloque()
        {
            m_PuntoInicio = m_Entidades[0].PuntoInicial();
            m_PuntoFinal = m_Entidades[m_Entidades.Count-1].PuntoFinal();
            m_bPiezaCerrada = m_PuntoInicio == m_PuntoFinal ? true : false;
            foreach (Entidad e in m_Entidades)
            {
                CotasBloque[0] = Math.Min(CotasBloque[0], e.CotasEntidad[0]);
                CotasBloque[1] = Math.Min(CotasBloque[1], e.CotasEntidad[1]);
                CotasBloque[2] = Math.Max(CotasBloque[2], e.CotasEntidad[2]);
                CotasBloque[3] = Math.Max(CotasBloque[3], e.CotasEntidad[3]);
            }
        }
        public void Append(Entidad E)
        {
            E.m_Bloque = this;
            m_Entidades.Add(E);
        }
        public void Insert(int dIndex, Entidad E)
        {
            E.m_Bloque = this;
            m_Entidades.Insert(dIndex, E);
        }
        public void Delete(int dIndex)
        {
            m_Entidades.RemoveAt(dIndex);
        }
        public void Clear()
        {
            m_Entidades.Clear();
        }
        public double Longitud()
        {
            double l = 0;
            foreach (Entidad e in m_Entidades)
                l += e.Longitud ();
            return (l);
        }
        public double FanucVelocidadNominalBisel(double AnguloBisel)
        {
            int i;
            AnguloBisel = Math.Abs(AnguloBisel);
            for (i = 0; i < dNumBiseles; i++)
                if (AnguloBisel <= AngBisel[i])
                    break;
            if (AnguloBisel == AngBisel[i])
                return (VelBisel[i+1]);
            --i;
            if (i >= dNumBiseles - 1)
                return (VelBisel[dNumBiseles-1]);
            if (i == -1)
                ++i;
            double d = AngBisel[i+1]-AngBisel[i];
            double x = (AngBisel[i+1]-AnguloBisel)/d;
            return (VelBisel[i+2]*(1-x)+VelBisel[i+1]* x);
        }
    }
}
