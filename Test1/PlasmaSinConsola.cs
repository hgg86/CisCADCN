using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Xml;


namespace Test1
{
    class PlasmaSinConsola:Herramienta
    {
        public int m_dTipoCebado;
        public int m_dTipoCorte;
        public double m_PrimeraAlturaCebado;
        public double m_SegundaAlturaCebado;
        public double m_CorreccionMarcadoCebado;
        public bool m_bDobleCebado;

        public double m_PrimeraAlturaCorte;
        public double m_SegundaAlturaCorte;
        public double m_TerceraAlturaCorte;
        public double m_CorreccionMarcadoCorte;

        public PlasmaSinConsola(int dToolNumero)
        {
            m_dIndiceHerramienta = dToolNumero;

            m_VelocidadBajada = 100.0;
            m_VelocidadSubida = 100.0;
            m_VelocidadRegulacion = 30.0;

            m_dTipoCebado = 2;
            m_dTipoCorte = 0;
            m_PrimeraAlturaCebado = 1.0;
            m_SegundaAlturaCebado = 2;
            m_CorreccionMarcadoCebado = 0.0;
            m_bDobleCebado = false;

            m_PrimeraAlturaCorte = 4.0;
            m_SegundaAlturaCorte = 7.0;
            m_TerceraAlturaCorte = 0.0;

            m_dTipoHerramienta = 0;
        }
        public override void EscribirAlturaPostCebado(StreamWriter StreamFileISO)
        {
            String Cadena = String.Format("G65 P1502 A{0} B{1} C{2} D{3} E{4} F{5}\n", 
                m_dTipoHerramienta,
                m_dTipoCebado,
                m_PrimeraAlturaCebado, 
                m_SegundaAlturaCebado,
                m_CorreccionMarcadoCebado, m_bDobleCebado ? 1 : 0);
            StreamFileISO.Write(Cadena);
        }
        public override void EscribirAlturaCorte(StreamWriter StreamFileISO)
        {
            string Cadena = string.Format("G65 P1502 A{0} B{1} C{2} D{3} E{4}\n",
                m_dTipoHerramienta,
                m_PrimeraAlturaCorte,
                m_SegundaAlturaCorte,
                m_TerceraAlturaCorte,
                m_CorreccionMarcadoCorte);
            StreamFileISO.Write(Cadena);
        }

        public override bool EscribirSubrutina_EncenderHerramienta(StreamWriter StreamFileCNC, int N)
        {
            StreamFileCNC.Write("IF [#1 NE {0}] GOTO {1}\n", m_dTipoHerramienta, N);
            StreamFileCNC.Write ("M53\n#500 = 0.013\n");
            StreamFileCNC.Write ("#1104 = 1 (ACTIVA ORDEN EN F54.4)\n");
            StreamFileCNC.Write ("WHILE [#1004 EQ 0] DO 1 (ESPERA A CONFIRMACION EN G54.4)\n");
            StreamFileCNC.Write ("END 1\n");
            StreamFileCNC.Write ("#1104 = 0\n");
            StreamFileCNC.Write ("#500 = 0.014\n");
            StreamFileCNC.Write ("#529 = 529+1\n");  // Contador arranques plasma
            StreamFileCNC.Write ("IF [#537 EQ 0] GOTO 1000000\n"); // dEnableLimpieza
            StreamFileCNC.Write ("#536 = #536+1\n"); // dLimpiezaContador,
            StreamFileCNC.Write ("IF [#503 EQ 5] GOTO 1000000\n");
            StreamFileCNC.Write ("G05.1Q1\n");
            StreamFileCNC.Write("GOTO 1000000\n");
            StreamFileCNC.Write("N{0}\n", N);
 
            return (true);
        }
        public override bool EscribirSubrutina_ApagarHerramienta(StreamWriter StreamFileCNC, int N)
        {
            StreamFileCNC.Write("IF [#1 NE {0}] GOTO {1}\n", m_dTipoHerramienta, N);
            StreamFileCNC.Write("M53\n#500 = 0.023\n");
            StreamFileCNC.Write ("#1108 = 1 (ACTIVA ORDEN EN F55.0)\n");
            StreamFileCNC.Write ("WHILE [#1008 EQ 0] DO 1 (ESPERA A CONFIRMACION EN G55.0)\n");
            StreamFileCNC.Write ("END 1\n");
            StreamFileCNC.Write ("#1108 = 0\n");
            StreamFileCNC.Write ("M53\n");
            StreamFileCNC.Write ("#500=0.024\n");
            StreamFileCNC.Write("GOTO 1000000\n");
            StreamFileCNC.Write("N{0}\n", N);

            return (true);
        }
        public override bool EscribirSubrutina_AlturaCebado(StreamWriter StreamFileCNC, int N)
        {
            StreamFileCNC.Write("IF [#1 NE {0}] GOTO {1}\n", m_dTipoHerramienta, N);
            StreamFileCNC.Write("M53\n#500 = 0.023\n");
            StreamFileCNC.Write("#1108 = 1 (ACTIVA ORDEN EN F55.0)\n");
            StreamFileCNC.Write("WHILE [#1008 EQ 0] DO 1 (ESPERA A CONFIRMACION EN G55.0)\n");
            StreamFileCNC.Write("END 1\n");
            StreamFileCNC.Write("#1108 = 0\n");
            StreamFileCNC.Write("M53\n");
            StreamFileCNC.Write("#500=0.024\n");
            StreamFileCNC.Write("GOTO 1000000\n");
            StreamFileCNC.Write("N{0}\n", N);

            return (true);
        }
        public override bool EscribirSubrutina_AlturaCorte(StreamWriter StreamFileCNC, int N)
        {
            StreamFileCNC.Write("IF [#1 NE {0}] GOTO {1}\n", m_dTipoHerramienta, N);
            StreamFileCNC.Write("M53\n#500 = 0.015\n");
            StreamFileCNC.Write("N20 IF [[#501 AND 2] EQ 0] GOTO 40\n");
            StreamFileCNC.Write("WHILE [#500 EQ 0.015] DO 1\n");
            StreamFileCNC.Write("END 1\n");
            StreamFileCNC.Write("N40 M53\n#500 = 0.016\n");
            StreamFileCNC.Write("#500=0.016\n");
            StreamFileCNC.Write("GOTO 1000000\n");
            StreamFileCNC.Write("N{0}\n", N);

            return (true);
        }
    }
}
