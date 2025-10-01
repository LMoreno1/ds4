using Laboratorio94;

internal class Program
{
    private static void Main(string[] args)
    {
        Aleatorios aleatorios = new Aleatorios();

        int[] arreglo = aleatorios.GenerarNoRepetidos(1, 20, 10);
        Console.WriteLine("Arreglo aleatorio no repetido: ");
        foreach (int a in arreglo)
            Console.Write(a + " ");
    }
}