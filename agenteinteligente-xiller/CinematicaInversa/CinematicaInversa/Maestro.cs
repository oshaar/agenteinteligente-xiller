using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CinematicaInversa
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

        private void cinematicaInversaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Principal form1 = new Principal();
            form1.MdiParent = this;
            form1.Show();
        }

        private void wiiMoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WiiMote form2 = new WiiMote();
            form2.MdiParent = this;
            form2.Show();
        }
    }
}
