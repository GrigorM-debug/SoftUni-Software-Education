using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParking
{
    public class Parking
    {
        private Dictionary<string, Car> cars;
        private int capasity;

        public Parking(int capasity)
        {
            this.capasity = capasity;
            cars = new Dictionary<string, Car>();
        }

        public int Count { get { return this.cars.Count; } }

        public string AddCar(Car car) 
        { 
            if (cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (Count == capasity)
            {
                return "Parking is full!";
            }

            this.cars.Add(car.RegistrationNumber, car);

            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public Car GetCar(string registrationNumber)
        {
            return cars[registrationNumber];
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!cars.ContainsKey(registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }

            cars.Remove(registrationNumber);

            return $"Successfully removed {registrationNumber}";
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var RegistrationNumber in registrationNumbers) 
            {
                RemoveCar(RegistrationNumber);
            }
        }
    }
}
//It's score 92/100 in judge. I dont know where i have mistakes. It takes me 3 days to get 92. I hate this task. The code part is easy but judge has some strange tests.