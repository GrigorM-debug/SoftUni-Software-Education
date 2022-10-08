using System;

namespace _07.AreaOfFigures
{
    internal class AreaOfFigures
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine(); 

            if(figure == "squere")
            {
                double a = double.Parse(Console.ReadLine());
                double area = Math.Pow(a, 2);
                Console.WriteLine($"{area:F3}");
            }
            else if (figure == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                double area = a * b;
                Console.WriteLine($"{area:F3}");
            }
            else if (figure == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                radius = Math.Pow(radius, 2);   
                double area = radius * Math.PI;
                Console.WriteLine($"{area:F3}");
            }
            else if (figure == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());
                double area = (a * h) / 2;
                Console.WriteLine($"{area:F3}");
            }
        }
    }
}
