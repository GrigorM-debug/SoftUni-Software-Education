using System;

namespace _06._Repainting
{
    internal class Repainting
    {
        static void Main(string[] args)
        {
            //Вход
            int neededNylon = int.Parse(Console.ReadLine());
            double neededLittersPaint = double.Parse(Console.ReadLine());
            int littersThinner = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            //Цени
            double nylonPriceOneSquereMeter = 1.50;
            double paintPriceOneLitter = 14.50;
            double thinnerPriceOneLitter = 5.00;
            double bagPrice = 0.40;
            double workManPriceForOneHour = 0.30;
            //Изчисления
            double nylonPrice = (neededNylon + 2) * nylonPriceOneSquereMeter;
            double paintPrice = neededLittersPaint * paintPriceOneLitter;
            paintPrice = paintPrice + paintPrice * 0.10;
            double thinnerPrice = littersThinner * thinnerPriceOneLitter;
            double totalSum = nylonPrice + paintPrice + thinnerPrice + bagPrice;
            double workManPrice = (totalSum * workManPriceForOneHour) * hours;
            double wholeSum = totalSum + workManPrice;
            Console.WriteLine(wholeSum);
        }
    }
}
