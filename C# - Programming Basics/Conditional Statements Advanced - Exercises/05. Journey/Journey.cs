using System;
using System.IO;

namespace _05._Journey
{
    internal class Journey
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string location = "";
            string breakType = "";
            double tripSum = 0.0;

            if (budget <= 100)
            {
                location = "Bulgaria";
                if (season == "summer")
                {
                    breakType = "Camp";
                    tripSum = budget * 0.3;
                }
                else if (season == "winter")
                {
                    breakType = "Hotel";
                    tripSum = budget * 0.7;
                }
            }
            else if (budget <= 1000)
            {
                location = "Balkans";
                if(season == "summer")
                {
                    breakType = "Camp";
                    tripSum = budget * 0.4;
                }
                else if (season == "winter")
                {
                    breakType = "Hotel";
                    tripSum = budget * 0.8;
                }
            }
            else if (budget > 1000)
            {
                location = "Europe";
                tripSum = budget * 0.9;
            }
            Console.WriteLine($"Somewhere in {location}");
            Console.WriteLine($"{breakType} - {tripSum:f2}");
        }
    }
}
