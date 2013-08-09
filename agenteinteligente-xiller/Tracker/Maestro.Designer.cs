namespace Tracker
{
    partial class Maestro
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rastreadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deteccionDeMovimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rastreadorDeRostroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.rastreadorToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(562, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // rastreadorToolStripMenuItem
            // 
            this.rastreadorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deteccionDeMovimientoToolStripMenuItem,
            this.rastreadorDeRostroToolStripMenuItem});
            this.rastreadorToolStripMenuItem.Name = "rastreadorToolStripMenuItem";
            this.rastreadorToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.rastreadorToolStripMenuItem.Text = "Rastreador";
            // 
            // deteccionDeMovimientoToolStripMenuItem
            // 
            this.deteccionDeMovimientoToolStripMenuItem.Name = "deteccionDeMovimientoToolStripMenuItem";
            this.deteccionDeMovimientoToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.deteccionDeMovimientoToolStripMenuItem.Text = "Deteccion de Movimiento";
            this.deteccionDeMovimientoToolStripMenuItem.Click += new System.EventHandler(this.deteccionDeMovimientoToolStripMenuItem_Click);
            // 
            // rastreadorDeRostroToolStripMenuItem
            // 
            this.rastreadorDeRostroToolStripMenuItem.Name = "rastreadorDeRostroToolStripMenuItem";
            this.rastreadorDeRostroToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.rastreadorDeRostroToolStripMenuItem.Text = "Rastreador de Rostro";
            this.rastreadorDeRostroToolStripMenuItem.Click += new System.EventHandler(this.rastreadorDeRostroToolStripMenuItem_Click);
            // 
            // Maestro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 362);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Maestro";
            this.Text = "Rastreador de Rostro";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rastreadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deteccionDeMovimientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rastreadorDeRostroToolStripMenuItem;
    }
}