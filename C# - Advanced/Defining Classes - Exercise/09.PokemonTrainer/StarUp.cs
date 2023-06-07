using _09.PokemonTrainer;
using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Reflection;

namespace _09.PokemonTrainer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Tournament")
                {
                    break;
                }

                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                //Trainer trainer = trainers.SingleOrDefault(t => t.Name == trainerName);

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

            while(true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                foreach(var trainer in trainers)
                {
                    trainer.CheckPokemons(command);
                }
            }
            foreach (var trainer in trainers.OrderByDescending(t => t.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}
