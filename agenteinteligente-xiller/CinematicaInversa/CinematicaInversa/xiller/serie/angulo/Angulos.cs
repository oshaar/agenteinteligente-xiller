using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace puertoserie.xiller.serie.angulo
{
    public class Angulos
    {
        private static double ConvertirRangoAnguloASenal(double angulo){
           double maxRangoAngulo = (double)Rangos.RangoAngulo;
           double maxRangoSenal = (double)Rangos.RangoSenal;
           double temp= maxRangoAngulo / maxRangoSenal;
           int ciclo = 0;
           for (double x = (double)Rangos.AnguloInicio; x <= (double)Rangos.AnguloFin; x+=temp)
           {
            if (x == angulo)return ciclo;        
            if (x > angulo)return ciclo;       
            ciclo++;
           }
           //if (angulo == 180) return 200;
           return ciclo;
        }
        public static double ConvertirAnguloASenal(double angulo)
        {
            double valor=ConvertirRangoAnguloASenal(angulo);
            return valor + 50;
        }
        public static double ConvertirSenalAAngulo(double senal)
        {
            double temp = (double)Rangos.RangoSenal / (double)Rangos.RangoAngulo;
            int ciclo=0;
            for (double x = (double)Rangos.SenalInicio; x <= (double)Rangos.SenalFin; x += temp)
            {
                if (x == senal) return ciclo;
                if (x > senal) return ciclo;
                ciclo++;
            }
            return ciclo;
        }
    }
}
