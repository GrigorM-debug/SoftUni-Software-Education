using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match_Tickets
{
    class Match_Tickets
    {
        static void Main(string[] args)
        {
            double Transport = 0;
            double VIP = 499.99;
            double Normal = 249.99;
            double Budget = double.Parse(Console.ReadLine());
            string Category = Console.ReadLine().ToLower();
            int НumberOfPeople = int.Parse(Console.ReadLine());
            if (НumberOfPeople >= 1 && НumberOfPeople < 5) Transport = 0.75 * Budget;
            else if (НumberOfPeople >= 5 && НumberOfPeople < 10) Transport = 0.6 * Budget;
            else if (НumberOfPeople >= 10 && НumberOfPeople < 25) Transport = 0.5 * Budget;
            else if (НumberOfPeople >= 25 && НumberOfPeople < 50) Transport = 0.4 * Budget;
            else if (НumberOfPeople >= 50) Transport = 0.25 * Budget;
            double RemainingMoney = Budget - Transport;
            double VipPrice = НumberOfPeople * VIP;
            double NormalPrice = НumberOfPeople * Normal;
            double VipTickets = RemainingMoney - VipPrice;
            double NormalTickets = RemainingMoney - NormalPrice;
            if (RemainingMoney >= VipPrice && Category == "vip")
                Console.WriteLine("Yes! You have {0:f2} leva left.", VipTickets);
            else if ((RemainingMoney >= NormalPrice && RemainingMoney < VipPrice && Category == "normal") ||
            (RemainingMoney >= VipPrice && Category == "normal"))
                Console.WriteLine("Yes! You have {0:f2} leva left.", NormalTickets);
            if (RemainingMoney < VipPrice && Category == "vip")
                Console.WriteLine("Not enough money! You need {0:f2} leva.", VipPrice - RemainingMoney);
            else if (RemainingMoney < NormalPrice && Category == "normal")
                Console.WriteLine("Not enough money! You need {0:f2} leva.", NormalPrice - RemainingMoney);
        }
    }
}