using System;
using System.Runtime.CompilerServices;

namespace _05._Supplies_for_School
{
    internal class SupliesForSchool
    {
        static void Main(string[] args)
        {
            //Вход 
            int numberPacketsChemicals = int.Parse(Console.ReadLine());
            int numberPacketsMarkers = int.Parse(Console.ReadLine());
            int littersDeskCleaner = int.Parse(Console.ReadLine());
            double percentDiscount = double.Parse(Console.ReadLine());
            percentDiscount = percentDiscount / 100;
            //Цени 
            double chemicalsOnePacketPrice = 5.80;
            double markersOnePacketPrice = 7.20;
            double deskCleanerOneLitterPrice = 1.20;
            //Изчисления
            double chemicalsPrice = numberPacketsChemicals * chemicalsOnePacketPrice;
            double markersPrice = numberPacketsMarkers * markersOnePacketPrice;
            double deskCleanerPrice = littersDeskCleaner * deskCleanerOneLitterPrice;
            double totalPrice = chemicalsPrice + markersPrice + deskCleanerPrice;
            double priceWithDiscount = totalPrice * percentDiscount;
            priceWithDiscount = totalPrice - priceWithDiscount;
            //Изход
            Console.WriteLine(priceWithDiscount);



        }
    }
}
