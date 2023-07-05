using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double IncreasedFuelConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapasity) : base(fuelQuantity, fuelConsumption, tankCapasity, IncreasedFuelConsumption)
        {
        }

        public override void Refuel(double amount)
        {
            if (amount + FuelQuantity > TankCapasity)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }
            base.Refuel(amount * 0.95);
        }
    }
}
