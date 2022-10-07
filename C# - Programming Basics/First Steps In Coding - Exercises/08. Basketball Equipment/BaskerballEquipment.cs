using System;

namespace _08._Basketball_Equipment
{
    internal class BaskerballEquipment
    {
        static void Main(string[] args)
        {
            //Вход от конзолата
            int yearlyPriceForBasketballTraining = int.Parse(Console.ReadLine());
            //Изчисления
            double sneakersPrice = yearlyPriceForBasketballTraining - yearlyPriceForBasketballTraining * 0.40;
            double basketballClothesPrice = sneakersPrice - sneakersPrice * 0.20;
            double basketballBallPrice = basketballClothesPrice * 1 / 4;
            double basketbalАccessories = basketballBallPrice * 1 / 5;
            double totalSum = yearlyPriceForBasketballTraining + sneakersPrice + basketballClothesPrice + basketballBallPrice + basketbalАccessories;
            //Изход
            Console.WriteLine(totalSum);
        }
    }
}
