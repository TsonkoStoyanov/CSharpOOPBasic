using System.Xml.Schema;
using P03_WildFarm.Contracts;

namespace P03_WildFarm.Models.Foods
{
    public abstract class Food : IFood
    {
        private int quantity;

        public Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get => quantity; protected set => quantity = value; }
    }
}