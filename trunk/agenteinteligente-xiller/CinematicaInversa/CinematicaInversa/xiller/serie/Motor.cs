using System;
using System.Collections.Generic;
using System.Text;

namespace puertoserie.xiller.serie
{
    public class Motor
    {
        private double ConvertirRangoAnguloASenal(double angulo)
        {
            double temp = this.rangoAngulo / this.rangoSenal;
            int ciclo = 0;
            for (double x = this.anguloInicio; x <= this.anguloFin; x += temp)
            {
                if (x == angulo) return ciclo;
                if (x > angulo) return ciclo;
                ciclo++;
            }
            return ciclo;
        }
        public double ConvertirAnguloASenal(double angulo)
        {
            double valor = ConvertirRangoAnguloASenal(angulo);
            return valor + 50;
        }
        public double ConvertirSenalAAngulo(double senal)
        {
            double temp = this.rangoSenal / this.rangoAngulo;
            int ciclo = 0;
            for (double x = this.senalInicio; x <= this.senalFin; x += temp)
            {
                if (x == senal) return ciclo;
                if (x > senal) return ciclo;
                ciclo++;
            }
            return ciclo;
        }

        public Motor(double aInicio,double aRango,double aFin,double sInicio,double sRango,double sFin) {
            this.anguloInicio = aInicio;
            this.rangoAngulo = aRango;
            this.anguloFin = aFin;
            this.senalInicio = sInicio;
            this.rangoSenal = sRango;
            this.senalFin = sFin;
        }
        public Motor() { }
        private double anguloInicio = 0;

        public double AnguloInicio
        {
            get { return anguloInicio; }
            set { anguloInicio = value; }
        }
        private double rangoAngulo = 180;

        public double RangoAngulo
        {
            get { return rangoAngulo; }
            set { rangoAngulo = value; }
        }
        private double anguloFin = 180;

        public double AnguloFin
        {
            get { return anguloFin; }
            set { anguloFin = value; }
        }
        private double senalInicio = 50;

        public double SenalInicio
        {
            get { return senalInicio; }
            set { senalInicio = value; }
        }
        private double rangoSenal = 200;

        public double RangoSenal
        {
            get { return rangoSenal; }
            set { rangoSenal = value; }
        }
        private double senalFin = 250;

        public double SenalFin
        {
            get { return senalFin; }
            set { senalFin = value; }
        }
    }
}
