using System;

namespace _03.Calculations
{
    internal class Calculations
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());  

            switch(command)
            {
                case "add":
                    Add(numberOne, numberTwo);
                    break;
                case "subtract":
                    Subtract(numberOne, numberTwo);
                    break;
                case "multiply":
                    Multiply(numberOne, numberTwo);   
                  break;
                case "divide":
                    Divide(numberOne, numberTwo);   
                    break;
            }
        }
        static void Add(int numberOne, int numberTwo)
        {
            int result = numberOne+ numberTwo;
            Console.WriteLine(result);
        }

        static void Subtract(int numberOne, int numberTwo)
        {
            int result = numberOne - numberTwo;
            Console.WriteLine(result);
        }

        static void Multiply(int numberOne, int numberTwo)
        { 
            int result = numberOne * numberTwo;
            Console.WriteLine(result);
        }

        static void Divide(int numberOne, int numberTwo)
        {
            int result = numberOne / numberTwo;
            Console.WriteLine(result);
        }
    }
}
