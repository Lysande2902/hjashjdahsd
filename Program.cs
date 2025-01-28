using System;
using FigurasGeometricas;

try
{
    Console.WriteLine("Seleccione una figura:");
    Console.WriteLine("1. Círculo");
    Console.WriteLine("2. Cuadrado");
    Console.WriteLine("3. Rectángulo");
    Console.WriteLine("4. Triángulo");
    string input = Console.ReadLine()!;
    if (string.IsNullOrEmpty(input))
    {
        throw new FormatException("Input cannot be null or empty.");
    }
    int opcion = int.Parse(input);

    switch (opcion)
    {
        case 1:
            Console.Write("Ingrese el radio del círculo: ");
            double radio = Convert.ToDouble(Console.ReadLine());
            Circulo circulo = new Circulo(radio);
            MostrarResultados(circulo);
            break;

        case 2:
            Console.Write("Ingrese el lado del cuadrado: ");
            double lado = Convert.ToDouble(Console.ReadLine());
            Cuadrado cuadrado = new Cuadrado(lado);
            MostrarResultados(cuadrado);
            break;

        case 3:
            Console.Write("Ingrese la base del rectángulo: ");
            double largo = Convert.ToDouble(Console.ReadLine());
            Console.Write("Ingrese la altura del rectángulo: ");
            double ancho = Convert.ToDouble(Console.ReadLine());
            Rectangulo rectangulo = new Rectangulo(largo, ancho);
            MostrarResultados(rectangulo);
            break;

        case 4:
            Console.Write("Ingrese el lado 1 del triángulo: ");
            double lado1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Ingrese el lado 2 del triángulo: ");
            double lado2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Ingrese el lado 3 del triángulo: ");
            double lado3 = Convert.ToDouble(Console.ReadLine());
            Triangulo triangulo = new Triangulo(lado1, lado2, lado3);
            MostrarResultados(triangulo);
            Console.WriteLine($"Tipo de triángulo: {triangulo.TipoDeTriangulo()}");
            break;

        default:
            Console.WriteLine("Opción inválida.");
            break;
    }
}
catch (FormatException)
{
    Console.WriteLine("Error: Ingrese un valor válido.");
}

void MostrarResultados(Figura figura)
{
    Console.WriteLine($"Área: {figura.CalcularArea():F2}");
    Console.WriteLine($"Perímetro: {figura.CalcularPerimetro():F2}");
}

namespace FigurasGeometricas
{
    abstract class Figura
    {
        public abstract double CalcularArea();
        public abstract double CalcularPerimetro();
    }

    class Circulo : Figura
    {
        public double Radio { get; set; }

        public Circulo(double radio)
        {
            Radio = radio;
        }

        public override double CalcularArea()
        {
            return Math.PI * Math.Pow(Radio, 2);
        }

        public override double CalcularPerimetro()
        {
            return 2 * Math.PI * Radio;
        }
    }

    class Cuadrado : Figura
    {
        public double Lado { get; set; }

        public Cuadrado(double lado)
        {
            Lado = lado;
        }

        public override double CalcularArea()
        {
            return Math.Pow(Lado, 2);
        }

        public override double CalcularPerimetro()
        {
            return 4 * Lado;
        }
    }

    class Rectangulo : Figura
    {
        public double Largo { get; set; }
        public double Ancho { get; set; }

        public Rectangulo(double largo, double ancho)
        {
            Largo = largo;
            Ancho = ancho;
        }

        public override double CalcularArea()
        {
            return Largo * Ancho;
        }

        public override double CalcularPerimetro()
        {
            return 2 * (Largo + Ancho);
        }
    }

    class Triangulo : Figura
    {
        public double Lado1 { get; set; }
        public double Lado2 { get; set; }
        public double Lado3 { get; set; }

        public Triangulo(double lado1, double lado2, double lado3)
        {
            Lado1 = lado1;
            Lado2 = lado2;
            Lado3 = lado3;
        }

        public override double CalcularArea()
        {
            double semiperimetro = CalcularPerimetro() / 2;
            return Math.Sqrt(
                semiperimetro
                    * (semiperimetro - Lado1)
                    * (semiperimetro - Lado2)
                    * (semiperimetro - Lado3)
            );
        }

        public override double CalcularPerimetro()
        {
            return Lado1 + Lado2 + Lado3;
        }

        public string TipoDeTriangulo()
        {
            if (Lado1 == Lado2 && Lado2 == Lado3)
                return "Equilátero";
            else if (Lado1 == Lado2 || Lado1 == Lado3 || Lado2 == Lado3)
                return "Isósceles";
            else
                return "Escaleno";
        }
    }
}
