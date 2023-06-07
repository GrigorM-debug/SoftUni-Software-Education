using _07.RawData;
using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Reflection;

namespace _07.RawData
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int numberOfInputs = int.Parse(Console.ReadLine());

            for(int i = 0; i< numberOfInputs; i++)
            {
                string[] carArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string model = carArgs[0];
                int engineSpeed = int.Parse(carArgs[1]);
                int enginePower = int.Parse(carArgs[2]);
                int cargoWeight = int.Parse(carArgs[3]);
                string cargoType = carArgs[4];
                double tyre1Pressure = double.Parse(carArgs[5]);
                int tyre1Age = int.Parse(carArgs[6]);
                double tyre2Pressure = double.Parse(carArgs[7]);
                int tyre2Age = int.Parse(carArgs[8]);
                double tyre3Pressure = double.Parse(carArgs[9]);
                int tyre3Age = int.Parse(carArgs[10]);
                double tyre4Pressure = double.Parse(carArgs[11]);
                int tyre4Age = int.Parse(carArgs[12]);

                Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tyre1Pressure, tyre1Age, tyre2Pressure, tyre2Age, tyre3Pressure, tyre3Age, tyre4Pressure, tyre4Age);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            string[] carsToPrint = null;

            if(command == "fragile")
            {
                carsToPrint = cars.Where(c => c.Cargo.Type == "fragile" && c.Tyres.Any(t => t.Pressure < 1)).Select(c => c.Model).ToArray();
            }
            else if(command== "flammable")
            {
                carsToPrint = cars.Where(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250).Select(c => c.Model).ToArray();
            }


            Console.WriteLine(string.Join(Environment.NewLine, carsToPrint));
        }
    }
}
