using System;
using System.Linq;
using System.Reflection;
using P03_WildFarm.Models.Animals.Birds;

namespace P03_WildFarm.Factories
{
    public class BirdFactory
    {
        public Bird CreateBird(string type, string name, double weight, double wingSize)
        {
            var birdType = this.GetType()
                .Assembly
                .GetTypes()
                .FirstOrDefault(t => typeof(Bird).IsAssignableFrom(t) && !t.IsAbstract && t.Name == type);

            if (birdType == null)
            {
                throw new InvalidOperationException("Invalid bird type!");
            }

            try
            {
                var bird = (Bird) Activator.CreateInstance(birdType, name, weight, wingSize);
                return bird;
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }
        }
    }
}