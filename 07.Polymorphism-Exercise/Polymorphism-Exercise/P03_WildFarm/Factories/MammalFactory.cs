using System;
using System.Linq;
using System.Reflection;
using P03_WildFarm.Models.Animals.Mammals;
using P03_WildFarm.Models.Foods;

namespace P03_WildFarm.Factories
{
    public class MammalFactory
    {
        public Mammal CreateMammal(string type, string name, double weight, string livingRegion)
        {
            var mammalType = this.GetType()
                .Assembly
                .GetTypes()
                .FirstOrDefault(t => typeof(Mammal).IsAssignableFrom(t) && !t.IsAbstract && t.Name == type);

            if (mammalType == null)
            {
                throw new InvalidOperationException("Invalid mammal type!");
            }

            try
            {
                var mammal = (Mammal) Activator.CreateInstance(mammalType, name, weight, livingRegion);
                return mammal;
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }
        }
    }
}