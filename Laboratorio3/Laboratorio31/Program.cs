internal class Program
{
    private static void Main(string[] args)
    {
        int a, b, r;

        Console.Write("Introduce el primer numero: ");
        a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Introduce el segundo numero: ");
        b = Convert.ToInt32(Console.ReadLine());

        CalculosMatematicos calculosMatematicos = new CalculosMatematicos();
        r = calculosMatematicos.Calcular(a, b);

        Console.WriteLine("La resultado de ({0} + {1}) * ({0} - {1}) es: {2}", a, b, r);

    }

    class CalculosMatematicos
    {
        public int Calcular(int a, int b)
        { 
            return (a + b) * (a - b); 
        }

    }
}