using System;

namespace _04.CarToGo
{
    internal class CarToGo
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine(); 
            string clas = " ";
            string car = "";

            if (budget <= 100) 
            {
                clas = "Economy class";
                switch (season) 
                {
                    case "Summer":
                        budget = budget * 0.35;
                        car = "Cabrio";
                        break;
                    case "Winter":
                        budget = budget * 0.65;
                        car = "Jeep";
                        break;
                }
            }
            else if (budget >100 && budget <=500)
            {
                clas = "Compact class";
                switch (season)
                {
                    case "Summer":
                        car = "Cabrio";
                        budget = budget * 0.45;
                        break;
                    case "Winter":
                        car = "Jeep";
                        budget = budget * 0.80;
                        break;
                }
            }
            else
            {
                clas = "Luxury class";
                switch (season)
                {
                    case "Summer":
                        car = "Jeep";
                        budget = budget * 0.90;
                        break;
                    case "Winter":
                        car = "Jeep";
                        budget = budget * 0.90;
                        break;
                }
            }
            Console.WriteLine($"{clas}");
            Console.WriteLine($"{car} - {budget:F2}");


        }
    }
}
