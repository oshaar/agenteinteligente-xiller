namespace Tracker
{
    partial class RostroTracker
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dispositivoLocalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wiiMoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cinematicaInversaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeXillerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.cbxRastreo = new System.Windows.Forms.CheckBox();
            this.lblResultado = new System.Windows.Forms.Label();
            this.pbFrame = new System.Windows.Forms.PictureBox();
            this.lblRostros = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPuerto = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.PuertoSerie = new System.IO.Ports.SerialPort(this.components);
            this.cronometro = new System.Windows.Forms.Timer(this.components);
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.cameraWindow = new Tracker.Camera.CameraWindow();
            this.btnHuella = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 2;
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
            this.timer.Interval = 750;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // cbxRastreo
            // 
            this.cbxRastreo.AutoSize = true;
            this.cbxRastreo.Location = new System.Drawing.Point(48, 271);
            this.cbxRastreo.Name = "cbxRastreo";
            this.cbxRastreo.Size = new System.Drawing.Size(153, 17);
            this.cbxRastreo.TabIndex = 3;
            this.cbxRastreo.Text = "Habilitar Rastreo de Rostro";
            this.cbxRastreo.UseVisualStyleBackColor = true;
            this.cbxRastreo.CheckedChanged += new System.EventHandler(this.cbxRastreo_CheckedChanged);
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Location = new System.Drawing.Point(48, 295);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(136, 13);
            this.lblResultado.TabIndex = 4;
            this.lblResultado.Text = "Ningun Rostro Reconocido";
            // 
            // pbFrame
            // 
            this.pbFrame.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pbFrame.Location = new System.Drawing.Point(369, 49);
            this.pbFrame.Name = "pbFrame";
            this.pbFrame.Size = new System.Drawing.Size(288, 216);
            this.pbFrame.TabIndex = 5;
            this.pbFrame.TabStop = false;
            // 
            // lblRostros
            // 
            this.lblRostros.AutoSize = true;
            this.lblRostros.Location = new System.Drawing.Point(599, 272);
            this.lblRostros.Name = "lblRostros";
            this.lblRostros.Size = new System.Drawing.Size(58, 13);
            this.lblRostros.TabIndex = 6;
            this.lblRostros.Text = "Rostros : 0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(375, 295);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "<vacio>";
            // 
            // txtPuerto
            // 
            this.txtPuerto.Location = new System.Drawing.Point(130, 322);
            this.txtPuerto.MaxLength = 4;
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(71, 20);
            this.txtPuerto.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(52, 320);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Conectar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PuertoSerie
            // 
            this.PuertoSerie.ParityReplace = ((byte)(0));
            // 
            // cronometro
            // 
            this.cronometro.Interval = 500;
            this.cronometro.Tick += new System.EventHandler(this.cronometro_Tick);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(48, 348);
            this.trackBar1.Maximum = 250;
            this.trackBar1.Minimum = 50;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(609, 45);
            this.trackBar1.TabIndex = 10;
            this.trackBar1.Value = 150;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(375, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "<vacio>";
            // 
            // cameraWindow
            // 
            this.cameraWindow.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cameraWindow.Camera = null;
            this.cameraWindow.Location = new System.Drawing.Point(48, 49);
            this.cameraWindow.Name = "cameraWindow";
            this.cameraWindow.Size = new System.Drawing.Size(288, 216);
            this.cameraWindow.TabIndex = 0;
            this.cameraWindow.Text = "cameraWindow1";
            // 
            // btnHuella
            // 
            this.btnHuella.Location = new System.Drawing.Point(450, 271);
            this.btnHuella.Name = "btnHuella";
            this.btnHuella.Size = new System.Drawing.Size(124, 23);
            this.btnHuella.TabIndex = 12;
            this.btnHuella.Text = "Huella Dactilar";
            this.btnHuella.UseVisualStyleBackColor = true;
            this.btnHuella.Visible = false;
            this.btnHuella.Click += new System.EventHandler(this.btnHuella_Click);
            // 
            // RostroTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 393);
            this.Controls.Add(this.btnHuella);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.txtPuerto);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRostros);
            this.Controls.Add(this.pbFrame);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.cbxRastreo);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.cameraWindow);
            this.Name = "RostroTracker";
            this.Text = "RostroTracker";
            this.Load += new System.EventHandler(this.RostroTracker_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RostroTracker_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tracker.Camera.CameraWindow cameraWindow;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dispositivoLocalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wiiMoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cinematicaInversaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeXillerToolStripMenuItem;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.CheckBox cbxRastreo;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.PictureBox pbFrame;
        private System.Windows.Forms.Label lblRostros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPuerto;
        private System.Windows.Forms.Button button1;
        private System.IO.Ports.SerialPort PuertoSerie;
        private System.Windows.Forms.Timer cronometro;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnHuella;
    }
}