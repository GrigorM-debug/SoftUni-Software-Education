using System;

namespace _07._Shopping
{
    internal class Shopping
    {
        static void Main(string[] args)
        {
            double budged = double.Parse(Console.ReadLine());
            double gpuCnt = double.Parse(Console.ReadLine());   
            double cpuCnt = double.Parse(Console.ReadLine());
            double ramCnt = double.Parse(Console.ReadLine());

            double oneGPUPrice = 250;
            double gpuSum = gpuCnt * oneGPUPrice;
            double cpuPrice = gpuSum * 0.35;
            double cpuSum = cpuCnt * cpuPrice;
            double ramPrice = gpuSum * 0.10;
            double ramSum = ramCnt * ramPrice;
            double totalSum = gpuSum + cpuSum + ramSum;

            if (gpuCnt > cpuCnt)
            {
                totalSum = totalSum - totalSum * 0.15;
            }
            if (budged >= totalSum)
            {
                double moneyLeft = budged - totalSum;
                Console.WriteLine($"You have {moneyLeft:f2} leva left!");
            }
            else if (totalSum > budged)
            {
                double moneyNeeded = totalSum - budged;
                Console.WriteLine($"Not enough money! You need {moneyNeeded:f2} leva more!");
            }

        }
    }
}
