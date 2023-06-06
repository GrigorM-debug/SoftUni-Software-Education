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
        private string name;
        private string element;
        private int health;

       public Pokemon(string pokemonName, string pokemonElement, int pokemonHealth)
        {
            Name= pokemonName;
            element= pokemonElement;
            health= pokemonHealth;
        }

        public string Name { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }
    }
}
