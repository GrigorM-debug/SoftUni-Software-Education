using System;

namespace _03._Celsius_to_Fahrenheit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double ceisius = double.Parse(Console.ReadLine());
            double fahrenheit = ceisius * 1.8 + 32;
            Console.WriteLine("{0:F2}", fahrenheit);
        }
    }
}
