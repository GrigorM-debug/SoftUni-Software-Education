using System;

namespace _06.EasterDecoration
{
    internal class EasterDecoration
    {
        static void Main(string[] args)
        {
            int customersCnt = int.Parse(Console.ReadLine());
            double allPurchase = 0.0;

            for (int i = 0; i < customersCnt; i++)
            {
                string product = Console.ReadLine();
                double currentClientPurchase = 0;
                int purchaseCnt = 0;

                while (product != "Finish")
                {
                    if (product == "basket")
                    {
                        currentClientPurchase = currentClientPurchase + 1.50;
                        purchaseCnt++;
                    }
                    else if (product == "wreath")
                    {
                        currentClientPurchase = currentClientPurchase + 3.80;
                        purchaseCnt++;
                    }
                    else if (product == "chocolate bunny")
                    {
                        currentClientPurchase = currentClientPurchase + 7;
                        purchaseCnt++;
                    }
                    product = Console.ReadLine();
                }
                if (purchaseCnt % 2 == 0)
                {
                    currentClientPurchase = currentClientPurchase - currentClientPurchase * 0.20;
                }

                allPurchase += currentClientPurchase;
                Console.WriteLine($"You purchased {purchaseCnt} items for {currentClientPurchase:f2} leva.");
            }
            double average = allPurchase / customersCnt;
            Console.WriteLine($"Average bill per client is: {average:f2} leva.");
        }
    }
}
