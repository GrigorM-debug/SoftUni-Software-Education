using System;

namespace _05._Pets
{
    internal class Pets
    {
        static void Main(string[] args)
        {
            double days = double.Parse(Console.ReadLine());
            int leftFood = int.Parse(Console.ReadLine());   
            double dogDayFood = double.Parse(Console.ReadLine());   
            double catDayFood = double.Parse(Console.ReadLine());   
            double turtleDayFood = double.Parse(Console.ReadLine());    

            double DogNeededFood = days * dogDayFood * 1000;
            double CatNeededFood = days * catDayFood * 1000;   
            double TurtleNeededFood = days * turtleDayFood;

            double totalFood = DogNeededFood + CatNeededFood + TurtleNeededFood;
            totalFood = totalFood / 1000;

            if (totalFood <= leftFood)
            {
                double foodLeft = leftFood- totalFood;
                Console.WriteLine($"{Math.Floor(foodLeft)} kilos of food left.");
            }
            else if (totalFood > dogDayFood) 
            {
                double foodNeeded = totalFood - leftFood;
                Console.WriteLine($"{Math.Ceiling(foodNeeded)} more kilos of food are needed.");
            }
        }
    }
}
