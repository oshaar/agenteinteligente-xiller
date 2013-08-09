using System;
using System.Collections.Generic;
using System.Text;

namespace CinematicaInversa.xiller.serie
{
    public class Almacen
    {
        private char[] almacen= new char[8];
        public Almacen() {
            Limpiar();
        }
        public void setCantidad(int index,int valor) {
            almacen[index] = Convert.ToChar(valor); 
        }
        public void setCantidad(int index, char valor)
        {
            almacen[index] = valor;
        }
        public int length() {
            return this.almacen.Length;
        }
        public string getElemento(int index) { 
          return almacen[index]+"";
        }
        public void Limpiar() { 
         for(int i=0; i<almacen.Length; i++)
             almacen[i]='0';
        }
    }
}
