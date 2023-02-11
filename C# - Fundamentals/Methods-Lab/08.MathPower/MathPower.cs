using System;

namespace _08.MathPower
{
    internal class MathPower
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());  
            double result = RaiseToPower(number, power);
            Console.WriteLine(result);
        }
        static double RaiseToPower(double number, double power)
        {
            double result = 1;
            for(double i = 0; i < power; i++)
            {
                result *= number;
            }

            return result;
        }
    }
}
