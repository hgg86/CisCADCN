namespace Test1
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Generalpanel = new System.Windows.Forms.Panel();
            this.Comandospanel = new System.Windows.Forms.Panel();
            this.Movilpanel = new System.Windows.Forms.Panel();
            this.Rotarbutton = new System.Windows.Forms.Button();
            this.Trasladarbutton = new System.Windows.Forms.Button();
            this.RotaciontextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TrasladarYtextBox = new System.Windows.Forms.TextBox();
            this.TrasladarXtextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SubrutinasButton = new System.Windows.Forms.Button();
            this.MaquinasVirtualesbutton = new System.Windows.Forms.Button();
            this.EnviarSubrutinasbutton = new System.Windows.Forms.Button();
            this.ToolspictureBox = new System.Windows.Forms.PictureBox();
            this.Estadopanel = new System.Windows.Forms.Panel();
            this.EjeYlabel = new System.Windows.Forms.Label();
            this.EjeXlabel = new System.Windows.Forms.Label();
            this.AlarmastextBox = new System.Windows.Forms.TextBox();
            this.EstadoAutomatalabel = new System.Windows.Forms.Label();
            this.EjeZlabel = new System.Windows.Forms.Label();
            this.ZoomWinbutton = new System.Windows.Forms.Button();
            this.ZoomOutbutton = new System.Windows.Forms.Button();
            this.ZoomInbutton = new System.Windows.Forms.Button();
            this.ZoomAllbutton = new System.Windows.Forms.Button();
            this.EnviarDNCButton = new System.Windows.Forms.Button();
            this.TrabajoOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.TemporizadorGeneral = new System.Windows.Forms.Timer(this.components);
            this.ConfiguracionOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.TrabajosimageList = new System.Windows.Forms.ImageList(this.components);
            this.TreeViewpanel = new System.Windows.Forms.Panel();
            this.BajarTrabajobutton = new System.Windows.Forms.Button();
            this.SubirTrabajobutton = new System.Windows.Forms.Button();
            this.EliminarTrabajobutton = new System.Windows.Forms.Button();
            this.Abrirbutton = new System.Windows.Forms.Button();
            this.TrabajostreeView = new System.Windows.Forms.TreeView();
            this.Generalpanel.SuspendLayout();
            this.Comandospanel.SuspendLayout();
            this.Movilpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToolspictureBox)).BeginInit();
            this.Estadopanel.SuspendLayout();
            this.TreeViewpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Generalpanel
            // 
            this.Generalpanel.BackColor = System.Drawing.SystemColors.Control;
            this.Generalpanel.Controls.Add(this.Comandospanel);
            this.Generalpanel.Controls.Add(this.Estadopanel);
            this.Generalpanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Generalpanel.Location = new System.Drawing.Point(0, 504);
            this.Generalpanel.Name = "Generalpanel";
            this.Generalpanel.Size = new System.Drawing.Size(1201, 144);
            this.Generalpanel.TabIndex = 2;
            // 
            // Comandospanel
            // 
            this.Comandospanel.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Comandospanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Comandospanel.Controls.Add(this.Movilpanel);
            this.Comandospanel.Location = new System.Drawing.Point(495, 6);
            this.Comandospanel.Name = "Comandospanel";
            this.Comandospanel.Size = new System.Drawing.Size(703, 103);
            this.Comandospanel.TabIndex = 16;
            // 
            // Movilpanel
            // 
            this.Movilpanel.Controls.Add(this.Rotarbutton);
            this.Movilpanel.Controls.Add(this.Trasladarbutton);
            this.Movilpanel.Controls.Add(this.RotaciontextBox);
            this.Movilpanel.Controls.Add(this.label3);
            this.Movilpanel.Controls.Add(this.TrasladarYtextBox);
            this.Movilpanel.Controls.Add(this.TrasladarXtextBox);
            this.Movilpanel.Controls.Add(this.label2);
            this.Movilpanel.Controls.Add(this.label1);
            this.Movilpanel.Controls.Add(this.SubrutinasButton);
            this.Movilpanel.Controls.Add(this.MaquinasVirtualesbutton);
            this.Movilpanel.Controls.Add(this.EnviarSubrutinasbutton);
            this.Movilpanel.Controls.Add(this.ToolspictureBox);
            this.Movilpanel.Location = new System.Drawing.Point(0, 0);
            this.Movilpanel.Name = "Movilpanel";
            this.Movilpanel.Size = new System.Drawing.Size(691, 102);
            this.Movilpanel.TabIndex = 17;
            this.Movilpanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Movilpanel_MouseDown);
            this.Movilpanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Movilpanel_MouseMove);
            this.Movilpanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Movilpanel_MouseUp);
            // 
            // Rotarbutton
            // 
            this.Rotarbutton.Location = new System.Drawing.Point(239, 40);
            this.Rotarbutton.Name = "Rotarbutton";
            this.Rotarbutton.Size = new System.Drawing.Size(64, 37);
            this.Rotarbutton.TabIndex = 23;
            this.Rotarbutton.Text = "Rotar";
            this.Rotarbutton.UseVisualStyleBackColor = true;
            this.Rotarbutton.Click += new System.EventHandler(this.Rotarbutton_Click);
            this.Rotarbutton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Movilpanel_MouseDown);
            this.Rotarbutton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Movilpanel_MouseMove);
            this.Rotarbutton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Movilpanel_MouseUp);
            // 
            // Trasladarbutton
            // 
            this.Trasladarbutton.Location = new System.Drawing.Point(239, 3);
            this.Trasladarbutton.Name = "Trasladarbutton";
            this.Trasladarbutton.Size = new System.Drawing.Size(64, 37);
            this.Trasladarbutton.TabIndex = 22;
            this.Trasladarbutton.Text = "Trasladar";
            this.Trasladarbutton.UseVisualStyleBackColor = true;
            this.Trasladarbutton.Click += new System.EventHandler(this.Trasladarbutton_Click);
            this.Trasladarbutton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Movilpanel_MouseDown);
            this.Trasladarbutton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Movilpanel_MouseMove);
            this.Trasladarbutton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Movilpanel_MouseUp);
            // 
            // RotaciontextBox
            // 
            this.RotaciontextBox.Location = new System.Drawing.Point(162, 54);
            this.RotaciontextBox.Name = "RotaciontextBox";
            this.RotaciontextBox.Size = new System.Drawing.Size(71, 20);
            this.RotaciontextBox.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Rotar";
            // 
            // TrasladarYtextBox
            // 
            this.TrasladarYtextBox.Location = new System.Drawing.Point(162, 30);
            this.TrasladarYtextBox.Name = "TrasladarYtextBox";
            this.TrasladarYtextBox.Size = new System.Drawing.Size(71, 20);
            this.TrasladarYtextBox.TabIndex = 19;
            // 
            // TrasladarXtextBox
            // 
            this.TrasladarXtextBox.Location = new System.Drawing.Point(162, 6);
            this.TrasladarXtextBox.Name = "TrasladarXtextBox";
            this.TrasladarXtextBox.Size = new System.Drawing.Size(71, 20);
            this.TrasladarXtextBox.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Trasladar Y";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Movilpanel_MouseDown);
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Movilpanel_MouseMove);
            this.label2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Movilpanel_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Trasladar X";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Movilpanel_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Movilpanel_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Movilpanel_MouseUp);
            // 
            // SubrutinasButton
            // 
            this.SubrutinasButton.Location = new System.Drawing.Point(3, 0);
            this.SubrutinasButton.Name = "SubrutinasButton";
            this.SubrutinasButton.Size = new System.Drawing.Size(86, 45);
            this.SubrutinasButton.TabIndex = 3;
            this.SubrutinasButton.Text = "Generar Subrutinas";
            this.SubrutinasButton.UseVisualStyleBackColor = true;
            this.SubrutinasButton.Click += new System.EventHandler(this.SubrutinasButton_Click);
            this.SubrutinasButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Movilpanel_MouseDown);
            this.SubrutinasButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Movilpanel_MouseMove);
            this.SubrutinasButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Movilpanel_MouseUp);
            // 
            // MaquinasVirtualesbutton
            // 
            this.MaquinasVirtualesbutton.Enabled = false;
            this.MaquinasVirtualesbutton.Location = new System.Drawing.Point(560, 6);
            this.MaquinasVirtualesbutton.Name = "MaquinasVirtualesbutton";
            this.MaquinasVirtualesbutton.Size = new System.Drawing.Size(128, 42);
            this.MaquinasVirtualesbutton.TabIndex = 1;
            this.MaquinasVirtualesbutton.Text = "Maq. Virtual";
            this.MaquinasVirtualesbutton.UseVisualStyleBackColor = true;
            this.MaquinasVirtualesbutton.Click += new System.EventHandler(this.MaquinasVirtualesbutton_Click);
            this.MaquinasVirtualesbutton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Movilpanel_MouseDown);
            this.MaquinasVirtualesbutton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Movilpanel_MouseMove);
            this.MaquinasVirtualesbutton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Movilpanel_MouseUp);
            // 
            // EnviarSubrutinasbutton
            // 
            this.EnviarSubrutinasbutton.Location = new System.Drawing.Point(3, 47);
            this.EnviarSubrutinasbutton.Name = "EnviarSubrutinasbutton";
            this.EnviarSubrutinasbutton.Size = new System.Drawing.Size(86, 45);
            this.EnviarSubrutinasbutton.TabIndex = 14;
            this.EnviarSubrutinasbutton.Text = "Enviar Subrutinas";
            this.EnviarSubrutinasbutton.UseVisualStyleBackColor = true;
            this.EnviarSubrutinasbutton.Click += new System.EventHandler(this.EnviarSubrutinasbutton_Click);
            this.EnviarSubrutinasbutton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Movilpanel_MouseDown);
            this.EnviarSubrutinasbutton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Movilpanel_MouseMove);
            this.EnviarSubrutinasbutton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Movilpanel_MouseUp);
            // 
            // ToolspictureBox
            // 
            this.ToolspictureBox.Image = global::Test1.Properties.Resources.Herramientas;
            this.ToolspictureBox.Location = new System.Drawing.Point(484, 6);
            this.ToolspictureBox.Name = "ToolspictureBox";
            this.ToolspictureBox.Size = new System.Drawing.Size(70, 70);
            this.ToolspictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ToolspictureBox.TabIndex = 15;
            this.ToolspictureBox.TabStop = false;
            this.ToolspictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Movilpanel_MouseDown);
            this.ToolspictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Movilpanel_MouseMove);
            this.ToolspictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Movilpanel_MouseUp);
            // 
            // Estadopanel
            // 
            this.Estadopanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Estadopanel.Controls.Add(this.EjeYlabel);
            this.Estadopanel.Controls.Add(this.EjeXlabel);
            this.Estadopanel.Controls.Add(this.AlarmastextBox);
            this.Estadopanel.Controls.Add(this.EstadoAutomatalabel);
            this.Estadopanel.Controls.Add(this.EjeZlabel);
            this.Estadopanel.Location = new System.Drawing.Point(6, 6);
            this.Estadopanel.Name = "Estadopanel";
            this.Estadopanel.Size = new System.Drawing.Size(483, 103);
            this.Estadopanel.TabIndex = 15;
            // 
            // EjeYlabel
            // 
            this.EjeYlabel.AutoSize = true;
            this.EjeYlabel.Location = new System.Drawing.Point(3, 21);
            this.EjeYlabel.Name = "EjeYlabel";
            this.EjeYlabel.Size = new System.Drawing.Size(35, 13);
            this.EjeYlabel.TabIndex = 9;
            this.EjeYlabel.Text = "label2";
            // 
            // EjeXlabel
            // 
            this.EjeXlabel.AutoSize = true;
            this.EjeXlabel.Location = new System.Drawing.Point(3, 2);
            this.EjeXlabel.Name = "EjeXlabel";
            this.EjeXlabel.Size = new System.Drawing.Size(35, 13);
            this.EjeXlabel.TabIndex = 8;
            this.EjeXlabel.Text = "label1";
            // 
            // AlarmastextBox
            // 
            this.AlarmastextBox.AcceptsReturn = true;
            this.AlarmastextBox.AcceptsTab = true;
            this.AlarmastextBox.Location = new System.Drawing.Point(148, 3);
            this.AlarmastextBox.Multiline = true;
            this.AlarmastextBox.Name = "AlarmastextBox";
            this.AlarmastextBox.ReadOnly = true;
            this.AlarmastextBox.Size = new System.Drawing.Size(325, 95);
            this.AlarmastextBox.TabIndex = 11;
            // 
            // EstadoAutomatalabel
            // 
            this.EstadoAutomatalabel.AutoSize = true;
            this.EstadoAutomatalabel.Location = new System.Drawing.Point(3, 63);
            this.EstadoAutomatalabel.Name = "EstadoAutomatalabel";
            this.EstadoAutomatalabel.Size = new System.Drawing.Size(19, 13);
            this.EstadoAutomatalabel.TabIndex = 12;
            this.EstadoAutomatalabel.Text = "17";
            // 
            // EjeZlabel
            // 
            this.EjeZlabel.AutoSize = true;
            this.EjeZlabel.Location = new System.Drawing.Point(3, 40);
            this.EjeZlabel.Name = "EjeZlabel";
            this.EjeZlabel.Size = new System.Drawing.Size(35, 13);
            this.EjeZlabel.TabIndex = 10;
            this.EjeZlabel.Text = "label3";
            // 
            // ZoomWinbutton
            // 
            this.ZoomWinbutton.Location = new System.Drawing.Point(214, 352);
            this.ZoomWinbutton.Name = "ZoomWinbutton";
            this.ZoomWinbutton.Size = new System.Drawing.Size(52, 45);
            this.ZoomWinbutton.TabIndex = 13;
            this.ZoomWinbutton.Text = "Zoom Win";
            this.ZoomWinbutton.UseVisualStyleBackColor = true;
            this.ZoomWinbutton.Click += new System.EventHandler(this.Panbutton_Click);
            // 
            // ZoomOutbutton
            // 
            this.ZoomOutbutton.Location = new System.Drawing.Point(214, 402);
            this.ZoomOutbutton.Name = "ZoomOutbutton";
            this.ZoomOutbutton.Size = new System.Drawing.Size(52, 45);
            this.ZoomOutbutton.TabIndex = 6;
            this.ZoomOutbutton.Text = "Zoom Out";
            this.ZoomOutbutton.UseVisualStyleBackColor = true;
            this.ZoomOutbutton.Click += new System.EventHandler(this.ZoomOutbutton_Click);
            // 
            // ZoomInbutton
            // 
            this.ZoomInbutton.Location = new System.Drawing.Point(214, 453);
            this.ZoomInbutton.Name = "ZoomInbutton";
            this.ZoomInbutton.Size = new System.Drawing.Size(52, 45);
            this.ZoomInbutton.TabIndex = 5;
            this.ZoomInbutton.Text = "Zoom In";
            this.ZoomInbutton.UseVisualStyleBackColor = true;
            this.ZoomInbutton.Click += new System.EventHandler(this.ZoomInbutton_Click);
            // 
            // ZoomAllbutton
            // 
            this.ZoomAllbutton.Location = new System.Drawing.Point(214, 302);
            this.ZoomAllbutton.Name = "ZoomAllbutton";
            this.ZoomAllbutton.Size = new System.Drawing.Size(52, 45);
            this.ZoomAllbutton.TabIndex = 4;
            this.ZoomAllbutton.Text = "Zoom All";
            this.ZoomAllbutton.UseVisualStyleBackColor = true;
            this.ZoomAllbutton.Click += new System.EventHandler(this.ZoomAllbutton_Click);
            // 
            // EnviarDNCButton
            // 
            this.EnviarDNCButton.Location = new System.Drawing.Point(97, 352);
            this.EnviarDNCButton.Name = "EnviarDNCButton";
            this.EnviarDNCButton.Size = new System.Drawing.Size(86, 45);
            this.EnviarDNCButton.TabIndex = 2;
            this.EnviarDNCButton.Text = "Enviar";
            this.EnviarDNCButton.UseVisualStyleBackColor = true;
            this.EnviarDNCButton.Click += new System.EventHandler(this.EnviarDNCButton_Click);
            // 
            // TrabajoOpenFileDialog
            // 
            this.TrabajoOpenFileDialog.DefaultExt = "cis";
            this.TrabajoOpenFileDialog.Filter = "Fichero de Trabajo (*.cis)|*.cis|Fichero Mint (*.mnt)|*.mnt";
            this.TrabajoOpenFileDialog.Multiselect = true;
            // 
            // TemporizadorGeneral
            // 
            this.TemporizadorGeneral.Interval = 80;
            this.TemporizadorGeneral.Tick += new System.EventHandler(this.TemporizadorGeneral_Tick);
            // 
            // ConfiguracionOpenFileDialog
            // 
            this.ConfiguracionOpenFileDialog.DefaultExt = "cfg";
            this.ConfiguracionOpenFileDialog.Filter = "Fichero de ConPiezación (*.cnf)|*.cfg";
            // 
            // TrabajosimageList
            // 
            this.TrabajosimageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TrabajosimageList.ImageStream")));
            this.TrabajosimageList.TransparentColor = System.Drawing.Color.Transparent;
            this.TrabajosimageList.Images.SetKeyName(0, "CintaMetrica.bmp");
            this.TrabajosimageList.Images.SetKeyName(1, "DesdeElComienzo.bmp");
            this.TrabajosimageList.Images.SetKeyName(2, "CajaFuerte.bmp");
            this.TrabajosimageList.Images.SetKeyName(3, "Retroceso.bmp");
            // 
            // TreeViewpanel
            // 
            this.TreeViewpanel.Controls.Add(this.BajarTrabajobutton);
            this.TreeViewpanel.Controls.Add(this.ZoomWinbutton);
            this.TreeViewpanel.Controls.Add(this.SubirTrabajobutton);
            this.TreeViewpanel.Controls.Add(this.EliminarTrabajobutton);
            this.TreeViewpanel.Controls.Add(this.Abrirbutton);
            this.TreeViewpanel.Controls.Add(this.TrabajostreeView);
            this.TreeViewpanel.Controls.Add(this.EnviarDNCButton);
            this.TreeViewpanel.Controls.Add(this.ZoomInbutton);
            this.TreeViewpanel.Controls.Add(this.ZoomOutbutton);
            this.TreeViewpanel.Controls.Add(this.ZoomAllbutton);
            this.TreeViewpanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.TreeViewpanel.Location = new System.Drawing.Point(0, 0);
            this.TreeViewpanel.Name = "TreeViewpanel";
            this.TreeViewpanel.Size = new System.Drawing.Size(271, 504);
            this.TreeViewpanel.TabIndex = 3;
            // 
            // BajarTrabajobutton
            // 
            this.BajarTrabajobutton.Location = new System.Drawing.Point(154, 301);
            this.BajarTrabajobutton.Name = "BajarTrabajobutton";
            this.BajarTrabajobutton.Size = new System.Drawing.Size(54, 46);
            this.BajarTrabajobutton.TabIndex = 21;
            this.BajarTrabajobutton.Text = "Bajar";
            this.BajarTrabajobutton.UseVisualStyleBackColor = true;
            this.BajarTrabajobutton.Click += new System.EventHandler(this.BajarTrabajobutton_Click);
            // 
            // SubirTrabajobutton
            // 
            this.SubirTrabajobutton.Location = new System.Drawing.Point(97, 301);
            this.SubirTrabajobutton.Name = "SubirTrabajobutton";
            this.SubirTrabajobutton.Size = new System.Drawing.Size(54, 46);
            this.SubirTrabajobutton.TabIndex = 20;
            this.SubirTrabajobutton.Text = "Subir";
            this.SubirTrabajobutton.UseVisualStyleBackColor = true;
            this.SubirTrabajobutton.Click += new System.EventHandler(this.SubirTrabajobutton_Click);
            // 
            // EliminarTrabajobutton
            // 
            this.EliminarTrabajobutton.Location = new System.Drawing.Point(4, 352);
            this.EliminarTrabajobutton.Name = "EliminarTrabajobutton";
            this.EliminarTrabajobutton.Size = new System.Drawing.Size(85, 45);
            this.EliminarTrabajobutton.TabIndex = 19;
            this.EliminarTrabajobutton.Text = "Eliminar";
            this.EliminarTrabajobutton.UseVisualStyleBackColor = true;
            this.EliminarTrabajobutton.Click += new System.EventHandler(this.EliminarTrabajobutton_Click);
            // 
            // Abrirbutton
            // 
            this.Abrirbutton.Location = new System.Drawing.Point(6, 300);
            this.Abrirbutton.Name = "Abrirbutton";
            this.Abrirbutton.Size = new System.Drawing.Size(85, 46);
            this.Abrirbutton.TabIndex = 18;
            this.Abrirbutton.Text = "Abrir";
            this.Abrirbutton.UseVisualStyleBackColor = true;
            this.Abrirbutton.Click += new System.EventHandler(this.Abrirbutton_Click);
            // 
            // TrabajostreeView
            // 
            this.TrabajostreeView.CheckBoxes = true;
            this.TrabajostreeView.HideSelection = false;
            this.TrabajostreeView.ImageIndex = 0;
            this.TrabajostreeView.ImageList = this.TrabajosimageList;
            this.TrabajostreeView.Location = new System.Drawing.Point(6, 10);
            this.TrabajostreeView.Name = "TrabajostreeView";
            this.TrabajostreeView.SelectedImageIndex = 0;
            this.TrabajostreeView.Size = new System.Drawing.Size(262, 284);
            this.TrabajostreeView.TabIndex = 17;
            this.TrabajostreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TrabajostreeView_AfterCheck);
            this.TrabajostreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TrabajostreeView_AfterSelect);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 648);
            this.Controls.Add(this.TreeViewpanel);
            this.Controls.Add(this.Generalpanel);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "xCisCADC";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize_1);
            this.Generalpanel.ResumeLayout(false);
            this.Comandospanel.ResumeLayout(false);
            this.Movilpanel.ResumeLayout(false);
            this.Movilpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToolspictureBox)).EndInit();
            this.Estadopanel.ResumeLayout(false);
            this.Estadopanel.PerformLayout();
            this.TreeViewpanel.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel Generalpanel;
    private System.Windows.Forms.OpenFileDialog TrabajoOpenFileDialog;
    private System.Windows.Forms.Timer TemporizadorGeneral;
    private System.Windows.Forms.Button MaquinasVirtualesbutton;
    private System.Windows.Forms.Button EnviarDNCButton;
    private System.Windows.Forms.OpenFileDialog ConfiguracionOpenFileDialog;
    private System.Windows.Forms.Button SubrutinasButton;
        private System.Windows.Forms.Button ZoomAllbutton;
        private System.Windows.Forms.Button ZoomOutbutton;
        private System.Windows.Forms.Button ZoomInbutton;
        private System.Windows.Forms.Label EjeXlabel;
        private System.Windows.Forms.Label EjeZlabel;
        private System.Windows.Forms.Label EjeYlabel;
        private System.Windows.Forms.TextBox AlarmastextBox;
        private System.Windows.Forms.Label EstadoAutomatalabel;
        private System.Windows.Forms.ImageList TrabajosimageList;
        private System.Windows.Forms.Panel TreeViewpanel;
        private System.Windows.Forms.TreeView TrabajostreeView;
        private System.Windows.Forms.Button EliminarTrabajobutton;
        private System.Windows.Forms.Button Abrirbutton;
        private System.Windows.Forms.Button BajarTrabajobutton;
        private System.Windows.Forms.Button SubirTrabajobutton;
        private System.Windows.Forms.Button ZoomWinbutton;
        private System.Windows.Forms.Button EnviarSubrutinasbutton;
        private System.Windows.Forms.Panel Estadopanel;
        private System.Windows.Forms.Panel Comandospanel;
        private System.Windows.Forms.PictureBox ToolspictureBox;
        private System.Windows.Forms.Panel Movilpanel;
        private System.Windows.Forms.Button Rotarbutton;
        private System.Windows.Forms.Button Trasladarbutton;
        private System.Windows.Forms.TextBox RotaciontextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TrasladarYtextBox;
        private System.Windows.Forms.TextBox TrasladarXtextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

