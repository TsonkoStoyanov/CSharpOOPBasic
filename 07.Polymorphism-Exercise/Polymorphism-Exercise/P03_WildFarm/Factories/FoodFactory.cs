using System;
using System.Linq;
using System.Reflection;
using P03_WildFarm.Models.Foods;

namespace P03_WildFarm.Factories
{
    public class FoodFactory
    {
        public Food CreateFood(string type, int quantity)
        {
            var foodType = this.GetType()
                .Assembly
                .GetTypes()
                .FirstOrDefault(t => typeof(Food).IsAssignableFrom(t) && !t.IsAbstract && t.Name == type);

            if (foodType == null)
            {
                throw new InvalidOperationException("Invalid food type!");
            }

            try
            {
                var food = (Food) Activator.CreateInstance(foodType, quantity);
                return food;
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }
        }
    }
}