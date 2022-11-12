using System;
using System.Transactions;

namespace _02.MovieDay
{
    internal class MovieDay
    {
        static void Main(string[] args)
        {
            int photoTime = int.Parse(Console.ReadLine());
            int sceneCnt = int.Parse(Console.ReadLine());
            int sceneTime = int.Parse(Console.ReadLine());

            double timeForPreparation = photoTime * 0.15;
            double timeForSceneFilming = sceneCnt * sceneTime;
            double totalTime = timeForPreparation + timeForSceneFilming;

            if(totalTime <= photoTime)
            {
                double timeLeft = photoTime - totalTime;
                Console.WriteLine($"You managed to finish the movie on time! You have {Math.Round(timeLeft)} minutes left!");
            }
            else
            {
                double timeNeeded = totalTime - photoTime;
                Console.WriteLine($"Time is up! To complete the movie you need {Math.Round(timeNeeded)} minutes.");
            }
           
        }
    }
}
