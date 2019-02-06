using System;
using System.Collections.Generic;
using System.Linq;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Hotels
{
    public class Hotel : IHotel
    {
        private const int defaultCapacity = 10;

        private int capacity;

        private Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            this.Capacity = defaultCapacity;
            this.animals = new Dictionary<string, IAnimal>();
        }

        public int Capacity { get => capacity; private set => capacity = value; }

        public IReadOnlyDictionary<string, IAnimal> Animals => this.animals;

        public void Accommodate(IAnimal animal)
        {
            if (animals.Count == this.Capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if (animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }

            animals.Add(animal.Name, animal);
        }

        public void Adopt(string animalName, string owner)
        {
            if (!animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            var animal = animals.FirstOrDefault(a => a.Key == animalName).Value;

            animal.IsAdopt = true;
          
            animal.Owner = owner;

            animals.Remove(animalName);
        }
    }
}