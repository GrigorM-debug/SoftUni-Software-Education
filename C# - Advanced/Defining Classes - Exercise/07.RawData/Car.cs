using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.RawData
{
    public class Car
    {
        public Car(
            string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, double tyre1Pressure, int tyre1Age, double tyre2Pressure, int tyre2Age, double tyre3Pressure, int tyre3Age, double tyre4Pressure, int tyre4Age
            ) 
        {
            Model = model;
            Engine = new(engineSpeed, enginePower);
            Cargo = new(cargoWeight, cargoType);
            Tyres = new Tyres[4];
            Tyres[0] = new (tyre1Pressure, tyre1Age);
            Tyres[1] = new Tyres(tyre2Pressure, tyre2Age);
            Tyres[2] = new Tyres(tyre3Pressure, tyre3Age);
            Tyres[3] = new Tyres(tyre4Pressure, tyre4Age);
        }    
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tyres[] Tyres { get; set; }
    }
}
