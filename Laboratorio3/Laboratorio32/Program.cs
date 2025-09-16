using System.Transactions;

internal class Program
{
    private static void Main(string[] args)
    {
        double radio, area;

        Console.WriteLine("Introduce el radio del circulo");
        radio = Convert.ToDouble(Console.ReadLine());

        CalculosMatematicos calculos = new CalculosMatematicos();

        area = calculos.CalcularArea(radio);

        Console.WriteLine("El area del circulo {0} es: {1}", radio, area);
    }

    class CalculosMatematicos
    {
        public double CalcularArea(double radio)
        {
            return Math.PI * Math.Pow(radio, 2);
        }

    }
}