using P03_WildFarm.Models.Foods;

namespace P03_WildFarm.Models.Animals.Mammals
{
    public abstract class Mammal : Animal
    {
        private string livingRegion;

        public Mammal(string name, double weight, string livingRegion) 
            : base(name, weight)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion { get => livingRegion; protected set => livingRegion = value; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}