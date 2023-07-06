using Raiding.Core.Interfaces;
using Raiding.Factories.Interfaces;
using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly IHeroFactory heroFactory;

       private readonly ICollection<IHero> heroes;

        public Engine(IHeroFactory heroFactory, ICollection<IHero> heroes)
        {
            this.heroFactory = heroFactory;
            this.heroes = heroes;
        }

        public void Run()
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            while(numberOfInputs > 0)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                try
                {
                    heroes.Add(heroFactory.Create(heroType, heroName));
                    numberOfInputs--;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach(var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            int bossPower = int.Parse(Console.ReadLine());

            if(heroes.Sum(x=> x.Power) >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
