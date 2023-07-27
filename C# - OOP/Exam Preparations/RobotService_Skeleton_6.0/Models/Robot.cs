using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        private string model;
        private int batteryCapacity;
        private int batteryLevel;
        private int convertionCapacityIndex;
        private List<int> interfaceStandarts;

        public Robot(string model, int batteryCapacity, int convertionCapacityIndex)
        {
            this.model = model;
            this.batteryCapacity = batteryCapacity;
            this.batteryLevel = batteryCapacity;
            this.convertionCapacityIndex = convertionCapacityIndex;
            this.interfaceStandarts = new List<int>();
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ModelNullOrWhitespace));
                }

                this.model = value;
            }
        }

        public int BatteryCapacity
        {
            get=> this.batteryCapacity;
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.BatteryCapacityBelowZero));
                }

                this.batteryCapacity = value;
            }
        }

        public int BatteryLevel => this.batteryLevel;

        public int ConvertionCapacityIndex => this.convertionCapacityIndex;

        public IReadOnlyCollection<int> InterfaceStandards =>this.interfaceStandarts;

        public virtual void Eating(int minutes)
        {
            int producedEnergy = ConvertionCapacityIndex * minutes;

            if(producedEnergy > BatteryCapacity - BatteryLevel)
            {
                batteryLevel = batteryCapacity;
            }

            batteryLevel += producedEnergy;
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if(batteryLevel >= consumedEnergy)
            {
                this.batteryLevel -= consumedEnergy;
                return true;
            }
            return false;
        }

        public void InstallSupplement(ISupplement supplement)
        {
            this.BatteryCapacity -= supplement.BatteryUsage;
            this.batteryLevel -= supplement.BatteryUsage;

            this.interfaceStandarts.Add(supplement.InterfaceStandard);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name} {this.Model}");
            sb.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            sb.AppendLine($"--Current battery level: {BatteryLevel}");
            sb.AppendLine($"--Supplements installed: ");

            if(this.interfaceStandarts.Count == 0)
            {
                sb.Append("none.");
            }
            else
            {
                sb.Append(string.Join(" ", this.interfaceStandarts));
            }

            return sb.ToString().TrimEnd();
        }
    }
}
