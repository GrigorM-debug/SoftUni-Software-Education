using _06.SpeedRacing;
using System;
using System.Collections.Generic;

namespace SpeedRacing;

public class StartUp
{
    static void Main(string[] args)
    {
        Dictionary<string, Car> carsByNames = new();

        int numberOfInputs = int.Parse(Console.ReadLine());

        for (int i =0; i < numberOfInputs; i++)
        {
            string[] carArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string carModel = carArgs[0];
            double fuelAmount = double.Parse(carArgs[1]);
            double fuelConsumptionPerKilometer = double.Parse(carArgs[2]);

            Car car = new Car()
            {
                Model= carModel,
                FuelAmount= fuelAmount,
                FuelConsumptionPerKilometer = fuelConsumptionPerKilometer,
            };

            carsByNames.Add(carModel, car);
        }

        string input;
        while((input = Console.ReadLine()) != "End")
        {
            string[] commandArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string carModel = commandArgs[1];
            double amountOfKm = double.Parse(commandArgs[2]);

            Car car = carsByNames[carModel];

            car.Drive(carModel, amountOfKm);
        }

        foreach (var car in carsByNames.Values)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount} {car.TravelledDistance}");
        }
    }
}