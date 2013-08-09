using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tracker
{
    public partial class Maestro : Form
    {
        public Maestro()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void deteccionDeMovimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.MdiParent = this;
            form.Show();
        }

        private void rastreadorDeRostroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RostroTracker form2 = new RostroTracker();
            form2.MdiParent =this;
            form2.Show();
        }
    }
}
