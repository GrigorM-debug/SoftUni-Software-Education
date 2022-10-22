using System;

namespace _08._NumberSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberCnt = int.Parse(Console.ReadLine());

            int minNumber = int.MaxValue;
            int maxNumber = int.MinValue;

            for (int i = 0; i < numberCnt; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number < minNumber)
                {
                    minNumber = number;
                }
                else if (number > maxNumber)
                {
                    maxNumber = number;
                }
            }
            Console.WriteLine($"Max number: {maxNumber}");
            Console.WriteLine($"Min number: {minNumber}");    
        }
    }
}
