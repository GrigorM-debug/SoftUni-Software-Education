using System;

namespace _08.PetShop
{
    internal class PetShop
    {
        static void Main(string[] args)
        {
            int numberPacketFoodForDogs = int.Parse(Console.ReadLine());
            int numberPacketFoodForCats = int.Parse(Console.ReadLine());
            double priceForOnePacketDogFood = 2.5;
            double priceForOnePacketCatFood = 4;
            double totalPrice = numberPacketFoodForDogs * priceForOnePacketDogFood + numberPacketFoodForCats * priceForOnePacketCatFood;
            Console.WriteLine($"{totalPrice} lv.");
        }
    }
}
