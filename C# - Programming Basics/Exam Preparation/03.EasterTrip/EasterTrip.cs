using System;

namespace _03.EasterTrip
{
    internal class EasterTrip
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string holidayDate = Console.ReadLine();
            int overnightsCnt = int.Parse(Console.ReadLine());
            int overnightsPrice = 0;

            switch (destination)
            {
                case "France":
                    switch (holidayDate)
                    {
                        case "21-23":
                            overnightsPrice = 30;
                            break;
                        case "24-27":
                            overnightsPrice = 35;
                            break;
                        case "28-31":
                            overnightsPrice = 40;
                            break;
                    }
                    break;
                case "Italy":
                    switch (holidayDate)
                    {
                        case "21-23":
                            overnightsPrice = 28;
                            break;
                        case "24-27":
                            overnightsPrice = 32;
                            break;
                        case "28-31":
                            overnightsPrice = 39;
                            break;
                    }
                    break;
                case "Germany":
                    switch (holidayDate)
                    {
                        case "21-23":
                            overnightsPrice = 32;
                            break;
                        case "24-27":
                            overnightsPrice = 37;
                            break;
                        case "28-31":
                            overnightsPrice = 43;
                            break;
                    }
                    break;
            }
            int totalPrice = overnightsCnt * overnightsPrice;
            Console.WriteLine($"Easter trip to {destination} : {totalPrice:f2} leva.");
        }
    }
}
