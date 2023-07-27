using RobotService.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public abstract class Supplement : ISupplement
    {
        private int interfaceStrandart;
        private int batteryUsage;

        public Supplement(int interfaceStrandart, int batteryusage)
        {
            this.interfaceStrandart = interfaceStrandart;
            this.batteryUsage = batteryusage;
        }

        public int InterfaceStandard {get; private set;}

        public int BatteryUsage { get; private set; } 
    }
}
