using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumation = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower= horsePower;
            Fuel= fuel;
        }

        public int HorsePower { get; set; }

        public double Fuel { get; set; }

        public virtual double FuelConsumation => DefaultFuelConsumation;

        public virtual void Drive(double kilometers)
        => Fuel -= kilometers * FuelConsumation;
    }
}
