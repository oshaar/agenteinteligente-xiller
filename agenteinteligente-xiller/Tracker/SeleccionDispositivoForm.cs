using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using dshow;
using dshow.Core;

namespace Tracker
{
    public partial class SeleccionDispositivoForm : Form
    {
        FilterCollection filtros;
        private string dispositivo;

        public string Dispositivo
        {
            get { return dispositivo; }
            set { dispositivo = value; }
        }
        public SeleccionDispositivoForm()
        {
            InitializeComponent();
            try
            {
                filtros = new FilterCollection(FilterCategory.VideoInputDevice);
                if (filtros.Count == 0) throw new ApplicationException();
                foreach (Filter filtro in filtros)
                    dispositivoComboBox.Items.Add(filtro.Name);             
            }
            catch (ApplicationException)
            {
                dispositivoComboBox.Items.Add("No se identifico ningun dispositivo.");
                dispositivoComboBox.Enabled = false;
                btnAceptar.Enabled = false;
            }
            dispositivoComboBox.SelectedIndex = 0;
        }

        private void SeleccionDispositivo_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            dispositivo = filtros[dispositivoComboBox.SelectedIndex].MonikerString;
        }

        private void CancelarBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
