Module peso

    Sub Main()
        'Declaracion de variables
        Dim M As Double
        Dim G As Double
        Dim P As Double

        'Ingresar valores para las variables
        G = 9.8
        Console.Write("Ingrese la masa del objeto: ")
        M = Console.ReadLine

        'Realizar procesos
        P = M * G

        'Mostrar resultados
        Console.WriteLine("Peso del objeto: {0}", P)
        Console.ReadKey()
    End Sub

End Module
