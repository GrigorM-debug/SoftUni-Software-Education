using System;
using System.Threading;

namespace _05.Vacation
{
    internal class Vacation
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string place = "";
            string location = "";

            if (budget <= 1000)
            {
                place = "Camp";
                switch (season)
                {
                    case "Summer":
                        location = "Alaska";
                        budget = budget * 0.65;
                        break;
                    case "Winter":
                        location = "Morocco";
                        budget = budget * 0.45;
                        break;
                }
            }
            else if (budget > 1000 && budget <= 3000)
            {
                place = "Hut";
                switch (season)
                {
                    case "Summer":
                        location = "Alaska";
                        budget = budget * 0.80;
                        break;
                    case "Winter":
                        location = "Morocco";
                        budget = budget * 0.60;
                        break;
                }
            }
            else
            {
                place = "Hotel";
                switch(season)
                {
                    case "Summer":
                        location = "Alaska";
                        budget = budget * 0.90;
                        break;
                    case "Winter":
                        location = "Morocco";
                        budget = budget * 0.90;
                        break;
                }
            }
            Console.WriteLine($"{location} - {place} - {budget:f2}");
        }
    }
}
