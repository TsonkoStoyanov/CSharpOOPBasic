using System;
using System.Linq;

namespace AnimalCentre.Core
{
    public class Engine
    {
        private AnimalCentre animalCentre;

        public Engine()
        {
            this.animalCentre = new AnimalCentre();
        }

        internal void Run()
        {
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                try
                {
                    string output = CommandParser(input);
                    Console.WriteLine(output);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"ArgumentException: {ex.Message}");
                }
                catch (InvalidOperationException ix)
                {
                    Console.WriteLine($"InvalidOperationException: {ix.Message}");
                }

            }

            ;
            foreach (var key in animalCentre.adoptedAnimals.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"--Owner: {key.Key}");

                Console.WriteLine($"    - Adopted animals: {string.Join(" ", key.Value)}");
            }
            
        }

        private string CommandParser(string input)
        {
            string[] inputArgs = input.Split();

            string command = inputArgs[0];

            string output = string.Empty;
            
            switch (command)
            {

                case "RegisterAnimal":
                    string type = inputArgs[1];
                    string name = inputArgs[2];
                    int energy = int.Parse(inputArgs[3]);
                    int happiness = int.Parse(inputArgs[4]);
                    int procedureTime = int.Parse(inputArgs[5]);
                    output = animalCentre.RegisterAnimal(type, name, energy, happiness, procedureTime);
                    break;
                case "Chip":
                    name = inputArgs[1];
                    procedureTime = int.Parse(inputArgs[2]);
                    output = animalCentre.Chip(name, procedureTime);
                    break;
                case "Vaccinate":
                    name = inputArgs[1];
                    procedureTime = int.Parse(inputArgs[2]);
                    output = animalCentre.Vaccinate(name, procedureTime);
                    break;
                case "Fitness":
                    name = inputArgs[1];
                    procedureTime = int.Parse(inputArgs[2]);
                    output = animalCentre.Fitness(name, procedureTime);
                    break;
                case "Play":
                    name = inputArgs[1];
                    procedureTime = int.Parse(inputArgs[2]);
                    output = animalCentre.Play(name, procedureTime);
                    break;
                case "DentalCare":
                    name = inputArgs[1];
                    procedureTime = int.Parse(inputArgs[2]);
                    output = animalCentre.DentalCare(name, procedureTime);
                    break;
                case "NailTrim":
                    name = inputArgs[1];
                    procedureTime = int.Parse(inputArgs[2]);
                    output = animalCentre.NailTrim(name, procedureTime);
                    break;
                case "Adopt":
                    name = inputArgs[1];
                    string owner = inputArgs[2];
                    output = animalCentre.Adopt(name, owner);
                    break;
                case "History":
                    name = inputArgs[1];
                    output = animalCentre.History(name);
                    break;
            }

            return output;
                
        }
    }
}