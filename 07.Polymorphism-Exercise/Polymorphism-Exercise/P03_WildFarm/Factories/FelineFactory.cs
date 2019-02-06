using System;
using System.Linq;
using System.Reflection;
using P03_WildFarm.Models.Animals.Mammals.Felines;

namespace P03_WildFarm.Factories
{
    public class FelineFactory
    {
        public Feline CreateFeline(string type, string name, double weight, string livingRegion, string breed)
        {
            var felineType = this.GetType()
                .Assembly
                .GetTypes()
                .FirstOrDefault(t => typeof(Feline).IsAssignableFrom(t) && !t.IsAbstract && t.Name == type);

            if (felineType == null)
            {
                throw new InvalidOperationException("Invalid feline type!");
            }

            try
            {
                var feline = (Feline) Activator.CreateInstance(felineType, name, weight, livingRegion, breed);
                return feline;
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }
        }
    }
}