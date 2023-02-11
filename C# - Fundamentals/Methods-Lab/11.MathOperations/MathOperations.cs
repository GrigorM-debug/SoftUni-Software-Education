using System;

namespace _11.MathOperations
{
    internal class MathOperations
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            char @operator = char.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            double result = Calculation(a, @operator, b);
            Console.WriteLine(result);
        }

        static double Calculation(double a, char @operator, double b)
        {
            double result = 0;

            switch(@operator)
            {
                case '/':
                    result = a / b;
                    break;
                case '*':
                    result = a * b;
                    break;
                case '+':
                    result = a + b;
                    break;
                case '-':
                    result = a - b;
                    break;
            }
            return result;
        }
    }
}
