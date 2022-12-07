using System;
using System.Diagnostics;
using System.Linq;

namespace _01.PipesInPool
{
    internal class PipesInPool
    {
        static void Main(string[] args)
        {
            double volume = double.Parse(Console.ReadLine());
            double p1 = double.Parse(Console.ReadLine()); 
            double p2 = double.Parse(Console.ReadLine()); 
            double h = double.Parse(Console.ReadLine());

            double totalLitters = p1 * h + p2 * h; 

            if (totalLitters <= volume)
            {
                double totalLittersInPercent = totalLitters / volume * 100;
                double p1Percent = p1 * h / totalLitters * 100;
                double p2Percent = p2 * h / totalLitters * 100;
                Console.WriteLine($"The poool is {totalLittersInPercent:F2}% full. Pipe 1 : {p1Percent:F2}%. Pipe 2: {p2Percent:F2}% liters.");
            }
            else if (totalLitters > volume)
            {
                totalLitters = totalLitters - volume;   
                Console.WriteLine($"For {h:F2} hours the pool overflows with {totalLitters:F2} liters.");
            }
        }
    }
}
