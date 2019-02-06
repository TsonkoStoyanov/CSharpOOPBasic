using System;
using P03_WildFarm.Models.Foods;

namespace P03_WildFarm.Models.Animals.Birds
{
    public class Owl : Bird
    {
        private const double weightIncrease = 0.25;
  
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                Weight += food.Quantity * weightIncrease;
             
                FoodEaten += food.Quantity;    
            }
            else
            {
                
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");

            }
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}