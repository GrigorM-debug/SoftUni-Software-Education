using System;

namespace _06._Fishland
{
    internal class Fishland
    {
        static void Main(string[] args)
        {
            //Вход
            double mackarelOneKgPrice = double.Parse(Console.ReadLine());
            double sprinkleOneKgPrice = double.Parse(Console.ReadLine());
            double palamudKg = double.Parse(Console.ReadLine());
            double safridKg = double.Parse(Console.ReadLine());
            double musselsKg = double.Parse(Console.ReadLine());

            //Изчисления
            double palamudOneKgPrice = mackarelOneKgPrice + (mackarelOneKgPrice * 0.60);
            double palamudPrice = palamudKg * palamudOneKgPrice;
            double safridOneKgPrice = sprinkleOneKgPrice + (sprinkleOneKgPrice * 0.80);
            double safridPrice = safridKg * safridOneKgPrice;
            double musselsOneKgPrice = 7.50;
            double musselsPrice = musselsKg * musselsOneKgPrice;
            double finalSum = palamudPrice + safridPrice + musselsPrice;
            
            //Изход
            Console.WriteLine("{0:F2}", finalSum);


        }
    }
}
