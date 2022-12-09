using System;

namespace _08.FuelTank_Part2
{
    internal class FuelTankPart2
    {
        static void Main(string[] args)
        {
            string fuelType = Console.ReadLine();
            double fuelAmount = double.Parse(Console.ReadLine());
            string clubCard = Console.ReadLine();

            double gasolinePrice = 2.22;
            double gasPrice = 0.93;
            double dieselPrice = 2.33;

            double gasolinePriceWithClubCard = gasolinePrice - 0.18;
            double gasPriceWithClubCard = gasPrice - 0.08;
            double dieselPriceWithClubCard = dieselPrice - 0.12;

            double result = 0;

            if (fuelAmount >= 20 && fuelAmount <= 25 && clubCard == "Yes")
            {
                if (fuelType == "Gasoline")
                {
                    gasolinePriceWithClubCard = gasolinePriceWithClubCard - (gasolinePriceWithClubCard * 0.08);
                    result = gasolinePriceWithClubCard * fuelAmount;
                }

                else if (fuelType == "Gas")
                {
                    gasPriceWithClubCard = gasPriceWithClubCard - (gasPriceWithClubCard * 0.08);
                    result = gasPriceWithClubCard * fuelAmount;
                }

                else if (fuelType == "Diesel")
                {
                    dieselPriceWithClubCard = dieselPriceWithClubCard - (dieselPriceWithClubCard * 0.08);
                    result = dieselPriceWithClubCard * fuelAmount;
                }
            }

            else if (fuelAmount >= 20 && fuelAmount <= 25 && clubCard == "No")
            {
                if (fuelType == "Gasoline")
                {
                    gasolinePrice = gasolinePrice - (gasolinePrice * 0.08);
                    result = gasolinePrice * fuelAmount;
                }

                else if (fuelType == "Gas")
                {
                    gasPrice = gasPrice - (gasPrice * 0.08);
                    result = gasPrice * fuelAmount;
                }

                else if (fuelType == "Diesel")
                {
                    dieselPrice = dieselPrice - (dieselPrice * 0.08);
                    result = dieselPrice * fuelAmount;
                }
            }

            else if (fuelAmount > 25 && clubCard == "Yes")
            {
                if (fuelType == "Gasoline")
                {
                    gasolinePriceWithClubCard = gasolinePriceWithClubCard - (gasolinePriceWithClubCard * 0.10);
                    result = gasolinePriceWithClubCard * fuelAmount;
                }

                else if (fuelType == "Gas")
                {
                    gasPriceWithClubCard = gasPriceWithClubCard - (gasPriceWithClubCard * 0.10);
                    result = gasPriceWithClubCard * fuelAmount;
                }

                else if (fuelType == "Diesel")
                {
                    dieselPriceWithClubCard = dieselPriceWithClubCard - (dieselPriceWithClubCard * 0.10);
                    result = dieselPriceWithClubCard * fuelAmount;
                }
            }

            else if (fuelAmount > 25 && clubCard == "No")
            {
                if (fuelType == "Gasoline")
                {
                    gasolinePrice = gasolinePrice - (gasolinePrice * 0.10);
                    result = gasolinePrice * fuelAmount;

                }

                else if (fuelType == "Gas")
                {
                    gasPrice = gasPrice - (gasPrice * 0.10);
                    result = gasPrice * fuelAmount;
                }

                else if (fuelType == "Diesel")
                {
                    dieselPrice = dieselPrice - (dieselPrice * 0.10);
                    result = dieselPrice * fuelAmount;
                }
            }
            else if (clubCard == "Yes")
            {
                if (fuelType == "Gasoline")
                {
                    result = gasolinePriceWithClubCard * fuelAmount;
                }

                else if (fuelType == "Gas")
                {
                    result = gasPriceWithClubCard * fuelAmount;
                }

                else if (fuelType == "Diesel")
                {
                    result = dieselPriceWithClubCard * fuelAmount;
                }
            }

            else
            {
                if (fuelType == "Gasoline")
                {
                    result = gasolinePrice * fuelAmount;
                }

                else if (fuelType == "Gas")
                {
                    result = gasPrice * fuelAmount;
                }

                else if (fuelType == "Diesel")
                {
                    result = dieselPrice * fuelAmount;
                }

            }
            Console.WriteLine($"{result:f2} lv.");

        }
    }
}
