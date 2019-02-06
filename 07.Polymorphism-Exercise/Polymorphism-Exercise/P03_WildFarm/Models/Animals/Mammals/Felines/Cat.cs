using System;
using P03_WildFarm.Models.Foods;

namespace P03_WildFarm.Models.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        private const double weightIncrease = 0.30;
        
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            if (food is Vegetable || food is Meat)
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
            Console.WriteLine("Meow");
        }
    }
}