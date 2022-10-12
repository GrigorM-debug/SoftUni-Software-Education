using System;
using System.Security.Principal;

namespace _06._World_Swimming_Record
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            double time1MInSeconds = double.Parse(Console.ReadLine());

            double ivanSwimmedDistanceInSeconds = distanceInMeters * time1MInSeconds;
            double slowTime = distanceInMeters / 15;
            slowTime = Math.Floor(slowTime);
            slowTime = slowTime * 12.5;

            ivanSwimmedDistanceInSeconds = ivanSwimmedDistanceInSeconds + slowTime;

            if (ivanSwimmedDistanceInSeconds >= recordInSeconds)
            {
                double timeDidntEnoughToBreakRec = ivanSwimmedDistanceInSeconds - recordInSeconds;
                Console.WriteLine($"No, he failed! He was {(ivanSwimmedDistanceInSeconds - recordInSeconds):f2} seconds slower.");

            }
            else
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {(ivanSwimmedDistanceInSeconds):f2} seconds.");
            }
        }
    }
}
