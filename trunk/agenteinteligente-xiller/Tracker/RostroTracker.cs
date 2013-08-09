using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VideoSource;
using motion;
using Tiger.Video.VFW;
using GrFingerXSampleCS2005;

namespace Tracker
{
    public partial class RostroTracker : Form
    {
        private IMotionDetector detector = new MotionDetector3Optimized();
        private AVIWriter writer = null;
        private bool camaraStart, camaraConfig;
        private int intervalsToSave = 0;
        private int statIndex = 0, statReady = 0;
        private Boolean HabilitadoEscaneo = true;
        private Bitmap bmpUltimoFrame;
        private clsFaceDetectionWrapper objFaceDetector;
        private Graphics picGraficos;
        private Pen Pluma = new Pen(Color.Red, 2.0f);
        private Rostro cara;
        private int CantidadDeRostrosDetectados = 0;
        private char[] Almacen = { '0', '0', '0', '0', '0', '0', '0', '0' };
        public RostroTracker()
        {
            InitializeComponent();
            camaraStart = false;
            camaraConfig = false;
        }

        private void dispositivoLocalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SeleccionDispositivoForm dlg = new SeleccionDispositivoForm();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                CaptureDevice local = new CaptureDevice();
                //CaptureDevice local2 = new CaptureDevice();
                local.VideoSource = dlg.Dispositivo;
                // local2.VideoSource = dlg.Dispositivo;
                AbrirVideoFuente(local);
            }
        }
        private void CerrarArchivo()
        {
            Camera.Camera camara = cameraWindow.Camera;
            if (camara != null)
            {
                cameraWindow.Camera = null;
                camara.SignalToStop();
                camara.WaitForStop();
                camara = null;
                if (detector != null)
                    detector.Reset();
            }
            if (writer != null)
            {
                writer.Dispose();
                writer = null;
            }
            intervalsToSave = 0;
        }
        private void AbrirVideoFuente(IVideoSource source)
        {
            this.Cursor = Cursors.WaitCursor;
            CerrarArchivo();
            if (detector != null)
                detector.MotionLevelCalculation = false;
            Camera.Camera camara = new Camera.Camera(source);
            camara.Start();
            cameraWindow.Camera = camara;

            statIndex = statReady = 0;

           // timer.Start();
            camaraStart = true;
            this.Cursor = Cursors.Default;
        }

        private void RostroTracker_FormClosing(object sender, FormClosingEventArgs e)
        {
            Camera.Camera tempCam = this.cameraWindow.Camera;
            if (tempCam != null)
            {
                this.cameraWindow.Camera = null;
                tempCam.SignalToStop();
                tempCam.WaitForStop();
                tempCam = null;
            }
            
                PuertoSerie.Close();
            
        }

        private void cbxRastreo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxRastreo.Checked)
            {
                timer.Enabled = true;
                cronometro.Enabled = true;
                btnHuella.Visible = false;
            }
            else
            {
                timer.Enabled = false;
                cronometro.Enabled = false;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (HabilitadoEscaneo)
            {
                Image img = CapturarFrame();

                if (img != null)
                {
                    //Size tamano = new Size(Convert.ToInt16(Math.Round(img.Width * 0.8)), Convert.ToInt16(Math.Round(img.Height * 0.8)));
                    Bitmap bmp = new Bitmap(img);
                    label1.Text = "";
                    pbFrame.Image = bmp;
                    bmpUltimoFrame = bmp;
                    pbFrame.Refresh();
                    AnalizarRostro();
                    lblRostros.Text = "Rostros: " + CantidadDeRostrosDetectados.ToString();
                }
            }
        }
        private Image CapturarFrame()
        {
            if (camaraStart)
            {
                try
                {
                    lock (cameraWindow.Camera)
                    {
                        if (cameraWindow.Camera.LastFrame == null) return null;
                        return (Image)cameraWindow.Camera.LastFrame.Clone();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Se ha presentado un error al capturar el frame de la Camara");
                }
            }
            return null;
        }
        private void AnalizarRostro() {

            this.HabilitadoEscaneo = false;
            if (bmpUltimoFrame != null)
            {
                int faces = objFaceDetector.WrapDetectFaces(bmpUltimoFrame);
                this.lblResultado.Text = DateTime.Now.ToString() + "Numero de Rostros : " + faces.ToString();
                CantidadDeRostrosDetectados += faces;
                // if (faces > 0) this.CargarImagenConRostro = true;
                unsafe
                {
                    picGraficos = pbFrame.CreateGraphics();
                    int lx, ly, rx, ry, res;
                    for (int f = 0; f < faces; f++)
                    {
                        objFaceDetector.WrapGetFaceCordinates(f, &lx, &ly, &rx, &ry);

                        picGraficos.DrawRectangle(Pluma, lx, ly, rx, ry);

                        res = objFaceDetector.WrapGetEyeCordinates(f, &lx, &ly, &rx, &ry);

                        if (res > -1)
                        {
                            picGraficos.DrawLine(Pluma, lx - 5, ly, lx + 5, ly);
                            picGraficos.DrawLine(Pluma, lx, ly - 5, lx, ly + 5);

                            picGraficos.DrawLine(Pluma, rx - 5, ry, rx + 5, ry);
                            picGraficos.DrawLine(Pluma, rx, ry - 5, rx, ry + 5);
                        }
                        if (f == 0) {
                            if (!cara.VerificacionIntervalo(lx, rx))
                            {
                                label1.Text = "MOTOR NECESITA CORREGIRSE";
                                int temp = cara.getIntervaloACorregir(trackBar1.Value);
                                if (temp >= trackBar1.Minimum && temp <= trackBar1.Maximum)
                                    trackBar1.Value = temp;
                                label2.Text = trackBar1.Value.ToString();
                                // timer.Enabled = false;
                            }
                            else { 
                                label1.Text = "ROSTRO EN CENTRO DE IMAGEN";
                                btnHuella.Visible = true;
                            timer.Enabled = false;
                            cronometro.Enabled = false;
                           
                            }
                        }
                    }
                    picGraficos.Save();
                    picGraficos.Dispose();
                }
            }
            this.HabilitadoEscaneo = true;
        }

        private void RostroTracker_Load(object sender, EventArgs e)
        {
            PuertoSerie.Encoding = System.Text.Encoding.GetEncoding(1252);
            objFaceDetector = clsFaceDetectionWrapper.GetSingletonInstance();
            cara = new Rostro(pbFrame.Width, pbFrame.Height, 0.1);
        }

        private void cronometro_Tick(object sender, EventArgs e)
        {
            char mensaje = Convert.ToChar(trackBar1.Value);
            Almacen[3]=mensaje;
            for (int i = 0; i < Almacen.Length; i++) {
                PuertoSerie.Write(Almacen[i]+"");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PuertoSerie.PortName = txtPuerto.Text;
            PuertoSerie.Open();
            button1.Enabled = false;
            txtPuerto.Enabled = false;
            cronometro.Enabled = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if(!cronometro.Enabled)
              cronometro.Enabled = true;
        }

        private void btnHuella_Click(object sender, EventArgs e)
        {
            formMain form1 = new formMain();

            form1.Show();
        }

    }
}
