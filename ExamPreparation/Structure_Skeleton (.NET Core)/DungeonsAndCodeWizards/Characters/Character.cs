using System;
using System.ComponentModel.DataAnnotations;
using DungeonsAndCodeWizards.Bags;
using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Enums;
using DungeonsAndCodeWizards.Items;

namespace DungeonsAndCodeWizards.Characters
{
    public abstract class Character
    {
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private Bag bag;
        private Faction faction;
        private bool isAlive;
        private double restHealMultiplier = 0.2;


        protected Character(string name, double baseHealth, double baseArmor, double abilityPoints, Bag bag, Faction faction)
        {
            Name = name;
            BaseHealth = baseHealth;
            Health = BaseHealth;
            BaseArmor = baseArmor;
            AbilityPoints = abilityPoints;
            Bag = bag;
            Faction = faction;
            IsAlive = true;
            Armor = BaseArmor;

        }

        public string Name
        {
            get
            {
                return name;
            }

            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                name = value;
            }
        }

        public double BaseHealth
        {
            get
            {
                return baseHealth;
            }
            protected set
            {
                baseHealth = value;
            }
        }

        public double Health
        {
            get
            {
                return health;
            }
            set
            {
                health = Math.Min(value, BaseHealth);
            }
        }

        public double BaseArmor
        {
            get
            {
                return baseArmor;
            }
            protected set
            {
                baseArmor = value;
            }
        }

        public double Armor
        {
            get
            {
                return armor;
            }
            set
            {
                armor = Math.Min(value, BaseArmor);
            }
        }

        public double AbilityPoints
        {
            get
            {
                return abilityPoints;
            }
            protected set
            {
                abilityPoints = value;
            }
        }

        public Bag Bag
        {
            get
            {
                return bag;
            }
            protected set
            {
                bag = value;
            }
        }

        public Faction Faction
        {
            get
            {
                return faction;
            }
            protected set
            {
                faction = value;
            }
        }

        public bool IsAlive
        {
            get
            {
                return isAlive;
            }
            set
            {
                isAlive = value;
            }
        }

        public virtual double RestHealMultiplier => this.restHealMultiplier;


        public void GiveCharacterItem(Item item, Character character)
        {
            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            this.Bag.AddItem(item);
        }


        public void Rest()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            this.Health = Math.Min(this.Health + this.BaseHealth * RestHealMultiplier, this.BaseHealth);
        }

        public void TakeDamage(double hitPoints)
        {
            if (!IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            var hitpointsLeftAfterArmorDamage = Math.Max(0, hitPoints - this.Armor);

            this.Armor = Math.Max(0, this.Armor - hitPoints);

            this.Health = Math.Max(0, this.Health - hitpointsLeftAfterArmorDamage);

            if (this.Health == 0)
            {
                this.IsAlive = false;
            }
        }

        public void UseItem(Item item)
        {
            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            item.AffectCharacter(character);
        }

        public override string ToString()
        {
            return $"{this.Name} - HP: {Health}/{BaseHealth}, AP: {Armor}/{BaseArmor}, Status: {(this.IsAlive ? "Alive" : "Dead")}";
        }
    }
}