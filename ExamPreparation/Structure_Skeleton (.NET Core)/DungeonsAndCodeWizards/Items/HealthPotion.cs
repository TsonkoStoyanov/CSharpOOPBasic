using System;
using DungeonsAndCodeWizards.Characters;

namespace DungeonsAndCodeWizards.Items
{
    public class HealthPotion : Item
    {
        private const int weight = 5;

        public HealthPotion() : base(weight)
        {
            this.Weight = weight;
        }

        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException($"Must be alive to perform this action!");
            }

            character.Health += 20;
        }
    }
}