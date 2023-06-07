using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine) 
        { 
            Model= model;
            Engine= engine;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            string weight;
            string color;
            if (Weight == 0)
            {
                weight = "n/a";
            }
            else
            {
                weight = Weight.ToString();
            }

            if (Color == null)
            {
                color = "n/a";
            }
            else
            {
                color = Color;
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Model}:");
            sb.AppendLine($"  {Engine.ToString()}");
            sb.AppendLine($"  Weight: {weight}");
            sb.AppendLine($"  Color: {color}");

            return sb.ToString().TrimEnd();
        }
    }
}
