using System;
using System.Diagnostics.CodeAnalysis;

namespace _05.ExcursionSale
{
    internal class ExcursionSale
    {
        static void Main(string[] args)
        {
            int seaHolidaysCnt = int.Parse(Console.ReadLine());
            int mountainHolidaysCnt = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            double price = 0;
            

            while (input != "Stop")
            {
                input = Console.ReadLine();

                if (input == "Stop")
                {
                    break;
                }
                if (input == "sea")
                {
                    if (seaHolidaysCnt == 0)
                    {
                        continue;
                    }
                    price = price + 680;
                    seaHolidaysCnt -= 1;
                }
                if (input == "mountain")
                {
                    if (mountainHolidaysCnt == 0)
                    {
                        continue;
                    }
                    price = price + 499;
                    mountainHolidaysCnt -= 1;
                }

                if (seaHolidaysCnt == 0 && mountainHolidaysCnt == 0)
                {
                    Console.WriteLine("Good job! Everything is sold.");
                    break;
                }
                
            }


            Console.WriteLine($"Profit: {price} leva.");
            


        }
    }
}
