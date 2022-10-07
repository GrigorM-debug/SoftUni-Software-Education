using System;

namespace _08._Circle_Area_and_Perimeter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console Input
            double radius = double.Parse(Console.ReadLine());

            //Calculations
            double perimeter = 2 * Math.PI * radius;
            double area = Math.PI * radius * radius;

            //Console Output
            Console.WriteLine("{0:F2}", area);
            Console.WriteLine("{0:F2}", perimeter);
        }
    }
}
