using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories.Models
{
    public class Dough
    {
        private const int BaseDoughCaloriesPerGram = 2;
        private readonly Dictionary<string, double> flourTypesCalories;
        private readonly Dictionary<string, double> bakingTechniqueCalories;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            flourTypesCalories = new Dictionary<string, double>{ { "white", 1.5 }, { "wholegrain", 1.0 } };

            bakingTechniqueCalories = new Dictionary<string, double> { { "crispy", 0.9 }, { "chewy", 1.1 }, { "homemade", 1.0 } };

            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public double Weight
        {
            get => weight;

            private set
            {
                if(value < 0 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        public string FlourType
        {
            get => flourType;
            private set
            {
                if (!flourTypesCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flourType = value.ToLower();
            }
        }

        public string BakingTechnique
        {
            get => bakingTechnique;
            private set
            {
                if (!bakingTechniqueCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Incalid type of dough.");
                }

                this.bakingTechnique = value.ToLower();
            }
        }

        public double Calories
        {
            get
            {
                double flourTypeModifier = bakingTechniqueCalories[BakingTechnique];
                double techniqueModifier = flourTypesCalories[FlourType];

                return BaseDoughCaloriesPerGram * weight * flourTypeModifier * techniqueModifier;
            }
        }
    }
}
