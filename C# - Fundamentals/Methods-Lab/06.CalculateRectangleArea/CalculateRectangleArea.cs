using System;

namespace _06.CalculateRectangleArea
{
    internal class CalculateRectangleArea
    {
        static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            double area = RectangleArea(a, b);
            Console.WriteLine(area);
        }

        static double RectangleArea(double a, double b)
        {
            double area = a * b;
            return area;
        } 
    }
}
