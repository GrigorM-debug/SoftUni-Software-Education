using System;

namespace _07._Projects_Creation
{
    internal class ProjectsCreation
    {
        static void Main(string[] args)
        {
            string architectName = Console.ReadLine();
            int projectNumber = int.Parse(Console.ReadLine());
            int timeForOneProject = 3;
            int timeForProject = projectNumber * timeForOneProject;
            Console.WriteLine($"The architect {architectName} will need {timeForProject} hours to complete {projectNumber} project/s.");
        }
    }
}
