using System;
using P03_WildFarm.Models.Foods;

namespace P03_WildFarm.Models.Animals.Birds
{
    public class Hen : Bird
    {
        private const double weightIncrease = 0.35;
       

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            Weight += food.Quantity * weightIncrease;
            FoodEaten += food.Quantity;
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Cluck");
        }
    }
}