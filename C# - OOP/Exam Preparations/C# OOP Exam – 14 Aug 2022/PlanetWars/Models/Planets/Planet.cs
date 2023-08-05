using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;

        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget= budget;
            this.Army = new ArmyRepository();
            this.Weapons = new WeaponRepository();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArithmeticException("Planet name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public double Budget
        {
            get => this.budget;
            private set
            {
                if(value < 0)
                {
                    throw new ArithmeticException("Budget's amount cannot be negative.");
                }

                this.budget = value;
            }
        }

        public double MilitaryPower => throw new NotImplementedException();

        public IReadOnlyCollection<IMilitaryUnit> Army { get; private set; }

        public IReadOnlyCollection<IWeapon> Weapons {get; private set; }

        public void AddUnit(IMilitaryUnit unit)
        {
            this.Army.A
        }

        public void AddWeapon(IWeapon weapon)
        {
            throw new NotImplementedException();
        }

        public string PlanetInfo()
        {
            throw new NotImplementedException();
        }

        public void Profit(double amount)
        {
            throw new NotImplementedException();
        }

        public void Spend(double amount)
        {
            throw new NotImplementedException();
        }

        public void TrainArmy()
        {
            throw new NotImplementedException();
        }
    }
}
