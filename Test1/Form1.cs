using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Test1
{
    public partial class Form1 : Form
    {
        #region Definición de variables

        int m_hBlock;
        static int m_hView;
        static int m_hLcWnd, m_hDrw;
        static int m_hStatBar;
        const int KeyPline = 101;
        const int KeyTextV = 102;
        const int KeyTextX = 103;
        const int KeyTextY = 104;
        private List<int> m_hCapaTrabajo = new List<int>();
        SistemaTecoi m_SistemaTecoi;
        int m_dTipoAutomataFanuc = 2;

        private F_LCEVENT LcEvent;
        private string m_VersionGUIInterna = "001.000";
        private string m_ClaveGUIInterna = "$$$$$$$$$$$$$$$$";
        private string m_CabeceraGUI = "#TECOI#";
        List<TreeNode> m_ViewTrabajos = new List<TreeNode>();
        private int m_dIndexTrabajo;
        public int m_hCapaEJES;

        private bool bRatonPulsado = false;
        private int X0Raton;
        private bool bSeEstaMoviendo = false;
        private double VelocidadPanel = 0;
        private int XRatonActual;
        private int YRatonActual;

        #endregion

        public bool ProcesarServerSocketForma(int dIndiceSocket, string buffer)
        {
            if (buffer.Length < 46)
                return (false);
            string Cabecera = buffer.Substring(0, 7);
            if (Cabecera != "#TECOI#")
                return (false);
            string Version = buffer.Substring(7, 7);
            int dNivelPrivilegio = int.Parse(buffer.Substring(14, 2));      // Nivel de privilegio
            string CodigoAcceso = buffer.Substring(14, 16);                 // Clave completa - incluye Nivel de privilegio
            int Comando = int.Parse(buffer.Substring(30, 8));
            int dNumDatos = int.Parse(buffer.Substring(38, 8));
            string Datos = buffer.Substring(46, dNumDatos);

            switch (Comando)
            {
                case 10:     // Abrir trabajo nuevo
                    MethodInvoker inv = delegate
                    {
                        AbrirNuevoTrabajo(Datos, m_SistemaTecoi.m_Maquinas[m_SistemaTecoi.MaquinaPorDefecto].m_MachinaCode);
                    };
                    Invoke(inv);
                    break;
                case 11:     // Procesar trabajo
                    m_SistemaTecoi.GenerarFicheroISO(m_SistemaTecoi.m_Work[0], @"C:\CisCAD2014\Test1\bin\x86\Debug\__CNC.ISO");
                    m_SistemaTecoi.EnviarPrograma(@"C:\CisCAD2014\Test1\bin\x86\Debug\__CNC.ISO", 1234);
                    break;
            }
            return (true);
        }

        public static void MiEvento(int hEvento)
        {
            int EventType;
            EventType = Lcad.PropGetInt(hEvento, Lcad.LC_PROP_EVENT_TYPE);
            switch (EventType)
            {
                case Lcad.LC_EVENT_MOUSEMOVE:
                    OnMouseMove(hEvento);
                    break;
                case Lcad.LC_EVENT_WNDVIEW:
                    OnWndView(hEvento);
                    break;
            }
        }
        public static void OnMouseMove(int hEvent)
        {
            double X, Y;
            int hLcWnd;

            hLcWnd = Lcad.PropGetHandle(hEvent, Lcad.LC_PROP_EVENT_WND);
            X = Lcad.PropGetFloat(hEvent, Lcad.LC_PROP_EVENT_FLOAT1);
            Y = Lcad.PropGetFloat(hEvent, Lcad.LC_PROP_EVENT_FLOAT2);
            string szBuf = X.ToString("F3");
            Lcad.StatbarText(m_hStatBar, 1, szBuf);
            szBuf = Y.ToString("F3");
            Lcad.StatbarText(m_hStatBar, 2, szBuf);
            Lcad.StatbarRedraw(m_hStatBar);
        }
        public static void OnWndView(int hEvent)
        {
            double X, Y, PixSize, Lef, Bot, Rig, Top, dx, dy;
            int hLcWnd;

            hLcWnd = Lcad.PropGetHandle(hEvent, Lcad.LC_PROP_EVENT_WND);
            PixSize = Lcad.PropGetFloat(hLcWnd, Lcad.LC_PROP_WND_PIXELSIZE);
            X = Lcad.PropGetFloat(hLcWnd, Lcad.LC_PROP_WND_CURX);
            Y = Lcad.PropGetFloat(hLcWnd, Lcad.LC_PROP_WND_CURY);
            Lef = Lcad.PropGetFloat(hLcWnd, Lcad.LC_PROP_WND_XMIN);
            Bot = Lcad.PropGetFloat(hLcWnd, Lcad.LC_PROP_WND_YMIN);
            Rig = Lcad.PropGetFloat(hLcWnd, Lcad.LC_PROP_WND_XMAX);
            Top = Lcad.PropGetFloat(hLcWnd, Lcad.LC_PROP_WND_YMAX);
            dx = Rig - Lef;
            dy = Top - Bot;
            string szBuf = X.ToString("F3");
            Lcad.StatbarText(m_hStatBar, 1, szBuf);
            szBuf = Y.ToString("F3");
            Lcad.StatbarText(m_hStatBar, 2, szBuf);
            szBuf = "Pixel size: " + PixSize.ToString("F4");
            Lcad.StatbarText(m_hStatBar, 3, szBuf);
            szBuf = "Visible area:  L=" + Lef.ToString("F2") + "  B=" + Bot.ToString("F2") + "  R=" + Rig.ToString("F2") + "  T=" + Bot.ToString("F2") + "   W=" + dx.ToString("F2") + "  H=" + dy.ToString("F2");
            Lcad.StatbarText(m_hStatBar, 4, szBuf);
            Lcad.StatbarRedraw(m_hStatBar);
        }

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            #region AUTOMATA

            if (m_dTipoAutomataFanuc == 1)  // 0i
                m_SistemaTecoi = new Automata_0i();
            else if (m_dTipoAutomataFanuc == 2)  // 300i, 0i-MB
                m_SistemaTecoi = new Automata_30i();
            m_SistemaTecoi.ProcesarServerSocketForma = ProcesarServerSocketForma;
            m_SistemaTecoi.m_bConectadoAutomata = m_SistemaTecoi.ConectarAutomata(9);
            if (!m_SistemaTecoi.m_bConectadoAutomata)
            {
                if (ConfiguracionOpenFileDialog.ShowDialog() == DialogResult.OK)
                    m_SistemaTecoi.LeerConfiguracionAutomata(ConfiguracionOpenFileDialog.FileName);
            }
            Text = m_SistemaTecoi.GetNombreMaquina();

            #endregion
            #region Sistema Tecoi
            m_SistemaTecoi.LeerDefinicionSistema(@"C:\CisCAD2014\Test1\bin\x86\Debug\SistemaTecoi_jag.xml");
            //AppDomain.CurrentDomain.BaseDirectory + "SistemaTecoi_jag.xml");
            #endregion
            #region LiteCAD

            LcEvent = new F_LCEVENT(Form1.MiEvento);
            Lcad.Initialize(LcEvent, 0, 0);
            m_hLcWnd = Lcad.CreateWindow(Handle, Lcad.LC_WS_DEFAULT | Lcad.LC_WS_RULERS);

            m_hStatBar = Lcad.CreateStatbar(Handle);
            Lcad.StatbarCell(m_hStatBar, 1, 0);
            Lcad.StatbarCell(m_hStatBar, 2, 100);
            Lcad.StatbarCell(m_hStatBar, 3, 200);
            Lcad.StatbarCell(m_hStatBar, 4, 350);
            m_hDrw = Lcad.CreateDrawing();
            Lcad.DrwNew(m_hDrw, "", m_hLcWnd);

            //m_hView = Lcad.DrwGetFirstObject(m_hDrw, Lcad.LC_PROP_WND_GRIDSHOW);
            //Lcad.PropPutBool(m_hView, Lcad.LC_PROP_WND_GRIDSHOW, true);

            Lcad.PropPutStr(m_hDrw, Lcad.LC_PROP_DRW_COLORBACKM, "0,0,0");
            m_hBlock = Lcad.PropGetHandle(m_hLcWnd, Lcad.LC_PROP_WND_VIEWBLOCK);

            m_hCapaEJES = Lcad.DrwAddLayer(m_hDrw, "EJES", "blue", 0, 1);
            Lcad.PropPutBool(m_hCapaEJES, Lcad.LC_PROP_LAYER_LOCKED, false);
            Lcad.BlockAddXline(m_hBlock, 0.0, 0.0, 0.0, true);
            Lcad.BlockAddXline(m_hBlock, 0.0, 0.0, Math.PI*0.5, true);
            Lcad.BlockAddXline(m_hBlock, 0.0, 0.0, Math.PI, true);
            Lcad.BlockAddXline(m_hBlock, 0.0, 0.0, Math.PI*1.5, true);
            Lcad.PropPutBool(m_hCapaEJES, Lcad.LC_PROP_LAYER_LOCKED, true);
            Lcad.PropPutBool(m_hCapaEJES, Lcad.LC_PROP_LAYER_NODLG, false);
            Lcad.WndZoomRect(m_hLcWnd, -10, -10, 100, 100);
            Lcad.WndRedraw(m_hLcWnd);
            this.OnResize(e);

            #endregion
            #region General
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            Movilpanel.Width = 5000;
            TemporizadorGeneral.Enabled = true;
            WindowState = FormWindowState.Maximized;
            #endregion
        }
        private void Form1_Resize_1(object sender, EventArgs e)
        {
            if (m_hLcWnd != 0)
            {
                int Hsbar = Lcad.PropGetInt(0, Lcad.LC_PROP_G_SBARHEIGHT);
                Lcad.WndResize(m_hLcWnd, TreeViewpanel.Width,  0, 
                    ClientSize.Width-TreeViewpanel.Width, ClientSize.Height-Hsbar-Generalpanel.Height);
                
                int x = 0;
                int y = ClientSize.Height-Hsbar;
                int w = ClientSize.Width;
                int h = Hsbar;
                Lcad.StatbarResize(m_hStatBar, x, y, w, h);
                Lcad.WndRedraw(m_hLcWnd);
            }
            ZoomInbutton.Top = TreeViewpanel.Height-ZoomInbutton.Height-4;
            ZoomOutbutton.Top = ZoomInbutton.Top-ZoomOutbutton.Height-4;
            ZoomWinbutton.Top = ZoomOutbutton.Top-ZoomWinbutton.Height-4;
            ZoomAllbutton.Top = ZoomWinbutton.Top-ZoomAllbutton.Height-4;
            Abrirbutton.Top = ZoomAllbutton.Top;
            SubirTrabajobutton.Top = ZoomAllbutton.Top;
            BajarTrabajobutton.Top = ZoomAllbutton.Top;
            EliminarTrabajobutton.Top = EnviarDNCButton.Top = ZoomWinbutton.Top;
            TrabajostreeView.Height = Abrirbutton.Top-2*TrabajostreeView.Top;
            Comandospanel.Width = Generalpanel.Width - Comandospanel.Left - 4;
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Lcad.Uninitialize(true);
            Lcad.DeleteDrawing(m_hDrw);
            m_SistemaTecoi.Salir();
            //m_SistemaTecoi.Work = null;
            GC.Collect();
        }

        private void Abrirbutton_Click(object sender, EventArgs e)
        {
            if (TrabajoOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in TrabajoOpenFileDialog.FileNames)
                {
                    if (!File.Exists(file))
                        continue;

                    Trabajo W = new Trabajo();
                    W.LeerFichero(file, m_SistemaTecoi.m_Maquinas[m_SistemaTecoi.MaquinaPorDefecto].m_MachinaCode);
                    m_SistemaTecoi.m_Work.Add(W);

                    AbrirNuevoTrabajo(file, m_SistemaTecoi.m_Maquinas[m_SistemaTecoi.MaquinaPorDefecto].m_MachinaCode);

                    string Cadena = m_CabeceraGUI + m_VersionGUIInterna + m_ClaveGUIInterna + "00000010" +
                        TrabajoOpenFileDialog.FileName.Length.ToString("D8") +
                        TrabajoOpenFileDialog.FileName;
                    m_SistemaTecoi.ReenviarForma2Clientes(Cadena);
                }
            }
        }
        private void AbrirNuevoTrabajo(string Fichero, string NombreMaquinaDefecto)
        {
            AnadirTrabajoNuevo();                       // Genera el arbol de entidades en el Treeview
            m_hCapaTrabajo.Add(m_ViewTrabajos.Count-1); // Capa nueva en LiteCAD

            string NombreCapa = "Trabajo"+m_ViewTrabajos.Count.ToString("D5");  // Cada capa tiene el nombre del trabajo
            int Capa = Lcad.DrwGetObjectByName(m_hDrw, Lcad.LC_OBJ_LAYER, NombreCapa);  // ¿Existe la capa? Por si se ha borrado.
            if (Capa == 0)  // Si no existe
                m_hCapaTrabajo[m_ViewTrabajos.Count-1] = Lcad.DrwAddLayer(m_hDrw, NombreCapa, "green", 0, 1);
            else            // Si  existe pero posiblemente esté borrada. Se recupera.
                m_hCapaTrabajo[m_ViewTrabajos.Count-1] = Lcad.DrwGetObjectByName(m_hDrw, Lcad.LC_OBJ_LAYER, NombreCapa);

            Lcad.PropPutBool(m_hCapaTrabajo[m_ViewTrabajos.Count-1], Lcad.LC_PROP_LAYER_LOCKED, false); // Desbloqueamos la Capa para poder añadir elementos.
            Lcad.PropPutHandle(m_hDrw, Lcad.LC_PROP_DRW_LAYER, m_hCapaTrabajo[m_ViewTrabajos.Count-1]); // Añadimos la nueva capa a las vistas de LiteCAD
            DibujarTrabajo(m_SistemaTecoi.m_Work.Count-1);                                              // Se genera el dibujo del trabajo en LiteCAD.
            TrabajostreeView.SelectedNode = m_ViewTrabajos[m_ViewTrabajos.Count-1];

            ZoomAll();
        }
        private void AnadirTrabajoNuevo ()
        {
            string[] TipoEntidad = { "", "", " - Segmento", "", " - Circunferencia", " - Arco" };
            int dIndexPieza = 1;
            int dIndexBloque = 1;
            int dIndexEntidad = 1;
            Trabajo TrabajoUltimo = m_SistemaTecoi.m_Work[m_SistemaTecoi.m_Work.Count-1];
            m_ViewTrabajos.Add(TrabajostreeView.Nodes.Add(TrabajoUltimo.m_NombreFichero));
            foreach (Pieza p in TrabajoUltimo.m_Piezas)
            {
                TreeNode Piezas = m_ViewTrabajos[m_ViewTrabajos.Count-1].Nodes.Add(dIndexPieza.ToString()+" - Pieza");
                Piezas.ImageIndex = 1;
                Piezas.SelectedImageIndex = 1;
                foreach (Bloque q in p.m_Bloques)
                {
                    if (!q.m_bEsMovimientoCorte)
                        continue;
                    TreeNode Bloques = Piezas.Nodes.Add(dIndexBloque.ToString()+"-Bloque");
                    Bloques.ImageIndex = 2;
                    Bloques.SelectedImageIndex = 2;
                    foreach (Entidad e in q.m_Entidades)
                    {
                        TreeNode Entidades = Bloques.Nodes.Add(dIndexEntidad.ToString()+TipoEntidad[e.m_dTipoEntidad]);
                        Entidades.ImageIndex = 3;
                        Entidades.SelectedImageIndex = 3;
                        ++dIndexEntidad;
                    }
                    dIndexEntidad = 1;
                    ++dIndexBloque;
                }
                dIndexBloque = 1;
                ++dIndexPieza;
            }

        }
        private void RehacerListaTrabajos()
        {
            string[] TipoEntidad = { "", "", " - Segmento", "", " - Circunferencia", " - Arco"};
            int dIndexPieza = 1;
            int dIndexBloque = 1;
            int dIndexEntidad= 1;
            TrabajostreeView.Nodes.Clear();
            m_ViewTrabajos.Clear();
            foreach (Trabajo t in m_SistemaTecoi.m_Work)
            {
                m_ViewTrabajos.Add(TrabajostreeView.Nodes.Add(t.m_NombreFichero));
                foreach (Pieza p in t.m_Piezas)
                {
                    TreeNode Piezas = m_ViewTrabajos[m_ViewTrabajos.Count-1].Nodes.Add(dIndexPieza.ToString()+" - Pieza");
                    Piezas.ImageIndex = 1;
                    Piezas.SelectedImageIndex = 1;
                    foreach (Bloque q in p.m_Bloques)
                    {
                        if (!q.m_bEsMovimientoCorte)
                            continue;
                        TreeNode Bloques = Piezas.Nodes.Add(dIndexBloque.ToString()+" - Bloque");
                        Bloques.ImageIndex = 2;
                        Bloques.SelectedImageIndex = 2;
                        foreach (Entidad e in q.m_Entidades)
                        {
                            TreeNode Entidades = Bloques.Nodes.Add(dIndexEntidad.ToString()+TipoEntidad[e.m_dTipoEntidad]);
                            Entidades.ImageIndex = 3;
                            Entidades.SelectedImageIndex = 3;
                            ++dIndexEntidad;
                        }
                        dIndexEntidad = 1;
                        ++dIndexBloque;
                    }
                    dIndexBloque = 1;
                    ++dIndexPieza;
                }
            }
        }
        private void ActualizarDibujo(Trabajo Work)
        {
        }
        private void DibujarTrabajo (int dIndex)
        {
            Trabajo Work = m_SistemaTecoi.m_Work[dIndex];
            double X0 = 0;
            double Y0 = 0;
            Punto P1;
            Punto C;

            TemporizadorGeneral.Enabled = false;
            ProgresoForm Progreso = new ProgresoForm();
            Progreso.Show();
            int i = 0;
            int dNumeroBloques = 0;
            foreach (Pieza f in Work.m_Piezas)
                dNumeroBloques += f.m_Bloques.Count;
            Lcad.PropPutHandle(m_hDrw, Lcad.LC_PROP_DRW_LAYER, m_hCapaTrabajo[dIndex]);
            foreach (Pieza f in Work.m_Piezas)
            {
                foreach (Bloque b in f.m_Bloques)
                {
                    if (Progreso.ValorProgreso(100*i++/dNumeroBloques))
                        break;
                    Progreso.Refresh();
                    Application.DoEvents();
                    X0 = b.m_PuntoInicio.m_lfx;
                    Y0 = b.m_PuntoInicio.m_lfy;
                    foreach (Entidad e in b.m_Entidades)
                    {
                        switch (e.TipoEntidad())
                        {
                            case 2: // Segmento
                                P1 = new Punto(e.PuntoFinal());
                                e.m_hLitlecad = Lcad.BlockAddLine(m_hBlock, X0, Y0, P1.m_lfx, P1.m_lfy);
                                X0 = P1.m_lfx;
                                Y0 = P1.m_lfy;
                                break;
                            case 4: // Cicunferencia
                                C = new Punto(e.PuntoCentro());
                                e.m_hLitlecad = Lcad.BlockAddCircle(m_hBlock, C.m_lfx, C.m_lfy, e.LeerRadio(),
                                    false);
                                break;
                            case 5: // Arco.
                                C = new Punto(e.PuntoCentro());
                                P1 = new Punto(e.PuntoFinal());
                                e.m_hLitlecad = Lcad.BlockAddArc(m_hBlock,
                                C.m_lfx, C.m_lfy, e.LeerRadio(),
                                    e.LeerAnguloInicial() * Math.PI/180,
                                    e.LeerAnguloArco() * Math.PI/180);
                                X0 = P1.m_lfx;
                                Y0 = P1.m_lfy;
                                break;
                        }
                        if (b.m_bEsMovimientoCorte)
                            Lcad.PropPutStr(e.m_hLitlecad, Lcad.LC_PROP_ENT_COLOR, "red");
                        else
                            Lcad.PropPutStr(e.m_hLitlecad, Lcad.LC_PROP_ENT_COLOR, "blue");
                    }
                }
            }
            Progreso.Close();

            TemporizadorGeneral.Enabled = true;
        }
        private void TemporizadorGeneral_Tick(object sender, EventArgs e)
        {
            TemporizadorGeneral.Enabled = false;

            string Alarmas = "";
            double X, Y, Z;
            m_SistemaTecoi.LecturaPosicionesEjes(out X, out Y, out Z);
            EjeXlabel.Text = string.Format("Eje X: {0}", X);
            EjeYlabel.Text = string.Format("Eje Y: {0}", Y);
            EjeZlabel.Text = string.Format("Eje Z: {0}",  Z);
            m_SistemaTecoi.LeerAlarmas(ref Alarmas);
            AlarmastextBox.Clear();
            AlarmastextBox.AppendText(Alarmas);
            EstadoAutomatalabel.Text = m_SistemaTecoi.LeerEstadoAutomata().ToString();

            TemporizadorGeneral.Enabled = true;
        }
        private void MaquinasVirtualesbutton_Click(object sender, EventArgs e)
        {
            ConPiezarMaquinasVirtuales ConfMaquina = new ConPiezarMaquinasVirtuales();
            ConfMaquina.ShowDialog();
        }
        private void EnviarDNCButton_Click(object sender, EventArgs e)
        {
            m_SistemaTecoi.GenerarFicheroISO(m_SistemaTecoi.m_Work[m_dIndexTrabajo], @"C:\CisCAD2014\Test1\bin\x86\Debug\__CNC.ISO");
            m_SistemaTecoi.EnviarPrograma(@"C:\CisCAD2014\Test1\bin\x86\Debug\__CNC.ISO", 1234);
        }
        private void ZoomAllbutton_Click(object sender, EventArgs e)
        {
            ZoomAll();
        }
        private void ZoomAll()
        {
            if (TrabajostreeView.SelectedNode == null)
                return;
            TreeNode NodoPadre = TrabajostreeView.SelectedNode;
            while (NodoPadre.Parent != null)
                NodoPadre = NodoPadre.Parent;
            int dIndex = NodoPadre.Index;

            double A = Math.PI/180.0*m_SistemaTecoi.m_Work[dIndex].m_RotacionActual;
            double x0 = m_SistemaTecoi.m_Work[dIndex].CotasTrabajo[0];
            double y0 = m_SistemaTecoi.m_Work[dIndex].CotasTrabajo[1];
            double x1 = m_SistemaTecoi.m_Work[dIndex].CotasTrabajo[2];
            double y1 = m_SistemaTecoi.m_Work[dIndex].CotasTrabajo[3];
            double Incx = 0.5*(x1-x0);
            double Incy = 0.5*(y1-y0);
            double R = Math.Sqrt(Incx*Incx+Incy*Incy);
            double dx = Incx*Math.Cos(A)-Incy*Math.Sin(A);
            double dy = Incy*Math.Sin(A)+Incy*Math.Cos(A);
            double xCentro = x0+dx;
            double yCentro = y0+dy;
            dx = Math.Abs(dx);
            dy = Math.Abs(dy);
            Lcad.WndZoomRect(m_hLcWnd, xCentro-dx, yCentro-dy, xCentro+dx, yCentro+dy);
        }
        private void ZoomInbutton_Click(object sender, EventArgs e)
        {
            Lcad.WndExeCommand(m_hLcWnd, Lcad.LC_CMD_ZOOM_IN, 0);
        }
        private void ZoomOutbutton_Click(object sender, EventArgs e)
        {
            Lcad.WndExeCommand(m_hLcWnd, Lcad.LC_CMD_ZOOM_OUT, 0);
        }
        private void EliminarTrabajobutton_Click(object sender, EventArgs e)
        {
            if (TrabajostreeView.SelectedNode == null)
                return;
            int dIndex;
            if (TrabajostreeView.SelectedNode.Parent == null)       // Nodo padre
                dIndex = TrabajostreeView.SelectedNode.Index;
            else                                                    // Nodo hijo
                dIndex = TrabajostreeView.SelectedNode.Parent.Index;

            foreach (Pieza P in m_SistemaTecoi.m_Work[dIndex].m_Piezas) // Borrar Entidades del dibujo
                foreach (Bloque B in P.m_Bloques)
                    foreach (Entidad E in B.m_Entidades)
                        Lcad.DrwDeleteObject(m_hDrw, E.m_hLitlecad);

            m_SistemaTecoi.m_Work.RemoveAt(dIndex);                     // Borrar Trabajo en SistemaTecoi
            m_ViewTrabajos.RemoveAt(dIndex);                            // Borrar Trabajo en Listado
            TrabajostreeView.Nodes.Remove(TrabajostreeView.SelectedNode);
            for (int i = dIndex; i < m_hCapaTrabajo.Count; i++)              // Renombrado de los nombres de las capas
            {
                Lcad.PropPutBool(m_hCapaTrabajo[i], Lcad.LC_PROP_LAYER_VISIBLE, false);
                string NombreCapa = "Trabajo"+i.ToString("D5");
                Lcad.PropPutStr(m_hCapaTrabajo[i], Lcad.LC_PROP_LAYER_NAME, NombreCapa);
                int Layer = Lcad.DrwGetObjectByName(m_hDrw, Lcad.LC_OBJ_LAYER, NombreCapa);
            }
            Lcad.DrwDeleteObject(m_hDrw, m_hCapaTrabajo[dIndex]);       // Borrado de capa del trabajo

            m_hCapaTrabajo.RemoveAt(dIndex);
            TrabajostreeView.SelectedNode = null;
            Lcad.WndRedraw(m_hLcWnd);
        }
        private void TrabajostreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode NodoPadre = e.Node;
            while (NodoPadre.Parent != null)
                NodoPadre = NodoPadre.Parent;
            m_dIndexTrabajo = NodoPadre.Index;

            for (int i = 0; i < m_hCapaTrabajo.Count; i++)
                Lcad.PropPutBool(m_hCapaTrabajo[i], Lcad.LC_PROP_LAYER_VISIBLE, false);
            Lcad.PropPutBool(m_hCapaTrabajo[m_dIndexTrabajo], Lcad.LC_PROP_LAYER_VISIBLE, true);
            //ZoomAll();
            Lcad.WndRedraw(m_hLcWnd);
        }
        private void SubirTrabajobutton_Click(object sender, EventArgs e)
        {
            if (m_dIndexTrabajo == 0)   // No se puede subir más.
                return;
            int CapaActual = m_hCapaTrabajo[m_dIndexTrabajo];
            m_hCapaTrabajo[m_dIndexTrabajo] = m_hCapaTrabajo[m_dIndexTrabajo-1];
            m_hCapaTrabajo[m_dIndexTrabajo-1] = CapaActual;
            TreeNode NodoSeleccionado = m_ViewTrabajos[m_dIndexTrabajo].Clone() as TreeNode;
            TreeNode NodoArriba = m_ViewTrabajos[m_dIndexTrabajo-1].Clone() as TreeNode;
            Trabajo TrabajoSeleccionado = m_SistemaTecoi.m_Work[m_dIndexTrabajo];
            Trabajo TrabajoArriba = m_SistemaTecoi.m_Work[m_dIndexTrabajo-1];

            m_ViewTrabajos[m_dIndexTrabajo] = NodoArriba;
            m_SistemaTecoi.m_Work[m_dIndexTrabajo] = TrabajoArriba;
            m_ViewTrabajos[m_dIndexTrabajo-1] = NodoSeleccionado;
            m_SistemaTecoi.m_Work[m_dIndexTrabajo-1] = TrabajoSeleccionado;

            TrabajostreeView.Nodes.Clear();
            foreach (TreeNode n in m_ViewTrabajos)
                TrabajostreeView.Nodes.Add(n);
            TrabajostreeView.SelectedNode = m_ViewTrabajos[--m_dIndexTrabajo];
        }
        private void BajarTrabajobutton_Click(object sender, EventArgs e)
        {
            if (m_dIndexTrabajo == m_ViewTrabajos.Count-1)   // No se puede bajar más.
                return;

            int CapaActual = m_hCapaTrabajo[m_dIndexTrabajo];
            m_hCapaTrabajo[m_dIndexTrabajo] = m_hCapaTrabajo[m_dIndexTrabajo+1];
            m_hCapaTrabajo[m_dIndexTrabajo+1] = CapaActual;
            TreeNode NodoSeleccionado = m_ViewTrabajos[m_dIndexTrabajo].Clone() as TreeNode;
            TreeNode NodoArriba = m_ViewTrabajos[m_dIndexTrabajo+1].Clone() as TreeNode;
            Trabajo TrabajoSeleccionado = m_SistemaTecoi.m_Work[m_dIndexTrabajo];
            Trabajo TrabajoArriba = m_SistemaTecoi.m_Work[m_dIndexTrabajo+1];

            m_ViewTrabajos[m_dIndexTrabajo] = NodoArriba;
            m_SistemaTecoi.m_Work[m_dIndexTrabajo] = TrabajoArriba;
            m_ViewTrabajos[m_dIndexTrabajo+1] = NodoSeleccionado;
            m_SistemaTecoi.m_Work[m_dIndexTrabajo+1] = TrabajoSeleccionado;

            TrabajostreeView.Nodes.Clear();
            foreach (TreeNode n in m_ViewTrabajos)
                TrabajostreeView.Nodes.Add(n);
            TrabajostreeView.SelectedNode = m_ViewTrabajos[++m_dIndexTrabajo];
        }
        private void TrabajostreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TrabajostreeView.AfterCheck -= TrabajostreeView_AfterCheck;
            CheckTreeViewNode(e.Node, e.Node.Checked);
            TrabajostreeView.AfterCheck += TrabajostreeView_AfterCheck;

            TreeNode NodoPadre = e.Node; 
            while (NodoPadre.Parent != null)
                NodoPadre = NodoPadre.Parent;
            TrabajostreeView.SelectedNode = NodoPadre;
            for (int p = 0; p < m_SistemaTecoi.m_Work[NodoPadre.Index].m_Piezas.Count; p++)
            {
                TreeNode NodoPieza = NodoPadre.Nodes[p];
                Pieza P = m_SistemaTecoi.m_Work[NodoPadre.Index].m_Piezas[p];
                for (int b = 0; b < P.m_Bloques.Count; b++)
                {
                    TreeNode NodoBloque = NodoPieza.Nodes[b];
                    Bloque B = P.m_Bloques[b];
                    if (!B.m_bEsMovimientoCorte)
                        continue;
                    for (int i = 0; i < B.m_Entidades.Count; i++)
                    {
                        TreeNode NodoEntidad = NodoBloque.Nodes[i];
                        if (NodoEntidad.Checked)
                            Lcad.PropPutStr(B.m_Entidades[i].m_hLitlecad, Lcad.LC_PROP_ENT_COLOR, "yellow");
                        else
                            Lcad.PropPutStr(B.m_Entidades[i].m_hLitlecad, Lcad.LC_PROP_ENT_COLOR, "red");
                        B.m_Entidades[i].m_bDebeCortarse = NodoEntidad.Checked;
                    }
                }
            }
            //ZoomAll();
            Lcad.WndRedraw(m_hLcWnd);
        }
        private bool CheckTreeViewNode(TreeNode node, Boolean isChecked)
        {
            bool bHayCasos = false;
            foreach (TreeNode item in node.Nodes)
            {
                item.Checked = isChecked;
                if (item.Nodes.Count > 0)
                {
                    CheckTreeViewNode(item, isChecked);
                    bHayCasos = true;
                }
            }
            return (bHayCasos);
        }
        private void Panbutton_Click(object sender, EventArgs e)
        {
            Lcad.WndExeCommand(m_hLcWnd, Lcad.LC_CMD_ZOOM_WIN, 0);
            Lcad.WndSetFocus(m_hLcWnd);
        }

        private void SubrutinasButton_Click(object sender, EventArgs e)
        {
            m_SistemaTecoi.GenerarSubrutinas(@"C:\CisCAD2014\Test1\bin\x86\Debug\rutinas.cnc");
        }
        private void EnviarSubrutinasbutton_Click(object sender, EventArgs e)
        {
            m_SistemaTecoi.EnviarSubrutinas(@"C:\CisCAD2014\Test1\bin\x86\Debug\rutinas.cnc", true, true);
        }

        private void Movilpanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!bRatonPulsado)
                return;
            VelocidadPanel = e.X - XRatonActual;
            YRatonActual = e.Y;
            MoverPanel(e.X);
        }
        private void Movilpanel_MouseDown(object sender, MouseEventArgs e)
        {
            bSeEstaMoviendo = false;
            bRatonPulsado = true;
            X0Raton = e.X;
        }
        private void Movilpanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (bSeEstaMoviendo && Math.Abs(VelocidadPanel) > 1)
            {
                float X0 = XRatonActual;
                int Signo = VelocidadPanel < 0 ? -1 : 1;
                VelocidadPanel = Signo*Math.Min(Math.Abs(VelocidadPanel), 2.0);
                while (Math.Abs(VelocidadPanel) > 0.01)
                {
                    VelocidadPanel *= 0.82;
                    MoverPanel((int)(X0+VelocidadPanel));
                    Movilpanel.Refresh();
                    Thread.Sleep(10);
                }
            }
            bSeEstaMoviendo = false;
            bRatonPulsado = false;
        }
        private void MoverPanel (int X)
        {
            XRatonActual = X;
	        int LeftPanelX = Movilpanel.Left + X - X0Raton;
            if (Movilpanel.Width+LeftPanelX < Comandospanel.Width)
                LeftPanelX = Comandospanel.Width-Movilpanel.Width;
            else if (LeftPanelX > 0)
        	    LeftPanelX = 0;
            Movilpanel.Left = LeftPanelX;
            bSeEstaMoviendo = true;
        }

        private void Trasladarbutton_Click(object sender, EventArgs e)
        {
            if (TrabajostreeView.SelectedNode.Index == -1)
                return;
            double dX = Convert.ToDouble(TrasladarXtextBox.Text)-m_SistemaTecoi.m_Work[m_dIndexTrabajo].m_TraslacionX;
            double dY = Convert.ToDouble(TrasladarYtextBox.Text)-m_SistemaTecoi.m_Work[m_dIndexTrabajo].m_TraslacionY;
            if (dX == 0 && dY == 0)
                return;

            m_SistemaTecoi.m_Work[m_dIndexTrabajo].m_TraslacionX += dX;
            m_SistemaTecoi.m_Work[m_dIndexTrabajo].m_TraslacionY += dY;
            int hModelBlock = Lcad.DrwGetFirstObject(m_hDrw, Lcad.LC_OBJ_BLOCK);
            Lcad.BlockSelectEnt(hModelBlock, 0, false);
            int hEnt = Lcad.BlockGetFirstEnt(hModelBlock);
            while (hEnt != 0)
            {
                if (m_hCapaTrabajo[m_dIndexTrabajo] == Lcad.PropGetHandle(hEnt, Lcad.LC_PROP_ENT_LAYER))
                    Lcad.BlockSelectEnt(hModelBlock, hEnt, true);
                hEnt = Lcad.BlockGetNextEnt(hModelBlock, hEnt);
            }
            Lcad.BlockSelMove(hModelBlock, dX, dY, false, false);
            Lcad.BlockSelectEnt(hModelBlock, 0, false);
            Lcad.WndRedraw(m_hLcWnd);
        }
        private void Rotarbutton_Click(object sender, EventArgs e)
        {
            if (TrabajostreeView.SelectedNode.Index == -1)
                return;
            double DebeRotar = Convert.ToDouble(RotaciontextBox.Text)-m_SistemaTecoi.m_Work[m_dIndexTrabajo].m_RotacionActual;
            if (DebeRotar == 0)
                return;

            m_SistemaTecoi.m_Work[m_dIndexTrabajo].m_RotacionActual = Convert.ToDouble(RotaciontextBox.Text);
            int hModelBlock = Lcad.DrwGetFirstObject(m_hDrw, Lcad.LC_OBJ_BLOCK);
            Lcad.BlockSelectEnt(hModelBlock, 0, false);
            int hEnt = Lcad.BlockGetFirstEnt(hModelBlock);
            while (hEnt != 0)
            {
                if (m_hCapaTrabajo[m_dIndexTrabajo] == Lcad.PropGetHandle(hEnt, Lcad.LC_PROP_ENT_LAYER))
                    Lcad.BlockSelectEnt(hModelBlock, hEnt, true);
                hEnt = Lcad.BlockGetNextEnt(hModelBlock, hEnt);
            }
            Lcad.BlockSelRotate(m_hBlock, 
                m_SistemaTecoi.m_Work[m_dIndexTrabajo].m_TraslacionX, 
                m_SistemaTecoi.m_Work[m_dIndexTrabajo].m_TraslacionY,
                DebeRotar*Math.PI/180.0, 
                false, false);
            Lcad.BlockSelectEnt(hModelBlock, 0, false);
            Lcad.WndRedraw(m_hLcWnd);
        }
    }
}

