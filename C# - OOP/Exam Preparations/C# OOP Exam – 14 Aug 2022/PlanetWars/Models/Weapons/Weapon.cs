﻿using PlanetWars.Models.Weapons.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private int destructionLevel;

        protected Weapon(int destructionLevel, double price)
        {
            this.Price= price;
            this.DestructionLevel= destructionLevel;
        }

        public double Price {get; private set;}

        public int DestructionLevel
        {
            get => this.destructionLevel;
            private set
            {
                if(value < 1)
                {
                    throw new ArgumentException("Destruction level cannot be zero or negative.");
                }
                else if(value > 10)
                {
                    throw new ArgumentException("Destruction level cannot exceed 10 power points.");
                }

                this.destructionLevel = value;
            }
        }
    }
}
