using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio93
{
    class Aleatorios
    {
        private Random rnd = new Random();

        public int GenerarNumero(int min,  int max)
        {
            return rnd.Next(min, max + 1);
        }

        public int[] GenerarArreglo(int min, int max, int cantidad)
        {
            int[] arreglo = new int[cantidad];
            for (int i = 0; i < cantidad; i++)
            {
                arreglo[i] = rnd.Next(min, max + 1);
            }
            return arreglo;
        }
    }
}
