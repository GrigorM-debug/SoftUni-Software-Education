using System;

namespace _04.TrainTheTrainers
{
    internal class TrainTheTrainers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            //double prezentationEV = 0;

            int prezentionnum = 0;

            double evaluetion = 0;

            string prezeteishenname;

            while (input != "Finish") // Finish !!!

            {

                double prezentationEV = 0; // must be set to 0 inside of while loop

                prezeteishenname = input;

                for (int i = 1; i <= n; i++)

                {

                    prezentationEV += double.Parse(Console.ReadLine());

                }

                prezentationEV = prezentationEV / n;

                evaluetion += prezentationEV;



                Console.WriteLine($"{prezeteishenname} - {prezentationEV:F2}.");

                prezentionnum++;

                input = Console.ReadLine();



            }



            Console.WriteLine($"Student's final assessment is {evaluetion / prezentionnum:F2}.");

        }
    }
}
