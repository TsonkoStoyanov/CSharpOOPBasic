using System;
using DungeonsAndCodeWizards.Characters;

namespace DungeonsAndCodeWizards.Items
{
    public class PoisonPotion : Item
    {
        private const int weight = 5;

        public PoisonPotion() : base(weight)
        {
            this.Weight = weight;
        }

        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException($"Must be alive to perform this action!");
            }

            character.Health = Math.Max(0, character.Health - 20);

            if (character.Health == 0)
            {
                character.IsAlive = false;
            }
        }
    }
}