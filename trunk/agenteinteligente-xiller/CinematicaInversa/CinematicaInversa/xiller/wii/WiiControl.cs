using System;
using System.Collections.Generic;
using System.Text;

namespace CinematicaInversa.xiller.wii
{
    public class WiiControl
    {
        public WiiControl() { }
        public double dMousePosX = 0;      // Current Mouse X-position
        public double dMousePosY = 0;      // Current Mouse Y-position

        public double dWiiMoteSetSpeedX = 0;
        public double dWiiMotePosX = 0;    // Current WiiMote-X value

        public double dWiiMoteSetSpeedY = 0;
        public double dWiiMotePosY = 0;    // Current WiiMote-Y value

        public double dPosX = 0;      // Current Mouse X-position
        public double dPosY = 0;      // Current Mouse Y-position

        public int MaxScreenX = 1280;      // This should go via sysinfo!!!
        public int MaxScreenY = 1024;
        public double dSamplePeriod = 0.01;
        public double dWiiOffsetX = 0.03846154;
        public double dWiiOffsetY = -0.04;

        public double dWiiMoteSSXQuadratic = 0;
        public double dWiiMoteSSYQuadratic = 0;
        public int nSign = 0;
        public int nSpeedGain = 10;

        public double CoordenadaXFinal = 0;
        public double CoordenadaYFinal = 0;

        public int MaxPanelX = 0;
        public int MaxPanelY = 0;
    }
}
