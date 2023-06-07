using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Reflection;

namespace _08.CarSalesman
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Car> cars = new();
            List<Engine> engines = new();

            int numberOfEngines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[0];
                int power = int.Parse(tokens[1]);

                Engine engine = new Engine(model, power);

                if (tokens.Length > 2)
                {
                    int displacement;

                    bool isDigit = int.TryParse(tokens[2], out displacement);

                    if (isDigit)
                    {
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        engine.Efficiency = tokens[2];
                    }

                    if (tokens.Length > 3)
                    {
                        engine.Efficiency = tokens[3];
                    }
                }

                engines.Add(engine);
            }

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i =0; i < numberOfCars; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                string engineModel = tokens[1];

                Engine engine = engines.Find(x => x.Model == engineModel);

                Car car = new(model, engine);

                if (tokens.Length > 2)
                {
                    int weight;

                    bool isDigit = int.TryParse(tokens[2], out weight);

                    if (isDigit)
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        car.Color = tokens[2];
                    }

                    if (tokens.Length > 3)
                    {
                        car.Color = tokens[3];
                    }
                }


                cars.Add(car);
            }
            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
