using System;
using System.Globalization;

namespace _03.SantasHoliday
{
    internal class SantasHoliday
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string typeOfRoom = Console.ReadLine();
            string mark = Console.ReadLine();
            double holidayPrice = 0;
            double nights = days - 1;

            switch (typeOfRoom)
            {
                case "room for one person":
                    holidayPrice = nights * 18.00;
                    if (mark == "positive")
                    {
                        holidayPrice = holidayPrice + holidayPrice * 0.25;
                    }
                    else if (mark == "negative")
                    {
                        holidayPrice = holidayPrice - holidayPrice * 0.10;
                    }
                    break;
                case "apartment":
                    holidayPrice = nights * 25.00;
                    if (days < 10)
                    {
                        holidayPrice = holidayPrice - holidayPrice * 0.30;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        holidayPrice = holidayPrice - holidayPrice * 0.35;
                    }
                    else if (days > 15)
                    {
                        holidayPrice = holidayPrice - holidayPrice * 0.50;
                    }
                    switch (mark)
                    {
                        case "positive":
                            holidayPrice = holidayPrice + holidayPrice * 0.25;
                            break;
                        case "negative":
                            holidayPrice = holidayPrice - holidayPrice * 0.10;
                            break;
                    }
                    break;
                case "president apartment":
                   holidayPrice = nights * 35.00;
                    if (days < 10)
                    {
                        holidayPrice = holidayPrice - holidayPrice * 0.10;
                    }
                    else if (days >= 10 && days <=15)
                    {
                        holidayPrice = holidayPrice - holidayPrice * 0.15;
                    }
                    else if (days > 15)
                    {
                        holidayPrice = holidayPrice - holidayPrice * 0.20;
                    }
                    switch (mark)
                    {
                        case "positive":
                            holidayPrice = holidayPrice + holidayPrice * 0.25;
                            break;
                        case "negative":
                            holidayPrice = holidayPrice - holidayPrice * 0.10;
                            break;
                    }
                    break;
            }
            Console.WriteLine($"{holidayPrice:f2}");
        }
    }
}
