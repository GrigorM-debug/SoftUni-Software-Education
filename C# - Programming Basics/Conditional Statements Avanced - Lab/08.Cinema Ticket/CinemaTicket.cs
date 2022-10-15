using System;

namespace _08.Cinema_Ticket
{
    internal class CinemaTicket
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            double ticketPrice = 0.0;

            switch (day)
            {
                case "Monday":
                    ticketPrice = 12;
                    break;
                case "Tuesday":
                    ticketPrice = 12;
                    break;
                case "Wednesday":
                    ticketPrice = 14;
                    break;
                case "Thursday":
                    ticketPrice = 14;
                    break;
                case "Friday":
                    ticketPrice = 12;
                    break;
                case "Saturday":
                    ticketPrice = 16;
                    break;
                case "Sunday":
                    ticketPrice = 16;
                    break;
            }
            Console.WriteLine(ticketPrice);
        }
    }
}
