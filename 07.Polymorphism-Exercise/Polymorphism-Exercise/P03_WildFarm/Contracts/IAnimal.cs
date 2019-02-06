using P03_WildFarm.Models.Foods;

namespace P03_WildFarm.Contracts
{
    public interface IAnimal
    {
        string Name { get; }

        double Weight { get; }

        int FoodEaten { get; }

        void ProduceSound();

        void Eat(Food food);
    }
}