using System;

namespace _03.Harvest
{
    internal class Harvest
    {
        static void Main(string[] args)
        {
            //кв.м лозе
            int x = int.Parse(Console.ReadLine());
            //грозде за един кв.м.
            double y = double.Parse(Console.ReadLine());
            //нужни литри вино
            int z = int.Parse(Console.ReadLine());
            //брой работници
            int workersCount = int.Parse(Console.ReadLine());

            double totalGrapes = x * y;
            double wineLiters = totalGrapes / 2.5 * 0.40;

            if (wineLiters >= z)
            {
                double wineLitersRemain = wineLiters - z;
                wineLitersRemain = Math.Floor(wineLitersRemain);
                double wineLitersPerWorker = wineLitersRemain / workersCount;
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(wineLiters)} liters.");
                Console.WriteLine($"{Math.Ceiling(wineLitersRemain)} liters left -> {Math.Ceiling(wineLitersPerWorker)} liters per person.");
            }
            else if (wineLiters < z)
            {
                double nedostiga6toVino = z - wineLiters;
                nedostiga6toVino = Math.Floor(nedostiga6toVino);
                Console.WriteLine($"It will be a tough winter! More {nedostiga6toVino} liters wine needed.");
            }
        }
    }
}
