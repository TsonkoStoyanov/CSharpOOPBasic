using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace P11_PokemonTrainer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            //Pesho Charizard Fire 100
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] inputArgs = input.Split();

                string trainerName = inputArgs[0];
                string pokemonName = inputArgs[1];
                string element = inputArgs[2];
                int health = int.Parse(inputArgs[3]);

                Trainer trainer = trainers.FirstOrDefault(x => x.Name == trainerName);

                if (trainer == null)
                {
                    trainer = new Trainer(trainerName);
                    trainers.Add(trainer);
                }

                Pokemon pokemon = new Pokemon(pokemonName, element, health);
                trainer.Add(pokemon);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                //Fire”, “Water”, “Electricity

                switch (input)
                {
                    case "Fire":
                        Execute(trainers, input);
                        break;

                    case "Water":
                        Execute(trainers, input);
                        break;

                    case "Electricity":
                        Execute(trainers, input);
                        break;
                }

            }

            foreach (var trainer in trainers.OrderByDescending(x=>x.NumberOfBadges))
            {
                Console.WriteLine(trainer);
            }
        }

        private static void Execute(List<Trainer> trainers, string input)
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Pokemons.Any(x => x.Element == input))
                {
                    trainer.NumberOfBadges += 1;
                }
                else
                {
                    trainer.DecreaseHealth();
                }
            }
        }
    }
}
