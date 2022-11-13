using System;

namespace _02.DeerOfSanta
{
    internal class DearOfSanta
    {
        static void Main(string[] args)
        {
            int daysWhenSantaIsNotHome = int.Parse(Console.ReadLine());
            int leftFoodInKg = int.Parse(Console.ReadLine());
            double firstDearDayFood = double.Parse(Console.ReadLine());   
            double secondDearDayFood = double.Parse(Console.ReadLine());
            double thirdDearDayFood = double.Parse(Console.ReadLine());

            double firstDearFood = daysWhenSantaIsNotHome * firstDearDayFood;
            double secondDearFood = daysWhenSantaIsNotHome * secondDearDayFood;
            double thirdDearFood = daysWhenSantaIsNotHome * thirdDearDayFood;

            double totalDearsNeededFood = firstDearFood + secondDearFood + thirdDearFood;

            if (totalDearsNeededFood > leftFoodInKg)
            {
                double foodNeeded = totalDearsNeededFood - leftFoodInKg;
                Console.WriteLine($"{Math.Ceiling(foodNeeded)} more kilos of food are needed.");
            }
            else
            {
                double foodLeft = leftFoodInKg - totalDearsNeededFood;
                Console.WriteLine($"{Math.Floor(foodLeft)} kilos of food left.");
            }
        }
    }
}
