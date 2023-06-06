﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParking
{
    public class Parking
    {
        public Dictionary<string, Car> cars;
        public int capasity;

        public Parking(int capasity)
        {
            this.capasity= capasity;
            cars = new Dictionary<string, Car>();
        }

        public int Count { get { return this.cars.Count; } }

        public string AddCar(Car car) 
        { 
            if (cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (cars.Count == capasity)
            {
                return "Parking is full!";
            }

            this.cars.Add(car.RegistrationNumber, car);

            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
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

        public Car GetCar(string registrationNumber)
        {
            return cars[registrationNumber];
        }

        public void RemoveSetOfRegistrationNumbers(List<string> registrationNumbers)
        {
            foreach (var registrationNumber in registrationNumbers) 
            {
                RemoveCar(registrationNumber);
            }
        }
    }
}
