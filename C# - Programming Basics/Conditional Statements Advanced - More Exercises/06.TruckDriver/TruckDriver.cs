using System;

namespace _06.TruckDriver
{
    internal class TruckDriver
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            double kilometersPerMouth = double.Parse(Console.ReadLine());
            double money = 0.0;

            if (kilometersPerMouth <= 5000)
            {
                switch (season)
                {
                    case "Summer":
                        money = kilometersPerMouth * 0.90 * 4;
                        break;
                    case "Autumn":
                        money = kilometersPerMouth * 0.75 * 4;
                        break;
                    case "Spring":
                        money = kilometersPerMouth * 0.75 * 4;
                        break;
                    case "Winter":
                        money = kilometersPerMouth * 1.05 * 4;
                        break;
                }
            }
            else if (kilometersPerMouth > 5000 && kilometersPerMouth <= 10000)
            {
                switch (season)
                {
                    case "Summer":
                        money = kilometersPerMouth * 1.10 * 4;
                        break;
                    case "Autumn":
                        money = kilometersPerMouth * 0.95 * 4;
                        break;
                    case "Spring":
                        money = kilometersPerMouth * 0.95 * 4;
                        break;
                    case "Winter":
                        money = kilometersPerMouth * 1.25 * 4;
                        break;
                }
            }
            else
            {
                switch (season)
                {
                    case "Summer":
                        money = kilometersPerMouth * 1.45 * 4;
                        break;
                    case "Autumn":
                        money = kilometersPerMouth * 1.45 * 4;
                        break;
                    case "Spring":
                        money = kilometersPerMouth * 1.45 * 4;
                        break;
                    case "Winter":
                        money = kilometersPerMouth * 1.45 * 4;
                        break;
                }
            }
            money = money - money * 0.10;
            Console.WriteLine($"{money:f2}");   
        }
    }
}
