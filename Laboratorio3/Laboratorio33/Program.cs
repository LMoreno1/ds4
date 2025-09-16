using System.Timers;

internal class Program
{
    private static void Main(string[] args)
    {
        double baseRectangulo, altura, perimetro;

        Console.Write("Introduce la base del rectangulo: ");
        baseRectangulo = Convert.ToDouble(Console.ReadLine());

        Console.Write("Introduce la altura del rectangulo: ");
        altura = Convert.ToDouble(Console.ReadLine());

        CalculosMatematicos calculos = new CalculosMatematicos();

        perimetro = calculos.CalcularPerimetro(baseRectangulo, altura);

        Console.WriteLine("El perimetro del rectangulo con base {0} y altura {1} es: {2}", baseRectangulo, altura, perimetro);

    }

    class CalculosMatematicos
    {
        public double CalcularPerimetro(double baseRectangulo, double altura)
        {
            return 2 * (baseRectangulo + altura);
        }
    }
}