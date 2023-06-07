using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace _09.PokemonTrainer
{
    public class Pokemon
    {
       public Pokemon(string pokemonName, string pokemonElement, int pokemonHealth)
        {
            Name = pokemonName;
            Element = pokemonElement;
            Health = pokemonHealth;
        }

        public string Name { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }
    }
}
