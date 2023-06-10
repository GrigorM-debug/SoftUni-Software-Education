using CarManufacturer;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            //var tires = new Tire[4]
            //{
            //    new Tire (1, 2.5),
            //    new Tire (1, 2.1),
            //    new Tire (2, 0.5),
            //    new Tire (2, 2.3),
            //};

            //var engine = new Engine(560, 6300);

            //var car = new Car("Lamborghini", "Urus", 2010, 250, 9, engine, tires);

            //string make = Console.ReadLine();
            //string model = Console.ReadLine();
            //int year = int.Parse(Console.ReadLine());
            //double fuelQuantity = double.Parse(Console.ReadLine());
            //double fuelConsumption = double.Parse(Console.ReadLine());

            //Car firstCar = new Car();
            //Car secondCar = new Car(make, model, year);
            //Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);
            List<List<Tire>> listOfTires = new List<List<Tire>>();
            List<Engine> listOfEngines = new List<Engine>();
            List<Car> listOfCars = new List<Car>();

            string commandForTires;
            while ((commandForTires = Console.ReadLine()) != "No more tires")
            {
                List<Tire> tempListOfTires = new List<Tire>();
                string[] tireTokens = commandForTires.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int year = int.Parse(tireTokens[0]);
                double pressure = double.Parse(tireTokens[1]);

                tempListOfTires.Add(new Tire(year, pressure));

                listOfTires.Add(tempListOfTires);
            }

            string commandForEngines;
            while ((commandForEngines = Console.ReadLine()) != "Engines done")
            {
                string[] enginesTokens = commandForEngines.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int horsePower = int.Parse(enginesTokens[0]);
                double cubicCapacity = double.Parse(enginesTokens[1]);

                listOfEngines.Add(new Engine(horsePower, cubicCapacity));
            }

            string commandForCars;
            while ((commandForCars = Console.ReadLine()) != "Show special")
            {
                string[] carsTokens = commandForCars.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = carsTokens[0];
                string model = carsTokens[1];
                int year = int.Parse(carsTokens[2]);
                double fuelQuantity = double.Parse(carsTokens[3]);
                double fuelConsumption = double.Parse(carsTokens[4]);
                int engineIndex = int.Parse(carsTokens[5]);
                int tiresIndex = int.Parse(carsTokens[6]);

                Engine engine = listOfEngines.ElementAtOrDefault(engineIndex);
                List<Tire> tires = listOfTires.ElementAtOrDefault(tiresIndex);

                if (engine != null && tires != null)
                {
                    Car newCar = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tires.ToArray());
                    listOfCars.Add(newCar);
                }
            }

            foreach (var car in listOfCars)
            {
                double tirePressureSum = car.Tires.Take(4).Sum(tire => tire.Pressure);  // Sum pressures for the first set of tires

                if (car.Year >= 2017 && car.Engine != null && car.Engine.HorsePower > 300 && tirePressureSum >= 9 && tirePressureSum <= 10)
                {
                    car.Drive(20);

                    Console.WriteLine(car.WhoAmI());
                    return; // Exit the loop after printing the first matching car
                }
            }

        }
    }
}