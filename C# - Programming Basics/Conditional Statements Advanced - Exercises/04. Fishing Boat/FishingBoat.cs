using System;
using System.Security.Cryptography.X509Certificates;

namespace _04._Fishing_Boat
{
    internal class FishingBoat
    {
        static void Main(string[] args)
        {
            //Input
            int crewBudget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishmanNumber = int.Parse(Console.ReadLine());
            double shipPrice = 0.0;

            switch (season)
            {
                case "Spring":
                    shipPrice = 3000;
                    break;
                case "Summer":
                    shipPrice = 4200;
                    break;
                case "Autumn":
                    shipPrice = 4200;
                    break;
                case "Winter":
                    shipPrice = 2600;
                    break;
            }
            if (fishmanNumber <= 6)
            {
                shipPrice = shipPrice - (shipPrice * 0.10);
            }
            else if (fishmanNumber >= 7 && fishmanNumber <= 11)
            {
                shipPrice = shipPrice - (shipPrice * 0.15);
            }
            else if (fishmanNumber >= 12)
            {
                shipPrice = shipPrice - (shipPrice * 0.25);
            }
            if (fishmanNumber % 2 == 0 && season != "Autumn")
            {
                shipPrice = shipPrice - (shipPrice * 0.05);
            }

            double moneyLeft = 0;
            double moneyNeeded = 0;
            if (crewBudget >= shipPrice)
            {
                moneyLeft = crewBudget - shipPrice;
                Console.WriteLine($"Yes! You have {moneyLeft:f2} leva left.");
            }
            else if (shipPrice > crewBudget)
            {
                moneyNeeded = shipPrice - crewBudget;
                Console.WriteLine($"Not enough money! You need {moneyNeeded:f2} leva.");
            }
        }
    }
}
