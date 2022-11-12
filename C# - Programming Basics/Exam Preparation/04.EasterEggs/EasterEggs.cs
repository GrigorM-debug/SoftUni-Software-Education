using System;

namespace _04.EasterEggs
{
    internal class EasterEggs
    {
        static void Main(string[] args)
        {
            int eggsCnt = int.Parse(Console.ReadLine());

            int redEggsCounter = 0;
            int orangeEggsCounter = 0;
            int blueEggsCounter = 0;
            int greenEggsCounter = 0;

            int maxColorCnt = int.MinValue;
            string maxColor = "";

            for (int i = 0; i <= eggsCnt; i++)
            {
                string eggsColor = Console.ReadLine();

                switch (eggsColor)
                {
                    case "red":
                        redEggsCounter++;
                        if (redEggsCounter > maxColorCnt)
                        {
                            maxColorCnt = redEggsCounter;
                            maxColor = eggsColor;
                        }
                        break;
                    case "orange":
                        orangeEggsCounter++;
                        if (orangeEggsCounter > maxColorCnt)
                        {
                            maxColorCnt = orangeEggsCounter;
                            maxColor = eggsColor;
                        }
                        break;
                    case "blue":
                        blueEggsCounter++;
                        if (blueEggsCounter > maxColorCnt)
                        {
                            maxColorCnt = blueEggsCounter;
                            maxColor = eggsColor;
                        }
                        break;
                    case "green":
                        greenEggsCounter++;
                        if (greenEggsCounter > maxColorCnt)
                        {
                            maxColorCnt = greenEggsCounter;
                            maxColor = eggsColor;
                        }
                        break;
                }
            }
            Console.WriteLine($"Red eggs: {redEggsCounter}");
            Console.WriteLine($"Orange eggs: {orangeEggsCounter}");
            Console.WriteLine($"Blue eggs: {blueEggsCounter}");
            Console.WriteLine($"Green eggs: {greenEggsCounter}");
            Console.WriteLine($"Max eggs: {maxColorCnt} -> {maxColor}");
        }
    }
}
