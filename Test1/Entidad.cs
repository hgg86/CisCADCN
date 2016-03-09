using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Test1
{
    class Entidad
    {
#region Definición de variables
        public Punto m_Inicio;
        public Punto m_Final;
        public int m_hLitlecad;
        public int m_dTipoEntidad;
        public double AngBiselIni = 0.0;
        public double AngBiselFin = 0.0;
        public ushort dTipoBisel = 0; // 0: Transversal, 1: longitudinal: 2: Mantener bisel 3: Definido por A y B (mantener bisel)
        public double m_AForzado = 0.0;
        public double m_BForzado = 0.0;

        public Punto m_Centro;
        public double m_lfRadio;
        public double m_lfAng0;
        public double m_lfAng1;
        public double m_lfAngulo;
        public double[] CotasEntidad = new double[4];

        public double m_lfLongitud;
        public double[] m_VectorRecta = new double[2];  // Vector inicial de la entidad
        public double m_Axy;                            // Ángulo inicial del vector.

        public int dIndiceMecanizado = 0;

        public bool m_bDebeCortarse = true;

        public FanucVariablesGlobales m_FanucGlobalVariables = null;
        //public StructFanucGeneral m_FanucGeneral = null;
        public Bloque m_Bloque = null;      // Bloque al que pertenece.
#endregion

        public virtual Punto PuntoInicial()
        {
            return (new Punto(0, 0));
        }
        public virtual Punto PuntoFinal()
        {
            return (new Punto(0, 0));
        }
        public virtual Punto PuntoCentro()
        {
            return (new Punto(0, 0));
        }
        public virtual double Longitud()
        {
            return (0);
        }
        public virtual void PuntoEntradaCircunferencia(Punto P)
        {
        }
        public virtual double LeerRadio()
        {
            return (0);
        }
        public virtual double LeerAnguloInicial()
        {
            return (0);
        }
        public virtual double LeerAnguloArco()
        {
            return (0);
        }
        public int TipoEntidad()
        {
            return (m_dTipoEntidad);
        }
        public virtual bool CalcularAngulosBiselTransversal(double AnguloBisel, ref double A, ref double B,
            ref double x, ref double y, ref double z)
        {
            A = B = 0.0;
            return (true);
        }
        public virtual bool CalcularAngulosBiselLongitudinal(double AnguloBisel, ref double A, ref double B,
            ref double x, ref double y, ref double z)
        {
            A = B = 0.0;
            return (true);
        }
        public virtual bool CalcularAngulosBiselTransversal(double AnguloBisel, double Angulo, double IncAngulo,
            ref double A, ref double B, ref double x, ref double y, ref double z)
        {
            A = B = 0.0;
            return (true);
        }
        public virtual bool CalcularAngulosBiselLongitudinal(double AnguloBisel, double Angulo, double IncAngulo,
            ref double A, ref double B,ref double x, ref double y, ref double z)
        {
            A = B = 0.0;
            return (true);
        }
    }
}
