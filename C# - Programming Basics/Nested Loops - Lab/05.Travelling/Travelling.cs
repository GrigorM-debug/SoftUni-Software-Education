using System;

namespace _05.Travelling
{
    internal class Travelling
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            double budget = 0;
            while(destination != "End")
            {
                budget = double.Parse(Console.ReadLine());
                double savedMoney = 0;

                while(savedMoney<budget)
                {
                    double currentMoney = double.Parse(Console.ReadLine());
                    savedMoney = savedMoney + currentMoney;
                }

                Console.WriteLine($"Going to {destination}!");

                destination = Console.ReadLine();
            }
        }
    }
}
