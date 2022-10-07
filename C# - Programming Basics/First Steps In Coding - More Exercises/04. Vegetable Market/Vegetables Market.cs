using System;

namespace _04._Vegetable_Market
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Вход 
            double priceFoeOneKgVegetables = double.Parse(Console.ReadLine());
            double priceForOneKgFruits = double.Parse(Console.ReadLine());
            double totalKgVegetables = double.Parse(Console.ReadLine());
            double totalKgFruits = double.Parse(Console.ReadLine());

            //Изчисления
            double vegetablesTotalPrice = priceFoeOneKgVegetables * totalKgVegetables;
            double fruitsTotalPrice = priceForOneKgFruits * totalKgFruits;
            double finalPriceInBGN = vegetablesTotalPrice + fruitsTotalPrice;
            double finalPriceInEuro = finalPriceInBGN / 1.94;
            Console.WriteLine("{0:F2}", finalPriceInEuro);

        }
    }
}
