using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories.Models
{
    public class Topping
    {
        private const int BaseToppingCalorirsPerGram = 2;
        private readonly Dictionary<string, double> toppingTypesCalories;

        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            toppingTypesCalories = new Dictionary<string, double> { { "meat", 1.2 }, { "veggies", 0.8 }, { "cheese", 1.1 }, { "sauce", 0.9 } };

            Type = type;
            Weight = weight;
        }

        public string Type
        {
            get => type;

            set
            {
                if(!toppingTypesCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                type = value;
            }
        }

        public double Weight
        {
            get=> weight;

            set
            {
                if(value < 1 || value > 50)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }

                weight= value;
            }
        }

        public double Calories
        {
            get
            {
                double toppintModifier = toppingTypesCalories[Type.ToLower()];

                return BaseToppingCalorirsPerGram * Weight * toppintModifier;
            }
        }
    }
}
