using System;

namespace _07._Hotel_Room
{
    internal class HotelRoom
    {
        static void Main(string[] args)
        {
            string mounth = Console.ReadLine();
            int overnightStaysCnt = int.Parse(Console.ReadLine());
            decimal studioPrice = 0;
            decimal studioDiscount = 0.00M;
            decimal apartmentPrice = 0.00M;
            decimal apartmentDiscount = 0.10M;

            switch (mounth)
            {
                case "May":
                case "October":
                    if (overnightStaysCnt <= 7)
                    {
                        studioPrice = 50M * overnightStaysCnt;
                        apartmentPrice = 65M* overnightStaysCnt;
                    }
                    else if (overnightStaysCnt > 7 && overnightStaysCnt <= 14)
                    {
                        studioPrice = 50M * overnightStaysCnt;
                        apartmentPrice = 65M * overnightStaysCnt;
                        studioDiscount = 0.05M;
                        studioPrice = studioPrice - (studioPrice * studioDiscount);
                    }   
                    else if (overnightStaysCnt > 14)
                    {
                        studioPrice = 50M * overnightStaysCnt;
                        studioDiscount = 0.30M;
                        studioPrice = studioPrice - (studioPrice * studioDiscount);
                        apartmentPrice = 65M * overnightStaysCnt;
                        apartmentPrice = apartmentPrice - (apartmentPrice * apartmentDiscount);
                    }   
                    break;
                case "June":
                case "September":
                    if (overnightStaysCnt <= 7)
                    {
                        studioPrice = 75.20M * overnightStaysCnt;
                        apartmentPrice = 68.70M * overnightStaysCnt;
                    }
                    else if (overnightStaysCnt > 7 && overnightStaysCnt <= 14)
                    {
                        studioPrice = 75.20M * overnightStaysCnt;
                        apartmentPrice = 68.70M * overnightStaysCnt;
                    }
                    else if (overnightStaysCnt > 14)
                    {
                        studioPrice = 75.20M * overnightStaysCnt;
                        apartmentPrice = 68.70M * overnightStaysCnt;
                        studioDiscount = 0.20M;
                        studioPrice = studioPrice - (studioPrice * studioDiscount);
                        apartmentPrice = apartmentPrice - (apartmentPrice * apartmentDiscount);
                    }
                    break;
                case "July":
                case "August":
                    if (overnightStaysCnt <= 7)
                    {
                        studioPrice = 76M * overnightStaysCnt;
                        apartmentPrice = 77M * overnightStaysCnt;
                    }
                    else if (overnightStaysCnt > 7 && overnightStaysCnt <= 14)
                    {
                        studioPrice = 76M * overnightStaysCnt;
                        apartmentPrice = 77M * overnightStaysCnt;
                    }
                    else if (overnightStaysCnt > 14)
                    {
                        studioPrice = 76M * overnightStaysCnt;
                        apartmentPrice = 77M * overnightStaysCnt;
                        apartmentPrice = apartmentPrice - (apartmentPrice * apartmentDiscount);
                    }
                    break;
            }
            Console.WriteLine($"Apartment: {apartmentPrice:F2} lv.");
            Console.WriteLine($"Studio: {studioPrice:F2} lv.");
        }
    }
}
