using System;

namespace _04.Walking
{
    internal class Walking
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int stepsGoal = 10000;
            int steps = 0;

            while (input != "Going home")
            {
                steps += int.Parse(input);

                if (steps >= 10000)
                {
                    break;
                }
                input = Console.ReadLine();
            }
            if (input == "Going home")
            {
                input = Console.ReadLine();
                steps += int.Parse(input);
            }

            if (steps < stepsGoal)
            {
                int stepsNeeded = stepsGoal - steps;
                Console.WriteLine($"{stepsNeeded} more steps to reach goal.");
            }
            else
            {
                int stepsOver = steps - stepsGoal;
                Console.WriteLine($"Goal reached! Good job!");
                Console.WriteLine($"{stepsOver} steps over the goal!");
            }
        }
    }
}
