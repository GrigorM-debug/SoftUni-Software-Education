using System;

namespace _01.CatDiet
{
    internal class CatDiet
    {
        static void Main(string[] args)
        {
           	 //1 грам мазнини = 9 калории
	         //1 грам протеини = 4 калории
	         //1 грам въглехидрати = 4 калории

            double fats = double.Parse(Console.ReadLine());
            double protein = double.Parse(Console.ReadLine());
            double carbs = double.Parse(Console.ReadLine());
            double calories = double.Parse(Console.ReadLine());
            double water = double.Parse(Console.ReadLine());

            double fatsPercent = fats / 100;
            double proteinPercent = protein / 100;   
            double carbsPercent = carbs / 100;   
            //double waterPercent = water / 100;

            double totalFatGrams = (fatsPercent * calories) / 9;
            double totalProteinGrams = (proteinPercent * calories) / 4;
            double totalCarbsGrams = (carbsPercent * calories  / 4);

            double foodGrams = totalFatGrams + totalProteinGrams + totalCarbsGrams;
            double caloriesForOneGramFood = calories / foodGrams;

            double caloriesWithoutWater = ((100 - water) / 100) * caloriesForOneGramFood;
            

            Console.WriteLine($"{caloriesWithoutWater:f4}");
        }
    }
}
