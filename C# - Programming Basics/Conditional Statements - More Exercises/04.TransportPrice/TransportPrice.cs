using System;
using System.Diagnostics.Contracts;

namespace _04.TransportPrice
{
    internal class TransportPrice
    {
        static void Main(string[] args)
        {
            int kilometersCnt = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();
            double price = 0.0;

            if(kilometersCnt <= 20)
            {
                switch (timeOfDay)
                {
                    case "day":
                        price = 0.70 + kilometersCnt * 0.79;
                        break;
                    case "night":
                        price = 0.70 + kilometersCnt * 0.90;
                        break;
                }
            }
            if (kilometersCnt >= 20 && kilometersCnt < 100) 
            {
                price = kilometersCnt * 0.09;
            }
            if (kilometersCnt >= 100)
            {
                price = kilometersCnt * 0.06; 
            }

            Console.WriteLine("{0:F2}", price);

        }
    }
}
