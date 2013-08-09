using System;
using System.Collections.Generic;
using System.Text;

namespace CinematicaInversa
{
    class AnguloMotor
    {
        private int AnguloMotor01 = 0;
        private int AnguloMotor02 = 0;
        private int AnguloMotor03 = 0;

        public int getAnguloMotor01() { return AnguloMotor01; }
        public int getAnguloMotor02() { return AnguloMotor02; }
        public int getAnguloMotor03() { return AnguloMotor03; }

        private static double IndiceAnguloMotor01 = 90;
        private static double IndiceAnguloMotor02 = 90;
        private static double IndiceAnguloMotor03 = 90;

        public AnguloMotor(double a1,double a2, double a3){
            setAnguloMotor01(a1);
            setAnguloMotor02(a2);
            setAnguloMotor03(a3);
        }
        public static double ConvertirAngulo01RealAEstandar(double a1)
        {
            return (a1 + IndiceAnguloMotor01);
        }
        public static double ConvertirAngulo02RealAEstandar(double a2)
        {
            return (a2 + IndiceAnguloMotor02);
        }
        public static double ConvertirAngulo03RealAEstandar(double a3)
        {
            return a3 + IndiceAnguloMotor03;
        }
        public double ConvertirAnguloRealAEstandar(double a1,double i1) {
            return a1 + i1;
        }

        public static double getRedondeo(double numero)
        {
            return Math.Truncate(numero);
        }
        public void setAnguloMotor01(double numero) {
            if (numero >= 0.0 && numero <= 180.0)
              AnguloMotor01= Convert.ToInt16(getRedondeo(numero));
        }
        public void setAnguloMotor02(double numero)
        {
            if (numero >= 0.0 && numero <= 180.0)
                AnguloMotor02 = Convert.ToInt16(getRedondeo(numero));
        }
        public void setAnguloMotor03(double numero)
        {
            if (numero >= 0.0 && numero <= 180.0)
                AnguloMotor03 = Convert.ToInt16(getRedondeo(numero));
        }
    }
}
