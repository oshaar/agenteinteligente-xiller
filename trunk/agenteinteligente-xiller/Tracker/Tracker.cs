using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VideoSource;
using Tiger.Video.VFW;
using motion;


namespace Tracker
{
    public partial class Form1 : Form
    {
        private bool camaraStart, camaraConfig;
        private const int statLength = 15;
        private int statIndex = 0, statReady = 0;
        private AVIWriter writer = null;
        private IMotionDetector detector = new MotionDetector3Optimized();
        private HaarDetector m_HaarDetector;
   
        private int intervalsToSave = 0;
        private int detectortype = 0;
        private Graphics picGraficos;
        private Pen Pluma = new Pen(Color.Green, 2.0f); 
        private clsFaceDetectionWrapper objFaceDetector;
        private Bitmap bmpUltimoFrame;
        private Boolean HabilitadoEscaneo = true;
        private Boolean CargarImagenConRostro = false;
        public Form1()
        {
            InitializeComponent();
            camaraStart = false;
            camaraConfig = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //m_HaarDetector = new HaarDetector();
            objFaceDetector = clsFaceDetectionWrapper.GetSingletonInstance();
        }
        private void DibujarRectangulo(int lx, int ly,int rx, int ry)
        {
            picGraficos = pbFrame.CreateGraphics();
            picGraficos.DrawRectangle(Pluma, lx,ly,(rx-lx),(ry-ly));
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
                AbrirVideoFuente2(local);
            }
        }
        private void AbrirVideoFuente(IVideoSource source)
        {
            this.Cursor = Cursors.WaitCursor;
            CerrarArchivo();
            if (detector != null)
                detector.MotionLevelCalculation = false;
            Camera.Camera camara = new Camera.Camera(source);
            camara.Start();
            cameraWindow2.Camera = camara;
        
            statIndex = statReady = 0;

            timer.Start();
            camaraStart = true;
            this.Cursor = Cursors.Default;
        }
        private void AbrirVideoFuente2(IVideoSource source)
        {
            this.Cursor = Cursors.WaitCursor;


            Camera.Camera camara = new Camera.Camera(source);
            camara.Start();
         
            cameraWindow.Camera = camara;
            statIndex = statReady = 0;

           
            this.Cursor = Cursors.Default;
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

        private void btnIniciar_Click(object sender, EventArgs e)
        {
        //    m_HaarDetector.clear_ai_classifiers();
        //    m_HaarDetector.unload_skin_filter();
        //    m_HaarDetector.clear_object_sizes();
        //    int res = 0;
        //    res = m_HaarDetector.load_skin_filter(@"C:\CODE\C#\AgenteInteligente\Tracker\recursos\skin.nn");
        //
        }

        private void btnCerrarCamara_Click(object sender, EventArgs e)
        {

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
        private void btnDetenerCamara_Click(object sender, EventArgs e)
        {
            if (camaraStart)
            {
                cameraWindow.Camera.SignalToStop();
                cameraWindow.Camera.WaitForStop();
                camaraStart = false;
            }
        }

        private void btnReproducir_Click(object sender, EventArgs e)
        {
            if (camaraStart)
                btnDetenerCamara_Click(sender,e);
            try {
                cameraWindow.Camera.Start();
                camaraStart = true;
            }
            catch (Exception ex) { MessageBox.Show("No se pudo iniciar la reproduccion"); }
        }

        private void btnCapturar_Click(object sender, EventArgs e)
        {
            Image img = CapturarFrame();
            
            if (img != null)
            {
                Size temp =new Size(275,210);
                Bitmap bmp = new Bitmap(img);
                //bmp.SetResolution(400f, 400f);

               // Bitmap bmp2 = new Bitmap(bmp.Size.Width * 0.50, bmp.Size.Height * 0.50, System.Drawing.Imaging.PixelFormat.Format16bppGrayScale);
               // bmp2.SetResolution(100f,100f);
                //Graphics foto = Graphics.FromImage(bmp2);
               // foto.DrawImage();
              //  bmp.PixelFormat = System.Drawing.Imaging.PixelFormat.Format16bppArgb1555;
                pbFrame.Image = bmp;
                bmpUltimoFrame = bmp;
                pbFrame.Refresh();
            }
        }

        private void btnAnalizar_Click(object sender, EventArgs e)
        {
            this.HabilitadoEscaneo = false;
            if (bmpUltimoFrame != null)
            {
                int faces = objFaceDetector.WrapDetectFaces(bmpUltimoFrame);
                this.lblResultado.Text = DateTime.Now.ToString()+"Numero de Rostros : " + faces.ToString();
                if (faces > 0) this.CargarImagenConRostro = true;
                unsafe 
                {
                    picGraficos =  pbFrame.CreateGraphics();
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
                    }
                    picGraficos.Save();
                    picGraficos.Dispose();
                }
            }
            this.HabilitadoEscaneo = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Camera.Camera tempCam = this.cameraWindow.Camera;
            if (tempCam != null)
            {
                this.cameraWindow.Camera = null;
                tempCam.SignalToStop();
                tempCam.WaitForStop();
                tempCam = null;
            }
            Camera.Camera tempCam2 = this.cameraWindow2.Camera;
            if (tempCam != null)
            {
                this.cameraWindow2.Camera = null;
                tempCam2.SignalToStop();
                tempCam2.WaitForStop();
                tempCam2 = null;
            }
        }

        private void cbxMotionAlgo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxMotionAlgo.SelectedIndex) {
                case 0:
                    algoritmoNinguno();
                    break;
                case 1:
                       algoritmo01();
                       break;
                case 2:
                       algoritmo02();
                       break;
                case 3:
                       algoritmo03();
                       break;
                case 4:
                       algoritmo03Opt();
                       break;
                case 5:
                       algoritmo04();
                       break;
            }
        }
        private void algoritmoNinguno() {
            this.detector = null;
            this.detectortype = 0;
            SetMotionDetector();
        }
        private void algoritmo01() {
            this.detector = new MotionDetector1();
            this.detectortype = 1;
            SetMotionDetector();
        }
        private void algoritmo02()
        {
            this.detector = new MotionDetector2();
            this.detectortype = 2;
            SetMotionDetector();
        }
        private void algoritmo03()
        {
            this.detector = new MotionDetector3();
            this.detectortype = 3;
            SetMotionDetector();
        }
        private void algoritmo03Opt()
        {
            this.detector = new MotionDetector3Optimized();
            this.detectortype = 4;
            SetMotionDetector();
        }
        private void algoritmo04()
        {
            this.detector = new MotionDetector4();
            this.detectortype = 5;
            SetMotionDetector();
        }
        private void SetMotionDetector()
        {
            Camera.Camera camera = cameraWindow2.Camera;

            // enable/disable motion alarm
            if (detector != null)
            {
                detector.MotionLevelCalculation = chxAlarma.Checked;
            }

            // set motion detector to camera
            if (camera != null)
            {
                camera.Lock();
                camera.MotionDetector = detector;

                // reset statistics
                statIndex = statReady = 0;
                camera.Unlock();
            }
        }
        private int contador=0;
        private void cronometro_Tick(object sender, EventArgs e)
        {
            if (HabilitadoEscaneo)
            {
                Image img = CapturarFrame();

                if (img != null)
                {
                    //Size tamano = new Size(Convert.ToInt16(Math.Round(img.Width * 0.8)), Convert.ToInt16(Math.Round(img.Height * 0.8)));
                    Bitmap bmp = new Bitmap(img);

                    pbFrame.Image = bmp;
                    bmpUltimoFrame = bmp;
                    pbFrame.Refresh();
                    btnAnalizar_Click(sender, e);
                    if (this.CargarImagenConRostro) {

                        ListaImagenes.Images.Add(contador.ToString(), pbFrame.Image);
                      
                        listView.Items.Add("rostro " + contador.ToString()+"_"+DateTime.Now.ToString(), ListaImagenes.Images.IndexOfKey(contador.ToString()).ToString());
                        this.CargarImagenConRostro = false;
                        contador++;
                    }
                }
            }
        }

        private void chxCronometro_CheckedChanged(object sender, EventArgs e)
        {
            if (chxCronometro.Checked)
                this.cronometro.Enabled = true;
            else
                this.cronometro.Enabled = false;
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count != 0)
            {

                string temp = listView.SelectedItems[0].ImageKey;
                //MessageBox.Show(ListaImagenes.Images.IndexOfKey(temp).ToString());
                //pbxPrevio.Image = ListaImagenes.Images[ListaImagenes.Images.IndexOfKey(temp)];
                pbxPrevio.Image = ListaImagenes.Images[temp];
                pbxPrevio.Refresh();
                label1.Text = temp;
            }
        }

        private void listView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //MessageBox.Show(listView.SelectedItems.Count.ToString());
            //string temp = listView.SelectedItems[listView.SelectedIndices.Count-1].ImageKey;
            //MessageBox.Show(ListaImagenes.Images.IndexOfKey(temp).ToString());
        }

        private void timer_Tick(object sender, EventArgs e)
        {

        }
    }
}
