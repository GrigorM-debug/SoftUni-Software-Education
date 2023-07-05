using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Core.Interfaces;
using Vehicles.Models;
using Vehicles.Models.Interfaces;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            string[] carTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] truckTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] busTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double carFuelQuantity = double.Parse(carTokens[1]);
            double carFuelConsumption = double.Parse(carTokens[2]);
            double carTankCapasity = double.Parse(carTokens[3]);
            IVehicle car = new Car(carFuelQuantity, carFuelConsumption, carTankCapasity);

            double truckFuelQuantity = double.Parse(truckTokens[1]);
            double truckFuelConsumption = double.Parse(truckTokens[2]);
            double truckTankCapasity = double.Parse(truckTokens[3]);
            IVehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapasity);

            double busFuelQuantity = double.Parse(busTokens[1]);
            double busFuelConsumption = double.Parse(busTokens[2]);
            double busTankCapasity = double.Parse(busTokens[3]);
            IVehicle bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapasity);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] commandTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    if (commandTokens[1] == "Car")
                    {
                        if (commandTokens[0] == "Drive")
                        {
                            double distance = double.Parse(commandTokens[2]);

                            Console.WriteLine(car.Drive(distance));
                        }
                        else if (commandTokens[0] == "Refuel")
                        {
                            double amount = double.Parse(commandTokens[2]);

                            car.Refuel(amount);
                        }
                    }
                    else if (commandTokens[1] == "Truck")
                    {
                        if (commandTokens[0] == "Drive")
                        {
                            double distance = double.Parse(commandTokens[2]);

                            Console.WriteLine(truck.Drive(distance));
                        }
                        else if (commandTokens[0] == "Refuel")
                        {
                            double amount = double.Parse(commandTokens[2]);

                            truck.Refuel(amount);
                        }
                    }
                    else if (commandTokens[1] == "Bus")
                    {
                        if (commandTokens[0] == "Drive")
                        {
                            double distance = double.Parse(commandTokens[2]);

                            Console.WriteLine(bus.Drive(distance)) ;
                        }
                        else if (commandTokens[0] == "DriveEmpty") 
                        {
                            double distance = double.Parse(commandTokens[2]);

                            Console.WriteLine(bus.Drive(distance, false));
                        }
                        else if (commandTokens[0] == "Refuel")
                        {
                            double fuel = double.Parse(commandTokens[2]);

                            bus.Refuel(fuel);
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
