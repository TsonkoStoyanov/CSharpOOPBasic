namespace DungeonsAndCodeWizards.Bags
{
    public class Backpack : Bag
    {
        private const int capacity = 100;

        public Backpack() : base(capacity)
        {
            this.Capacity = capacity;
        }
    }
}