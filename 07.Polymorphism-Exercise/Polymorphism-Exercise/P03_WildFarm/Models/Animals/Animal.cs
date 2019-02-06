using P03_WildFarm.Contracts;
using P03_WildFarm.Models.Foods;

namespace P03_WildFarm.Models.Animals
{
    public abstract class Animal:IAnimal
    {
        private string name;
        private double weight;
        private int foodEaten;

        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }

        public string Name { get => name; protected set => name = value; }
        public double Weight { get => weight; protected set => weight = value; }
        public int FoodEaten { get => foodEaten; protected set => foodEaten = value; }

        public abstract void Eat(Food food);

        public abstract void ProduceSound();

    }
}