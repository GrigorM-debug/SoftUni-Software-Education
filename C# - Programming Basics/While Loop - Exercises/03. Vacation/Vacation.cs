using System;

namespace _03._Vacation
{
    internal class Vacation
    {
        static void Main(string[] args)
        {
            double holidayPrice = double.Parse(Console.ReadLine());
            double availableMoney = double.Parse(Console.ReadLine());
            double money = 0;
            string input = "";
            int DaysCounter = 0;
            int spendingMoneyCounter = 0;

            while(availableMoney<holidayPrice)
            {
                input = Console.ReadLine();
                money = double.Parse(Console.ReadLine());
                DaysCounter++;
                
                if (input == "save")
                {
                    availableMoney += money;
                    spendingMoneyCounter = 0;
                }
                else
                {
                    availableMoney -= money;
                    if (availableMoney < 0)
                    {
                        availableMoney = 0;
                    }

                    spendingMoneyCounter++;

                    if (spendingMoneyCounter == 5)
                    {
                        Console.WriteLine($"You can't save the money.");
                        Console.WriteLine($"{DaysCounter}");
                        break;
                    }
                }
            
            }
            if (availableMoney >= holidayPrice)
            {
                Console.WriteLine($"You saved the money for {DaysCounter} days.");
            }
        }
    }
}
