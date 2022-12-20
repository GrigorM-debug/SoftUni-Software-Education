using System;

namespace _03.Flowers
{
    internal class Flowers
    {
        static void Main(string[] args)
        {
            var hrizantemi = int.Parse(Console.ReadLine());
            var rozi = int.Parse(Console.ReadLine());
            var laleta = int.Parse(Console.ReadLine());
            var season = Console.ReadLine();
            var holiday = Console.ReadLine();
            double hrprice = 0, roprice = 0, laprice = 0;//, totalprice = 1;
            if (season == "Spring" || season == "Summer")
            {
                hrprice = 2 * hrizantemi;
                roprice = 4.1 * rozi;
                laprice = 2.5 * laleta;
            }
            if (season == "Autumn" || season == "Winter")
            {
                hrprice = 3.75 * hrizantemi;
                roprice = 4.5 * rozi;
                laprice = 4.15 * laleta;
            }
            double totalprice = hrprice + roprice + laprice;
            //if (holiday == "N")
            //{
            //    totalprice = hrizantemi * hrprice + rozi * roprice + laleta * laprice;
            //}
            if (laleta > 7 && season == "Spring")
            {
                totalprice *= 0.95;//= totalprice - totalprice * 5 / 100;
            }
            if ((rozi >= 10) && (season == "Winter"))
            {
                totalprice *= 0.90;//= totalprice - totalprice * 10 / 100;
            }
            if (holiday == "Y")
            {
                totalprice *= 1.15;//= (hrizantemi * hrprice + rozi * roprice + laleta * laprice) * 1.15;
                                   // + ((hrizantemi * hrprice + rozi * roprice + laleta * laprice) * 15 / 100);
            }
            if (rozi + laleta + hrizantemi >= 20)
            {
                totalprice *= 0.80;//= totalprice - totalprice * 20 / 100;
            }
            Console.WriteLine(string.Format("{0:f2}", totalprice + 2));
            Console.ReadLine();
        }
    }
}
