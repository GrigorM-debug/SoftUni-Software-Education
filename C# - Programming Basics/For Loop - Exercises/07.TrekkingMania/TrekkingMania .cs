using System;
using System.Diagnostics.Contracts;

namespace _07.TrekkingMania
{
    internal class TrekkingMania    
    {
        static void Main(string[] args)
        {
            int groupCnt = int.Parse(Console.ReadLine());
            int Musala = 0;
            int Montblanc = 0;
            int Kilimanjaro = 0;
            int K2 = 0;
            int Everest = 0;

            for (int i = 1; i <= groupCnt; i++)
            {
                int climbersCnt = int.Parse(Console.ReadLine());

                if (climbersCnt <= 5)
                {
                    Musala += climbersCnt;
                }
                else if (climbersCnt >= 6 && climbersCnt <= 12)
                {
                    Montblanc += climbersCnt;
                }
                else if (climbersCnt >= 13 && climbersCnt <= 25)
                {
                    Kilimanjaro += climbersCnt;
                }
                else if (climbersCnt >= 26 && climbersCnt <= 40)
                {
                    K2 += climbersCnt;
                }
                else if (climbersCnt >= 41)
                {
                    Everest += climbersCnt;
                }
            }
            double totalClimebersCnt = Musala + Montblanc + Kilimanjaro + K2 + Everest;
            double percentMusala = Musala / totalClimebersCnt * 100;
            double percentMontblanc = Montblanc / totalClimebersCnt * 100;  
            double percentKilimanjaro = Kilimanjaro / totalClimebersCnt * 100;  
            double percentK2 = K2 / totalClimebersCnt * 100;
            double percentEverest = Everest / totalClimebersCnt * 100;

            Console.WriteLine($"{percentMusala:f2}%");
            Console.WriteLine($"{percentMontblanc:f2}%");
            Console.WriteLine($"{percentKilimanjaro:f2}%");
            Console.WriteLine($"{percentK2:f2}%");
            Console.WriteLine($"{percentEverest:f2}%");
        }
    }
}
