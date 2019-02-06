﻿using System;
using DungeonsAndCodeWizards.Bags;
using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Enums;

namespace DungeonsAndCodeWizards.Characters
{
    public class Cleric : Character, IHealable
    {
        private const double baseHealth = 50;
        private const double baseArmor = 25;
        private const double abilityPoints = 40;

        public Cleric(string name, Faction faction) : base(name, baseHealth, baseArmor, abilityPoints, new Backpack(), faction)
        {

        }

        public override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");

            }

            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }

            character.Health = Math.Min(character.BaseHealth, character.Health + this.AbilityPoints);

        }


    }
}