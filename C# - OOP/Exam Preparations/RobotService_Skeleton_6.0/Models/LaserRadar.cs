using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class LaserRadar : Supplement
    {
        private const int LazerRadarInterfaceStrandart = 20082;
        private const int LazerRadarBatteryUsage = 5000;

        public LaserRadar() : base(LazerRadarInterfaceStrandart, LazerRadarBatteryUsage)
        {
        }
    }
}
