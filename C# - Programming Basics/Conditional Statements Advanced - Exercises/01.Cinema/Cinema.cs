using System;
using System.Runtime.InteropServices;

namespace _01.Cinema
{
    internal class Cinema
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());
            double income = 0.0;

            switch (type)
            {
                case "Premiere":
                    income = rows * columns * 12.00;
                    break;
                case "Normal":
                    income = rows * columns * 7.50;
                    break;
                case "Discount":
                    income = rows * columns * 5.00;
                    break;
            }
            Console.WriteLine($"{income:f2} leva");
        }
    }
}
