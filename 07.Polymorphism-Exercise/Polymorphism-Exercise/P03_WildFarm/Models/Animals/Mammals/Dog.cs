using System;
using P03_WildFarm.Models.Foods;

namespace P03_WildFarm.Models.Animals.Mammals
{
    public class Dog : Mammal
    {
        private const double weightIncrease = 0.40;

        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
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
            Console.WriteLine("Woof!");
        }
    }
}