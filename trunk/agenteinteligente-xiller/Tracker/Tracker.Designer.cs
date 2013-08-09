namespace Tracker
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dispositivoLocalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wiiMoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cinematicaInversaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeXillerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnDetenerCamara = new System.Windows.Forms.Button();
            this.btnReproducir = new System.Windows.Forms.Button();
            this.pbFrame = new System.Windows.Forms.PictureBox();
            this.btnCapturar = new System.Windows.Forms.Button();
            this.btnAnalizar = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            this.cbxMotionAlgo = new System.Windows.Forms.ComboBox();
            this.chxAlarma = new System.Windows.Forms.CheckBox();
            this.cronometro = new System.Windows.Forms.Timer(this.components);
            this.chxCronometro = new System.Windows.Forms.CheckBox();
            this.listView = new System.Windows.Forms.ListView();
            this.ListaImagenes = new System.Windows.Forms.ImageList(this.components);
            this.pbxPrevio = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cameraWindow2 = new Tracker.Camera.CameraWindow();
            this.cameraWindow = new Tracker.Camera.CameraWindow();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPrevio)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.controlToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(950, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dispositivoLocalToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // dispositivoLocalToolStripMenuItem
            // 
            this.dispositivoLocalToolStripMenuItem.Name = "dispositivoLocalToolStripMenuItem";
            this.dispositivoLocalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.dispositivoLocalToolStripMenuItem.Text = "Dispositivo Local";
            this.dispositivoLocalToolStripMenuItem.Click += new System.EventHandler(this.dispositivoLocalToolStripMenuItem_Click);
            // 
            // controlToolStripMenuItem
            // 
            this.controlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wiiMoteToolStripMenuItem,
            this.cinematicaInversaToolStripMenuItem});
            this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
            this.controlToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.controlToolStripMenuItem.Text = "Control";
            // 
            // wiiMoteToolStripMenuItem
            // 
            this.wiiMoteToolStripMenuItem.Name = "wiiMoteToolStripMenuItem";
            this.wiiMoteToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.wiiMoteToolStripMenuItem.Text = "WiiMote";
            // 
            // cinematicaInversaToolStripMenuItem
            // 
            this.cinematicaInversaToolStripMenuItem.Name = "cinematicaInversaToolStripMenuItem";
            this.cinematicaInversaToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.cinematicaInversaToolStripMenuItem.Text = "Cinematica Inversa";
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeXillerToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaDeXillerToolStripMenuItem
            // 
            this.acercaDeXillerToolStripMenuItem.Name = "acercaDeXillerToolStripMenuItem";
            this.acercaDeXillerToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.acercaDeXillerToolStripMenuItem.Text = "Acerca de Xiller";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(626, 216);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(71, 64);
            this.btnIniciar.TabIndex = 2;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnDetenerCamara
            // 
            this.btnDetenerCamara.Location = new System.Drawing.Point(12, 260);
            this.btnDetenerCamara.Name = "btnDetenerCamara";
            this.btnDetenerCamara.Size = new System.Drawing.Size(35, 29);
            this.btnDetenerCamara.TabIndex = 4;
            this.btnDetenerCamara.Text = "||";
            this.btnDetenerCamara.UseVisualStyleBackColor = true;
            this.btnDetenerCamara.Click += new System.EventHandler(this.btnDetenerCamara_Click);
            // 
            // btnReproducir
            // 
            this.btnReproducir.Location = new System.Drawing.Point(53, 260);
            this.btnReproducir.Name = "btnReproducir";
            this.btnReproducir.Size = new System.Drawing.Size(33, 29);
            this.btnReproducir.TabIndex = 5;
            this.btnReproducir.Text = ">";
            this.btnReproducir.UseVisualStyleBackColor = true;
            this.btnReproducir.Click += new System.EventHandler(this.btnReproducir_Click);
            // 
            // pbFrame
            // 
            this.pbFrame.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbFrame.Location = new System.Drawing.Point(12, 295);
            this.pbFrame.Name = "pbFrame";
            this.pbFrame.Size = new System.Drawing.Size(288, 216);
            this.pbFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFrame.TabIndex = 6;
            this.pbFrame.TabStop = false;
            // 
            // btnCapturar
            // 
            this.btnCapturar.Location = new System.Drawing.Point(92, 260);
            this.btnCapturar.Name = "btnCapturar";
            this.btnCapturar.Size = new System.Drawing.Size(78, 29);
            this.btnCapturar.TabIndex = 7;
            this.btnCapturar.Text = "Capturar";
            this.btnCapturar.UseVisualStyleBackColor = true;
            this.btnCapturar.Click += new System.EventHandler(this.btnCapturar_Click);
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.Location = new System.Drawing.Point(12, 530);
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.Size = new System.Drawing.Size(203, 24);
            this.btnAnalizar.TabIndex = 8;
            this.btnAnalizar.Text = "Analizar";
            this.btnAnalizar.UseVisualStyleBackColor = true;
            this.btnAnalizar.Click += new System.EventHandler(this.btnAnalizar_Click);
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Location = new System.Drawing.Point(6, 514);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(35, 13);
            this.lblResultado.TabIndex = 9;
            this.lblResultado.Text = "label1";
            // 
            // cbxMotionAlgo
            // 
            this.cbxMotionAlgo.FormattingEnabled = true;
            this.cbxMotionAlgo.Items.AddRange(new object[] {
            "<ninguno>",
            "Algoritmo 01",
            "Algoritmo 02",
            "Algoritmo 03",
            "Algoritmo 03 Optimizado",
            "Algoritmo 04"});
            this.cbxMotionAlgo.Location = new System.Drawing.Point(315, 261);
            this.cbxMotionAlgo.Name = "cbxMotionAlgo";
            this.cbxMotionAlgo.Size = new System.Drawing.Size(224, 21);
            this.cbxMotionAlgo.TabIndex = 11;
            this.cbxMotionAlgo.SelectedIndexChanged += new System.EventHandler(this.cbxMotionAlgo_SelectedIndexChanged);
            // 
            // chxAlarma
            // 
            this.chxAlarma.AutoSize = true;
            this.chxAlarma.Location = new System.Drawing.Point(545, 263);
            this.chxAlarma.Name = "chxAlarma";
            this.chxAlarma.Size = new System.Drawing.Size(58, 17);
            this.chxAlarma.TabIndex = 12;
            this.chxAlarma.Text = "Alarma";
            this.chxAlarma.UseVisualStyleBackColor = true;
            // 
            // cronometro
            // 
            this.cronometro.Interval = 500;
            this.cronometro.Tick += new System.EventHandler(this.cronometro_Tick);
            // 
            // chxCronometro
            // 
            this.chxCronometro.AutoSize = true;
            this.chxCronometro.Location = new System.Drawing.Point(222, 532);
            this.chxCronometro.Name = "chxCronometro";
            this.chxCronometro.Size = new System.Drawing.Size(80, 17);
            this.chxCronometro.TabIndex = 13;
            this.chxCronometro.Text = "Cronometro";
            this.chxCronometro.UseVisualStyleBackColor = true;
            this.chxCronometro.CheckedChanged += new System.EventHandler(this.chxCronometro_CheckedChanged);
            // 
            // listView
            // 
            this.listView.GridLines = true;
            this.listView.LargeImageList = this.ListaImagenes;
            this.listView.Location = new System.Drawing.Point(315, 295);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(290, 216);
            this.listView.TabIndex = 14;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.List;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            this.listView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView_ItemSelectionChanged);
            // 
            // ListaImagenes
            // 
            this.ListaImagenes.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.ListaImagenes.ImageSize = new System.Drawing.Size(256, 192);
            this.ListaImagenes.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pbxPrevio
            // 
            this.pbxPrevio.Location = new System.Drawing.Point(626, 295);
            this.pbxPrevio.Name = "pbxPrevio";
            this.pbxPrevio.Size = new System.Drawing.Size(288, 216);
            this.pbxPrevio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxPrevio.TabIndex = 15;
            this.pbxPrevio.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(626, 514);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "label1";
            // 
            // cameraWindow2
            // 
            this.cameraWindow2.Camera = null;
            this.cameraWindow2.Location = new System.Drawing.Point(315, 38);
            this.cameraWindow2.Name = "cameraWindow2";
            this.cameraWindow2.Size = new System.Drawing.Size(288, 216);
            this.cameraWindow2.TabIndex = 10;
            this.cameraWindow2.Text = "cameraWindow1";
            // 
            // cameraWindow
            // 
            this.cameraWindow.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cameraWindow.Camera = null;
            this.cameraWindow.Location = new System.Drawing.Point(12, 38);
            this.cameraWindow.Name = "cameraWindow";
            this.cameraWindow.Size = new System.Drawing.Size(288, 216);
            this.cameraWindow.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 561);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbxPrevio);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.chxCronometro);
            this.Controls.Add(this.chxAlarma);
            this.Controls.Add(this.cbxMotionAlgo);
            this.Controls.Add(this.cameraWindow2);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.btnAnalizar);
            this.Controls.Add(this.btnCapturar);
            this.Controls.Add(this.pbFrame);
            this.Controls.Add(this.btnReproducir);
            this.Controls.Add(this.btnDetenerCamara);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.cameraWindow);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Xiller";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPrevio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tracker.Camera.CameraWindow cameraWindow;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dispositivoLocalToolStripMenuItem;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnDetenerCamara;
        private System.Windows.Forms.Button btnReproducir;
        private System.Windows.Forms.PictureBox pbFrame;
        private System.Windows.Forms.Button btnCapturar;
        private System.Windows.Forms.Button btnAnalizar;
        private System.Windows.Forms.Label lblResultado;
        private Tracker.Camera.CameraWindow cameraWindow2;
        private System.Windows.Forms.ComboBox cbxMotionAlgo;
        private System.Windows.Forms.CheckBox chxAlarma;
        private System.Windows.Forms.Timer cronometro;
        private System.Windows.Forms.CheckBox chxCronometro;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ImageList ListaImagenes;
        private System.Windows.Forms.PictureBox pbxPrevio;
        private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wiiMoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cinematicaInversaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeXillerToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}

