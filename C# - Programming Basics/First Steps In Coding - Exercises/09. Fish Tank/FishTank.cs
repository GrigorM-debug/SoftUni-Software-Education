using System;

namespace _09._Fish_Tank
{
    internal class FishTank
    {
        static void Main(string[] args)
        {
            //Вход
            int lenth = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine()); 
            double percent = double.Parse(Console.ReadLine());
            //Изчисления
            double volume = lenth * width * height;
            double volumeInLitters = volume / 1000;
            percent = percent / 100;
            double neededLitters = volumeInLitters * (1 - percent);
            //Изход
            Console.WriteLine(neededLitters);
        }
    }
}
