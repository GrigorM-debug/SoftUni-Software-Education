using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Facade
{
    public class CarInfoBuilder : CarBuilderFacade
    {
        public CarInfoBuilder(Car car)
        {
            this.Car = car;
        }

        public CarInfoBuilder WithType(string type)
        {
            Car.Type = type;
            return this;
        }

        public CarInfoBuilder WithColor(string color)
        {
            Car.Color = color;
            return this;
        }

        public CarInfoBuilder WithNumberOfDoors(int numberOfDoors)
        {
            Car.NumberOfDoors = numberOfDoors;
            return this;
        }
    }
}
