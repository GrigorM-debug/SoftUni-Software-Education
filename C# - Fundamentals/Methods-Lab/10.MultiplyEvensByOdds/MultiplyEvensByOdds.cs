using System;
using System.Linq;

namespace _10.MultiplyEvensByOdds
{
    internal class MultiplyEvensByOdds
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));
            int oddSum = 0;
            int evenSum = 0;
           
            int result = GetAndMultiplySumOfEvenAndOddDigits(number, oddSum, evenSum);
            Console.WriteLine(result);
        }

        static int GetAndMultiplySumOfEvenAndOddDigits(int number, int oddSum, int evenSum)
        {
            int result = 0;
          while (number != 0)
          {
                int currentNumber = number % 10;

                if (currentNumber % 2 == 0)
                {
                    evenSum += currentNumber;
                }
                else if (currentNumber % 2 != 0)
                {
                    oddSum += currentNumber;
                }
                number /= 10;

                result = oddSum * evenSum;
          }

            return result;
        }
    }
}
