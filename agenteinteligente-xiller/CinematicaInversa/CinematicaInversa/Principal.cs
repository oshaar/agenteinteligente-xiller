using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using puertoserie.xiller.serie.angulo;

namespace CinematicaInversa
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            
            PuntoMedio = new Point(planoCartersiano.Size.Width / 2, planoCartersiano.Size.Height / 2);
            PuntoInicio = new Point(planoCartersiano.Size.Width, planoCartersiano.Size.Height);
            PuntoLinea01 = new Point(PuntoMedio.X + 210, PuntoMedio.Y - 200);
            PuntoLinea02 = new Point(PuntoMedio.X + 50, PuntoMedio.Y - 200);
            this.planoCartersiano.Paint += new System.Windows.Forms.PaintEventHandler(Dibujar);
        }
        private delegate void setTextoCallback(string texto);
        Point PuntoMedio;
        Point PuntoInicio;
        Point PuntoLinea01;
        Point PuntoLinea02;
        char[] almacen = { '0', '0', '0', '0', '0', '0', '0', '0' };

        private double PorcentajeMotor01=0.55;
        private double PorcentajeMotor02 = 0.30;
        private double PorcentajeMotor03 = 0.15;
        private AnguloMotor MotorDeAngulos;
        private void Dibujar(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Pen blackPen = new Pen(Color.Black, 3);
            g.DrawEllipse(blackPen, PuntoLinea01.X, PuntoLinea01.Y - 5, 10, 10);
            //g.DrawEllipse(blackPen, PuntoInicio.X-10, PuntoMedio.Y, 10, 10);
            g.DrawLine(Pens.Gray, 0, PuntoMedio.Y, PuntoInicio.X, PuntoMedio.Y);
            g.DrawLine(Pens.Blue, PuntoMedio.X, 0, PuntoMedio.X, PuntoInicio.Y);
            g.DrawLine(Pens.Purple, PuntoMedio, PuntoLinea01);
            //g.DrawLine(Pens.Green,   PuntoMedio, PuntoLinea02);

          //  double angulo = Math.Atan2((centrox - 100) - (centroy - 200), (centroy + 100) - (centroy + 50)) * 180 / Math.PI;
          //  label1.Text = angulo.ToString();
            double angulo = Math.Atan2(PuntoLinea02.Y - 0, PuntoLinea02.X - PuntoMedio.X) * 180 / Math.PI;
            label1.Text = angulo.ToString();
            double angulo2 = Math.Atan2(PuntoLinea01.Y-PuntoLinea02.Y ,PuntoLinea01.X-PuntoLinea02.X) * 180 / Math.PI;
            label2.Text = angulo2.ToString();

            #region gradocentral
             double hipotenusaAnguloCentral= (PuntoLinea01.Y - PuntoMedio.Y) / -(PuntoLinea01.X - PuntoMedio.X);
             double gradosangulo = Math.Atan2((PuntoLinea01.Y - PuntoMedio.Y), (PuntoLinea01.X - PuntoMedio.X)) * 180 / Math.PI;
             gradosangulo = -gradosangulo;
            label3.Text = gradosangulo.ToString();
            #endregion


            double hipotenusa = Math.Sqrt(Math.Pow(getXReal(PuntoLinea01.X),2)+Math.Pow(getYReal(PuntoLinea01.Y),2));
            
            double MitadHipotenusa = hipotenusa / 2;
            double LongitudMotor01;
            double LongitudMotor02;
            double LongitudMotor03;

            if (!checkBox3.Checked)
            {
                LongitudMotor01 = hipotenusa * PorcentajeMotor01;
                LongitudMotor02 = hipotenusa * PorcentajeMotor02;
                LongitudMotor03 = hipotenusa * PorcentajeMotor03;
            }
            else
            {
                LongitudMotor01 = 100;
                LongitudMotor02 = 50;
                LongitudMotor03 = 15;
            }

            double alturaMotor01 = LongitudMotor01 * (Math.Sin((gradosangulo*Math.PI)/180));
            double baseMotor01 =Math.Sqrt( Math.Pow(LongitudMotor01,2)-Math.Pow(alturaMotor01,2));
            double alturaMotor02 = LongitudMotor02 * (Math.Sin((gradosangulo * Math.PI) / 180));
            double baseMotor02 = Math.Sqrt(Math.Pow(LongitudMotor02, 2) - Math.Pow(alturaMotor02, 2));
            double alturaMotor03 = LongitudMotor03 * (Math.Sin((gradosangulo * Math.PI) / 180));
            double baseMotor03 = Math.Sqrt(Math.Pow(LongitudMotor03, 2) - Math.Pow(alturaMotor03, 2));

            float Motor01Medio = PuntoMedio.X + (float)baseMotor01;
            float Motor02Medio = Motor01Medio + (float)baseMotor02;
            float Motor03Medio = Motor02Medio + (float)baseMotor03;
            label4.Text = (alturaMotor01/LongitudMotor01).ToString();


            g.DrawLine(Pens.Red, Motor01Medio, PuntoMedio.Y, Motor01Medio, PuntoMedio.Y - (float)alturaMotor01);
            g.DrawLine(Pens.RoyalBlue, Motor02Medio, PuntoMedio.Y, Motor02Medio, PuntoMedio.Y - (float)(alturaMotor02+alturaMotor01));
            g.DrawLine(Pens.Plum, Motor03Medio, PuntoMedio.Y, Motor03Medio, PuntoMedio.Y - (float)(alturaMotor03+alturaMotor02+alturaMotor01));

            double anguloMotor01 = Math.Asin(LongitudMotor01/hipotenusa)*180/Math.PI;
       // importante   double anguloMotoro01Base = anguloMotor01 + gradosangulo;
            double anguloMotoro01Base;
            if(checkBox2.Checked)
              anguloMotoro01Base = anguloMotor01+gradosangulo;
            else
              anguloMotoro01Base = anguloMotor01;
            double alturaAnguloMotor01 = LongitudMotor01 * (Math.Sin((anguloMotoro01Base * Math.PI) / 180));
            double baseAnguloMotor01 = Math.Sqrt(Math.Pow(LongitudMotor01, 2) - Math.Pow(alturaAnguloMotor01, 2));
            PointFloat PuntoFinalMotor01 = new PointFloat((float)baseAnguloMotor01 + PuntoMedio.X, PuntoMedio.Y - (float)alturaAnguloMotor01);
           // g.DrawLine(Pens.Black, PuntoMedio.X, PuntoMedio.Y, (float)baseAnguloMotor01 + PuntoMedio.X, PuntoMedio.Y - (float)alturaAnguloMotor01);
            g.DrawLine(Pens.Black, PuntoMedio.X, PuntoMedio.Y, PuntoFinalMotor01.X, PuntoFinalMotor01.Y);
            g.DrawLine(Pens.Green, (float)baseAnguloMotor01 + PuntoMedio.X, PuntoMedio.Y - (float)alturaAnguloMotor01, Motor01Medio, PuntoMedio.Y - (float)alturaMotor01);
            g.DrawLine(Pens.Yellow, (float)baseAnguloMotor01 + PuntoMedio.X, PuntoMedio.Y - (float)alturaAnguloMotor01, Motor02Medio, PuntoMedio.Y - (float)(alturaMotor02 + alturaMotor01));
           // g.DrawLine(Pens.SkyBlue, (float)baseAnguloMotor01 + PuntoMedio.X, PuntoMedio.Y - (float)alturaAnguloMotor01, (float)baseAnguloMotor01 + PuntoMedio.X, PuntoMedio.Y);
            g.DrawLine(Pens.Tomato, (float)baseAnguloMotor01 + PuntoMedio.X, PuntoMedio.Y - (float)alturaAnguloMotor01, Motor01Medio, PuntoMedio.Y);

          //  double pendiente = ((PuntoMedio.Y - (float)alturaMotor01) - (PuntoMedio.Y - (float)alturaAnguloMotor01)) / (Motor01Medio - ((float)baseAnguloMotor01 + PuntoMedio.X));
          //  label6.Text = pendiente.ToString()+" - ";
            g.DrawLine(Pens.IndianRed, Motor01Medio, PuntoMedio.Y - (float)alturaMotor01, Motor02Medio, PuntoMedio.Y - (float)(alturaMotor02 + alturaMotor01));

            //double angulo6 = Math.Atan2((PuntoMedio.Y - (float)(alturaMotor02 + alturaMotor01)) - (PuntoMedio.Y - (float)alturaMotor01), Motor02Medio - Motor01Medio) * 180 / Math.PI;
            //label6.Text = angulo2.ToString();
          //  g.DrawLine(Pens.SkyBlue, (float)baseAnguloMotor01 + PuntoMedio.X, PuntoMedio.Y - (float)alturaAnguloMotor01, Motor02Medio + PuntoMedio.X, PuntoMedio.Y - (float)(alturaMotor02 + alturaMotor01) - (float)alturaAnguloMotor01);
            //g.DrawLine(Pens.SkyBlue, (float)baseAnguloMotor01 + PuntoMedio.X, PuntoMedio.Y - (float)alturaAnguloMotor01, Motor01Medio, PuntoMedio.Y - (float)alturaMotor01);

           // double angulo2 = Math.Atan2(x-(centroy - 200),  y-(centroy + 50)) * 180 / Math.PI;
           // label2.Text = angulo2.ToString();
           // double angulo3 = Math.Atan2((centroy - 100)-0, (centroy + 100)-y2) * 180 / Math.PI;
           // label3.Text = angulo3.ToString();

          //  double pendiente01 = getPendiente((float)baseAnguloMotor01 + PuntoMedio.X, PuntoMedio.Y - (float)alturaAnguloMotor01, Motor01Medio, PuntoMedio.Y - (float)alturaMotor01);
            double pendiente01 = getPendiente(Motor01Medio, PuntoMedio.Y - (float)alturaMotor01, Motor02Medio, PuntoMedio.Y - (float)(alturaMotor02 + alturaMotor01));
            g.DrawLine(Pens.Green, (float)baseAnguloMotor01 + PuntoMedio.X, PuntoMedio.Y - (float)alturaAnguloMotor01, Motor01Medio, PuntoMedio.Y - (float)alturaMotor01);
            double pendiente02 = getPendiente((float)baseAnguloMotor01 + PuntoMedio.X, PuntoMedio.Y - (float)alturaAnguloMotor01, Motor02Medio, PuntoMedio.Y - (float)(alturaMotor02 + alturaMotor01));

            label9.Text = getAnguloEntreRecta(pendiente01, pendiente02).ToString();


            double distancia = getDistanciaEntreDosPuntos(PuntoFinalMotor01.X,PuntoFinalMotor01.Y,PuntoLinea01.X,PuntoLinea01.Y);
            double distancia2 = getDistanciaEntreDosPuntos(PuntoMedio.X, PuntoMedio.Y, PuntoFinalMotor01.X, PuntoFinalMotor01.Y);
          

            //double anguloMotor02 = -CalcularASeno(LongitudMotor02 / hipotenusa);
            double anguloMotor02 = getAnguloEntreRecta( pendiente02,pendiente01);
            double alturaAnguloMotor02 = LongitudMotor02 * CalcularSeno(anguloMotor02);
            
            double baseAnguloMotor02 = Math.Sqrt(Math.Pow(LongitudMotor02, 2) - Math.Pow(alturaAnguloMotor02, 2));
            
            PointFloat PuntoFinalMotor02 = new PointFloat((float)baseAnguloMotor02 + PuntoMedio.X + (float)baseAnguloMotor01, PuntoMedio.Y - (float)alturaAnguloMotor02-(float)alturaAnguloMotor01);
            label6.Text = getDistanciaEntreDosPuntos(PuntoFinalMotor01.X, PuntoFinalMotor01.Y, PuntoFinalMotor02.X, PuntoFinalMotor02.Y).ToString();
            label4.Text = getDistanciaEntreDosPuntos(Motor01Medio, PuntoMedio.Y - (float)alturaMotor01, Motor02Medio, PuntoMedio.Y - (float)(alturaMotor02 + alturaMotor01)).ToString();
         //CAMBIO DEBIDO AL MOTOR ROTO

         //   g.DrawLine(Pens.Black,  PuntoFinalMotor01.X, PuntoFinalMotor01.Y,PuntoFinalMotor02.X,PuntoFinalMotor02.Y);
          //  g.DrawLine(Pens.Black,  PuntoFinalMotor02.X, PuntoFinalMotor02.Y,PuntoLinea01.X,PuntoLinea01.Y);
            g.DrawLine(Pens.Black, PuntoFinalMotor01.X, PuntoFinalMotor01.Y, PuntoLinea01.X, PuntoLinea01.Y);
           //  g.DrawLine(Pens.Black,  PuntoFinalMotor02.X, PuntoFinalMotor02.Y,PuntoLinea01.X,PuntoLinea01.Y);
          //  double dLineaCentral = getPendiente(PuntoMedio.X, PuntoMedio.Y, PuntoInicio.X, PuntoMedio.Y);
          //  double dLineaMotor01 = getPendiente(PuntoMedio.X, PuntoMedio.Y, PuntoFinalMotor01.X, PuntoFinalMotor01.Y);
            //lblAnguloMotor01.Text = getAnguloEntreRecta(dLineaMotor01, dLineaCentral) + "";
            lblAnguloMotor01.Text = getAnguloEntreDosRectas(PuntoFinalMotor01.X, PuntoFinalMotor01.Y, PuntoMedio.X, PuntoMedio.Y) + "";
            lblAnguloMotor02.Text = anguloMotor02 + "";

            double dLineaCentral = getPendiente(PuntoFinalMotor02.X, PuntoFinalMotor02.Y, PuntoLinea01.X, PuntoLinea01.Y);
            double dLineaMotor01 = getPendiente(PuntoMedio.X,PuntoMedio.Y, PuntoLinea01.X,PuntoLinea01.Y);
            //lblAnguloMotor03.Text = getAnguloEntreRecta(dLineaMotor01, dLineaCentral) + "";
            
           // lblAnguloMotor03.Text = getAnguloEntreDosRectas(PuntoFinalMotor02.X, PuntoFinalMotor02.Y, Motor02Medio, PuntoMedio.Y - (float)(alturaMotor02 + alturaMotor01))-360 + "";
           // g.DrawEllipse(blackPen, Motor02Medio, PuntoMedio.Y - (float)(alturaMotor02 + alturaMotor01), 10, 10);
            MotorDeAngulos.setAnguloMotor01( AnguloMotor.ConvertirAngulo01RealAEstandar(Convert.ToDouble(lblAnguloMotor01.Text)));
            MotorDeAngulos.setAnguloMotor02( AnguloMotor.ConvertirAngulo02RealAEstandar(Convert.ToDouble(lblAnguloMotor02.Text)));
           // MotorDeAngulos.setAnguloMotor03( AnguloMotor.ConvertirAngulo03RealAEstandar(Convert.ToDouble(lblAnguloMotor03.Text)));

           // label10.Text = MotorDeAngulos.getAnguloMotor01().ToString();
            //label11.Text = MotorDeAngulos.getAnguloMotor02().ToString();
            label12.Text = MotorDeAngulos.getAnguloMotor03().ToString();

            ActualizarMotor();
        }
        public void ActualizarMotor() {

            almacen[0] = Convert.ToChar((int)(Angulos.ConvertirAnguloASenal(MotorDeAngulos.getAnguloMotor02())));
            almacen[1] = Convert.ToChar((int)(Angulos.ConvertirAnguloASenal(MotorDeAngulos.getAnguloMotor01())));
            label10.Text =Angulos.ConvertirAnguloASenal(MotorDeAngulos.getAnguloMotor01())+ "";
            label11.Text = Angulos.ConvertirAnguloASenal(MotorDeAngulos.getAnguloMotor02()) + "";
           // almacen[2] = Convert.ToChar(MotorDeAngulos.getAnguloMotor01());
     
        }
        public double getPendiente(double x1, double y1, double x2, double y2)
        {
            return (y2 - y1) / (x2 - x1);
        }
        public double getAnguloEntreRecta(double m1, double m2){
            double div = (m2 - m1) / (1 + (m1 * m2));
            return CalcularATan(div);
        }
        public double getAnguloEntreDosRectas(double x1, double y1, double x2, double y2) {

            return Math.Atan2((y1 - y2), (x1 - x2)) * 180 / Math.PI;
        }
        public double getDistanciaEntreDosPuntos(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x1 - x2), 2.0) + Math.Pow((y1 - y2), 2.0));
        }
        public double CalcularSeno(double valor)
        {
            double temp = (valor * Math.PI)/180;
            return Math.Sin(temp);
        }

        public double CalcularASeno(double valor)
        {
            double temp = Math.Asin(valor);
            return (valor * 180) / Math.PI;
            
        }
        public double CalcularATan(double valor)
        {
            double temp = Math.Atan(valor);
            return (valor * 180) / Math.PI;

        }
        public double getXReal(double valor)
        {
            return valor - PuntoMedio.X;
        }
        public double getYReal(double valor)
        {
            return valor - PuntoMedio.Y;
        }
        private void Principal_Load(object sender, EventArgs e)
        {
            puerto.Encoding = System.Text.Encoding.GetEncoding(1252);
            MotorDeAngulos = new AnguloMotor(0,0,0);
        }

        private void planoCartersiano_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void planoCartersiano_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void planoCartersiano_MouseMove(object sender, MouseEventArgs e)
        {
            label5.Text = e.X + " - " + e.Y;
            if (checkBox1.Checked)
            {
                PuntoLinea01.X = e.X;
                PuntoLinea01.Y = e.Y;
                planoCartersiano.Refresh();
            }
        }

        private void planoCartersiano_MouseClick(object sender, MouseEventArgs e)
        {
            PuntoLinea01.X = e.X;
            PuntoLinea01.Y = e.Y;
            planoCartersiano.Refresh();
        }

        private void planoCartersiano_MouseHover(object sender, EventArgs e)
        {

        }

        private void planoCartersiano_MouseEnter(object sender, EventArgs e)
        {

        }

        private void txtMotor01_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMotor02_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMotor03_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double valor = Convert.ToDouble(txtMotor01.Text);
            if (valor > 0 && valor < 100)
                PorcentajeMotor01 = valor / 100;
            double valor2 = Convert.ToDouble(txtMotor02.Text);
            if (valor2 > 0 && valor2 < 100)
                PorcentajeMotor02 = valor2 / 100;
            double valor3 = Convert.ToDouble(txtMotor03.Text);
            if (valor3 > 0 && valor3 < 100)
                PorcentajeMotor03 = valor3 / 100;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            puerto.Close();
        }

        private void reloj_Tick(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Black;
            label18.Text = DateTime.Now.ToString();
            for (int i = 0; i < almacen.Length; i++)
                puerto.Write(almacen[i] + "");
            panel1.BackColor = Color.Red;
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            char mensaje = Convert.ToChar(trackBar4.Value);
            almacen[3] = mensaje;
            lblMotorInferiorBase.Text = "[" + mensaje + "]" + " / " + Angulos.ConvertirSenalAAngulo((double)trackBar4.Value) + "°";
           
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                puerto.PortName = txtIniciar.Text;
                puerto.Open();
                txtIniciar.Enabled = false;
                btnIniciar.Enabled = false;
                reloj.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source);
            }
        }
        private void setTextoTxtMotor(string mensaje)
        {
            if (this.txtDatosRecibidos.InvokeRequired)
            {
                setTextoCallback temp = new setTextoCallback(setTextoTxtMotor);
                this.Invoke(temp, new object[] { mensaje });

            }
            else txtDatosRecibidos.Text += mensaje;

        }

        private void puerto_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            setTextoTxtMotor(puerto.ReadExisting() + "...");
        }

        private void txtIniciar_TextChanged(object sender, EventArgs e)
        {

        }

        private void planoCartersiano_Click(object sender, EventArgs e)
        {

        }
    }
}
