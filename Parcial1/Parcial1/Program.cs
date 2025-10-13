using System;

internal class Program
{
    static void Main(string[] args)
    {
        int n;
        Console.Write("Ingrese el valor de N (NÚMERO PAR): ");
        n = int.Parse(Console.ReadLine());

        if (n % 2 != 0)
        {
            Console.WriteLine("N debe ser par");
            return;
        }

        int[,] matriz = new int[n, n];
        Random random = new Random();
        int suma = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == 0 || i == n - 1 || j == 0 || j == n - 1)
                {
                    matriz[i, j] = random.Next(1, 100);
                    suma += matriz[i, j];
                }
                else
                {
                    matriz[i, j] = 0;
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"{matriz[i, j],4}");
            }
            Console.WriteLine();
        }
        Console.WriteLine($"\nSuma total de elementos: {suma}");
    }
}
