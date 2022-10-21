using System;
using System.Xml;

namespace _06._Operations_Between_Numbers
{
    internal class OperationBetweenNumbers
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            string operation = Console.ReadLine();
            double result = 0.0;
            switch (operation)
            {
                case "+":
                    result = n1 + n2;
                    if (result % 2 == 0)
                    {
                        Console.WriteLine($"{n1} {operation} {n2} = {result} - even");

                    }
                    else
                    {
                        Console.WriteLine($"{n1} {operation} {n2} = {result} - odd");
                    }
                    break;
                case "-":
                    result = n1 - n2;
                    if (result % 2 == 0)
                    {
                        Console.WriteLine($"{n1} {operation} {n2} = {result} - even");

                    }
                    else
                    {
                        Console.WriteLine($"{n1} {operation} {n2} = {result} - odd");
                    }
                    break;
                case "*":
                    result = n1 * n2;
                    if (result % 2 == 0)
                    {
                        Console.WriteLine($"{n1} {operation} {n2} = {result} - even");

                    }
                    else
                    {
                        Console.WriteLine($"{n1} {operation} {n2} = {result} - odd");
                    }
                    break;

                case "/":
                    if (n2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {n1} by zero");
                    }
                    else
                    {
                        result = 1.0 * n1 / n2;
                        Console.WriteLine($"{n1} {operation} {n2} = {result:f2}");
                    }
                    break;
                case "%":
                    if (n2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {n1} by zero");
                    }
                    else
                    {
                        result = 1.0 * n1 % n2;
                        Console.WriteLine($"{n1} {operation} {n2} = {result}");
                    }
                    break;


            }
        }
    }
}
