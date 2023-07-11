using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight, int foodEaten)
        {
            Name = name;
            Weight = weight;
            FoodEaten = foodEaten;
        }

        public string Name { get; private set; }

        public double Weight {get; private set; }

        public int FoodEaten {get; private set; }

        protected abstract double WeighMultiplier { get;  }

        protected abstract ICollection<Type> PreferredFoodTypes { get; }

        public abstract string ProduceSound();

        public void Eat(IFood food)
        {

        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, ";
        }
    }
}
