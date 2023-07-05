using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double increasedFuelConsumption;
        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapasity, double increasedFuelConsumption)
        {
            TankCapasity = tankCapasity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            this.increasedFuelConsumption = increasedFuelConsumption;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            private set
            {
                if (TankCapasity < value)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity= value;
                }
            }
        }

        public double FuelConsumption { get; private set; }

        public double TankCapasity
        { get; private set; }

        public string Drive(double distance, bool isIcreased = true)
        {
            // double consumption = isIcreased
            //? FuelConsumption + increasedFuelConsumption
            //: FuelConsumption;

            double consumption;
            if (isIcreased)
            {
                consumption = FuelConsumption + increasedFuelConsumption;
            }
            else
            {
                consumption = FuelConsumption;
            }

            if (FuelQuantity < distance * consumption)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }
            FuelQuantity -= distance * consumption;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double amount)
        {
            if(amount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if(amount + fuelQuantity > TankCapasity)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }

            FuelQuantity += amount;
        }
    }
}
