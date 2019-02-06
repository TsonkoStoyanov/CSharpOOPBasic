using System;
using System.Linq;
using System.Reflection;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Factories
{
    public class AnimalFactory
    {
        public IAnimal CreateAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            var animalType = this.GetType()
                .Assembly
                .GetTypes()
                .FirstOrDefault(t => typeof(Animal).IsAssignableFrom(t) && !t.IsAbstract && t.Name == type);

            if (animalType == null)
            {
                throw new InvalidOperationException("Invalid animal type!");
            }

            try
            {
                var animal = (IAnimal)Activator.CreateInstance(animalType, name, energy, happiness, procedureTime);
                return animal;
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }
        }
    }
}