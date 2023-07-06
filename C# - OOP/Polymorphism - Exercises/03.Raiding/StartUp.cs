using Raiding.Core;
using Raiding.Core.Interfaces;
using Raiding.Factories.Interfaces;
using Raiding.Factories;
using Raiding.Models.Interfaces;

namespace Raiding
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IHeroFactory heroFactory = new HeroFactory();
            ICollection<IHero> heroes = new List<IHero>();

            IEngine engine = new Engine(heroFactory, heroes);
            engine.Run();
        }
    }
}