using System;
using DungeonsAndCodeWizards.Characters;

namespace DungeonsAndCodeWizards.Items
{
    public class ArmorRepairKit : Item
    {
        private const int weight = 10;

        public ArmorRepairKit() : base(weight)
        {
            this.Weight = weight;
        }

        public override void AffectCharacter(Character character)
        {
            EnsureAlive(character);

            character.Armor = character.BaseArmor;

        }

        private static void EnsureAlive(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException($"Must be alive to perform this action!");
            }
        }
    }
}