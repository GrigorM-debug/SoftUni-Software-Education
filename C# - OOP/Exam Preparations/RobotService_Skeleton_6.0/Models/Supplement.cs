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
        //private int interfaceStrandart;
        //private int batteryUsage;

        protected Supplement(int interfaceStrandart, int batteryusage)
        {
            this.InterfaceStandard = interfaceStrandart;
            this.BatteryUsage = batteryusage;
        }

        public int InterfaceStandard { get; private set; }

        public int BatteryUsage { get; private set; }
    }
}
