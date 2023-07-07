using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models.Interfaces
{
    internal interface IAnimal
    {
        public string Name { get; }

        public double Weight { get; }

        public int FoodEaten { get; }
    }
}
