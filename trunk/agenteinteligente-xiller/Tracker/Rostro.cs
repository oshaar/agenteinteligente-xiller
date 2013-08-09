using System;
using System.Collections.Generic;
using System.Text;

namespace Tracker
{
    public class Rostro
    {
        private int marcoWidth =0;
        private int marcoHeight = 0;


        private double intervaloError = 0.10;
        private int PointMarcoCentroY = 0;
        private int PointMarcoCentroX = 0;

        private int IntervaloCorrecion=0;

        public Rostro(int MarcoWidth,int MarcoHeight,double error) {

         this.marcoHeight = MarcoHeight;
         
         this.marcoWidth = MarcoWidth;
         PointMarcoCentroY = MarcoHeight/2;
         PointMarcoCentroX = MarcoWidth/2;
         
         this.intervaloError = error;

         //int ErrotPointMarcoCentroX = error * PointMarcoCentroX;
        }
        public bool VerificacionIntervalo(int ix, int width) {
            int temp = ix + (width/2);
            return VerificarIntervalo(temp);
        }
        private bool VerificarIntervalo(int Ix) {
            int ErrorPointMarcoX =(int)Math.Round( intervaloError * PointMarcoCentroX);
            //int ErrorPointMarcoY =(int)Math.Round (intervaloError * PointMarcoCentroY);
            if (Ix >= (PointMarcoCentroX - ErrorPointMarcoX) && Ix <= (PointMarcoCentroX + ErrorPointMarcoX)) {
                return true;
                this.IntervaloCorrecion = 0;
            }
            /*
            int temp =(int)Math.Round(tMarco * porcentaje);
            int interInferior = (int)Math.Round((tMarco * intervaloError) - temp);
            int interSuperior = (int)Math.Round((tMarco * intervaloError) + temp);
            if (interInferior >= imagen && interSuperior <= imagen) {
                return true;
            }
            return false;*/
            this.IntervaloCorrecion = (PointMarcoCentroX-Ix);
            return false;
        }
        public int getIntervaloACorregir(int ActualAngulo) {
            int temp = Math.Abs(IntervaloCorrecion);
            int incremento = 0;
            if (temp < 5) incremento = 1;
            else if (temp < 10) incremento = 3;
            else if (temp < 20) incremento = 5;
            else if (temp < 40) incremento = 6;
            else if (temp < 80) incremento = 7;
            else if (temp < 90) incremento = 8;
            else incremento = 10;
            if (this.IntervaloCorrecion < 0)
            {
                return (ActualAngulo - 2);
            }
            else {
                return (ActualAngulo +2);
            }
        }

    }
}
