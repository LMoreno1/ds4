using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio94
{
    class Aleatorios
    {
        private Random rnd = new Random();

        public int[] GenerarNoRepetidos(int min, int max, int cantidad)
        {
            HashSet<int> numeros = new HashSet<int>();
            while (numeros.Count < cantidad)
            {
                numeros.Add(rnd.Next(min, max + 1));
            }
            return new List<int>(numeros).ToArray();
        }
    }
}
