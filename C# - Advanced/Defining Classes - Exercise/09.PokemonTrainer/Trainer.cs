using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace _09.PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string trainerName)
        {
            Name=trainerName;
            Pokemons = new List<Pokemon>();
        }

        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemons { get; set; }


        public void CheckPokemons(string element)
        {
            if (Pokemons.Any(p=> p.Element == element))
            {
                NumberOfBadges++;
            }
            else
            {
                for (int i = 0; i < Pokemons.Count; i++)
                {
                    Pokemon currPokemon = Pokemons[i];

                    currPokemon.Health -= 10;

                    if(currPokemon.Health <= 0)
                    {
                        Pokemons.Remove(currPokemon);
                    }
                }
            }
        }
    }
}
