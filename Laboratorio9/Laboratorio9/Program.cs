internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Ingrese el precio del producto (valor positivo): ");
        double precio = double.Parse(Console.ReadLine());

        if (precio <= 0)
        {
            Console.WriteLine("El precio debe ser positivo");
            return;
        }

        Console.WriteLine("Ingrese forma de pago (efectivo o tarjeta): ");
        string formaPago = Console.ReadLine().ToLower();

        if (formaPago == "tarjeta")
        {
            Console.WriteLine("Ingrese número de cuenta (16 digitos): ");
            string cuenta = Console.ReadLine();

            if (cuenta.Length == 16 && long.TryParse(cuenta, out _))
            {
                Console.WriteLine($"Pago con tarjeta, cuenta: {cuenta}, precio: {precio}");
            }
            else
            {
                Console.WriteLine("El número de cuenta es inválido");
            }
        }
        else if (formaPago == "efectivo")
        {
            Console.WriteLine($"Pago en efectivo, precio: {precio}");
        }
        else
        {
            Console.WriteLine("Forma de pago no válida");
        }
    }
}