using System;
using System.Collections.Generic;
using System.Linq;
using AnimalCentre.Factories;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Hotels;
using AnimalCentre.Models.Procedures;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        public Dictionary<string, List<string>> adoptedAnimals;

        private AnimalFactory animalFactory;
        private Hotel hotel;
        private Chip chip;
        private Fitness fitness;
        private Play play;
        private NailTrim nailTrim;
        private DentalCare dentalCare;
        private Vaccinate vaccinate;

        public AnimalCentre()
        {
            this.animalFactory = new AnimalFactory();
            this.hotel = new Hotel();
            this.chip = new Chip();
            this.fitness = new Fitness();
            this.play = new Play();
            this.nailTrim = new NailTrim();
            this.dentalCare = new DentalCare();
            this.vaccinate = new Vaccinate();
            this.adoptedAnimals = new Dictionary<string, List<string>>();
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            var animal = animalFactory.CreateAnimal(type, name, energy, happiness, procedureTime);

            hotel.Accommodate(animal);

            return $"Animal {animal.Name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            var animal = GetAnimal(name);
            chip.DoService(animal, procedureTime);
            return $"{animal.Name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            var animal = GetAnimal(name);
            vaccinate.DoService(animal, procedureTime);
            return $"{animal.Name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            var animal = GetAnimal(name);
            fitness.DoService(animal, procedureTime);
            return $"{animal.Name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            var animal = GetAnimal(name);
            play.DoService(animal, procedureTime);
            return $"{animal.Name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            var animal = GetAnimal(name);
            dentalCare.DoService(animal, procedureTime);
            return $"{animal.Name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            var animal = GetAnimal(name);
            nailTrim.DoService(animal, procedureTime);
            return $"{animal.Name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            var animal = GetAnimal(animalName);

            hotel.Adopt(animalName, owner);

            if (!adoptedAnimals.ContainsKey(owner))
            {
                adoptedAnimals.Add(owner, new List<string>());
            }
            adoptedAnimals[owner].Add(animalName);
            

            if (animal.IsChipped)
            {
                return $"{owner} adopted animal with chip";
            }

            return $"{owner} adopted animal without chip";
        }

        public string History(string type)
        {
            string output = string.Empty;

            switch (type)
            {
                case "Chip":
                    output = chip.History();
                    break;
                case "Vaccinate":
                    output = vaccinate.History();
                    break;
                case "Fitness":
                    output = fitness.History();
                    break;
                case "DentalCare":
                    output = dentalCare.History();
                    break;
                case "NailTrim":
                    output = nailTrim.History();
                    break;
                case "Play":
                    output = play.History();
                    break;
            }
            return output;
        }


        private IAnimal GetAnimal(string name)
        {
            var animal = hotel.Animals.FirstOrDefault(a => a.Key == name).Value;

            if (animal == null)
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            return animal;
        }
    }
}