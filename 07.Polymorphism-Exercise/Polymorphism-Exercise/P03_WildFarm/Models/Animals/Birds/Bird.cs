using System.Runtime.CompilerServices;

namespace P03_WildFarm.Models.Animals.Birds
{
    public abstract class Bird : Animal
    {
        private double wingSize;

        public Bird(string name, double weight, double wingSize)
            : base(name, weight)
        {
            WingSize = wingSize;
        }

        public double WingSize { get => wingSize; protected set => wingSize = value; }


        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";

        }
    }
}