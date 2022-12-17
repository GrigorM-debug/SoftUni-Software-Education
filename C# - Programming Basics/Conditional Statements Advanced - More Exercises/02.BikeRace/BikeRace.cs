using System;
using System.Diagnostics;

namespace _02.BikeRace
{
    internal class BikeRace
    {
        static void Main(string[] args)
        {
            var juniors = int.Parse(Console.ReadLine());
            var seniors = int.Parse(Console.ReadLine());
            var trace = Console.ReadLine();
            var taxes = 0.0;


            if (trace == "trail")
            {
                taxes = (juniors * 5.5) + (seniors * 7) - (0.05 * ((juniors * 5.5) + (seniors * 7)));

            }
            else if (trace == "downhill")
            {
                taxes = (juniors * 12.25) + (seniors * 13.75) - (0.05 * ((juniors * 12.25) + (seniors * 13.75)));
            }
            else if (trace == "road")
            {
                taxes = (juniors * 20) + (seniors * 21.5) - (0.05 * ((juniors * 20) + (seniors * 21.5)));
            }
            else if (trace == "cross-country" && ((juniors + seniors) < 50))
            {
                taxes = ((juniors * 8) + (seniors * 9.5) - (0.05 * ((juniors * 8) + (seniors * 9.5))));
            }
            else if (trace == "cross-country" && ((juniors + seniors) >= 50))
            {
                taxes = ((juniors * 6) + (seniors * 7.125)) - (0.05 * ((juniors * 6) + (seniors * 7.125))); //Тук ми е грешката!!!
            }
            Console.WriteLine("{0:f2}", taxes);
        }
    }
}
