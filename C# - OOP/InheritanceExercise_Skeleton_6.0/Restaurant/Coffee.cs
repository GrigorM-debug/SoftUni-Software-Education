using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double CoffeeMilliters = 50;
        private const decimal CoffeePrice = 3.50m;

        public Coffee(string name, decimal price, double milliliters, double caffeine) : base(name, price, milliliters)
        {
            Caffeine= caffeine;
        }

        public double Caffeine { get; private set; }
    }
}
