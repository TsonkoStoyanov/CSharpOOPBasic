using DungeonsAndCodeWizards.Characters;
using DungeonsAndCodeWizards.Contracts;

namespace DungeonsAndCodeWizards.Items
{
    public abstract class Item
    {
        private int weight;

        protected Item(int weight)
        {
            Weight = weight;
        }

        public int Weight { get => weight; protected set => weight = value; }

        public abstract void AffectCharacter(Character character);

    }
}