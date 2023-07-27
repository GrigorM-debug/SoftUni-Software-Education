using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public abstract class Vehicle : IVehicle
    {
        private string brand;
        private string model;
        private double maxMileage;
        private string licensePlateNumber;
        private int batteryLevel;
        private bool isDamaged;

        protected Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            this.Brand = brand;
            this.Model = model;
            this.MaxMileage = maxMileage;
            this.LicensePlateNumber = licensePlateNumber;
            this.BatteryLevel = 100;
            this.IsDamaged = false;
        }

        public string Brand
        {
            get => this.brand;
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandNull);
                }
                this.brand = value;
            }
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNull);
                }
                this.model = value;
            }
        }

        public double MaxMileage
        {
            get => this.maxMileage;
            private set
            {
                this.maxMileage = value;
            }
        }

        public string LicensePlateNumber
        {
            get => this.licensePlateNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LicenceNumberRequired);
                }
                this.licensePlateNumber = value;
            }
        }

        public int BatteryLevel
        {
            get => this.batteryLevel;
            private set
            {
                batteryLevel = value;
            }
        }

        public bool IsDamaged
        {
            get=> this.isDamaged;   
            private set
            {
                isDamaged = value;
            }
        }

        public void ChangeStatus()
        {
            if(this.IsDamaged == true)
            {
                this.IsDamaged = false;
            }

            this.IsDamaged = true;
        }

        public void Drive(double mileage)
        {
            this.BatteryLevel -= (int)Math.Round(mileage / MaxMileage * 100);

            if(this.GetType() == typeof(CargoVan))
            {
                this.BatteryLevel -= 5;
            }
        }

        public void Recharge()
        {
            this.BatteryLevel = 100;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: {(IsDamaged ? "damaged" : "OK")}");
           ////if(IsDamaged)
           //// {
           ////     sb.Append("damaged");
           //// }
           //// else
           //// {
           ////     sb.Append("OK");
           //// }

            return sb.ToString().TrimEnd();
        }
    }
}
