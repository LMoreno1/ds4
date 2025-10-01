internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Ingrese lado 1: ");
        int a = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese lado 2: ");
        int b = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese lado 3: ");
        int c = int.Parse(Console.ReadLine());

        if ( a + b > c && a + c > b && b + c > a)
        {
            if (a == b && b == c)
            {
                Console.WriteLine("Triángulo equilátero");
            }
            else if (a == b || a == c || b == c)
            {
                Console.WriteLine("Triángulo isósceles");
            }
            else
            {
                Console.WriteLine("Triángulo escaleno");
            }
        }
        else
        {
            Console.WriteLine("Los lados no forman un triángulo válido");
        }
    }
}