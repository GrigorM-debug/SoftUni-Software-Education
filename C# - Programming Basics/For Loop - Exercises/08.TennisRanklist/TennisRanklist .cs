using System;

namespace _08.TennisRanklist
{
    internal class TennisRanklist
    {
        static void Main(string[] args)
        {
            int tournamentCnt = int.Parse(Console.ReadLine());
            int startingPoints = int.Parse(Console.ReadLine());

            double pointsForW = 0;
            double pointsForF = 0;
            double pointsForSF = 0;
            double winsNumber = 0;

            for (int i = 1; i <= tournamentCnt; i++)
            {
                string reachedTournamentStage = Console.ReadLine();

                if (reachedTournamentStage == "W")
                {
                    pointsForW += 2000;
                    winsNumber++;

                }
                else if (reachedTournamentStage == "F")
                {
                    pointsForF += 1200;
                }    
                else if (reachedTournamentStage == "SF")
                {
                    pointsForSF += 720;
                }
            }
            double totalPointsFromTournaments = pointsForW + pointsForF + pointsForSF;
            double totalPoints = startingPoints + totalPointsFromTournaments;
            double totalWinsNumber = winsNumber / tournamentCnt * 100;
            double averagePoints = Math.Floor(totalPointsFromTournaments / tournamentCnt);

            Console.WriteLine($"Final points: {totalPoints}");
            Console.WriteLine($"Average points: {averagePoints}");
            Console.WriteLine($"{totalWinsNumber:f2}%");
        }
    }
}
