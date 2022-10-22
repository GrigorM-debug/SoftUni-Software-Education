using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace _09._Ski_Trip
{
    internal class SkiTrip
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string ocenka = Console.ReadLine();

            //Цени за помещения
            double roomForOnePerson = 18;
            double apartment = 25;
            double presidentApartment = 35;

            //Нощувки 
            days = days - 1;

            //Цена за различните помещения според нощувките
            double roomForOnePersonPrice = days * roomForOnePerson;
            double apartmentPrice = days * apartment;
            double presidentApartmentPrice = days * presidentApartment;

            //Намаления според броят на дните
            switch (roomType)
            {
                case "apartment":
                    if (days <= 10)
                    {
                        apartmentPrice = apartmentPrice - (apartmentPrice * 0.3);
                    }
                    else if (days > 10 && days <= 15)
                    {
                        apartmentPrice = apartmentPrice - (apartmentPrice * 0.35);
                    }
                    else if (days > 15)
                    {
                        apartmentPrice = apartmentPrice - (apartmentPrice * 0.5);
                    }
                    break;

                case "president apartment":
                    if (days <= 10)
                    {
                        presidentApartmentPrice = presidentApartmentPrice - (presidentApartmentPrice * 0.10);
                    }
                    else if (days > 10 && days <= 15)
                    {
                        presidentApartmentPrice = presidentApartmentPrice - (presidentApartmentPrice * 0.15);
                    }
                    else if (days > 15)
                    {
                        presidentApartmentPrice = presidentApartmentPrice - (presidentApartmentPrice * 0.2);
                    }
                    break;
            }

            //Намаление според оценката
            switch (ocenka)
            {
                case "positive":
                    if (roomType == "room for one person")
                    {
                        roomForOnePersonPrice = roomForOnePersonPrice + (roomForOnePersonPrice * 0.25);
                        Console.WriteLine($"{roomForOnePersonPrice:f2}");
                    }
                    else if (roomType == "apartment")
                    {
                        apartmentPrice = apartmentPrice + (apartmentPrice * 0.25);
                        Console.WriteLine($"{apartmentPrice:f2}");
                    }
                    else if (roomType == "preseident apartment")
                    {
                        presidentApartmentPrice = presidentApartmentPrice + (presidentApartmentPrice + 0.25);
                        Console.WriteLine($"{presidentApartmentPrice:f2}");
                    }
                    break;

                case "negative":
                    if (roomType == "room for one person")
                    {
                        roomForOnePersonPrice = roomForOnePersonPrice - (roomForOnePersonPrice * 0.10);
                        Console.WriteLine($"{roomForOnePersonPrice:f2}");
                    }
                    else if (roomType == "apartment")
                    {
                        apartmentPrice = apartmentPrice - (apartmentPrice * 0.10);
                        Console.WriteLine($"{apartmentPrice:f2}");
                    }
                    else if (roomType == "president apartment")
                    {
                        presidentApartmentPrice = presidentApartmentPrice - (presidentApartmentPrice * 0.10);
                        Console.WriteLine($"{presidentApartmentPrice:f2}");
                    }
                    break;
            }
        }
    }
}
