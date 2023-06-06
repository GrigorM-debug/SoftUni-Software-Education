using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SpeedRacing
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }


        public void Drive(string carModel, double amountOfKm)
        {
            if (amountOfKm * FuelConsumptionPerKilometer > FuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                FuelAmount -= amountOfKm * FuelConsumptionPerKilometer;
                TravelledDistance += amountOfKm;
            }
        }
    }
}
