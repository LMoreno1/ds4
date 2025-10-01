using Laboratorio93;

internal class Program
{
    private static void Main(string[] args)
    {
        Aleatorios aleatorios = new Aleatorios();

        Console.WriteLine("Número aleatorio entre 5 y 20: " + aleatorios.GenerarNumero(5, 20));

        int[] arreglo = aleatorios.GenerarArreglo(1, 50, 10);
        Console.WriteLine("Arreglo aleatorio: ");
        foreach (int a in arreglo)
            Console.Write(a + " ");
    }
}