using System;
using System.Threading;

namespace _05.Darts
{
    internal class Darts
    {
        static void Main(string[] args)
        {
            int startingPoints = 301;

            string playerName = Console.ReadLine();
            int succesfullShootsCounter = 0;
            int failedShootsCounter = 0;

            while (startingPoints != 0)
            {
                string input = Console.ReadLine();

                if (input == "Retire")
                {
                   break;
                }

                int points = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case "Single":
                        if (points <= startingPoints)
                        {
                            startingPoints = startingPoints - points;
                            succesfullShootsCounter++;   
                        }
                        else
                        {
                            failedShootsCounter++;
                        }
                        break;
                    case "Double":
                        if (points * 2 <= startingPoints)
                        {
                            startingPoints = startingPoints - points * 2;
                            succesfullShootsCounter++;
                        }
                        else
                        {
                            failedShootsCounter++;
                        }
                        points = startingPoints - points;
                        break;
                    case "Triple":
                        if (points * 3 <= startingPoints)
                        {
                            startingPoints = startingPoints - points * 3;
                            succesfullShootsCounter++;
                        }
                        else
                        {
                            failedShootsCounter++;
                        }
                        points = startingPoints - points;
                        break;
                }
            }
            if (startingPoints == 0)
            {
                Console.WriteLine($"{playerName} won the leg with {succesfullShootsCounter} shots.");
            }
            else
            {
                Console.WriteLine($"{playerName} retired after {failedShootsCounter} unsuccessful shots.");
            }
        }
    }
}
