using System;
using System.Xml.Linq;

namespace _06.Oscars
{
    internal class Oscars
    {
        static void Main(string[] args)
        {
            string actorName = Console.ReadLine();
            double academiaPoints = double.Parse(Console.ReadLine());
            int judgeCnt = int.Parse(Console.ReadLine());
            bool cycleEnd = false;
            double sumPoints = academiaPoints;

            for (int i = 0; i < judgeCnt; i++)
            {
                string judgeName = Console.ReadLine();
                double judgePoints = double.Parse(Console.ReadLine());
                double momentsPoints = ((judgeName.Length * judgePoints) / 2);
                sumPoints = sumPoints + momentsPoints;

                if (sumPoints >= 1250.5)
                {
                    cycleEnd = true;
                    break;
                }
            }
            if (cycleEnd)
            {
                Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {sumPoints:F1}!");
            }
            else
            {
                Console.WriteLine($"Sorry, {actorName} you need {(1250.5 - sumPoints):F1} more!");
            }
        }
    }   
}
