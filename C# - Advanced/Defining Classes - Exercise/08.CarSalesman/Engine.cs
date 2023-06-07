using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace _08.CarSalesman
{
    public class Engine
    {
        public Engine(string model, int power) 
        { 
            Model = model;
            Power = power;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }


        public override string ToString()
        {
            string displacement;
            string efficiency;

            if (Displacement == 0)
            {
                displacement = "n/a";
            }
            else
            {
                displacement = Displacement.ToString();
            }

            if (Efficiency == null)
            {
                efficiency = "n/a";
            }
            else
            {
                efficiency = Efficiency;
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Model}:");
            sb.AppendLine($"    Power: {Power}");
            sb.AppendLine($"    Displacement: {displacement}");
            sb.AppendLine($"    Efficiency: {efficiency}");

            return sb.ToString().TrimEnd();
        }
    }
}
