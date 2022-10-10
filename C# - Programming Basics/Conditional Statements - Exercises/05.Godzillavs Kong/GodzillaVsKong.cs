using System;

namespace _05.Godzillavs_Kong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Данни от конзолата
            double filmBudget = double.Parse(Console.ReadLine());
            int extrasCount = int.Parse(Console.ReadLine());
            double extrasClothesPrice = double.Parse(Console.ReadLine());
            // Изчисления
            double decorSum = filmBudget * 0.10;
            double clothesSum = extrasCount * extrasClothesPrice;

            double clotheAndDecorTotalSum = clothesSum + decorSum;

            if (extrasCount > 150)
            {
                clothesSum = clothesSum - (clothesSum * 0.1);
            }
            double filmSum = decorSum + clothesSum;

            if (filmSum > filmBudget)
            {

                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {Math.Abs(filmBudget - filmSum):f2} leva more.");
            }
            else if (clotheAndDecorTotalSum <= filmBudget)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {filmBudget - filmSum:f2} leva left.");
            }

        }
    }
}
