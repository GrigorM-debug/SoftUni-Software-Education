using System;

namespace _02.BonusScore
{
    internal class BonusScore
    {
        static void Main(string[] args)
        {
            //Input
            int number = int.Parse(Console.ReadLine());
            double bonusScore = 0;
            //Actions 
            if (number <= 100)
            {
                bonusScore = 5;
            }
            else if (number > 1000)
            {
                bonusScore = number * 0.1;
            }
            else
            {
                bonusScore = number * 0.2;
            }

            if (number % 2 == 0)
            {
                bonusScore += 1;
            }
            else if (number % 10 == 5)
            {
                bonusScore += 2;
            }

            //Output 
            Console.WriteLine(bonusScore);
            Console.WriteLine(bonusScore + number);

        }
    }
}
