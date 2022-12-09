using System;

namespace _06.FlowerShop
{
    internal class FlowersShop
    {
        static void Main(string[] args)
        {
            double magnoliasPrice = 3.25;
            double hyacinthsPrice = 4;
            double rosesPrice = 3.50;
            double cactusPrice = 8;

            int magnoliasCnt = int.Parse(Console.ReadLine());
            int hyacinthsCnt = int.Parse(Console.ReadLine());   
            int rosesCnt = int.Parse(Console.ReadLine());
            int cactusCnt = int.Parse(Console.ReadLine());  
            double giftPrice = double.Parse(Console.ReadLine());

            double magnoliasSum = magnoliasPrice * magnoliasCnt;
            double hyacinthsSum = hyacinthsPrice* hyacinthsCnt;
            double rosesSum = rosesPrice* rosesCnt; 
            double cactusSum = cactusPrice * cactusCnt;

            double totalSum = magnoliasSum + hyacinthsSum + rosesSum + cactusSum;

            totalSum = totalSum - totalSum * 0.05;

            if (totalSum >= giftPrice) 
            {
                double moneyLeft = totalSum - giftPrice;
                Console.WriteLine($"She is left with {Math.Floor(moneyLeft)} leva.");
            }
            else if (totalSum < giftPrice)
            {
                double moneyNeeded = giftPrice - totalSum;
                Console.WriteLine($"She will have to borrow {Math.Ceiling(moneyNeeded)} leva.");
            }



        }
    }
}
