using System;

namespace _05.Salary
{
    internal class Salary
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());
            
            for (int i = 1; i <= n; i++)
            {
                string website = Console.ReadLine();
                
               if (website == "Facebook")
               {
                    salary -= 150;
               }
               else if (website == "Instagram")
               {
                    salary -= 100;
               }
               else if (website == "Reddit")
               {
                    salary -= 50;
               }
                
                if (salary <= 0)
                {
                    Console.WriteLine($"You have lost your salary.");
                    return; // Program ends here if salary is <= 0.
                }
            }
            Console.WriteLine($"{salary:f0}");
        }
    }
}
