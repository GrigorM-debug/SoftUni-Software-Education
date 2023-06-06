using _09.PokemonTrainer;
using System;
using System.Net.Http.Headers;
using System.Reflection;

namespace SoftUniParking
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string input;
            while((input = Console.ReadLine()) != "Tournament")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                //Trainer trainer = trainers.SingleOrDefault(trainer => trainer.Name == trainerName);

                //if (trainer == null)
                //{
                //    trainer = new(trainerName);
                //    trainer.Pokemons.Add(new(pokemonName, pokemonElement, pokemonHealth));
                //    trainers.Add(trainer);
                //}
                //else
                //{
                //    trainer.Pokemons.Add(new(pokemonName, pokemonElement, pokemonHealth));
                //}

                bool trainerExists = false;
                Trainer trainer = null;

                foreach (var existingTrainer in trainers)
                {
                    if (existingTrainer.Name == trainerName)
                    {
                        trainerExists = true;
                        trainer = existingTrainer;
                        break;
                    }
                }

                if (!trainerExists)
                {
                    trainer = new Trainer(trainerName);
                    trainers.Add(trainer);
                    trainer.Pokemons.Add(new(pokemonName, pokemonElement, pokemonHealth));
                }
                else
                {
                    trainer.Pokemons.Add(new(pokemonName, pokemonElement, pokemonHealth));
                }
            }
        }
    }
}
