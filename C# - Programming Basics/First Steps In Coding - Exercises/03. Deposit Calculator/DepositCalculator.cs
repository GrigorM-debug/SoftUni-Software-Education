using System;

namespace _03._Deposit_Calculator
{
    internal class DepositCalculator
    {
        static void Main(string[] args)
        {
            //Вход от конзолата
            double depositSum = double.Parse(Console.ReadLine());
            int mouths = int.Parse(Console.ReadLine());
            double interestPercent = double.Parse(Console.ReadLine()) / 100;
            //Действия
            double calculatesTheAccruedInterest = (depositSum * interestPercent) / 12;
            double depositGain = mouths * calculatesTheAccruedInterest;
            double totalSum = depositSum + depositGain;
            //Изход
            Console.WriteLine(totalSum);
        }
    }
}
