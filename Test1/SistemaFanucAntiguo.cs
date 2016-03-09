using System;
using System.Linq;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;

namespace Test1
{
    class StructFanucGeneral
    {
        public unsafe struct Datos
        {
            public byte dTipoControl;           // 0: 0i, 1: 300i 2:0imd
            public byte dTipoMaquina;           // 0: Multi, 1: Teox,  2: Duct, 3: Láser, 4 TRF
            public byte dNumeroEjesX;
            public byte dNumeroEjesY;
            public byte dNumeroEjesZ;
            public byte bExisteBevel;           // 0: No existe, 1: Existe
            public byte dNumeroEjesV;
            public byte dNumeroEjesW;
            public byte dNumeroCabezalesTeox;
            public byte bResevadoCisCADCN;  // Se pone a 1 cuando se ejecuta CisCADCN

            public UInt16 dAcceleracionVacio;
            public UInt16 dDeceleracionVacio;
            public UInt16 dAcceleracionCorte;
            public UInt16 dDeceleracionCorte;
            public UInt16 dVelocidadVacio;
            public UInt16 dVelocidadCorte;
            public UInt16 dVelocidadEntrada;
            public UInt16 dVelocidadSalida;
            public UInt16 dVelocidadManual_NO_USADO;
            public byte dOverrideVelocidadXY;       // Base de los 8 bits de salida
            public byte dOverrideVelocidadZ;        // Base de los 8 bits de salida
            public byte dTrasladarChapa;            // Entrada
            public byte dRotarChapa;            // Entrada
            public byte dInicioChapa;           // Entrada
            public byte dAddPuntoChapa;         // Entrada
            public byte dFinChapa;          // Entrada
            public byte dManualAvanceX;         // Salida
            public byte dManualRetrocesoX;      // Salida
            public byte dManualAvanceY;         // Salida
            public byte dManualRetrocesoY;      // Salida
            public byte dControlAutomaticoAltura;       // Entrada
            public byte dSetaEmergencia;            // Entrada
            public byte dPausaActiva;           // Salida
            public byte dAlmuadillasSeguridad;      // Salida ?
            public byte dErrorPlasma;           // Entrada
            public byte CheckBoxInductivoRotulaSeguridad;   //dAnularEsperaSoplete;		// Salida
            public byte CheckBoxFinalesCarrera;     //dHoldTeox;			// Entrada
            public byte dNumeroGeneradoresPlasma;
            public byte dPotencia;          // Base de los 8 bits de salida
            public byte dSopleteCalentamiento;      // Salida
            public byte dSopleteSobrecalentamiento; // Salida
            public byte dSopleteCorte;
            public uint dCuentahorasMaquina;
            public byte bEjeVirtualActivo;
            public byte dLuzSemaforoVerde;      // Salida
            public byte dLuzSemaforoAmbar;      // Salida
            public byte dLuzSemaforoRojo;           // Salida
            public byte dCabezalNeumatico;      // Salida
            public byte dEncendidoPunteroLaser;     // Salida
            public byte dConexionFotocelulas;       // Salida
            public byte dConexionAspiracion;        // Salida
            public char _dOffsetReconocimientoXChapa;   // Offset de reconocimiento de chapa automático
            public byte dConexionLimpiezaCabezales; // Salida
            public UInt16 dVelocidadReconocimientoChapa;    // Velocidad de reconocimiento de chapa automático
            public byte bVerRefrigeracionLaser;     // Visualizar Refrigeración láser
            public byte dHomeInversoCabezales;
            public byte dApartarCabezales;      // Salida
            public byte dRecorridoPrueba;
            public byte dComenzarDesdeDondeEste;
            public byte dNoRetornarOrigen;
            public byte dSuavizadoAutomatico;
            public byte dColisionActivaEnBaja;
            public UInt16 dAnguloSuavizadoAutomatico;
            public UInt16 dTiempoSuavizadoAutomatico;
            public byte dEliminarControlCebado;
            public byte dRepetirInfinito;
            public byte dPausaSiNoArcoPrincipal;
            public byte dManualFinCorte;
            public byte dActivarManual;
            public byte dParadaPrograma;            // 0: No activo, 1: Activo
            public byte bActivarCisCADServer;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] szNombreMaquina;  //Se pone la mitad Nombre de la máquina para el server
            public byte bMostrarTecladoTactil;
            public byte bInvertirManualX;
            public byte bInvertirManualY;
            public UInt16 dAnchoChapa;          // Específicos de chapa - bancada.
            public UInt16 dLargoChapa;
            public UInt16 dAnchoBancada;
            public UInt16 dLargoBancada;
            public UInt16 dMarcaMovimientoManual;       // Marca para movimientos en manual
            public UInt16 dTiempoSinRegularAvanzar;
            public UInt16 dMarcaHabilitacionEjesManual; // Marca para habilitar el control manual
            public UInt16 dAcceleracionManual;
            public UInt16 dDeceleracionManual;
            public UInt16 TCambioManual1;
            public UInt16 TCambioManual2;
            public byte dPorcentajeManual1;
            public byte dPorcentajeManual2;
            public byte dPorcentajeManual3;
            public byte dEntradaEngrase;
            public UInt16 dVelocidadManualZ_NO_USADO;
            public UInt16 dAcceleracionManualZ;
            public UInt16 dVelocidadRetornoColision;
            public UInt16 dVelocidadRetornoColisionZ;
            public UInt16 dTiempoAspiracion;
            public UInt16 dHabilitarSemaforo;
            public UInt16 dActivacionAspiracion;
            public UInt16 dActivacionLimpieza;
            public uint dLimpiezaY1;
            public uint dLimpiezaY2;
            public UInt16 dNumPerforaciones;
            public byte EditTiempoLimpieza;
            public byte dTiempoRegBajar;
            public UInt16 dAccelercaionSkipZ;
            public UInt16 dTiempoSopletePenetracion;
            public UInt16 dTiempoSopleteSubida;
            public UInt16 dTiempoCalentamientoSoplete;
            public UInt16 dVelocidadCambioAnguloBisel;
            public UInt16 dSopleteTiempoHome;
            public UInt16 dSopleteTiempoVacio;
            public byte dInvertirMovimientoEjeX;
            public byte dInvertirMovimientoEjeY;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public UInt16[] dDistanciasMinimasMulti;
            public UInt16 dPosicionParkingMulticabezal;
            public UInt16 dVelocidadesEjes;
            public Int16 dBiselSubidaExtraCebado;
            public Int16 dOtroBiselSubidaExtraCebado;
            public Int16 dParkingYTubos;
            public byte ControlVoltaicoPorDefecto;
            public byte bControlM10M11Tubos;
            public byte bAICCTubos;
            public byte bAICCBevel;
            public UInt16 dVelocidadVacioC;
            public byte bFlagSoloTubos;
            public byte bTipoCorteInicio;
            public byte bCompensacionActiva;
            public byte bControlM10M11Bisel;
            public byte bPermitirSolapamiento;
            public byte bHabilitarConsolaOxicorte;
            public Int16 dVelocidadMarcadoTinta;
            public byte bTripleSoplete;
            public byte bAspiracionActivaTubos;
            public byte bSeguridadEntreCabezales;
            public byte bExisteSpindle;
            public UInt16 dDistanciaChapa;
            public byte bDosPlasmasIndependientes;
            public byte dAspiradoSiempreActivo;
            public UInt16 dRetardoApagadoAspiracion;
            public byte bExclusionBulon;
            public byte bRetadroGrupoHidraulico;
            public Int16 ExclusionBulon1;
            public Int16 ExclusionBulon2;
            public Int16 ExclusionPison1;
            public Int16 ExclusionPison2;
            public UInt16 TiempoRetadroGrupoHidraulico;
            public byte bG92Z0Activo;
            public byte bSoltarHerramientaMecanizado;
            public byte bMaquinaEsMecanizado;
            public byte bGestionarAnguloTrayectoria;
            public UInt16 AnguloTrayectoria;
            public Int16 ExclusionPisonX1;
            public Int16 ExclusionPisonX2;
            public byte bExclusionPisonX;
            public byte bExclusionPisonY;
            public byte bBarrerasSeguridad;
            public byte bTCPActivo;
            public UInt16 dTCPLongitud;
            public byte bExclusionAntorchaX;
            public byte bExclusionAntorchaY;
            public UInt16 ExclusionAntorchaX1;
            public UInt16 ExclusionAntorchaX2;
            public UInt16 ExclusionAntorchaY1;
            public UInt16 ExclusionAntorchaY2;
            public byte dEjeZSopleteTriple;
            public byte bApartarYTrampilla;
            public UInt16 dMinimaDistanciaGosubAltura;
            public byte bEnableMinimaDistanciaGosubAltura;
            public byte bEnableMinimaDistanciaCebado;
            public UInt16 dMinimaDistanciaGosubAlturaCebado;
            public UInt16 ReduccionVelocidadRejilla;
            public byte bPuertasSeguridad;
            public byte bExclusionTorretaY;
            public UInt16 ExclusionTorretaY1;
            public UInt16 ExclusionTorretaY2;
            public byte bSuavizarArranqueCorte;
            public byte bExisteProfibus;
            public UInt16 dTiempoSuavizarArranqueCorte;
            public byte bEnviarDataServer;
            public byte dNumeroCabezalesLaser;
            public byte bEnableCarenado1;
            public byte bEnableCarenado2;
            public byte bEnableCarenado3;
            public byte bEnableCarenado4;
            public byte bSeguridadHerramientaLaser;
            public byte bMacro500;
            public UInt16 bEstadoProgramaRealMacro;
            public UInt16 PerforacionLaser;
            public Int16 SegundaAlturaLaser;
            public Int16 AlturaCorteLaser;
            public UInt16 b503RealMacro;
            public UInt16 dVelocidadSegundaAltura;
            public byte bSopladoPenetrarLaser;
            public byte bRecorridoPruebPunteroLaser;
            public UInt16 dTiempoPerforacionLaser;
            public UInt16 dPresionPreforacionLaser;
            public UInt16 dPresionCorteLaser;
            public UInt16 dTiempoPreflowLaser;
            public UInt16 dRetrasoCorteLaser;
            public byte GasPerforacionLaser;
            public byte GasCorteLaser;
            public UInt16 dVelocidadAspiracion;
            public byte bExisteXPrima;
            public byte bEjeXPrima;
            public UInt16 TiempoAngulo;
            public UInt16 dGiroAnguloBisel;
            public byte bTiempoEsperaTrampillaFlag;
            public byte dTiempoEsperaTrampilla;
            public byte CheckBoxFlexSupport;
            public byte CheckBoxSeguridadRadial;
            public byte bTripleSoplete2;
            public byte dEjeZSopleteTriple2;
            public byte bBarrerasSeguridadExternas;
            public byte bFinalCarreraPuente;
            public char _dOffsetReconocimientoYChapa;   // Offset de reconocimiento de chapa automático
            public byte bFlags1;    //D1445 Bit 0: Tipo reconocimientno de chapa analógico 1/ digital 0
                                    // 	Cabezal 1 Bit 1: Spindled (0) o servomotor (1)
                                    // 	Cabezal 2 Bit 2: Spindled (0) o servomotor (1)
        };
        public Datos u = new Datos();
        public int TamanoArray()
        {
            return (Marshal.SizeOf(u));
        }
        public byte[] getBytes()
        {
            int size = Marshal.SizeOf(u);
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(u, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return (arr);
        }
        public Datos fromBytes(byte[] arr)
        {
            int size = Marshal.SizeOf(u);
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(arr, 0, ptr, size);
            u = (Datos)Marshal.PtrToStructure(ptr, u.GetType());
            Marshal.FreeHGlobal(ptr);
            return (u);
        }
        public String GetNombreMaquina()
        {
            byte[] Memoria = getBytes();
            byte[] NombreBytes = new byte[32];
            Array.Copy(Memoria, 87, NombreBytes, 0, 32);
            System.Text.ASCIIEncoding Nombre = new System.Text.ASCIIEncoding();
            return (Nombre.GetString(NombreBytes));
        }
    }
    class StructFanucCarenados
    {
        public unsafe struct Datos
        {
            public byte dEnableMotor1;
            public byte dEnableMotor2;
            public byte dNumEjeMotor1;
            public byte dNumEjeMotor2;
            public UInt16 dVelocidadMotor1;
            public UInt16 dVelocidadMotor2;
            public UInt16 dAceleracionMotor1;
            public UInt16 dAceleracionMotor2;
            public Int32 dPosicionAbierta1;
            public Int32 dPosicionAbierta2;
            public Int32 dPosicionCerrada1;
            public Int32 dPosicionCerrada2;
        }
        public Datos u = new Datos();
        public int TamanoArray()
        {
            return (Marshal.SizeOf(u));
        }
        public byte[] getBytes()
        {
            int size = Marshal.SizeOf(u);
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(u, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return (arr);
        }
        public Datos fromBytes(byte[] arr)
        {
            int size = Marshal.SizeOf(u);
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(arr, 0, ptr, size);
            u = (Datos)Marshal.PtrToStructure(ptr, u.GetType());
            Marshal.FreeHGlobal(ptr);
            return (u);
        }
    }
    class StructFanucCompuertas
    {
        public unsafe struct Datos
        {
            public byte dPuerto;
            public byte dActivo;
            public UInt16 dDesde;
            public UInt16 dHasta;
            public Int16 dValorSolape;
        }
        public Datos u = new Datos();
        public int TamanoArray()
        {
            return (Marshal.SizeOf(u));
        }
        public byte[] getBytes()
        {
            int size = Marshal.SizeOf(u);
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(u, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return (arr);
        }
        public Datos fromBytes(byte[] arr)
        {
            int size = Marshal.SizeOf(u);
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(arr, 0, ptr, size);
            u = (Datos)Marshal.PtrToStructure(ptr, u.GetType());
            Marshal.FreeHGlobal(ptr);
            return (u);
        }
    }
    class StructFanucEjeX
    {
        public unsafe struct Datos
        {
            public byte dNumeroEje;
            public byte dReservado1;
            public byte dReservado2;
            public byte dReservado3;
            public UInt16 dEscala;
            public byte dHome;
            public byte dLimiteInferior;
            public byte dLimiteSuperior;
            public byte bPaNada1;
            public UInt16 dVelocidadHome;
            public UInt16 dBackOff;
            public byte dFreno;
            public char dSentidoEje;
            public Int16 LimiteIntensidadL;
            public Int16 LimiteIntensidadR;
            public Int16 dRelaccionInercia;
            public Int16 dVelocityPulse;
            public Int16 dPositionPulse;
            public Int16 dRefCounter;
            public Int16 dGananciaProporcional;
            public Int16 dGananciaIntegral;
            public Int16 dGananciaLoop;
            public Int16 dVelocidadManual;
            public Int16 dAccVacio;
            public Int16 dAccCorte;
            public Int16 VelocidadVacio;
        }
        public Datos u = new Datos();
        public int TamanoArray()
        {
            return (Marshal.SizeOf(u));
        }
        public byte[] getBytes()
        {
            int size = Marshal.SizeOf(u);
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(u, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return (arr);
        }
        public Datos fromBytes(byte[] arr)
        {
            int size = Marshal.SizeOf(u);
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(arr, 0, ptr, size);
            u = (Datos)Marshal.PtrToStructure(ptr, u.GetType());
            Marshal.FreeHGlobal(ptr);
            return (u);
        }
    }
    class StructFanucEjeY
    {
        public unsafe struct Datos
        {
            public byte dNumeroEje;
            public byte dReservado1;
            public byte dReservado2;
            public byte dReservado3;
            public byte dTipoEje;           // 0: Lineal 1: tubo
            public byte bPaNada1;
            public UInt16 dAcceleracionColocacion;
            public UInt16 dDeceleracionColocacion;
            public UInt16 dAcceleracionSeparacion;
            public UInt16 dDeceleracionSeparacion;
            public UInt16 dEscala;
            public byte dHome;
            public byte dLimiteInferior;
            public byte dLimiteSuperior;
            public byte bPaNada2;
            public UInt16 dVelocidadHome;
            public UInt16 dVelocidadApartarCabezales;
            public UInt16 dVelocidadColocarCabezales;
            public UInt16 dBackOff;
            public UInt16 dSeparacionMinimaSiguienteCabezal;
            public byte dParkingEje;
            public byte dPosicionCabezalTeox;
            public byte dFreno;
            public char dSentidoEje;
            public Int16 LimiteIntensidadL;
            public Int16 LimiteIntensidadR;
            public Int16 dRelaccionInercia;
            public Int16 dVelocityPulse;
            public Int16 dPositionPulse;
            public Int16 dRefCounter;
            public Int16 dGananciaProporcional;
            public Int16 dGananciaIntegral;
            public Int16 dGananciaLoop;
            public Int16 dVelocidadManual;
            public Int16 dAccVacio;
            public Int16 dAccCorte;
            public Int16 TestLaser;
            public Int16 VelocidadVacio;
            public UInt16 dMaxVelocidadGiro;
        }
        public Datos u = new Datos();
        public int TamanoArray()
        {
            return (Marshal.SizeOf(u));
        }
        public byte[] getBytes()
        {
            int size = Marshal.SizeOf(u);
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(u, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return (arr);
        }
        public Datos fromBytes(byte[] arr)
        {
            int size = Marshal.SizeOf(u);
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(arr, 0, ptr, size);
            u = (Datos)Marshal.PtrToStructure(ptr, u.GetType());
            Marshal.FreeHGlobal(ptr);
            return (u);
        }
    }
    class StructFanucEjeZ
    {
        public unsafe struct Datos
        {
            public byte dNumeroEje;
            public byte dReservado1;
            public byte dReservado2;
            public byte dReservado3;
            public byte dTipoEje;   // 0 es Fanuc (plasma/oxicorte), 1 TEOX, 2 Mecanizado
            public byte bEsEjeMecanizado;
            public UInt16 dEscala;
            public byte dHome;
            public byte dLimiteInferior;
            public byte dLimiteSuperior;
            public byte bNoVale2;
            public UInt16 dVelocidadHome;
            public UInt16 dBackOff;
            public UInt16 dVelocidadRegulacion;
            public UInt16 dVelocidadCebado;
            public UInt16 VelocidadVacio;
            public UInt16 dAcceleracionRegulacionSubir;
            public UInt16 dDeceleracionRegulacionSubir;
            public UInt16 dAcceleracionRegulacionBajar;
            public UInt16 dDeceleracionRegulacionBajar;
            public byte dEntradaColision;           // Entrada
            public byte dFreno;
            public char dSentidoEje;
            public Int16 LimiteIntensidadL;
            public Int16 LimiteIntensidadR;
            public Int16 dRelaccionInercia;
            public Int16 dVelocityPulse;
            public Int16 dPositionPulse;
            public Int16 dRefCounter;
            public Int16 dGananciaProporcional;
            public Int16 dGananciaIntegral;
            public Int16 dGananciaLoop;
            public Int16 dVelocidadManual;
            public Int16 dAccVacio;
            public Int16 dAccCorte;
            public byte dEjeSpindleActivo;
            public byte dEjeSpindleAsociado;
            public Int16 dPrimeraAlturaTestLaser;
            public Int16 dSegundaAlturaTestLaser;
            public Int16 NumeroLimpiezaLaser;
            public Int16 AlturaAproximacionLaser;
            public Int16 VelocidadCebadoAutomata;
            public UInt16 LimpiezaLaserPosY;
            public UInt16 CiclosLimpiezaLaser;
            public UInt16 ZigZagLimpiezaLaser;
            public UInt16 AlturaLimpiezaLaser;
            public UInt16 VelocidadSkipLaser;
            public UInt16 PosicionTestAltura;
            public UInt16 AceleracionRegulacion;
            public UInt16 PosicionTestAlturaBevel;
        }
        public Datos u = new Datos();
        public int TamanoArray()
        {
            return (Marshal.SizeOf(u));
        }
        public byte[] getBytes()
        {
            int size = Marshal.SizeOf(u);
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(u, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return (arr);
        }
        public Datos fromBytes(byte[] arr)
        {
            int size = Marshal.SizeOf(u);
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(arr, 0, ptr, size);
            u = (Datos)Marshal.PtrToStructure(ptr, u.GetType());
            Marshal.FreeHGlobal(ptr);
            return (u);
        }
    }
    class StructFanucEjeV
    {
        public unsafe struct Datos
        {
            public byte dNumeroEje;
            public byte dReservado1;
            public byte dReservado2;
            public byte dReservado3;
            public UInt16 dEscala;
            public byte dHome;
            public byte dLimiteInferior;            // Entrada
            public byte dLimiteSuperior;            // Entrada
            public char dSentidoEje;
            public UInt16 dVelocidadHome;
            public UInt16 dBackOff;
            public byte dEjeAsociadoBevel;      // -1 No hay: Otro: Eje asociado
            public byte dFreno;
            public Int16 LimiteIntensidadL;
            public Int16 LimiteIntensidadR;
            public Int16 dRelaccionInercia;
            public Int16 dVelocityPulse;
            public Int16 dPositionPulse;
            public Int16 dRefCounter;
            public Int16 dGananciaProporcional;
            public Int16 dGananciaIntegral;
            public Int16 dGananciaLoop;
            public Int16 dFocalBevel;
            public Int16 dVelocidadManual;
            public Int16 dAccVacio;
            public Int16 dAccCorte;
            public Int16 VelocidadVacio;
        }
        public Datos u = new Datos();
        public int TamanoArray()
        {
            return (Marshal.SizeOf(u));
        }
        public byte[] getBytes()
        {
            int size = Marshal.SizeOf(u);
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(u, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return (arr);
        }
        public Datos fromBytes(byte[] arr)
        {
            int size = Marshal.SizeOf(u);
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(arr, 0, ptr, size);
            u = (Datos)Marshal.PtrToStructure(ptr, u.GetType());
            Marshal.FreeHGlobal(ptr);
            return (u);
        }
    }
    class StructFanucPlasmaSoplete
    {
        public unsafe struct Datos
        {
            public byte dEjeZAsociado;
            public byte dConsolaAutomatica;     // bit 0: Hypertherm, 1: Kejellberg, etc.
            public byte dConsolaAutomaticaActiva;
            public byte bEsPlasma;
            public Int16 dOffsetMarcadoPlasmaX;
            public Int16 dOffsetMarcadoPlasmaY;
            public Int16 dOffsetMarcadoTintaX;
            public Int16 dOffsetMarcadoTintaY;
            public Int16 dOffsetMarcadoPunteroLaserX;
            public Int16 dOffsetMarcadoPunteroLaserY;
            public Int16 dOffsetCebadoMarcadoZ;
            public byte dBaseVoltaico;          // Base de los 8 bits de entrada
            public byte dBaseCapacitivo;            // Base de los 8 bits de entrada
            public byte dArcoPrincipal;         // Entrada
            public byte dBaseConsignaPotencia;      // Base de los 8 bits de salida
            public byte dBasePotenciaActual;        // Base de los 8 bits de entrada
            public byte dActivacionPotencia;        // Flag:
            public byte dBaseConsignaVoltaje;       // Salidas 8 bits
            public byte dBaseConsignaCapacitivo;        // Salidas 8 bits
            public UInt16 dExistePlasmaMarcadoExterno;
            public byte dArraquePlasma;         // Salida
            public byte dErrorPlasma;           // Entrada
            public byte dArranquePlasmaMarcado;     // Salida
            public byte dPuertoSerieConsola;
            public uint dContadorArranquePerpetuo;
            public UInt16 dContadorArranqueRelativo;
            public byte dAnularEsperaSoplete;
            public byte dSopleteCalentamiento;      // Entrada
            public byte dSopleteSobrecalentamiento; // Entrada
            public byte dExisteMarcadoTinta;
            public UInt16 dAlturaCebadoFija;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public UInt16[] dCebadoPorArco;     // Solamente se utilizan dos
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public UInt16[] dValoresAlturaCorteFijo;    // Solamente se utilizan menos
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public UInt16[] dValoresRegulacionAltura;   // Solamente se utilizan menos
            public byte dTipoCebado;
            public byte dTipoCorte;
            public byte dTipoRetornarlFinalizarCorte;   // Home, Altura vacío, etc.
            public byte dExisteCabezalMarcadoTinta;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public UInt16[] dDatosCebado;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public UInt16[] dDatosCorte;
            public UInt16 dEsperaRegulacionEsquina;
            public UInt16 dEsperaRegulacionBajar;
            public byte dArranqueSoplete;
            public byte dExisteMarcadoPlasma;
            public Int16 dVoltaicoBajo;         // Valor de voltaje Bajo
            public Int16 dVoltaicoAlto;         // Valor de Voltaje Alto
            public byte EjeCAsociadoCodenet;
            public byte dHabilitarPotenciaAnalogica;
            public UInt16 dPotenciaAnalogicaMinimo;
            public UInt16 dPotenciaAnalogicaMaximo;
            public byte dEjeZAsociadoCodenet;
            public byte dConsolaAutomaticaCodenet;
            public byte dConsolaAutomaticaActivaCodenet;
            public byte dPuertoSerieConsolaCodenet;
            public Int16 dOffsetMacrojetX;
            public Int16 dOffsetMacrojetY;
            public Int16 dOffsetOxicorteX;
            public Int16 dOffsetOxicorteY;
            public Int16 dRetrocesoREA;
        }
        public Datos u = new Datos();
        public int TamanoArray()
        {
            return (Marshal.SizeOf(u));
        }
        public byte[] getBytes()
        {
            int size = Marshal.SizeOf(u);
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(u, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return (arr);
        }
        public Datos fromBytes(byte[] arr)
        {
            int size = Marshal.SizeOf(u);
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(arr, 0, ptr, size);
            u = (Datos)Marshal.PtrToStructure(ptr, u.GetType());
            Marshal.FreeHGlobal(ptr);
            return (u);
        }
    }
    class StructFanucLimitesSoftware
    {
        public unsafe struct Datos
        {
            public Int32 dDesde;
            public Int32 dHasta;
        }
        public Datos u = new Datos();
        public int TamanoArray()
        {
            return (Marshal.SizeOf(u));
        }
        public byte[] getBytes()
        {
            int size = Marshal.SizeOf(u);
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(u, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return (arr);
        }
        public Datos fromBytes(byte[] arr)
        {
            int size = Marshal.SizeOf(u);
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(arr, 0, ptr, size);
            u = (Datos)Marshal.PtrToStructure(ptr, u.GetType());
            Marshal.FreeHGlobal(ptr);
            return (u);
        }
    }
    class StructFanucLimitesVariablesMacro
    {
        public unsafe struct Datos
        {
            public UInt16 dEstadoPrograma;
            public UInt16 dTipoCebado;
            public UInt16 dValorCebadoCapacitivo;
            public UInt16 dCebadoContacto1;
            public UInt16 dCebadoContacto2;
            public UInt16 dCebadoAlturaFija;
            public UInt16 dCebadoArco1;
            public UInt16 dCebadoArco2;
            public UInt16 dTipoRegulacionCorte;
            public UInt16 dCambioAnguloBevel;   // Desplazadas por que no hay sitio.
            public UInt16 dAlturaFinalCorte;
            public UInt16 dRegCorteCapacitivo;
            public UInt16 dRegCorteAlturaFija;
            public UInt16 dRegCorteAltura1;
            public UInt16 dRegCorteAltura2;
            public UInt16 dFlagAlturaVacioHome;
            public UInt16 dAlturaVacio;
            public UInt16 dVelocidadZVacio;
            public UInt16 dVelocidadZCebado;
            public UInt16 dVelocidadZRetorno;
            public UInt16 dTipoCortePlasmaSoplete;
            public UInt16 dOtroBiselExtraCebado;
            public UInt16 dCorteActualTubos;
            public UInt16 bActualEsMarcado;
            public UInt16 dCebadoMarcado;
            public UInt16 dNumeroCebados;
            public UInt16 dTiempoSobrecalentamiento;
            public UInt16 dValorPotencia;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public UInt16[] dEjesActivos; // [MAX_EJES_Z];
            public UInt16 dHayDatosNuevos;
            public UInt16 dHayDobleContacto;
            public UInt16 dCebadoContacto3;
            public UInt16 dVelocidadDobleCebado;
            public UInt16 dLimpiezaCuentaInicial;
            public UInt16 dLimpiezaContador;
            public UInt16 dEnableLimpieza;
            public Int16 dPosicionLimpieza1;
            public Int16 dPosicionLimpieza2;
            public UInt16 dFlagActivacionSalidaLimpieza;
            public UInt16 dFlagEsperaLimpieza;
            public UInt16 dEntidadActual;
            public UInt16 dContadorArranquesPlasma;
            public UInt16 dExisteBevel;
            public UInt16 dAnguloBevelNegativo;
            public UInt16 dBevelExtraAntorcha;
            public UInt16 dRegCorteVoltaico1;
            public UInt16 dRegCorteVoltaico2;
        }
        public Datos u = new Datos();
        public int TamanoArray()
        {
            return (Marshal.SizeOf(u));
        }
        public byte[] getBytes()
        {
            int size = Marshal.SizeOf(u);
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(u, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return (arr);
        }
        public Datos fromBytes(byte[] arr)
        {
            int size = Marshal.SizeOf(u);
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(arr, 0, ptr, size);
            u = (Datos)Marshal.PtrToStructure(ptr, u.GetType());
            Marshal.FreeHGlobal(ptr);
            return (u);
        }
    }
    class StructFanucSubrutinas
    {
        public unsafe struct Datos
        {
            public UInt16 dCebadoCapacitivo;
            public UInt16 dCebadoContacto;
            public UInt16 dCebadoFijo;
            public UInt16 dCebadoArco;
            public UInt16 dRegulacionVoltaico;
            public UInt16 dRegulacionCapacitivo;
            public UInt16 dRegulacionFija;
            public UInt16 dRegulacionAltura;
            public UInt16 dEncendidoPlasma;
            public UInt16 dEncendidoSoplete;
            public UInt16 dEncendidoPlasmaMarcado;
            public UInt16 dEncendidoTintaMarcado;
            public UInt16 dEncendidoLaser;
            public UInt16 dApagadoPlasma;
            public UInt16 dApagadoSoplete;
            public UInt16 dApagadoPlasmaMarcado;
            public UInt16 dApagadoTintaMarcado;
            public UInt16 dApagadoLaser;
            public UInt16 dHomeX;
            public UInt16 dHomeY;
            public UInt16 dHomeYTubos;
            public UInt16 dHomeZ;
            public UInt16 dHomeV;
            public UInt16 dHomeW;
            public UInt16 dHomeXY;
            public UInt16 dHomeZVW;
            public UInt16 dHomeVW;
            public UInt16 dHomeTodos;
            public UInt16 dAlturaVacio;
            public UInt16 dAlturaHomeZ;
            public UInt16 dColision;
            public UInt16 dReanudarCorteAutomatico;
            public UInt16 dReanudarCorteEntrada;
            public UInt16 dApartarCabezales;
            public UInt16 dColocarCabezales;
            public UInt16 dFinalizarCorrectamente;
            public UInt16 dAbortarPrograma;
            public UInt16 dEntradaManual;
            public UInt16 dLazoAutomaticoEsquinas;
            public UInt16 dCambioBiselInsitu;
            public UInt16 dCambioBiselParando;
            public UInt16 dLimpiezaCabezales;
            public UInt16 dPonerPotencia;
            public UInt16 dHomeZSoplete;
            public UInt16 dCebadoSoplete;
            public UInt16 dHomeVacioSoplete;
            public UInt16 dCebadoMecanizado;
            public UInt16 dAlturaVacioMecanizado;
            public UInt16 dHomeZMecanizado;
            public UInt16 dMecanizadoOff;
            public UInt16 dMecanizadoOn;
            public UInt16 dGestionTrampilla;
            public UInt16 dHomeZLaser;
            public UInt16 dHomeVacioLaser;
            public UInt16 dCebadoContactoLaser;
            public UInt16 dRegulacionVoltaicoLaser;
            public UInt16 dTestAlturaLaserFino;
            public UInt16 dCambioHerramientaMecanizado;
            public UInt16 dSacarZonaExclusion;
            public UInt16 dSubrutinaM10;
            public UInt16 dSubrutinaM11;
            public UInt16 dPinPon;
            public UInt16 dTestAlturaLaserFino2;
            public UInt16 dLaserMarcadorON;
            public UInt16 dLaserMarcadorOFF;
            public UInt16 dLaserMarcadorCebado;
            public UInt16 dLaserMarcadorCogerSoltar;
            public UInt16 dCebadoContactoCanal2;
        }
        public Datos u = new Datos();
        public int TamanoArray()
        {
            return (Marshal.SizeOf(u));
        }
        public byte[] getBytes()
        {
            int size = Marshal.SizeOf(u);
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(u, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return (arr);
        }
        public Datos fromBytes(byte[] arr)
        {
            int size = Marshal.SizeOf(u);
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(arr, 0, ptr, size);
            u = (Datos)Marshal.PtrToStructure(ptr, u.GetType());
            Marshal.FreeHGlobal(ptr);
            return (u);
        }
    }
    class StructFanucGeneral2
    {
        public unsafe struct Datos
        {
            public byte bExisteElevadores;
            public byte bNumeroEjesElevadoresTubos;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] NumeroEje;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public UInt16[] Velocidad;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public UInt16[] LimitesMin;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public UInt16[] LimitesMax;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public UInt16[] OxigenoD;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] OxigenoPresion;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public UInt16[] AireD;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] AirePresion;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public UInt16[] NitrogenoD;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NitrogenoPresion;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public UInt16[] SensorCabezal1D;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SensorCabezal1Presion;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public UInt16[] SensorCabezal2D;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SensorCabezal2Presion;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public Int32[] dZonaCarenado1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public Int32[] dZonaCarenado2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public Int32[] dZonaCarenado3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public Int32[] dZonaCarenado4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public Int32[] dLimitesZonaExclusionCompuertas;
            public byte bStopAlarmas;
            public byte bActivarCarenados2;
            public byte bActivarBloqueoAutomaticoCabezales;
            public byte bSpotLaserActivo;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public UInt16[] dCabezalAutomaticoMulti;
            public Int16 dPosXLlama;
            public Int16 dPosYLlama;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public UInt16[] AcometidasOxigenoD;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] AcometidasOxigenoPresion;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public UInt16[] AcometidasAireD;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] AcometidasAirePresion;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public UInt16[] AcometidasNitrogenoD;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] AcometidasNitrogenoPresion;
            public byte bExisteAspiracion;
            public byte IndiceLaserCorte;
            public byte dAbrirCompuertasManual;
            public byte bActivarAcometidas;
            public UInt16 dPosicionParkingMulticabezal1;
            public UInt16 ExclusionTorreta2_Y1;
            public UInt16 ExclusionTorreta2_Y2;
            public UInt16 bActivarCiclosCAP;
            public byte bExisteRollOver;
            public byte bCompuertasOxicorte;
            public byte bHabilitarYCAF;
            public byte bOverrideVelocidad2;
            public UInt16 dPosYCAF;
            public byte bFlexSupport;
            public byte bComunicacionTCPMaquina;
            public fixed byte IPTCP[16];
            public UInt16 PuertoTCP;
            public byte bMarca1SopleteTriple;
            public byte bMarca2SopleteTriple;
            public byte bOmitirAvisosCorte;
            public byte bControlPlasmaUltimaEntidad;
            public uint dTiempoPlasmaUltimaEntidad;
            public byte AjustesMemoria1;
            public byte bTipoResonadorLaser;
            public byte bMostrarMensajesCorte; // 0: Limpieza. 1:Lubricación. 2: Pison. 3: Grupohidraulico. 4:pinzas. 5: Trampilla. 6: VidaUtil
            public byte bOtrasmuestras;
            public UInt16 dTiempoCicloAutomata;
            public byte bLubricacionContinua;
            public byte bControles1;
            public byte bPallets;
            public byte bCalibradoAlturaLaser;  // 7: Flag de activación. 0-6: Valor de cebados 127 máximno.
            public byte bNumeroCebadosLaser;
            public byte bTipoReconocimientoChapa;
            public UInt16 dAnchoTramex;
            public char bFlagMecanizado;
            public byte bDirectorioSubrutinas;
            public byte bPallets2;
            public byte bComunicacionPallets;
            public byte bSegResetAuto;
            public byte bBiselReconocerChapa;
            public UInt16 dAlturaReconocimiento;
            public byte SeguridadPison;
            public byte bPisonNumatico;
            public byte bHerramientaSiempreManual;
            public byte bExistePinPon;
            public byte bLubricacion2;  // Bit 0
            public byte bExisteGranete;
            public Int16 OffsetGraneteX;
            public Int16 OffsetGraneteY;
            public Int16 OffsetAccelerometro1;
            public Int16 GainAccelerometro1;
            public Int16 OffsetAccelerometro2;
            public Int16 GainAccelerometro2;    // 224 bytes / 400bytes
            public Int16 LimAcc1Min;
            public Int16 LimAcc1Max;
            public Int16 LimAcc2Min;
            public Int16 LimAcc2Max;
            public Int16 LimLente1Min;
            public Int16 LimLente1Max;
            public Int16 LimLente2Min;
            public Int16 LimLente2Max;
            public byte bStopAlarmas2;
            public byte IndiceLaserCorte2;
            public Int16 dCorregirReconocimientoXChapa;
            public Int16 dCorregirReconocimientoYChapa;
            public Int16 dLongitudLaser;
            public Int16 dSaltoLaser;
            public Int32 dDeteccionEscalon;
            public Int16 dOffsetReconocimientoXChapa;
            public Int16 dOffsetReconocimientoYChapa;
            public Int16 dCorreccionGeneralRecChapaX;
            public Int16 dCorreccionGeneralRecChapaY;
            public Int32 dLongitudHerramientaMecanizado;
            public Int32 dPosicionCerradoCarenado1_1;
            public Int32 dHastaCarenado1_1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public Int32[] dLimitesZonaExclusionCompuertas2;
            public byte FlagMultiproposito;
            public char VelLentaHorquillaFLA;
            public UInt16 VelRapidaHorquillaFLA;
            public uint PuntoInicioRapidoFLA;
            public uint PuntoFinRapidoFLA;
            public Int32 HomeXCAP;
            public Int32 HomeYCAP;
            public Int16 OffsetXCebadoLaser;
            public Int16 OffsetYCebadoLaser;
            public Int16 OffsetZCebadoLaser;
            public byte bFlags2;
            public byte bEjeNuevoCarenado;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public Int32[] PosNuevosCarenados;
            public Int32 VelocidadNuevoCarenado;
            public Int16 dOffsetLaserMarcadoX;
            public Int16 dOffsetLaserMarcadoY;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public char[] IP_SSISMA;
            public Int16 dPuertoSISMA;
            public UInt16 CeroA1Relativo;
            public UInt16 CeroB1Relativo;
            public UInt16 AjustesMemoria2;
            public Int32 dTamanoCarenado;
            public Int32 dOffset5Pos1;
            public Int32 dOffset5Pos2;
            public Int32 dMinPuenteCAP;
            public Int32 dMaxPuenteCAP;
            public Int32 dLimiteDesdeCarenado5Pos;
            public Int32 dLimiteHastaCarenado5Pos;
            public char dUnidadLogicaSISMA;
            public byte bFlagDFPChecked;    // Bit 0 Espejo Fijo Cab 1
                                            // Bit 1 No usado
                                            // Bit 2 Espejo Móvil Cab 1
                                            // Bit 3 No usado
                                            // Bit 4 Espejo Fijo Cab 2
                                            // Bit 5 No usado
                                            // Bit 6 Espejo Móvil Cab 2
                                            // Bit 7 No usado
            public byte bFlags3;    // Bit 0 Machine condition
                                    // Bit 1 Existe Pellets
                                    // bit 2 Controla Altura Fanuc
        }
        public Datos u = new Datos();
        public int TamanoArray()
        {
            return (Marshal.SizeOf(u));
        }
        public byte[] getBytes()
        {
            int size = Marshal.SizeOf(u);
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(u, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return (arr);
        }
        public Datos fromBytes(byte[] arr)
        {
            int size = Marshal.SizeOf(u);
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(arr, 0, ptr, size);
            u = (Datos)Marshal.PtrToStructure(ptr, u.GetType());
            Marshal.FreeHGlobal(ptr);
            return (u);
        }
    }
    class StructFanucGeneral3
    {
        public unsafe struct Datos
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public Int16[] OxigenoD2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public Byte[] OxigenoPresion2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public Int16[] AireD2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public Byte[] AirePresion2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public Int16[] NitrogenoD2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public Byte[] NitrogenoPresion2;
            public Int16 dPresionPreforacionLaser2;
            public Int16 dPresionCorteLaser2;
            public Int16 dOffsetReconocimiento5PosX;
            public Int16 dOffsetReconocimiento5PosY;
            public Int16 dDesplazamiento5Pos;
            public Int16 dTempEspFijo1Desde;
            public Int16 dTempEspFijo1Hasta;
            public Int16 ShosrtNoUsado1;
            public Int16 ShosrtNoUsado2;
            public Int16 dTempEspMovilDesde1;
            public Int16 dTempEspMovilHasta1;
            public Int16 ShosrtNoUsado3;
            public Int16 ShosrtNoUsado4;
            public Int16 dTempEspFijo2Desde;
            public Int16 dTempEspFijo2Hasta;
            public char EjeExclusionxPrima;
            public char EjeExclusionYxPrima;
            public Int16 dFondoEscalaLaserCebado;
            public Int16 dTempEspMovilDesde2;
            public Int16 dTempEspMovilHasta2;
            public Int32 HastaExclusionXPrima;
            public Byte bFlags1;    // D3760.0: 0 DFP en manual, DFP 1 en automático
                                    // D3760.1: 0 Ir a posición 1, 1 Ir a posición 2. (Cabezal Láser 1.)
                                    // D3760.2: 1 está  posición 1.
                                    // D3760.3: 1 está  posición 2
            public Byte bFlags2;    // D3761.0: 0 DFP en manual, DFP 1 en automático
                                    // D3761.1: 0 Ir a posición 1, 1 Ir a posición 2. (Cabezal Láser 2).
                                    // D3761.2: 1 está  posición 1.
                                    // D3761.3: 1 está  posición 2
            public Int16 dOffset2Reconocimiento5PosX;
            public Byte bFlagsSISMA;    // D3764.0 : 0 Manual 1 automático
                                        // D3764.1 : 0 Desenganchar, 1 Enganchar
                                        // D3764.2 : 0 VelocidadNormal, 1 Velocidad Reducida
            public Byte bFlags3;    // Bit 0. TXT2DXF automaticamente
                                    // Bit 1. Reconocimiento de chapa automaticamente. Carenado 5 posiciones.
                                    // Bit 2. Existe esclavos SISMA
                                    // bit 3. Activar zona de exclusión x-prima
                                    // bit 4. Inductivo Carenado
                                    // bit 5. Seguridad Laser Activa (cabezal 2).
                                    // bit 6. Existe Posicionamiento en X con cambio herramienta manual X.
                                    // bit 7. Existe Posicionamiento en X con cambio herramienta manual Y.
            public Int16 OffsetZCebadoPison1;
            public Int16 OffsetZCebadoPison2;
            public UInt16 CeroA2Relativo;  // D3770
            public UInt16 CeroB2Relativo;   // D3772
            public Int16 OffsetXCebadoPison1;
            public Int16 OffsetYCebadoPison1;
            public Int16 OffsetXCebadoPison2;
            public Int16 OffsetYCebadoPison2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public Byte[] FibrasDFP;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public Byte[] FibrasLaser;
            public Byte FibraISO1;
            public Byte FibraISO2;
            public Int16 HastaExclusionYxPrima;
            public Int16 dMinDistanciaLaserCebado;
            public byte VelocidadMarcadorSisma;
            public byte NoUsado;
            public Int16 dOffsetLaserMarcado1FigX;
            public Int16 dOffsetLaserMarcado1FigY;
            public Int16 dOffsetLaserMarcado2TextoX;
            public Int16 dOffsetLaserMarcado2TextoY;
            public Int16 dOffsetLaserMarcado2FigX;
            public Int16 dOffsetLaserMarcado2FigY;
            public Int16 AltMinSISMA;
            public Int16 AltMinCabra;
            public Int16 AltMinLaser;
            public Int32 SeguridadLaserDesde;
            public Int32 SeguridadLaserHasta;
            public UInt16 dHerManX;
            public UInt16 dHerManY;

        }
        public Datos u = new Datos();
        public int TamanoArray()
        {
            return (Marshal.SizeOf(u));
        }
        public byte[] getBytes()
        {
            int size = Marshal.SizeOf(u);
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(u, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return (arr);
        }
        public Datos fromBytes(byte[] arr)
        {
            int size = Marshal.SizeOf(u);
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(arr, 0, ptr, size);
            u = (Datos)Marshal.PtrToStructure(ptr, u.GetType());
            Marshal.FreeHGlobal(ptr);
            return (u);
        }
    }

    class SistemaFanucAntiguo:SistemaTecoi
    {
        #region Definición de variables

        public const int MAX_CARENADOS = 4;
        public const int MAX_COMPUERTAS = 48;
        public const int MAX_EJES_X = 2;
        public const int MAX_EJES_Y = 6;
        public const int MAX_EJES_Z = 6;
        public const int MAX_EJES_V = 6;
        public const int MAX_EJES_W = 6;
        public const int MAX_PLASMA_SOPLETE = 6;
        public const int MAX_LIMITES_SOFTWARE = 26;

        public StructFanucGeneral FanucGeneral = new StructFanucGeneral();
        public StructFanucCarenados[] FanucCarenados = new StructFanucCarenados[MAX_CARENADOS];
        public StructFanucCompuertas[] FanucCompuertas = new StructFanucCompuertas[MAX_COMPUERTAS];
        public StructFanucEjeX[] FanucEjeX = new StructFanucEjeX[MAX_EJES_X];
        public StructFanucEjeY[] FanucEjeY = new StructFanucEjeY[MAX_EJES_Y];
        public StructFanucEjeZ[] FanucEjeZ = new StructFanucEjeZ[MAX_EJES_Z];
        public StructFanucEjeV[] FanucEjeV = new StructFanucEjeV[MAX_EJES_V];
        public StructFanucEjeV[] FanucEjeW = new StructFanucEjeV[MAX_EJES_W];
        public StructFanucPlasmaSoplete[] FanucPlasmaSoplete = new StructFanucPlasmaSoplete[MAX_PLASMA_SOPLETE];
        public StructFanucLimitesSoftware[] FanucLimitesSoftware = new StructFanucLimitesSoftware[MAX_LIMITES_SOFTWARE];
        public StructFanucLimitesVariablesMacro FanucVariablesMacros = new StructFanucLimitesVariablesMacro();
        public StructFanucSubrutinas FanucSubrutinas = new StructFanucSubrutinas();
        public StructFanucGeneral2 FanucGeneral2 = new StructFanucGeneral2();
        public StructFanucGeneral3 FanucGeneral3 = new StructFanucGeneral3();

        int FANUC_RETARDO = 200;
        int FANUC_RETARDO_MANUAL = 20;

        protected ushort m_dMiManipulador;
        protected Focas1.ODBST cncStatus = new Focas1.ODBST();
        protected Focas1.ODBAHIS alarmHis = new Focas1.ODBAHIS();
        protected Focas1.IODBPSD BufferParam = new Focas1.IODBPSD();
        protected Focas1.IODBPSD_1 prmDataNoAxis = new Focas1.IODBPSD_1();
        protected Focas1.ODBERR err = new Focas1.ODBERR();
        protected Focas1.ODBAXIS EjesAbsolutas = new Focas1.ODBAXIS();
        protected Focas1.ODBAXIS EjesRelativas = new Focas1.ODBAXIS();
        protected Focas1.ODBACT ActualFeed = new Focas1.ODBACT();
        protected Focas1.IODBPMC0 Buffer = new Focas1.IODBPMC0();
        protected Focas1.IODBPMC1 Buffer1 = new Focas1.IODBPMC1();
        protected Focas1.IODBPMC2 Buffer2 = new Focas1.IODBPMC2();
        protected Focas1.ODBM BufferMacro = new Focas1.ODBM();

        private short m_TipoDireccion;
        private short m_TipoDato;
        private ushort m_DireccionInicio;
        private ushort m_DireccionFin;
        private ushort m_Tamano;
        private Int32[] MaxSpindle = new Int32[2];
        private bool m_bHSSB = true;
        private int m_dNodo = 0;
        private String m_IpAddress;
        private ushort m_dPuerto;
        private short m_dNumPrograma;

        StreamReader m_ReaderDNC;
        public volatile bool m_bEnabledDNC;
        public volatile bool m_bEnabledGeneral;
        public Thread m_ThreadDNC = null;
        public Thread m_ThreadGeneral = null;
        private volatile bool m_bTerminarThreadDNC = false;
        private volatile bool m_bTerminarThreadGeneral = false;

        protected Focas1.focas_ret ret;

        #endregion

        public SistemaFanucAntiguo()
        {
            for (int i = 0; i < MAX_CARENADOS; i++)
                FanucCarenados[i] = new StructFanucCarenados();
            for (int i = 0; i < MAX_COMPUERTAS; i++)
                FanucCompuertas[i] = new StructFanucCompuertas();
            for (int i = 0; i < MAX_EJES_X; i++)
                FanucEjeX[i] = new StructFanucEjeX();
            for (int i = 0; i < MAX_EJES_Y; i++)
                FanucEjeY[i] = new StructFanucEjeY();
            for (int i = 0; i < MAX_EJES_Z; i++)
                FanucEjeZ[i] = new StructFanucEjeZ();
            for (int i = 0; i < MAX_EJES_V; i++)
                FanucEjeV[i] = new StructFanucEjeV();
            for (int i = 0; i < MAX_EJES_W; i++)
                FanucEjeW[i] = new StructFanucEjeV();
            for (int i = 0; i < MAX_PLASMA_SOPLETE; i++)
                FanucPlasmaSoplete[i] = new StructFanucPlasmaSoplete();
            for (int i = 0; i < MAX_LIMITES_SOFTWARE; i++)
                FanucLimitesSoftware[i] = new StructFanucLimitesSoftware();
            m_bParadaEmergencia = false;
        }
        ~SistemaFanucAntiguo()
        {
            GC.Collect();
        }
        public void ThreadProcDNC()
        {
            ushort dMiManipuladorDNC;
            bool bEnabledDNCAntes = false;
            short DCNReturn = 0;
            if (m_bHSSB)
                ret = (Focas1.focas_ret)Focas1.cnc_allclibhndl2(m_dNodo, out dMiManipuladorDNC);
            else
                ret = (Focas1.focas_ret)Focas1.cnc_allclibhndl3(m_IpAddress, m_dPuerto, 5, out dMiManipuladorDNC);
            m_bTerminarThreadDNC = false;
            while (!m_bTerminarThreadDNC)
            {
                while (m_bEnabledDNC)
                {
                    if (bEnabledDNCAntes != m_bEnabledDNC)
                    {
                        ret = (Focas1.focas_ret)Focas1.cnc_delete(dMiManipuladorDNC, m_dNumPrograma);
                        FanucPararProgramaActivo(dMiManipuladorDNC);
                        FanucModoEdit(dMiManipuladorDNC);
                        FanucPararProgramaActivo(dMiManipuladorDNC);
                        FanucBorrarFicheroActivo(m_dNumPrograma);
                        FanucReset(dMiManipuladorDNC);
                        ret = (Focas1.focas_ret)Focas1.cnc_wrmacro(dMiManipuladorDNC, 542, 10, 0, 0);
                        ret = (Focas1.focas_ret)Focas1.cnc_search(dMiManipuladorDNC, m_dNumPrograma);
                        FanucModoMem(dMiManipuladorDNC);
                        FanucActivarDNC(dMiManipuladorDNC);

                        FanucKeyCycleStart(dMiManipuladorDNC);
                        ret = (Focas1.focas_ret)Focas1.cnc_dncend2(dMiManipuladorDNC, DCNReturn);   // Por si estaba enviando algo.
                        Thread.Sleep(FANUC_RETARDO_MANUAL);
                        ret = (Focas1.focas_ret)Focas1.cnc_dncstart2(dMiManipuladorDNC, String.Format("O{0:0000}", m_dNumPrograma)); //  "O01234");
                        Thread.Sleep(FANUC_RETARDO_MANUAL);
                        bEnabledDNCAntes = m_bEnabledDNC;
                    }
                    if (m_ReaderDNC.Peek() == -1)
                    {
                        m_ReaderDNC.Close();
                        ret = (Focas1.focas_ret)Focas1.cnc_dncend2(dMiManipuladorDNC, DCNReturn);
                        m_bEnabledDNC = false;
                        bEnabledDNCAntes = false;
                        break;
                    }
                    String Cadena = m_ReaderDNC.ReadLine() + "\n";
                    String Linea = String.Copy(Cadena);
                    Int32 len = Linea.Count();
                    Int32 n;
                    while (len > 0)
                    {
                        n = len;
                        ret = (Focas1.focas_ret)Focas1.cnc_dnc2(dMiManipuladorDNC, ref n, Linea);
                        if (ret == Focas1.focas_ret.EW_BUFFER)
                            continue;
                        if (ret == Focas1.focas_ret.EW_OK || ret == Focas1.focas_ret.EW_HANDLE)
                        {
                            Linea = Linea.Substring(n);
                            len -= n;
                        }
                        else
                        {
                            ret = (Focas1.focas_ret)Focas1.cnc_dncend2(dMiManipuladorDNC, DCNReturn);
                            m_ReaderDNC.Close();
                            m_bEnabledDNC = false;
                            bEnabledDNCAntes = false;
                            break;
                        }
                    }
                }
                Thread.Sleep(FANUC_RETARDO_MANUAL);
            }
            ret = (Focas1.focas_ret)Focas1.cnc_freelibhndl(dMiManipuladorDNC);
        }
        public void ThreadProcGeneral ()
        {
            int ContadorAlarmas = 0;
            ushort dMiManipuladorGeneral;
            if (m_bHSSB)
                ret = (Focas1.focas_ret)Focas1.cnc_allclibhndl2(m_dNodo, out dMiManipuladorGeneral);
            else
                ret = (Focas1.focas_ret)Focas1.cnc_allclibhndl3(m_IpAddress, m_dPuerto, 5, out dMiManipuladorGeneral);
            while (!m_bTerminarThreadGeneral)
            {
                if (!m_bEnabledGeneral)
                    continue;
                ContadorAlarmas = ++ContadorAlarmas%5000;
                if (ContadorAlarmas == 0)
                {
                    LeerAlarmasFanuc(dMiManipuladorGeneral, ref m_AlarmasMensages);
                    m_bAlarmarReady = true;
                    Thread.Sleep(FANUC_RETARDO_MANUAL);
                    m_bAlarmarReady = false;
                    m_AlarmasMensages = "";
                }
                else if (ContadorAlarmas == 1)
                {
                    ret = (Focas1.focas_ret)Focas1.cnc_absolute(dMiManipuladorGeneral, Focas1.ALL_AXES, 4+4*Focas1.MAX_AXIS, EjesAbsolutas);
                    ret |= (Focas1.focas_ret)Focas1.cnc_relative(dMiManipuladorGeneral, Focas1.ALL_AXES, 4+4*Focas1.MAX_AXIS, EjesRelativas);
                    foreach (EjeMaquina eje in m_EjeMaquina)
                    {
                        eje.m_lfPosicion = EjesAbsolutas.data[eje.m_dIndiceEje] * 0.001;
                    }
                    LeerMacro(dMiManipuladorGeneral, (short)500, ref m_EstadoPrograma);
                }
                //else
                    //Thread.Sleep(1);
            }
            ret = (Focas1.focas_ret)Focas1.cnc_freelibhndl(dMiManipuladorGeneral);
        }
        public virtual bool LeerAlarmasFanuc(ushort HandleLocal, ref string Texto)
        {
            return (true);
        }
        public override bool ConectarAutomata(int dNodo = 0)
        {
            m_bHSSB = true;
            m_dNodo = dNodo;
            ret = (Focas1.focas_ret)Focas1.cnc_allclibhndl2 (dNodo, out m_dMiManipulador);
            m_bConectadoAutomata = ret == Focas1.focas_ret.EW_OK;
            if (m_bConectadoAutomata)
                IniciarAutomata();
            return (m_bConectadoAutomata);
        }
        public override bool ConectarAutomata(String IpAddress, ushort dPuerto)
        {
            m_bHSSB = false;
            m_IpAddress = IpAddress;
            m_dPuerto = dPuerto;
            ret = (Focas1.focas_ret)Focas1.cnc_allclibhndl3(IpAddress, dPuerto, 5, out m_dMiManipulador);
            m_bConectadoAutomata = ret == Focas1.focas_ret.EW_OK;
            IniciarAutomata();
            return (m_bConectadoAutomata);
        }
        private bool IniciarAutomata()
        {
            ret = Focas1.focas_ret.EW_OK;

            LeerConfiguracionAutomata();
            m_dNumeroEjesSistema = LeerNumeroEjes();
            FanucActivarKey();
            FanucModoMDI();
            FanucParaTodosEjesManualNuevo();
            FanucParametro20(m_dNodo);
            FanucGeneral.u.dMarcaHabilitacionEjesManual = 2001;

            BufferParam.datano = 6001;      // Para que no se borren las variables #100 - #149
            BufferParam.type = 0;
            ret |= (Focas1.focas_ret)Focas1.cnc_rdparam(m_dMiManipulador, 6001, 0, 5, BufferParam);
            BufferParam.u.cdata |= (byte)(0x01 << 6);
            BufferParam.u.cdatas[0] |= (Byte)(0x01 << 6);
            Thread.Sleep(FANUC_RETARDO);
            ret |= (Focas1.focas_ret)Focas1.cnc_wrparam(m_dMiManipulador, 5, BufferParam);
            Thread.Sleep(FANUC_RETARDO);

            BufferParam.datano = 3411;  // Para que se pare en las M's
            BufferParam.type = 0;
            ret |= (Focas1.focas_ret)Focas1.cnc_rdparam(m_dMiManipulador, 3411, 0, 5, BufferParam);
            BufferParam.u.cdata = (byte)53;
            BufferParam.u.cdatas[0] = (byte)53;
            Thread.Sleep(FANUC_RETARDO);
            ret |= (Focas1.focas_ret)Focas1.cnc_wrparam(m_dMiManipulador, 5, BufferParam);
            Thread.Sleep(FANUC_RETARDO);

            if (FanucGeneral.u.bEnviarDataServer == 1)    // Directorio por defecto si haty dataserver
                ret |= (Focas1.focas_ret)Focas1.cnc_wrpdf_curdir(m_dMiManipulador, 1, "//DATA_SV/");

            BufferParam.datano = 4127;      // Porcentaje del spindle
            BufferParam.type = 1;
            ret |= (Focas1.focas_ret)Focas1.cnc_rdparam(m_dMiManipulador, 4127, 1, 6, BufferParam);
            MaxSpindle[0] = MaxSpindle[1] = BufferParam.u.idata;

            m_ThreadDNC = new Thread(new ThreadStart(ThreadProcDNC));
            m_bEnabledDNC = false;
            m_ThreadDNC.Start();

            m_ThreadGeneral = new Thread(new ThreadStart(ThreadProcGeneral));
            m_bEnabledGeneral = true;
            m_ThreadGeneral.Start();

            return (ret == Focas1.focas_ret.EW_OK);
        }
        public override bool Salir()
        {
            m_ServidorSocket.Cerrar();
            FanucReset(m_dMiManipulador);
            ret = Focas1.focas_ret.EW_OK;
            if (m_ThreadDNC != null)
            {
                m_bTerminarThreadDNC = true;
                m_ThreadDNC.Abort();
                while (m_ThreadDNC.IsAlive) ;
            }
            if (m_ThreadGeneral != null)
            {
                m_bTerminarThreadGeneral = true;
                m_ThreadGeneral.Abort();
                while (m_ThreadGeneral.IsAlive) ;
            }
            if (m_bConectadoAutomata)
                ret = (Focas1.focas_ret)Focas1.cnc_freelibhndl (m_dMiManipulador);
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public virtual int LeerNumeroEjes ()
        {
            int i;
            ret = (Focas1.focas_ret)Focas1.cnc_absolute(m_dMiManipulador, -1, 4+4*Focas1.ALL_AXES, EjesAbsolutas);
            if (ret == Focas1.focas_ret.EW_OK)
                return (-1);
            for (i = 0; i < Focas1.ALL_AXES; i++)
                if (EjesAbsolutas.type < 0)
                    break;
            return (i);
        }
        public virtual bool FanucActivarKey(ushort HandleLocal)
        {
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(HandleLocal, 5, 0, 1005, 1005, 9, Buffer);
            Buffer.cdata[0] |= 0x80;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(HandleLocal, 9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public virtual bool FanucActivarKey () 
        {
            return (FanucActivarKey (m_dMiManipulador));
        }
        public virtual bool FanucDesactivarKey(ushort HandleLocal)
        {
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(HandleLocal, (short)5, (short)0,
                (ushort)1005, (ushort)1005, (ushort)9, Buffer);
            Buffer.cdata[0] |= 0x7F;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(HandleLocal, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public virtual bool FanucDesactivarKey()
        {
            return (FanucDesactivarKey(m_dMiManipulador));
        }
        public virtual bool FanucPararProgramaActivo(ushort HandleLocal)
        {
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(HandleLocal, 5, 0, 1006, 1006, 9, Buffer);
            Buffer.cdata[0] = 1;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(HandleLocal, 9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
            Buffer.cdata[0] = 0;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(HandleLocal, 9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public virtual bool FanucPararProgramaActivo()
        {
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)5, (short)0,
                (ushort)1006, (ushort)1006, (ushort)9, Buffer);
            Buffer.cdata[0] = 1;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
            Buffer.cdata[0] = 0;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public virtual bool FanucReset(ushort HandleLocal)
        {
            if (!FanucSetaPulsada())
                return (true);
            byte by_valor = 4;

            int i = 0;
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(HandleLocal, (short)5, (short)0,
                (ushort)1006, (ushort)1006, (ushort)9, Buffer);
            Buffer.cdata[0] |= (byte)by_valor;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(HandleLocal, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
            Buffer.cdata[0] &= (byte)(~by_valor);
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(HandleLocal, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO);


            for (i = 0; i < 400; i++)   // 8 segundos
            {
                ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(HandleLocal, 1, 0,
                    1, 1, 9, Buffer);
                if (m_FanucGlobalVariables.dNumeroAlarmas > 0)	// 13AGO2015 Ruben dice que Cuando hay una alarma se confirma con la F1.0
                {
                    if ((Buffer.cdata[0] & (byte)1) == 0)
                        break;
                }
                else
                {
                    if (((Buffer.cdata[0] >> 1) & (byte)1) == 0)
                        break;
                }
                Thread.Sleep(FANUC_RETARDO_MANUAL);
            }

            ret = (Focas1.focas_ret)Focas1.cnc_wrmacro(HandleLocal, 1000, 10, 1, 0);
            ret = (Focas1.focas_ret)Focas1.cnc_wrmacro(HandleLocal, 1001, 10, 1, 0);
            ret = (Focas1.focas_ret)Focas1.cnc_wrmacro(HandleLocal, 1002, 10, 1, 0);
            ret = (Focas1.focas_ret)Focas1.cnc_wrmacro(HandleLocal, 1100, 10, 0, 0);
            ret = (Focas1.focas_ret)Focas1.cnc_wrmacro(HandleLocal, 1101, 10, 0, 0);
            ret = (Focas1.focas_ret)Focas1.cnc_wrmacro(HandleLocal, 1102, 10, 0, 0);

            if (i < 400)
                return (true);
            return false;
        }
        public virtual bool FanucReset()
        {
            if (!FanucSetaPulsada())
                return (true);
            byte by_valor = 4;

            int i = 0;
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)5, (short)0,
                (ushort)1006, (ushort)1006, (ushort)9, Buffer);
            Buffer.cdata[0] |= (byte)by_valor;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
            Buffer.cdata[0] &= (byte)(~by_valor);
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO);


            for (i = 0; i < 400; i++)   // 8 segundos
            {
                ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, 1, 0,
                    1, 1, 9, Buffer);
                if (m_FanucGlobalVariables.dNumeroAlarmas > 0)	// 13AGO2015 Ruben dice que Cuando hay una alarma se confirma con la F1.0
                {
                    if ((Buffer.cdata[0] & (byte)1) == 0)
                        break;
                }
                else
                {
                    if (((Buffer.cdata[0] >> 1) & (byte)1) == 0)
                        break;
                }
                Thread.Sleep(FANUC_RETARDO_MANUAL);
            }

            ret = (Focas1.focas_ret)Focas1.cnc_wrmacro(m_dMiManipulador, 1000, 10, 1, 0);
            ret = (Focas1.focas_ret)Focas1.cnc_wrmacro(m_dMiManipulador, 1001, 10, 1, 0);
            ret = (Focas1.focas_ret)Focas1.cnc_wrmacro(m_dMiManipulador, 1002, 10, 1, 0);
            ret = (Focas1.focas_ret)Focas1.cnc_wrmacro(m_dMiManipulador, 1100, 10, 0, 0);
            ret = (Focas1.focas_ret)Focas1.cnc_wrmacro(m_dMiManipulador, 1101, 10, 0, 0);
            ret = (Focas1.focas_ret)Focas1.cnc_wrmacro(m_dMiManipulador, 1102, 10, 0, 0);

            if (i < 400)
                return (true);
            return (false);
        }
        public bool FanucBorrarFicheroActivo (int dNumPrograma)
        {
            return (FanucBorrarFicheroActivo(m_dMiManipulador, dNumPrograma));
        }
        public bool FanucBorrarFicheroActivo(ushort HandleLocal, int dNumPrograma)
        {
            ret = (Focas1.focas_ret)Focas1.cnc_search(HandleLocal, 4321);
            if (ret == Focas1.focas_ret.EW_OK)	// No existe fichero dummy
            {
                String FicheroDummy = "\nO4321\nM30\n%%\n";
                ret = (Focas1.focas_ret)Focas1.cnc_dwnend(HandleLocal);
                ret |= (Focas1.focas_ret)Focas1.cnc_dwnstart(HandleLocal);
                ret |= (Focas1.focas_ret)Focas1.cnc_download(HandleLocal, FicheroDummy, (short)FicheroDummy.Length);
                ret |= (Focas1.focas_ret)Focas1.cnc_dwnend(HandleLocal);
                ret |= (Focas1.focas_ret)Focas1.cnc_search(HandleLocal, 4321);
            }
            ret |= (Focas1.focas_ret)Focas1.cnc_delete(HandleLocal, (short)dNumPrograma);
            Thread.Sleep(FANUC_RETARDO);
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public virtual bool FanucEsperaReset()
        {
            m_TipoDireccion = 5;
            m_TipoDato = 0;
            m_DireccionInicio = 1006;
            m_DireccionFin = 1006;
            m_Tamano = 9;

            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, m_TipoDireccion, m_TipoDato,
                m_DireccionInicio, m_DireccionFin, m_Tamano, Buffer);
            return (Buffer.cdata[0] == 4);
        }
        public virtual bool FanucSetaPulsada (ushort HandleLocal)
        {
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(HandleLocal, 5, 0, 2048, 2018, 9, Buffer);
            return ((Buffer.cdata[0] & 0x01) == 0x01);
        }
        public virtual bool FanucSetaPulsada()
        {
            return (FanucSetaPulsada(m_dMiManipulador));
        }
        public virtual bool FanucModoEdit(ushort HandleLocal)
        {
            bool b_EsEdit = false;

            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(HandleLocal, 5, 0, 1004, 1004, 9, Buffer);
            Buffer.cdata[0] = 2;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(HandleLocal, 9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
            Buffer.cdata[0] = 0;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(HandleLocal, 9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(HandleLocal, 9, 0, 3, 3, 9, Buffer);

            b_EsEdit = ((Buffer.cdata[0] >> 6) & 1) == 1;
            return (b_EsEdit);
        }
        public virtual bool FanucModoEdit()
        {
            bool b_EsEdit = false;

            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)5, (short)0,
                (ushort)1004, (ushort)1004, (ushort)9, Buffer);
            Buffer.cdata[0] = 2;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
            Buffer.cdata[0] = 0;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)9, (short)0,
                (ushort)3, (ushort)3, (ushort)9, Buffer);
                
            b_EsEdit = ((Buffer.cdata[0] >> 6) & 1) == 1;
            return (b_EsEdit);
        }
        public virtual bool FanucModoMem(ushort HandleLocal)
        {
            bool b_EsMem = false;

            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(HandleLocal, (short)1, (short)0,
                (ushort)3, (ushort)3, (ushort)9, Buffer);

            for (int i = 0; i < 10; i++)
            {

                m_TipoDireccion = 5;
                m_DireccionInicio = 1004;
                m_DireccionFin = 1004;
                ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(HandleLocal, (short)5, (short)0,
                    (ushort)1004, (ushort)1004, (ushort)9, Buffer);
                Buffer.cdata[0] = 1;
                ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(HandleLocal, (ushort)9, Buffer);
                Thread.Sleep(FANUC_RETARDO);
                Buffer.cdata[0] = 0;
                ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(HandleLocal, (ushort)9, Buffer);
                Thread.Sleep(FANUC_RETARDO);
                ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(HandleLocal, (short)1, (short)0,
                    (ushort)3, (ushort)3, (ushort)9, Buffer);
                b_EsMem = ((Buffer.cdata[0] >> 5) & 1) == 1;
                if (b_EsMem)
                    break;
            }
            return (b_EsMem);
        }
        public virtual bool FanucModoMem()
        {
            bool b_EsMem = false;

            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)1, (short)0,
                (ushort)3, (ushort)3, (ushort)9, Buffer);

            for (int i = 0; i < 10; i++)
            {

                m_TipoDireccion = 5;
                m_DireccionInicio = 1004;
                m_DireccionFin = 1004;
                ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)5, (short)0,
                    (ushort)1004, (ushort)1004, (ushort)9, Buffer);
                Buffer.cdata[0] = 1;
                ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
                Thread.Sleep(FANUC_RETARDO);
                Buffer.cdata[0] = 0;
                ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
                Thread.Sleep(FANUC_RETARDO);
                ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)1, (short)0,
                    (ushort)3, (ushort)3, (ushort)9, Buffer);
                b_EsMem = ((Buffer.cdata[0] >> 5) & 1) == 1;
                if (b_EsMem)
                    break;
            }
            return (b_EsMem);
        }
        public virtual bool FanucActivarDNC(ushort HandleLocal)
        {
            bool bEsDNC = false;
            for (int i = 0; i < 4; i++)
            {
                ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(HandleLocal, 5, 0, 1004, 1004, 9, Buffer);
                Buffer.cdata[0] = 8;
                ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(HandleLocal, 9, Buffer);
                Thread.Sleep(FANUC_RETARDO);
                Buffer.cdata[0] = 0;
                ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(HandleLocal, 9, Buffer);
                Thread.Sleep(FANUC_RETARDO);
                ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(HandleLocal, 1, 0, 3, 3, 9, Buffer);
                bEsDNC = ((Buffer.cdata[0] >> 4) & 1) == 1;
                if (bEsDNC)
                    return (true);
            }
            return (false);
        }
        public virtual bool FanucActivarDNC()
        {
            bool bEsDNC = false;
            for (int i = 0; i < 4; i++)
            {
                ret  = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, 5, 0, 1004, 1004, 9, Buffer);
                Buffer.cdata[0] = 8;
                ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, 9, Buffer);
                Thread.Sleep(FANUC_RETARDO);
                Buffer.cdata[0] = 0;
                ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, 9, Buffer);
                Thread.Sleep(FANUC_RETARDO);
                ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, 1, 0, 3, 3, 9, Buffer);
                bEsDNC = ((Buffer.cdata[0] >> 4) & 1) == 1;
                if (bEsDNC)
                    return (true);
            }
            return (false);
        }
        public virtual bool FanucModoMDI()
        {
            byte by_valor = 4;
            bool b_EsMDI = false;

            for (int i = 0; i < 10; i++)
            {
                ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)5, (short)0,
                    (ushort)1004, (ushort)1004, (ushort)9, Buffer);
                Buffer.cdata[0] |= by_valor;
                ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
                Thread.Sleep(FANUC_RETARDO);
                Buffer.cdata[0] &= (byte)(~by_valor);
                ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
                Thread.Sleep(FANUC_RETARDO);
                ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)1, (short)0,
                    (ushort)3, (ushort)3, (ushort)9, Buffer);

                b_EsMDI = ((Buffer.cdata[0] >> 3) & 1) == 1;
                if (b_EsMDI)
                    break;
            }
            return (b_EsMDI);

        }
        public virtual bool FanucModoJOG()
        {
            byte by_valor = 0x20;
            bool b_EsJOG = false;

            m_bParadaEmergencia = false;

            for (int i = 0; i < 10; i++)
            {

                m_TipoDireccion = 5;
                m_DireccionInicio = 1006;
                m_DireccionFin = 1006;
                ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)5, (short)0,
                    (ushort)1006, (ushort)1006, (ushort)9, Buffer);
                Buffer.cdata[0] |= by_valor;
                ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
                Thread.Sleep(FANUC_RETARDO);
                Buffer.cdata[0] &= (byte)(~(int)by_valor);
                ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
                Thread.Sleep(FANUC_RETARDO);
                m_TipoDireccion = 1;
                m_DireccionInicio = 3;
                m_DireccionFin = 3;
                ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)1, (short)0,
                    (ushort)3, (ushort)3, (ushort)9, Buffer);
                b_EsJOG = ((Buffer.cdata[0] >> 2) & 1) == 1;
            }

            return (b_EsJOG);
        }
        public virtual void FanucKeyCycleStart()
        {
            byte by_valor = 2;
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)5, (short)0,
                (ushort)1006, (ushort)1006, (ushort)9, Buffer);
            Buffer.cdata[0] |= by_valor;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
            Buffer.cdata[0] &= (byte)(~(int)by_valor);
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
        }
        public void FanucKeyCycleStart (ushort HandleLocal)
        {
            byte by_valor = 2;
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(HandleLocal, 5, 0, 1006, 1006, 9, Buffer);
            Buffer.cdata[0] |= by_valor;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(HandleLocal, 9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
            Buffer.cdata[0] &= (byte)(~(int)by_valor);
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(HandleLocal, 9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
        }
        public virtual void FanucKeyCycleStop()
        {
            byte by_valor = 1;
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)5, (short)0,
                (ushort)1006, (ushort)1006, (ushort)9, Buffer);
            Buffer.cdata[0] = by_valor;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
            by_valor = 0;
            Buffer.cdata[0] = by_valor;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
        }
        public virtual bool IsBitSet (byte value, ushort bitNumber)
        {
            return ((value & (1 << bitNumber)) != 0);
        }
        public bool FanucEnviarProgramaThread(string Nombre, short dNumPrograma)
        {
            if (m_ReaderDNC != null)
                m_ReaderDNC.Close();
            m_ReaderDNC = new StreamReader(Nombre);
            if (m_ReaderDNC == null)
                return(false);
            m_dNumPrograma = dNumPrograma;
            m_bEnabledDNC = true;
            return (true);
        }
        public bool FanucEnviarPrograma(string Nombre, short prog_number)
        {
            short DCNReturn = 0;
            int len, n;
            string line = "\n"; ;
            ret = (Focas1.focas_ret)Focas1.cnc_delete (m_dMiManipulador, prog_number);
            FanucModoEdit();
            FanucPararProgramaActivo();
            FanucBorrarFicheroActivo(prog_number);
            FanucReset();
            ret = (Focas1.focas_ret)Focas1.cnc_wrmacro(m_dMiManipulador, 542, 10, 0, 0);
            ret = (Focas1.focas_ret)Focas1.cnc_search(m_dMiManipulador, prog_number);
            FanucActivarDNC();
            FanucKeyCycleStart();

            ret = (Focas1.focas_ret)Focas1.cnc_dncend2(m_dMiManipulador, DCNReturn);   // Por si estaba enviando algo.
            Thread.Sleep(50);
            ret = (Focas1.focas_ret)Focas1.cnc_dncstart2(m_dMiManipulador, "O01234");
            if (ret != Focas1.EW_OK)
                return (false);
            len = line.Length;
            ret = (Focas1.focas_ret)Focas1.cnc_dnc2(m_dMiManipulador, ref len, line);
            if (ret != Focas1.EW_OK)
                return (false);
            StreamReader reader = new StreamReader(Nombre);
            bool bSalirse = false;
            while (!bSalirse)
            { 
                if (reader.Peek() == -1)
                {
                    reader.Close();
                    ret = (Focas1.focas_ret)Focas1.cnc_dncend2(m_dMiManipulador, DCNReturn);
                    bSalirse = true;
                    break;
                }
                String Cadena = reader.ReadLine();
                String Linea = String.Copy(Cadena)+"\n";
                len = Linea.Count();
                while (len > 0)
                {
                    n = len;
                    ret = (Focas1.focas_ret)Focas1.cnc_dnc2(m_dMiManipulador, ref n, Linea);
                    if (ret == Focas1.focas_ret.EW_BUFFER)
                        continue;
                    if (ret == Focas1.focas_ret.EW_OK)
                    {
                        Linea = Linea.Substring(n);
                        len -= n;
                    }
                    else
                    {
                        reader.Close();
                        ret = (Focas1.focas_ret)Focas1.cnc_dncend2(m_dMiManipulador, DCNReturn);
                        bSalirse = true;
                        break;
                    }
                }
            }
            if (ret != Focas1.EW_OK)
                return (false);
            return (true);
        }
        public virtual bool FanucEnviarFicheroDataServer (ushort HandleLocal, string FicheroISO, Int32 dNumeroPrograma)
        {
            return (true);
        }
        public override bool GenerarFicheroISO(Trabajo Work, string Fichero)
        {
            StreamWriter StreamFileISO = new StreamWriter(Fichero);
            StreamFileISO.Write("O1234\n");
            StreamFileISO.Write("G90\n");
            foreach (Pieza f in Work.m_Piezas)
            { 
                foreach (Bloque b in f.m_Bloques)
                {
                   if (!b.m_bEsMovimientoCorte)
                        continue;
                    foreach (MaquinaNormal m in m_Maquinas)
                    {
                        if (b.m_MachinaCode == m.m_MachinaCode)
                        {
                            //StreamFileISO.Write("G68 {0}{1} {2}{3} R{4}\n", 
                            //    m.m_EjesX[0].m_NombreEjeISO, Work.m_TraslacionX, 
                            //    m.m_EjesY[0].m_NombreEjeISO, Work.m_TraslacionY, Work.m_RotacionActual);    // En el simulador no funciona
                            m.PosicionadoBloque(StreamFileISO, b);
                            m.PrepararProcesadoBloque(StreamFileISO, b);
                            m.Bloque2ISO(StreamFileISO, b);
                            m.PrepararSalidaProcesadoCorte(StreamFileISO, b);
                            //StreamFileISO.Write("G69\n");                                                   // En el simulador no funciona
                            break;
                        }
                    }
                }
            }
            StreamFileISO.Write("M30\n");
            StreamFileISO.Write("%\n");
            StreamFileISO.Close();

            return (true);
        }
        public override bool GenerarSubrutinas(string Fichero)
        {
            int n = 1;
            StreamWriter StreamFileCNC = new StreamWriter(Fichero);
            if (StreamFileCNC == null)
                return (false);

//
//  -- Encender Herramienta
//

            StreamFileCNC.Write("O1500\n"); 
            foreach (Herramienta h in m_Herramientas)
            {
                h.EscribirSubrutina_EncenderHerramienta(StreamFileCNC, n);
                n += 50;
            }
            StreamFileCNC.Write("N1000000 M99\n");
            StreamFileCNC.Write("M30\n");
            StreamFileCNC.Write("%\n\n");

//
//  -- Apagar Herramienta
//

            n = 1;
            StreamFileCNC.Write("O1501\n");
            foreach (Herramienta h in m_Herramientas)
            {
                h.EscribirSubrutina_ApagarHerramienta(StreamFileCNC, n);
                n += 50;
            }
            StreamFileCNC.Write("N1000000 M99\n");
            StreamFileCNC.Write("M30\n");
            StreamFileCNC.Write("%\n\n");

//
//  -- Subrutina de cebado.
//

            n = 1;
            StreamFileCNC.Write("O1502\n");
            StreamFileCNC.Write("M53\n#500=0.011\nM53\n");
            foreach (MaquinaNormal M in m_Maquinas)
            {
                int dLineaMaquina = n-1+100*m_TecnologiasCebado.Count;
                StreamFileCNC.Write("\nIF [#1 NE {0}] GOTO {1} (Maquina indice = {0})\n", M.m_dMachinaIndex, dLineaMaquina);
                if (M.m_EjesA.Count > 0)            // Existe bisel
                    StreamFileCNC.Write("G49\n");
                foreach (EjeMaquina E in M.m_EjesZ) // Reset de ejes Z
                {
                    if (E.m_dCodigoEje != 2)
                        continue;
                    StreamFileCNC.Write("G92.1{0}0\n", E.m_NombreEjeISO);
                }
                StreamFileCNC.Write("M14\nIF [#3 EQ -1] GOTO 999999\n");

                foreach (TecnologiaCebado C in m_TecnologiasCebado)
                {
                    if (!M.m_bTecnologiasCebado[C.m_dTipoCebado])
                        continue;
                    C.GenerarSubrutinaCebado(StreamFileCNC, M, n);
                    n += 100;
                }

                StreamFileCNC.Write("N{0}\n", dLineaMaquina);
            }
            StreamFileCNC.Write("N999999 \n");
            if (((FanucGeneral2.u.bFlagMecanizado >> 6) & 1) == 1)
                StreamFileCNC.Write("M28 (esperar al z del canal 2)\n");
            if (FanucGeneral.u.bEjeVirtualActivo == 1)
                StreamFileCNC.Write("M53\nM132\nM53\nM130\n");
            StreamFileCNC.Write("M53\n#500=0.012\nM53\n");

            StreamFileCNC.Write("N1000000 M99\n");
            StreamFileCNC.Write("M30\n");
            StreamFileCNC.Write("%\n\n");

//
//  -- Subrutina de segunda y tercera altura de cebado.
//

            n = 1;
            StreamFileCNC.Write("O1503\n");
            foreach (Herramienta h in m_Herramientas)
            {
                h.EscribirSubrutina_AlturaPostCebado(StreamFileCNC, n);
                n += 100;
            }
            StreamFileCNC.Write("N1000000 M99\n");
            StreamFileCNC.Write("M30\n");
            StreamFileCNC.Write("%\n\n");

//
//  -- Subrutina de primera y segunda altura de corte.
//

            n = 1;
            StreamFileCNC.Write("O1504\n");
            foreach (Herramienta h in m_Herramientas)
            {
                h.EscribirSubrutina_AlturaCorte(StreamFileCNC, n);
                n += 100;
            }
            StreamFileCNC.Write("N1000000 M99\n");
            StreamFileCNC.Write("M30\n");
            StreamFileCNC.Write("%\n\n");

//
//  -- Subrutina de altura de vacío.
 //

            n = 1;
            StreamFileCNC.Write("O1505\n");
            foreach (MaquinaNormal M in m_Maquinas)
            {
                M.EscribirSubrutina_AlturaVacio(StreamFileCNC, n);
                n += 50;
            }
            StreamFileCNC.Write("N1000000 M99\n");
            StreamFileCNC.Write("M30\n");
            StreamFileCNC.Write("%\n\n");

            StreamFileCNC.Close();
            return (true);
        }
        public override bool EnviarSubrutinas(string Fichero, bool bMem, bool bUser)
        {
            StreamReader StreamFileCNC = new StreamReader(Fichero);
            if (StreamFileCNC == null)
                return (false);

            String linea;
            int n;
            short dNumeroPrograma;

            FanucActivarKey (m_dMiManipulador);
            FanucPararProgramaActivo (m_dMiManipulador);
	        FanucReset (m_dMiManipulador);

	        FanucModoEdit (m_dMiManipulador);
	        prmDataNoAxis.datano = 20;
	        prmDataNoAxis.type = 0;

	        ret = (Focas1.focas_ret)Focas1.cnc_rdparam (m_dMiManipulador, 20, 0, 5, prmDataNoAxis);
	        prmDataNoAxis.cdata = 4;
	        Thread.Sleep(FANUC_RETARDO);
            ret = (Focas1.focas_ret)Focas1.cnc_wrparam (m_dMiManipulador, 5, prmDataNoAxis);

//
//      -- Siempre se envía las subrutinas al CNC en directorio nuevo.
//

	        char []CarpetaOriginalRutinas = new char[256];
            ret = (Focas1.focas_ret)Focas1.cnc_rdpdf_curdir(m_dMiManipulador, 1, CarpetaOriginalRutinas);
            ret = (Focas1.focas_ret)Focas1.cnc_wrpdf_curdir(m_dMiManipulador, 1, "//CNC_MEM/MTB1/");
            ret = (Focas1.focas_ret)Focas1.cnc_delall(m_dMiManipulador);
	        FanucModoEdit ();
            ret = (Focas1.focas_ret)Focas1.cnc_delall(m_dMiManipulador);

            if (bMem)
            {
                prmDataNoAxis.datano = 20;
                prmDataNoAxis.type = 0;
                ret = (Focas1.focas_ret)Focas1.cnc_rdparam(m_dMiManipulador, 20, 0, 5, prmDataNoAxis);
                prmDataNoAxis.cdata = 4;
                Thread.Sleep(FANUC_RETARDO);
                ret = (Focas1.focas_ret)Focas1.cnc_wrparam(m_dMiManipulador, 5, prmDataNoAxis);
                StreamFileCNC.BaseStream.Seek(0, SeekOrigin.Begin);
                while (!StreamFileCNC.EndOfStream) 
                {

//
//	-- Buscamos número de programa
//

                    do
                    {
                        while ((linea = StreamFileCNC.ReadLine()) == null) 
                            break;
                        if (linea == null)
                            break;
                        linea += "\n";
                    } while (linea[0] != 'O');
                    if (StreamFileCNC.EndOfStream)
                            break;
                    dNumeroPrograma = Convert.ToInt16(linea.Substring(1));
                    FanucModoEdit (m_dMiManipulador);

                    ret = (Focas1.focas_ret)Focas1.cnc_dwnstart4(m_dMiManipulador, 0, "//CNC_MEM/MTB1/");
                    linea = String.Format ("\nO{0:0000}\n", dNumeroPrograma);
                    while (linea[0] != '%')
                    {
                        n = linea.Length;
                        ret = (Focas1.focas_ret)Focas1.cnc_download4(m_dMiManipulador, ref n, linea);
                        if (ret == Focas1.focas_ret.EW_HANDLE)
                        {
                            StreamFileCNC.Close();
                            return (false);
                        }
                        if (n < linea.Length)
		    	        {
                            Thread.Sleep(150);
                            linea = linea.Substring(n);
                            n = linea.Length;
                            ret = (Focas1.focas_ret)Focas1.cnc_download4(m_dMiManipulador, ref n, linea);
                        }
                        if (ret == Focas1.focas_ret.EW_BUFFER)
                            continue;
                        if (ret == Focas1.focas_ret.EW_OK)
                        {
                            if ((linea = StreamFileCNC.ReadLine()) == null) 
                                break;
                            linea += "\n";
                            n = linea.Length;
                        }
                        if (ret != Focas1.focas_ret.EW_OK)
                        {
                            ret = (Focas1.focas_ret)Focas1.cnc_getdtailerr(m_dMiManipulador, err);
                            break;
                        }
                    }
                    n = 1;

                    ret = (Focas1.focas_ret)Focas1.cnc_download4(m_dMiManipulador, ref n, linea);
                    ret = (Focas1.focas_ret)Focas1.cnc_dwnend4(m_dMiManipulador);
                }
            }

//
//      -- Siempre se envías las subrutinas al CNC (por los programas MDI).
//

	        FanucModoEdit ();
            ret = (Focas1.focas_ret)Focas1.cnc_wrpdf_curdir(m_dMiManipulador, 1, "//CNC_MEM/USER/PATH1/");
            ret = (Focas1.focas_ret)Focas1.cnc_delall(m_dMiManipulador);
            if (bUser)
            {
                FanucModoEdit (m_dMiManipulador);
                StreamFileCNC.BaseStream.Seek(0, SeekOrigin.Begin);
                while (!StreamFileCNC.EndOfStream)
                {
                    do
                    {
                        while ((linea = StreamFileCNC.ReadLine()) == null)
                            break;
                        if (linea == null)
                            break;
                        linea += "\n";
                    } while (linea[0] != 'O');
                    if (StreamFileCNC.EndOfStream)
                        break;
                    dNumeroPrograma = Convert.ToInt16(linea.Substring(1));
                    FanucModoEdit(m_dMiManipulador);

                    ret = (Focas1.focas_ret)Focas1.cnc_dwnstart3(m_dMiManipulador, 0);
                    linea = String.Format("\nO{0:0000}\n", dNumeroPrograma);
                    while (linea[0] != '%')
                    {
                        n = linea.Length;
                        ret = (Focas1.focas_ret)Focas1.cnc_download3 (m_dMiManipulador, ref n, linea);
    			        if (n < linea.Length)
	    		        {
                            Thread.Sleep(150);
                            linea = linea.Substring(n);
                            n = linea.Length;
                            ret = (Focas1.focas_ret)Focas1.cnc_download3 (m_dMiManipulador, ref n, linea);
    			        }
                        if (ret == Focas1.focas_ret.EW_HANDLE)
                        {
                            StreamFileCNC.Close();
                            return (false);
                        }
                        if (ret == Focas1.focas_ret.EW_BUFFER)
                            continue;
                        if (ret == Focas1.focas_ret.EW_OK)
                        {
                            if ((linea = StreamFileCNC.ReadLine()) == null) 
                                break;
                            linea += "\n";
                            n = linea.Length;
                        }
                        if (ret != Focas1.focas_ret.EW_OK)
                            break;
                    }
                    n = 1;

                    ret = (Focas1.focas_ret)Focas1.cnc_download3 (m_dMiManipulador, ref n, linea);
                    ret = (Focas1.focas_ret)Focas1.cnc_dwnend3 (m_dMiManipulador);
                }

	            StreamFileCNC.Close ();
            }

    	    ret = (Focas1.focas_ret)Focas1.cnc_wrpdf_curdir (m_dMiManipulador, 1, CarpetaOriginalRutinas);
            prmDataNoAxis.datano = 3457;
	        prmDataNoAxis.type = 0;
	        ret = (Focas1.focas_ret)Focas1.cnc_rdparam (m_dMiManipulador, 20, 0, 5, prmDataNoAxis);
            prmDataNoAxis.cdata = 0x8B;
	        ret = (Focas1.focas_ret)Focas1.cnc_wrparam (m_dMiManipulador, 5, prmDataNoAxis);

            prmDataNoAxis.datano = 20;
       	    prmDataNoAxis.type = 0;
            ret = (Focas1.focas_ret)Focas1.cnc_rdparam (m_dMiManipulador, 20, 0, 5, prmDataNoAxis);
            /*
            if (FanucGeneral->bEnviarDataServer)
        	    prmDataNoAxis.cdata = 5;
            else
        	    prmDataNoAxis.cdata = 15;
            */
            Thread.Sleep(FANUC_RETARDO);
            ret = (Focas1.focas_ret)Focas1.cnc_wrparam (m_dMiManipulador, 5, prmDataNoAxis);

            return (true);
        }
        public override bool LeerConfiguracionAutomata()
        {
            UInt16 TamanoBuffer;
            UInt16 Tamano = 10240;
            byte[] bytes = new byte[Tamano]; 
            UInt16 m = 0;
            byte[] DatosBytes = FanucGeneral.getBytes();
            do
            {
                TamanoBuffer = Math.Min((UInt16)255, Tamano);
                ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, 9, 0, m, (UInt16)(m+TamanoBuffer),
                    (UInt16)(TamanoBuffer + 9), Buffer);
                if (ret != (Focas1.focas_ret)Focas1.EW_OK)
                    break;
                Array.Copy(Buffer.cdata, 0, bytes, m, TamanoBuffer);
                Tamano -= TamanoBuffer;
                m += TamanoBuffer;
                Thread.Sleep(FANUC_RETARDO_MANUAL);
            } while (Tamano > 0);

            LeerConfiguracionAutomataMemoryStream(bytes);

            return (Tamano > 0);
        }
        public override bool LeerConfiguracionAutomata(String Fichero)
        {
            FileStream file = new FileStream(Fichero, FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[file.Length];
            file.Read(bytes, 0, (int)file.Length);
            LeerConfiguracionAutomataMemoryStream (bytes);
            file.Close();
            return (true);
        }
        public bool LeerConfiguracionAutomataMemoryStream(byte[] Memoria)
        {
            LeerFanucGeneral(Memoria);
            LeerFanucCarenados(Memoria);
            LeerFanucLimitesSoftware(Memoria);
            LeerFanucCompuertas(Memoria);
            LeerFanucEjesX(Memoria);
            LeerFanucEjesY(Memoria);
            LeerFanucEjesZ(Memoria);
            LeerFanucEjesV(Memoria);
            LeerFanucEjesW(Memoria);
            LeerFanucPlasmaSoplete(Memoria);
            LeerFanucVariablesMacros(Memoria);
            LeerFanucSubrutinas(Memoria);
            LeerFanucGeneral2(Memoria);
            LeerFanucGeneral3(Memoria);
            return (true);
        }
        protected override void ActualizarVariablesSistemaTecoi()
        {
            int dIndiceX = 0;
            int dIndiceY = 0;
            int dIndiceZ = 0;
            int dIndiceA = 0;
            int dIndiceB = 0;
            foreach (EjeMaquina E in m_EjeMaquina)
            {
                switch (E.m_dCodigoEje)
                {
                    case 0: // Eje X
                        E.m_lfLimiteSuperior = FanucLimitesSoftware[dIndiceX].u.dHasta;
                        E.m_lfLimiteInferior = FanucLimitesSoftware[dIndiceX].u.dDesde;
                        ++dIndiceX;
                        break;
                    case 1: // Eje Y
                        E.m_lfLimiteSuperior = FanucLimitesSoftware[2+dIndiceY].u.dHasta;
                        E.m_lfLimiteInferior = FanucLimitesSoftware[2+dIndiceY].u.dDesde;
                        ++dIndiceY;
                        break;
                    case 2: // Eje Z
                        E.m_lfLimiteSuperior = FanucLimitesSoftware[8+dIndiceZ].u.dHasta;
                        E.m_lfLimiteInferior = FanucLimitesSoftware[8+dIndiceZ].u.dDesde;
                        ++dIndiceZ;
                        break;
                    case 3: // Eje A
                        E.m_lfLimiteSuperior = FanucLimitesSoftware[10+dIndiceA].u.dHasta;
                        E.m_lfLimiteInferior = FanucLimitesSoftware[10+dIndiceA].u.dDesde;
                        ++dIndiceA;
                        break;
                    case 4: // Eje B
                        E.m_lfLimiteSuperior = FanucLimitesSoftware[10+dIndiceB].u.dHasta;
                        E.m_lfLimiteInferior = FanucLimitesSoftware[10+dIndiceB].u.dDesde;
                        ++dIndiceB;
                        break;
                }
            }

            m_FanucGlobalVariables.m_dFondoEscalaLaserCebado = FanucGeneral3.u.dFondoEscalaLaserCebado;
            m_FanucGlobalVariables.m_dMinDistanciaLaserCebado = FanucGeneral3.u.dMinDistanciaLaserCebado;
            m_FanucGlobalVariables.m_OffsetZCebadoLaser = FanucGeneral2.u.OffsetZCebadoLaser;
            m_FanucGlobalVariables.m_bExisteSegundoCanalAutomata = ((FanucGeneral2.u.bFlagMecanizado >> 6) & 1) == 1;
            m_FanucGlobalVariables.m_bExisteAlturaFanuc = ((FanucGeneral2.u.bFlags3 >> 2) & 1) == 1;
        }
        public bool LeerFanucGeneral(byte[] Memoria) //  -- Leer Fanuc General D1100 - D1450 --> 350
        {
            byte[] DatosBytes = new byte[FanucGeneral.TamanoArray()];
            Array.Copy(Memoria, 1100, DatosBytes, 0, DatosBytes.Length);
            FanucGeneral.fromBytes(DatosBytes);
            m_FanucGlobalVariables.dGiroAnguloBisel = FanucGeneral.u.dGiroAnguloBisel;
            return (true);
        }
        public bool LeerFanucCarenados(byte[] Memoria) //  -- Leer Fanuc Carenados D1450 - D1600 --> 4x30
        {
            for (int i = 0; i < MAX_CARENADOS; i++)
            {
                byte[] DatosBytes = FanucCarenados[i].getBytes();
                int Inicio = 1450+i*30;
                Array.Copy(Memoria, Inicio, DatosBytes, 0, DatosBytes.Length);
                FanucCarenados[i].fromBytes(DatosBytes);
            }
            return (true);
        }
        public bool LeerFanucCompuertas(byte[] Memoria) //  -- Leer Fanuc Compuertas D16000 - D2000 --> 48x8
        {
            for (int i = 0; i < MAX_COMPUERTAS; i++)
            {
                byte[] DatosBytes = FanucCompuertas[i].getBytes();
                int Inicio = 1600+i*8;
                Array.Copy(Memoria, Inicio, DatosBytes, 0, DatosBytes.Length);
                FanucCompuertas[i].fromBytes(DatosBytes);
            }
            return (true);
        }
        public bool LeerFanucEjesX(byte[] Memoria) //  -- Leer Fanuc Ejes X D2000 - D2200 --> 2x100
        {
            for (int i = 0; i < MAX_EJES_X; i++)
            {
                byte[] DatosBytes = FanucEjeX[i].getBytes();
                int Inicio = 2000+i*100;
                Array.Copy(Memoria, Inicio, DatosBytes, 0, DatosBytes.Length);
                FanucEjeX[i].fromBytes(DatosBytes);
            }
            return (true);
        }
        public bool LeerFanucEjesY(byte[] Memoria) //  -- Leer Fanuc Ejes Y D2000 - D2800 --> 6x100
        {
            for (int i = 0; i < MAX_EJES_Y; i++)
            {
                byte[] DatosBytes = FanucEjeY[i].getBytes();
                int Inicio = 2200+i*100;
                Array.Copy(Memoria, Inicio, DatosBytes, 0, DatosBytes.Length);
                FanucEjeY[i].fromBytes(DatosBytes);
            }
            return (true);
        }
        public bool LeerFanucEjesZ(byte[] Memoria) //  -- Leer Fanuc Ejes Z D2800 - D3400 --> 6x100
        {
            for (int i = 0; i < MAX_EJES_Z; i++)
            {
                byte[] DatosBytes = FanucEjeZ[i].getBytes();
                int Inicio = 2800+i*100;
                Array.Copy(Memoria, Inicio, DatosBytes, 0, DatosBytes.Length);
                FanucEjeZ[i].fromBytes(DatosBytes);
            }
            return (true);
        }
        public bool LeerFanucEjesV(byte[] Memoria) //  -- Leer Fanuc Ejes A D3400 - D4000 --> 6x100
        {
            for (int i = 0; i < MAX_EJES_V; i++)
            {
                byte[] DatosBytes = FanucEjeV[i].getBytes();
                int Inicio = 3400+i*100;
                Array.Copy(Memoria, Inicio, DatosBytes, 0, DatosBytes.Length);
                FanucEjeV[i].fromBytes(DatosBytes);
            }
            return (true);
        }
        public bool LeerFanucEjesW(byte[] Memoria) //  -- Leer Fanuc Ejes B D4000 - D4600 --> 6x100
        {
            for (int i = 0; i < MAX_EJES_W; i++)
            {
                byte[] DatosBytes = FanucEjeW[i].getBytes();
                int Inicio = 4000+i*100;
                Array.Copy(Memoria, Inicio, DatosBytes, 0, DatosBytes.Length);
                FanucEjeW[i].fromBytes(DatosBytes);
            }
            return (true);
        }
        public bool LeerFanucPlasmaSoplete(byte[] Memoria) //  -- Leer Fanuc Plasma/Soplete D4600 - D6000 --> 6x250
        {
            for (int i = 0; i < MAX_PLASMA_SOPLETE; i++)
            {
                byte[] DatosBytes = FanucPlasmaSoplete[i].getBytes();
                int Inicio = 4600+i*250;
                Array.Copy(Memoria, Inicio, DatosBytes, 0, DatosBytes.Length);
                FanucPlasmaSoplete[i].fromBytes(DatosBytes);
            }
            return (true);
        }
        public bool LeerFanucLimitesSoftware(byte[] Memoria) //  -- Leer Fanuc Límites Software D6000 - D6208 --> 26x8
        {
            for (int i = 0; i < MAX_LIMITES_SOFTWARE; i++)
            {
                byte[] DatosBytes = FanucLimitesSoftware[i].getBytes();
                int Inicio = 6000+i*8;
                Array.Copy(Memoria, Inicio, DatosBytes, 0, DatosBytes.Length);
                FanucLimitesSoftware[i].fromBytes(DatosBytes);
            }
            return (true);
        }
        public bool LeerFanucVariablesMacros(byte[] Memoria) //  -- Leer Fanuc Variables Macro D6300 - D6400
        {
            byte[] DatosBytes = FanucVariablesMacros.getBytes();
            Array.Copy(Memoria, 6300, DatosBytes, 0, DatosBytes.Length);
            FanucVariablesMacros.fromBytes(DatosBytes);
            return (true);
        }
        public bool LeerFanucSubrutinas(byte[] Memoria) //  -- Leer Fanuc Subroutinas D6400 - D6600
        {
            byte[] DatosBytes = FanucSubrutinas.getBytes();
            Array.Copy(Memoria, 6400, DatosBytes, 0, DatosBytes.Length);
            FanucSubrutinas.fromBytes(DatosBytes);
            return (true);
        }
        public bool LeerFanucGeneral2(byte[] Memoria) //  -- Leer Fanuc General2 D6600 - 7000
        {
            byte[] DatosBytes = FanucGeneral2.getBytes();
            Array.Copy(Memoria, 6600, DatosBytes, 0, DatosBytes.Length);
            FanucGeneral2.fromBytes(DatosBytes);
            return (true);
        }
        public bool LeerFanucGeneral3(byte[] Memoria) //  -- Leer Fanuc General3 D3700 - 4000
        {
            byte[] DatosBytes = FanucGeneral3.getBytes();
            Array.Copy(Memoria, 3700, DatosBytes, 0, DatosBytes.Length);
            FanucGeneral3.fromBytes(DatosBytes);
            return (true);
        }
        public override bool EscribirConfiguracionAutomata()
        {
            UInt16 Tamano = 10240;
            byte[] Memoria = new byte[Tamano];

            EscribirFanucGeneral(Memoria);
            EscribirFanucCarenados(Memoria);
            EscribirFanucCompuertas(Memoria);
            EscribirFanucEjesX(Memoria);
            EscribirFanucEjesY(Memoria);
            EscribirFanucEjesZ(Memoria);
            EscribirFanucEjesV(Memoria);
            EscribirFanucEjesW(Memoria);
            EscribirFanucPlasmaSoplete(Memoria);
            EscribirFanucVariablesMacros(Memoria);
            EscribirFanucSubrutinas(Memoria);
            EscribirFanucGeneral2(Memoria);
            EscribirFanucGeneral3(Memoria);

            EscribirConfiguracionAutomataMemoryStream(Memoria);

            return (true);
        }
        public override bool EscribirConfiguracionAutomata(string Fichero)
        {
            UInt16 Tamano = 10240;
            byte[] Memoria = new byte[Tamano];

            EscribirFanucGeneral(Memoria);
            EscribirFanucCarenados(Memoria);
            EscribirFanucCompuertas(Memoria);
            EscribirFanucEjesX(Memoria);
            EscribirFanucEjesY(Memoria);
            EscribirFanucEjesZ(Memoria);
            EscribirFanucEjesV(Memoria);
            EscribirFanucEjesW(Memoria);
            EscribirFanucPlasmaSoplete(Memoria);
            EscribirFanucVariablesMacros(Memoria);
            EscribirFanucSubrutinas(Memoria);
            EscribirFanucGeneral2(Memoria);
            EscribirFanucGeneral3(Memoria);

            FileStream file = new FileStream(Fichero, FileMode.Open, FileAccess.Write);
            file.Write(Memoria, 0, (int)file.Length);
            file.Close();

            EscribirConfiguracionAutomataMemoryStream(Memoria);

            return (true);
        }
        public bool EscribirConfiguracionAutomataMemoryStream(byte[] bytes)
        {
            short TamanoBuffer;
            short Tamano = 10240;
            short m = 0;
            byte[] DatosBytes = FanucGeneral.getBytes();
            Buffer.type_a = 9;  // Tipo de memoria: D.
            Buffer.type_d = 0;  // Tamaño del dato: 1 byte
            do
            {
                TamanoBuffer = Math.Min((short)255, Tamano);
                Buffer.datano_s = m;
                Buffer.datano_e = TamanoBuffer;
                ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (UInt16)(TamanoBuffer+9), Buffer);
                if (ret != (Focas1.focas_ret)Focas1.EW_OK)
                    return (false);
                Array.Copy(Buffer.cdata, TamanoBuffer, bytes, m, TamanoBuffer);
                Tamano -= TamanoBuffer;
                m += TamanoBuffer;
                Thread.Sleep(FANUC_RETARDO_MANUAL);
            } while (m_Tamano > 0);

            return (true);
        }
        public bool EscribirFanucGeneral(byte[] Memoria) //  -- Escribir Fanuc General D1100 - D1450 --> 350
        {
            byte[] DatosBytes = FanucGeneral.getBytes();
            Array.Copy(DatosBytes, 0, Memoria, 1100, DatosBytes.Length);
            return (true);
        }
        public bool EscribirFanucCarenados(byte[] Memoria) //  -- Escribir Fanuc Carenados D1450 - D1600 --> 4x30
        {
            for (int i = 0; i < MAX_CARENADOS; i++)
            {
                byte[] DatosBytes = FanucCarenados[i].getBytes();
                int Inicio = 1450 + i * 30;
                Array.Copy(DatosBytes, 0, Memoria, Inicio, DatosBytes.Length);
            }
            return (true);
        }
        public bool EscribirFanucLimitesSoftware(byte[] Memoria) //  -- Escribir Fanuc Carenados D1450 - D1600 --> 4x30
        {
            for (int i = 0; i < MAX_LIMITES_SOFTWARE; i++)
            {
                byte[] DatosBytes = FanucLimitesSoftware[i].getBytes();
                int Inicio = 6000 + i * 8;
                Array.Copy(DatosBytes, 0, Memoria, Inicio, DatosBytes.Length);
            }
            return (true);
        }
        public bool EscribirFanucCompuertas(byte[] Memoria) //  -- Escribir Fanuc Compuertas D16000 - D2000 --> 48x8
        {
            for (int i = 0; i < MAX_COMPUERTAS; i++)
            {
                byte[] DatosBytes = FanucCompuertas[i].getBytes();
                int Inicio = 1600 + i * 8;
                Array.Copy(DatosBytes, 0, Memoria, Inicio, DatosBytes.Length);
            }
            return (true);
        }
        public bool EscribirFanucEjesX(byte[] Memoria) //  -- EscribirFanuc Ejes X  D2000 - D2200 --> 2x16
        {
            for (int i = 0; i < MAX_EJES_X; i++)
            {
                byte[] DatosBytes = FanucEjeX[i].getBytes();
                int Inicio = 2000+i* 00;
                Array.Copy(DatosBytes, 0, Memoria, Inicio, DatosBytes.Length);
            }
            return (true);
        }
        public bool EscribirFanucEjesY(byte[] Memoria) //  -- Escribir Fanuc Ejes Y D2000 - D2800 --> 6x100
        {
            for (int i = 0; i < MAX_EJES_Y; i++)
            {
                byte[] DatosBytes = FanucEjeY[i].getBytes();
                int Inicio = 2200+i*100;
                Array.Copy(DatosBytes, 0, Memoria, Inicio, DatosBytes.Length);
            }
            return (true);
        }
        public bool EscribirFanucEjesZ(byte[] Memoria) //  -- Escribir Fanuc Ejes Z D2800 - D3400 --> 6x100
        {
            for (int i = 0; i < MAX_EJES_Z; i++)
            {
                byte[] DatosBytes = FanucEjeZ[i].getBytes();
                int Inicio = 2800+i*100;
                Array.Copy(DatosBytes, 0, Memoria, Inicio, DatosBytes.Length);
            }
            return (true);
        }
        public bool EscribirFanucEjesV(byte[] Memoria) //  -- Escribir Fanuc Ejes A D3400 - D4000 --> 6x100
        {
            for (int i = 0; i < MAX_EJES_V; i++)
            {
                byte[] DatosBytes = FanucEjeV[i].getBytes();
                int Inicio = 3400+i*100;
                Array.Copy(DatosBytes, 0, Memoria, Inicio, DatosBytes.Length);
            }
            return (true);
        }
        public bool EscribirFanucEjesW(byte[] Memoria) //  -- Escribir Fanuc Ejes B D4000 - D4600 --> 6x100
        {
            for (int i = 0; i < MAX_EJES_W; i++)
            {
                byte[] DatosBytes = FanucEjeW[i].getBytes();
                int Inicio = 4000+i*100;
                Array.Copy(DatosBytes, 0, Memoria, Inicio, DatosBytes.Length);
            }
            return (true);
        }
        public bool EscribirFanucPlasmaSoplete(byte[] Memoria) //  -- Escribir Fanuc Plasma/Soplete D4600 - D6000 --> 6x250
        {
            for (int i = 0; i < MAX_PLASMA_SOPLETE; i++)
            {
                byte[] DatosBytes = FanucPlasmaSoplete[i].getBytes();
                int Inicio = 4600+i*250;
                Array.Copy(DatosBytes, 0, Memoria, Inicio, DatosBytes.Length);
            }
            return (true);
        }
        public bool EscribirFanucVariablesMacros(byte[] Memoria) //  -- Escribir Fanuc Variabels Macro D6300 - D6400
        {
            byte[] DatosBytes = FanucVariablesMacros.getBytes();
            Array.Copy(DatosBytes, 0, Memoria, 6300, DatosBytes.Length);
            return (true);
        }
        public bool EscribirFanucSubrutinas(byte[] Memoria) //  -- Escribir Fanuc Subroutinas D6400 - D6600
        {
            byte[] DatosBytes = FanucSubrutinas.getBytes();
            Array.Copy(DatosBytes, 0, Memoria, 6400, DatosBytes.Length);
            return (true);
        }
        public bool EscribirFanucGeneral2(byte[] Memoria) //  -- Escribir Fanuc General2 D6600 - 7000
        {
            byte[] DatosBytes = FanucGeneral2.getBytes();
            Array.Copy(DatosBytes, 0, Memoria, 6600, DatosBytes.Length);
            return (true);
        }
        public bool EscribirFanucGeneral3(byte[] Memoria) //  -- Escribir Fanuc General2 D3700 - 4000
        {
            byte[] DatosBytes = FanucGeneral3.getBytes();
            Array.Copy(DatosBytes, 0, Memoria, 3700, DatosBytes.Length);
            return (true);
        }
        public bool FanucActivarMirrorMulticabezal(short dIndiceEje, bool bActivo)
        {
            LeerParametro_IODBPSD_1 ((short)8312, dIndiceEje, (short)6);
            prmDataNoAxis.idata = (short)(bActivo ? 100 : 0);
            EscribirParametro_IODBPSD_1 ((short)6);
            return (true);
        }
        public bool FanucActivarEsclavoMulticabezal(short dIndiceEje, bool bActivar, short dEjeIndiceMaster)
        {

//
//	-- Valor G138 de sincronización.
//

            ushort Direccion = (ushort)(138+1000*(dIndiceEje/8));
            LeerMemoriaAutomata ((short)0, Direccion, Direccion);
            byte Valor  = (byte)(1 << dIndiceEje%8);
            if (bActivar)
		        Buffer.cdata[0] |= Valor;
            else
		        Buffer.cdata[0] &= (byte)(~Valor);
	        EscribirMemoriaAutomata (Direccion, Direccion);
        
            Direccion = (ushort)(140+1000*(dIndiceEje/8));
	        Buffer.datano_s = (short)Direccion;
	        Buffer.datano_e = (short)Direccion;
	        EscribirMemoriaAutomata (Direccion, Direccion);

//
//	-- Activar variables de tipo macro correspondientes.
//

            float Valor_float = (float)0.0;
            LeerMacro(m_dMiManipulador, (short)501, ref Valor_float);
            int i;
            for (i = 0; i < MAX_EJES_Y; i++)
        	    if (m_EjeMaquina[i].m_dIndiceEje == dIndiceEje)
                    	break;
            if (i < MAX_EJES_Y)
            {
		        ushort Valor_ushort = (ushort)Valor_float;
        	    if (bActivar)
	        	    Valor_ushort |= (ushort)(1 << i);
	            else
		            Valor_ushort &= (ushort)(~(1 << i));
                EscribirMacro(m_dMiManipulador, (short)501, (float)(Valor_ushort));
            }
            return (true);
        }
        public bool FanucPonerEjeMaestro(MaquinaMultiCabezal Maquina, short dIndiceEje)
        {
	        FanucActivarKey ();
            FanucModoMDI ();
            ushort Direccion = (ushort)(8138+1000*(Maquina.m_EjesY[dIndiceEje].m_dNumEje/8));
            LeerMemoriaAutomata ((short)9, Direccion, Direccion);
            Buffer.cdata[0] &= (byte)(~(1 << Maquina.m_EjesY[dIndiceEje].m_dNumEje%8));
            EscribirMemoriaAutomata (Direccion, Direccion);
	        Direccion = (ushort)(140+1000*(Maquina.m_EjesY[dIndiceEje].m_dNumEje/8));
            LeerMemoriaAutomata ((short)9, Direccion, Direccion);
            EscribirMemoriaAutomata (Direccion, Direccion);
            if (Maquina.m_EjesA.Count > 0)
            {
                Direccion = (ushort)(138+1000*(Maquina.m_EjesA[dIndiceEje].m_dNumEje/8));
                LeerMemoriaAutomata ((short)9, Direccion, Direccion);
                Buffer.cdata[0] &= (byte)(~(1 << Maquina.m_EjesA[dIndiceEje].m_dNumEje%8));
                EscribirMemoriaAutomata (Direccion, Direccion);
	            Direccion = (ushort)(140+1000*(Maquina.m_EjesA[dIndiceEje].m_dNumEje/8));
                LeerMemoriaAutomata ((short)9, Direccion, Direccion);
                EscribirMemoriaAutomata (Direccion, Direccion);

                Direccion = (ushort)(138+1000*(Maquina.m_EjesB[dIndiceEje].m_dNumEje/8));
                LeerMemoriaAutomata ((short)9, Direccion, Direccion);
                Buffer.cdata[0] &= (byte)(~(1 << Maquina.m_EjesB[dIndiceEje].m_dNumEje%8));
                EscribirMemoriaAutomata (Direccion, Direccion);
	            Direccion = (ushort)(140+1000*(Maquina.m_EjesB[dIndiceEje].m_dNumEje/8));
                LeerMemoriaAutomata ((short)9, Direccion, Direccion);
                EscribirMemoriaAutomata (Direccion, Direccion);
            }
            return (true);
        }
        public bool FanucEscribirMarcaMulticabezales(bool bAlgunEsclavo)
        {
            LeerMemoriaAutomata (5, 2023, 2023);
            byte Valor = 0x01 << 7;
            if (bAlgunEsclavo)
		        Buffer.cdata[0] |= Valor;
            else
                Buffer.cdata[0] &= (byte)(~Valor);
            return (EscribirMemoriaAutomata(2023, 2023));
        }
        public bool FanucActivarCabezal(int dCabezal, bool bActivar)
        {
            LeerMemoriaAutomata (5, 2005, 2005);
            byte Valor = (byte)(1 << (dCabezal+1));
            if (bActivar)
        	    Buffer.cdata[0] |= Valor;
            else
                Buffer.cdata[0] &= (byte)(~Valor);
            return (EscribirMemoriaAutomata(2025, 2025));
        }
        public bool LeerMacro(ushort HandleLocal, short dIndiceMacro, ref float Valor)
        {
            int ValorEntero = (int)(Valor*1000);
            ret = (Focas1.focas_ret)Focas1.cnc_rdmacro(HandleLocal, dIndiceMacro, (short)10, BufferMacro);
            Valor = BufferMacro.mcr_val;
            for (short i = 0; i < BufferMacro.dec_val; i++)
                Valor *= (float)0.1;
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public bool EscribirMacro(ushort HandleLocal, short dIndiceMacro, float Valor)
        {
            int ValorEntero = (int)(Valor * 1000);
            ret = (Focas1.focas_ret)Focas1.cnc_wrmacro(HandleLocal, dIndiceMacro, 10, ValorEntero, 3);
            Thread.Sleep(FANUC_RETARDO);
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public bool LeerParametro_IODBPSD_1(short dIndiceParametro, short m_dEje, short Tamano)
        {
            ret = (Focas1.focas_ret)Focas1.cnc_rdparam(m_dMiManipulador, dIndiceParametro, (short)(m_dEje+1),
                Tamano, prmDataNoAxis);
            Thread.Sleep(FANUC_RETARDO);
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public bool EscribirParametro_IODBPSD_1(short Tamano)
        {
            ret = (Focas1.focas_ret)Focas1.cnc_wrparam(m_dMiManipulador, Tamano, prmDataNoAxis);
            Thread.Sleep(FANUC_RETARDO);
            return (ret == Focas1.focas_ret.EW_OK);
        }

        public bool FanucParametro20(int dNodo)
        {
            BufferParam.datano = 20;
            BufferParam.type = 0;
            ret = (Focas1.focas_ret)Focas1.cnc_rdparam(m_dMiManipulador, 20, 0, 5, BufferParam);
            if (FanucGeneral.u.bEnviarDataServer == 1)
            {
                BufferParam.u.cdata = 5;
                BufferParam.u.cdatas[0] = 5;
            }
            else if (!m_bHSSB)   // 29DIC2015 Ethernet
            {
                BufferParam.u.cdata = 6;
                BufferParam.u.cdatas[0] = 6;
            }
            else
            {
                byte Valor = 15;
                if (dNodo == 9) // Es simulador
                    Valor = 16;
                BufferParam.u.cdata = Valor;
                BufferParam.u.cdatas[0] = Valor;
            }
            Thread.Sleep(FANUC_RETARDO);
            ret = (Focas1.focas_ret)Focas1.cnc_wrparam(m_dMiManipulador, 5, BufferParam);
            Thread.Sleep(FANUC_RETARDO);
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public double FanucValorVoltaico(bool bEsLaser)
        {
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)12, (short)0,
                (ushort)7090, (ushort)7091, (ushort)10, Buffer1);
            if (FanucGeneral.u.bExisteProfibus == 1)
            {
                if (bEsLaser)
                    return (Buffer1.idata[0]*10.0/32767.0);
                else
                    return (Buffer1.idata[0]/150.0);
            }
            return ((double)Buffer1.idata[0]);
        }
        public double FanucValorVoltaico2(bool bEsLaser)
        {
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)12, (short)0,
                (ushort)7200, (ushort)7201, (ushort)10, Buffer1);
            if (FanucGeneral.u.bExisteProfibus == 1)
            {
                if (bEsLaser)
                    return (Buffer1.idata[0]*10.0/32767.0);
                else
                    return (Buffer1.idata[0]/150.0);
            }
            return ((double)Buffer1.idata[0]);
        }
        public byte FanucValorCapacitivo()
        {
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)9, (short)0,
                (ushort)7000, (ushort)7000, (ushort)10, Buffer);
            return (Buffer.cdata[0]);
        }
        public bool EscribirSalidasBit(byte bSalida, bool bEstado)
        {
            byte ByteSalida = (byte)(bSalida / 8);
            byte Bit = (byte)(bSalida%8);
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)2, (short)0,
                (ushort)ByteSalida, (ushort)ByteSalida, (ushort)9, Buffer);
            if (bEstado)
                Buffer.cdata[ByteSalida] |= (byte)(1 << Bit);
    	    else
	    	    Buffer.cdata[ByteSalida] &= (byte)~(1 << Bit);
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public bool FanucParadaEmergencia()
        {
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)5, (short)0,
                (ushort)1006, (ushort)1006, (ushort)9, Buffer);
            Buffer.cdata[0] = 8;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
            Buffer.cdata[0] = 0;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public bool FanucParadaEmergenciaG8()
        {
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)0, (short)0,
                (ushort)8, (ushort)8, (ushort)9, Buffer);
            Buffer.cdata[0] &= 0xEF; //  ~(1 << 4);
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
            Buffer.cdata[0] |= 0x10;    // 1 << 4
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO);
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public bool FanucEstaParadaEmergenciaPulsada()
        {
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)5, (short)0,
                (ushort)1006, (ushort)1006, (ushort)9, Buffer);
            return ((Buffer.cdata[0] & 8) == 8);
        }
        public void FanucAvanceJOG(bool bActivo)
        {
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)5, (short)0,
                (ushort)1010, (ushort)1010, (ushort)9, Buffer);

            Thread.Sleep(FANUC_RETARDO_MANUAL);
            if (bActivo)
                Buffer.cdata[0] |= 0x10;
            else
                Buffer.cdata[0] &= 0xEF; //  ~0x10;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO_MANUAL);
        }
        public void FanucRetrocesoJOG(bool bActivo)
        {
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)5, (short)0,
                (ushort)1010, (ushort)1010, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO_MANUAL);
            if (bActivo)
                Buffer.cdata[0] |= 0x40;
            else
                Buffer.cdata[0] &= 0xBF; //  ~0x40;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
            Thread.Sleep(FANUC_RETARDO_MANUAL);
        }
        public bool FanucMoverEjeManual(Int16 dNumEje, bool bAvance)
        {
            Int16 Direccion = (Int16)(2040+dNumEje/4);
            byte BitDesplazar = (byte)((dNumEje % 4) << 1);
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)5, (short)0,
                (ushort)Direccion, (ushort)Direccion, (ushort)9, Buffer);
            if (bAvance)
            {
                Buffer.cdata[0] |= (byte)(1 << BitDesplazar);
                Buffer.cdata[0] &= (byte)~((byte)1 << (BitDesplazar + 1));
            }
            else
            {
                Buffer.cdata[0] |= (byte)(1 << (BitDesplazar + 1));
                Buffer.cdata[0] &= (byte)~((byte)1 << BitDesplazar);
            }
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)9, Buffer);
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public bool FanucParaTodosEjesManualNuevo()
        {
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)5, (short)0,
                (ushort)2040, (ushort)2045, (ushort)14, Buffer);
            for (int i = 0; i < 6; i++)
                Buffer.cdata[i] = 0x00;
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)14, Buffer);
            Thread.Sleep(FANUC_RETARDO_MANUAL);
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public bool FanucHabilitarEjeManual(Int16 dNumEje, bool bSentido)
        {
            ushort Direccion;
            if (dNumEje < 4)
                Direccion = 2001;
            else if (dNumEje < 6)
            {
                Direccion = 2004;
                dNumEje -= 2;    // son los bit 4 5 6 y 7. No hay que restar el eje.
            }
            else
            {
                Direccion = 2012;
                dNumEje -= 6;
            }
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, 5, 0,
                Direccion, Direccion, 9, Buffer);
            if (!bSentido)
                Buffer.cdata[0] |= (byte)(1 << (2*dNumEje+1));
            else
                Buffer.cdata[0] |= (byte)(1 << 2 * dNumEje);
            ret |= (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, 9, Buffer);
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public bool FanucInhabilitarEjeManual(Int16 dNumEje, bool bSentido)
        {
            ushort Direccion;
            if (dNumEje < 4)
                Direccion = 2001;
            else if (dNumEje < 6)
                Direccion = 2004;
            else
            {
                Direccion = 2012;
                dNumEje -= 6;
            }
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, 5, 0,
                Direccion, Direccion, 9, Buffer);
            if (!bSentido)
                Buffer.cdata[0] &= (byte)~(1 << (2 *dNumEje+1));
            else
                Buffer.cdata[0] &= (byte)~(1 << 2*dNumEje);
            ret |= (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, 9, Buffer);
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public bool FanucBorrarFicheroActivo(short dNumPrograma)
        {

            //
            //	-- Borrar (por si existe) el fichero al que enviamos el programa. Antes de nada selecciono otro
            //	por que si no no lo puedo borrar.
            //

            ret = (Focas1.focas_ret)Focas1.cnc_search(m_dMiManipulador, 4321);
            if (ret != Focas1.focas_ret.EW_OK)    // No existe fichero dummy
            {
                string FicheroDummy = "\nO4321\nM30\n%%\n";
                ret = (Focas1.focas_ret)Focas1.cnc_dwnend(m_dMiManipulador);
                ret = (Focas1.focas_ret)Focas1.cnc_dwnstart(m_dMiManipulador);
                ret = (Focas1.focas_ret)Focas1.cnc_download(m_dMiManipulador, FicheroDummy, (short)FicheroDummy.Length);
                ret = (Focas1.focas_ret)Focas1.cnc_dwnend(m_dMiManipulador);
                ret = (Focas1.focas_ret)Focas1.cnc_search(m_dMiManipulador, 4321);
            }
            ret = (Focas1.focas_ret)Focas1.cnc_delete(m_dMiManipulador, dNumPrograma);
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public override void ActivarRegulacionEjeZ(StreamWriter StreamFileISO, bool bActivar)
        {
            if (m_FanucGlobalVariables.m_M10_Activo == bActivar)
                return;
            m_FanucGlobalVariables.m_M10_Activo = bActivar;
            if (FanucGeneral.u.bControlM10M11Bisel == 0)
            {
                if (bActivar)
                    StreamFileISO.Write(String.Format("G65P{0}\n", FanucSubrutinas.u.dSubrutinaM11));
                else
                {
                    StreamFileISO.Write(String.Format("G65P{0}\n", FanucSubrutinas.u.dSubrutinaM10));
                    if (FanucGeneral.u.bG92Z0Activo != 0)
                    {
                        StreamFileISO.Write("G49\n");
                        if (FanucGeneral.u.dNumeroEjesZ > m_FanucGlobalVariables.dNumCabezalesMecanizado)
                            StreamFileISO.Write("G92.1Z0");
                        if (FanucGeneral.u.dNumeroEjesZ > 1)
                        {

                            if (m_FanucGlobalVariables.dNumCabezalesMecanizado > 0)
                                StreamFileISO.Write(" G92.1V0");
                        }
                        StreamFileISO.Write("\n");
                    }
                }
            }
            else
            {
                m_FanucGlobalVariables.dIndiceRealTimeMacro = 1;
                StreamFileISO.Write(String.Format("//#IOG[444,7] = {0}\n", bActivar));
            }
        }

        public override bool LeerMemoriaAutomata(short dTipoDato, ushort dInicio, ushort dFin)
        {
            ret = (Focas1.focas_ret)Focas1.pmc_rdpmcrng(m_dMiManipulador, (short)1, m_TipoDato,
                dInicio, dFin, (ushort)(dFin - dInicio + 9), Buffer);
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public override bool EscribirMemoriaAutomata(ushort dInicio, ushort dFin)
        {
            Thread.Sleep(FANUC_RETARDO);
            ret = (Focas1.focas_ret)Focas1.pmc_wrpmcrng(m_dMiManipulador, (ushort)(dFin - dInicio + 9), Buffer);
            return (ret == Focas1.focas_ret.EW_OK);
        }
        public override bool EscribirParametroTipoEjeY(EjeMaquina Eje, int dIndiceMaestro)
        {
            if (Eje.m_dTipoEje == 1)	// Es un tubo
                prmDataNoAxis.cdata = 0;
            else if (Eje.m_dIndiceEje == dIndiceMaestro)
                prmDataNoAxis.cdata = 2;
            else
                prmDataNoAxis.cdata = 6;
            LeerParametro_IODBPSD_1((short)1022, (short)(Eje.m_dIndiceEje), (short)5);
            return (EscribirParametro_IODBPSD_1(5));
        }
        public override bool EscribirParametroTipoEjeZ(EjeMaquina Eje, int dIndiceMaestro)
        {
            if (Eje.m_dIndiceEje == dIndiceMaestro)
                prmDataNoAxis.cdata = 3;
            else
                prmDataNoAxis.cdata = 7;
            LeerParametro_IODBPSD_1((short)1022, (short)(Eje.m_dIndiceEje), (short)5);
            return (EscribirParametro_IODBPSD_1(5));
        }
        public override bool EscribirParametroTipoEjeBisel(EjeMaquina EjeA, EjeMaquina EjeB)
        {
            LeerParametro_IODBPSD_1((short)19681, (short)(EjeA.m_dIndiceEje), (short)5);
            EscribirParametro_IODBPSD_1(5);
            LeerParametro_IODBPSD_1((short)19686, (short)(EjeB.m_dIndiceEje), (short)5);
            return (EscribirParametro_IODBPSD_1(5));
        }
        public override string GetNombreMaquina()
        {
            return (FanucGeneral.GetNombreMaquina());
        }
        public override void ActivarRTCP(StreamWriter StreamFileISO, bool bActivar)
        {
            if (m_FanucGlobalVariables.m_bRTCP_Activo == bActivar)
                return;
            m_FanucGlobalVariables.m_bRTCP_Activo = bActivar;
            if (bActivar)
            {
                StreamFileISO.Write("G40G49\n");
                StreamFileISO.Write("G43.4H01P1\n");
            }
            else
                StreamFileISO.Write("G49\n");

        }
        public override void WikiWiki(StreamWriter StreamFileISO, int dIndiceEjeA, int dIndiceEjeB, double A, double B)
        {
            ActivarRegulacionEjeZ(StreamFileISO, false);
            if (FanucGeneral.u.bG92Z0Activo == 0)
                StreamFileISO.Write("G91G00Z0.01G90G01\n");
            ActivarRTCP(StreamFileISO, true);
            StreamFileISO.Write(string.Format("{0}{1} {2}{3} F{4}\n",
                m_EjeMaquina[dIndiceEjeA].m_NombreEjeISO, A, 
                m_EjeMaquina[dIndiceEjeB].m_NombreEjeISO, B, 
                FanucGeneral.u.dVelocidadCambioAnguloBisel*60.0));
            ActivarRTCP(StreamFileISO, false);
            ActivarRegulacionEjeZ(StreamFileISO, true);
            m_FanucGlobalVariables.bPlanoXYPrimaActivo = true;
            if (FanucGeneral.u.bExisteXPrima != 0)
                StreamFileISO.Write("G91G17X0Y0G90\n");
        }
        public override bool EnviarPrograma(string Nombre, Int16 prog_number)
        {
            return (FanucEnviarProgramaThread (Nombre, prog_number));
        }
    }

}
