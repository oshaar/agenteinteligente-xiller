using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using WiimoteLib;
using CinematicaInversa.xiller.wii;
using CinematicaInversa.xiller.serie;
using puertoserie.xiller.serie.angulo;

namespace CinematicaInversa
{
    public partial class WiiMote : Form
    {
        private delegate void UpdateWiimoteStateDelegate(WiimoteChangedEventArgs args);
        private Wiimote wm = new Wiimote();
        private Mutex m = new Mutex();
        public WiiEstado wiiEstados;
        public WiiControl control;
        public WiiPanel wPanel;
        public Almacen almacen;
        private Boolean EstadoBotonConectar = true;
        public WiiMote()
        {
            InitializeComponent();

          //  this.panel1.Paint +=new PaintEventHandler(panel1_Paint);
        }
        private void CargarWiiMote() {
            try
            {
                wm.WiimoteChanged += new WiimoteChangedEventHandler(wm_OnWiimoteChanged);
                //wm.WiimoteExtensionChanged += new WiimoteExtensionChangedEventHandler(wm_WiimoteExtensionChanged);

                wm.Connect();
                wm.SetReportType(Wiimote.InputReport.IRAccel, true);
                wm.SetLEDs(false, true, true, false);

                
            }
            catch (Exception ex)
            {
                FormError error = new FormError();
                error.txtMensajeError.Text = ex.Message + "\n LA APLICACION SE CERRARA.";
                error.ShowDialog();
                error.Dispose();
                Application.Exit();
                //this.Close();
                //this.Dispose();
            }
        }
        private void UpdateWiimoteState(WiimoteChangedEventArgs args)
        {
            m.WaitOne();

            WiimoteState ws = args.WiimoteState;

            wiiEstados.A = ws.ButtonState.A;
            wiiEstados.B = ws.ButtonState.B;
            wiiEstados.Up = ws.ButtonState.Up;
            wiiEstados.Down = ws.ButtonState.Down;
            wiiEstados.Left = ws.ButtonState.Left;
            wiiEstados.Right = ws.ButtonState.Right;
            wiiEstados.X = ws.AccelState.X;
            wiiEstados.Y = ws.AccelState.Y;
            wiiEstados.Z = ws.AccelState.X;

            wiiEstados.irX1 = ws.IRState.X1;
            wiiEstados.irX2 = ws.IRState.X2;
            wiiEstados.irY1 = ws.IRState.Y1;
            wiiEstados.irY2 = ws.IRState.Y2;

            if (ws.ButtonState.Plus)
                IncrementarNumeric();
            if (ws.ButtonState.Minus)
                DecrementarNumeric();
            if (ws.ButtonState.Home) {
                checkBox1.Checked = true;
            }
            if (ws.ButtonState.One)
            {
                if (EstadoBotonConectar)
                {
                    if (txtPuerto.Text == "") txtPuerto.Text = "COM1";
                    btnConectar();
                }
            }
            if (ws.ButtonState.Up) {
                IncrementarMotor01();
            }
            if (ws.ButtonState.Down)
            {
                DecrementarMotor01();
            }
            pbBattery.Value = (ws.Battery > 0xc8 ? 0xc8 : (int)ws.Battery);
            float f = (((100.0f * 48.0f * (float)(ws.Battery / 48.0f))) / 192.0f);
            lblBattery.Text = f.ToString("F");

            m.ReleaseMutex();

        }
        private void IncrementarMotor01() {
            if (trackBar3.Value < trackBar3.Maximum)
            {
                trackBar3.Value++;
                setValorMotor(0, trackBar3.Value);
            }
        }
        private void DecrementarMotor01(){
            if (trackBar3.Value > trackBar3.Minimum)
            {
                trackBar3.Value--;
                setValorMotor(0, trackBar3.Value);
            }
        }
        //private void wm_WiimoteExtensionChanged(object sender, WiimoteExtensionChangedEventArgs args)
        //{
        //    BeginInvoke(new UpdateExtensionChangedDelegate(UpdateExtensionChanged), args);

        //}
        //private void UpdateExtensionChanged(WiimoteExtensionChangedEventArgs args)
        //{
        //    if (args.Inserted)
        //        wm.SetReportType(Wiimote.InputReport.IRExtensionAccel, true);
        //    else
        //        wm.SetReportType(Wiimote.InputReport.IRAccel, true);
        //}

        public void wm_OnWiimoteChanged(object sender, WiimoteChangedEventArgs args)
        {
            this.BeginInvoke(new UpdateWiimoteStateDelegate(UpdateWiimoteState), args);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            CargarWiiMote();
            
            control = new WiiControl();
            wiiEstados = new WiiEstado();
            wPanel = new WiiPanel();
            almacen = new Almacen();

            panel1.Height = wPanel.PanelHeight;
            panel1.Width = wPanel.PanelWidth;
            PuertoSerie.Encoding = System.Text.Encoding.GetEncoding(1252);
            lblConexion.Text = EstadoConexion.e0;
        }

        private void IncrementarNumeric() {
            int valor =(int)numericUpDown1.Value;
            if (valor >= numericUpDown1.Minimum && valor < numericUpDown1.Maximum)
                numericUpDown1.Value++;
        }
        private void DecrementarNumeric()
        {
            int valor = (int)numericUpDown1.Value;
            if (valor > numericUpDown1.Minimum && valor <= numericUpDown1.Maximum)
                numericUpDown1.Value--;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (wiiEstados.B == true)
            {
                Graphics g = e.Graphics;
                control.MaxPanelX = panel1.Width;
                control.MaxPanelY = panel1.Height;
                label1.Text = wiiEstados.X.ToString();
                label2.Text = wiiEstados.Y.ToString();
                label3.Text = wiiEstados.Z.ToString();

                control.dWiiMoteSetSpeedX = wiiEstados.X - control.dWiiOffsetX;
                control.nSign = Math.Sign(control.dWiiMoteSetSpeedX);
                control.dWiiMoteSSXQuadratic = Math.Pow(control.dWiiMoteSetSpeedX, 2.0) * control.nSign;
                control.dWiiMotePosX = (control.dWiiMotePosX + (control.dWiiMoteSSXQuadratic * control.dSamplePeriod) * control.nSpeedGain);

                if (control.dWiiMotePosX >= 1) control.dWiiMotePosX = 1;
                if (control.dWiiMotePosX <= -1) control.dWiiMotePosX = -1;

                control.dMousePosX = control.dWiiMotePosX;
                control.CoordenadaXFinal = (control.MaxPanelX / 2) * (control.dMousePosX + 1);

                //  COORDENADA Y

                control.dWiiMoteSetSpeedY = wiiEstados.Y - control.dWiiOffsetY;   // CURRENT position Y from WiiMote
                //lblVy.Text = dWiiMoteSetSpeedY.ToString();  // Just for debug visualisation

                // Using the Signed Square function:
                control.nSign = Math.Sign(control.dWiiMoteSetSpeedY);   // Mind the Wiimote directions ...
                control.dWiiMoteSSYQuadratic = Math.Pow(control.dWiiMoteSetSpeedY, 2.0) * control.nSign;


                control.dWiiMotePosY = (control.dWiiMotePosY + (control.dWiiMoteSSYQuadratic * control.dSamplePeriod) * control.nSpeedGain);   // INTEGRATOR

                // Do some limitations ...
                if (control.dWiiMotePosY >= 1) control.dWiiMotePosY = 1;
                if (control.dWiiMotePosY <= -1) control.dWiiMotePosY = -1;
                control.dMousePosY = control.dWiiMotePosY;

                control.CoordenadaYFinal = (control.MaxPanelY / 2) * (control.dMousePosY + 1);   // Mid screen


                Pen blackPen = new Pen(Color.Black, 3);
                //trackBar2.Value = Convert.ToInt16(control.CoordenadaXFinal);
                setValorTrack02(control.CoordenadaXFinal);
               // trackBar1.Value = Convert.ToInt16();
                setValorTrack01(control.CoordenadaYFinal);
                g.DrawEllipse(blackPen, (float)control.CoordenadaXFinal, (float)control.CoordenadaYFinal, 10 + (wiiEstados.Z * 10), 10 + (wiiEstados.Z * 10));
            }
            
        }
        private void setValorTrack01(double valor) {
            int conv = Convert.ToInt16(Math.Round(valor));
            if (conv >= 0 && conv <= wPanel.PanelWidth) {
                trackBar1.Value = conv + 50;
                setValorMotor(1, trackBar1.Value);
            }
        }
        private void setValorTrack02(double valor)
        {
            int conv = Convert.ToInt16(Math.Round(valor));
            if (conv >= 0 && conv <= wPanel.PanelHeight)
            {
                trackBar2.Value = conv + 50;
                setValorMotor(3,trackBar2.Value);
            }
        }
        private void setValorMotor(int motor , int valor) {
            almacen.setCantidad(motor, valor);
            switch (motor) {
                case 0:
                       this.label15.Text = Angulos.ConvertirSenalAAngulo((double)trackBar3.Value).ToString() + "°";
                       break;
                case 1:
                       //almacen.setCantidad(1, valor);
                       this.label14.Text = Angulos.ConvertirSenalAAngulo((double)trackBar1.Value).ToString() + "°";
                       break;
                case 2:
                      this.label14.Text = Angulos.ConvertirSenalAAngulo((double)trackBar1.Value).ToString() + "°";
                       break;
                case 3:
                      this.label8.Text = Angulos.ConvertirSenalAAngulo((double)trackBar2.Value).ToString() + "°";
                      break;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cronometro.Enabled = true;
        }

        private void cronometro_Tick(object sender, EventArgs e)
        {
            panel1.Refresh();
        }

        private void WiiMote_FormClosing(object sender, FormClosingEventArgs e)
        {
            wm.Disconnect();
            PuertoSerie.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            control.nSpeedGain = Convert.ToInt16(numericUpDown1.Value);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            cronometro.Enabled = true;
            else
                cronometro.Enabled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (button1.Text.Contains("Conectar"))
             btnConectar();
            else
             btnDesconectar();
        }
        private void btnConectar() {
            try
            {
                lblConexion.Text = EstadoConexion.e1;
                PuertoSerie.PortName = txtPuerto.Text;
                PuertoSerie.Open();
                lblConexion.Text = EstadoConexion.e2;
                cronometroPort.Interval = Convert.ToInt16(ndVelocidadTrasmision.Value);
                cronometroPort.Enabled = false;
                txtPuerto.Enabled = false;
                cronometroPort.Enabled = true;
                EstadoBotonConectar = false;
                button1.Text = "Desconectar";
                ndVelocidadTrasmision.Enabled = false;
            }
            catch (Exception ex)
            {
                FormError error = new FormError();
                error.txtMensajeError.Text = ex.Message;
                error.ShowDialog();
                error.Dispose();
                lblConexion.Text = EstadoConexion.e0;
                cronometroPort.Enabled = true;
                txtPuerto.Enabled = true;
                cronometroPort.Enabled = false;
                button1.Text = "Conectar";
                ndVelocidadTrasmision.Enabled = true;
            }
        }
        private void btnDesconectar() {
            EstadoBotonConectar = true;
            PuertoSerie.Close();
            lblConexion.Text = EstadoConexion.e0;
            cronometroPort.Enabled = true;
            txtPuerto.Enabled = true;
            cronometroPort.Enabled = false;
            button1.Text = "Conectar";
            ndVelocidadTrasmision.Enabled = true;
        }

        private void PuertoSerie_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            lblConexion.Text = EstadoConexion.e3;
        }

        private void cronometroPort_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString();
            for (int i = 0; i < almacen.length(); i++)
                PuertoSerie.Write(almacen.getElemento(i));
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            this.label8.Text = Angulos.ConvertirSenalAAngulo((double)trackBar2.Value).ToString() + "°";
        }
    }
}
