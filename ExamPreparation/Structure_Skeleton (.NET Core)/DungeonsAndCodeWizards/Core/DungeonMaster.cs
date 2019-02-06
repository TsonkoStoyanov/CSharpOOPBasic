using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonsAndCodeWizards.Characters;
using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Factories;
using DungeonsAndCodeWizards.Items;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private List<Character> charactersParty;
        private Stack<Item> itemsPool;
        private ItemFactory itemFactory;
        private CharacterFactory characterFactory;

        private int lastSurvivorRounds;

        public DungeonMaster()
        {
            this.charactersParty = new List<Character>();
            this.itemsPool = new Stack<Item>();
            this.itemFactory = new ItemFactory();
            this.characterFactory = new CharacterFactory();
        }

        public string JoinParty(string[] args)
        {
            string faction = args[0];
            string characterType = args[1];
            string name = args[2];

            var character = characterFactory.CreateCharacter(faction, characterType, name);

            charactersParty.Add(character);

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item = itemFactory.CreateItem(itemName);

            itemsPool.Push(item);

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            var character = GetCharacter(characterName);

            if (itemsPool.Count < 1)
            {
                throw new InvalidOperationException($"No items left in pool!");
            }

            var item = itemsPool.Pop();

            character.ReceiveItem(item);

            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            var character = GetCharacter(characterName);

            var item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];

            string itemName = args[2];

            var character = GetCharacter(giverName);
            var reciverCharacter = GetCharacter(receiverName);


            var item = character.Bag.GetItem(itemName);

            character.UseItemOn(item, reciverCharacter);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];

            string itemName = args[2];

            var character = GetCharacter(giverName);
            var reciverCharacter = GetCharacter(receiverName);


            var item = character.Bag.GetItem(itemName);

            character.GiveCharacterItem(item, reciverCharacter);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            var sortedCharacters = this.charactersParty
                .OrderByDescending(a => a.IsAlive)
                .ThenByDescending(a => a.Health);

            var result = string.Join(Environment.NewLine, sortedCharacters);

            return result;
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var attackReceiverName = args[1];

            var attacker = this.GetCharacter(attackerName);
            var receiver = this.GetCharacter(attackReceiverName);

            if (!(attacker is IAttackable attackingCharacter))
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            attackingCharacter.Attack(receiver);

            var result =
                $"{attacker.Name} attacks {receiver.Name} for {attacker.AbilityPoints} hit points! {receiver.Name} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!";

            if (!receiver.IsAlive)
            {
                result += Environment.NewLine + $"{receiver.Name} is dead!";
            }

            return result;

            }

        public string Heal(string[] args)
        {
            
            var healerName = args[0];
            var healingReceiverName = args[1];

            var healer = this.GetCharacter(healerName);
            var receiver = this.GetCharacter(healingReceiverName);

            if (!(healer is IHealable healingCharacter))
            {
                throw new ArgumentException($"{healer.Name} cannot heal!");
            }

            healingCharacter.Heal(receiver);

            var result =
                $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";

            return result;
        }

        public string EndTurn(string[] args)
        {var aliveCharacters = charactersParty.Where(c => c.IsAlive).ToArray();

            var sb = new StringBuilder();

            foreach (var character in aliveCharacters)
            {
                var previousHealth = character.Health;

                character.Rest();

                var currentHealth = character.Health;
                sb.AppendLine($"{character.Name} rests ({previousHealth} => {currentHealth})");
            }

            if (aliveCharacters.Length <= 1)
            {
                this.lastSurvivorRounds++;
            }

            var result = sb.ToString().TrimEnd('\r', '\n');

            return result;
        }

        public bool IsGameOver()
        {
            var oneOrZeroSurvivorsLeft = this.charactersParty.Count(c => c.IsAlive) <= 1;

            var lastSurviverSurvivedTooLong = this.lastSurvivorRounds > 1;

            return oneOrZeroSurvivorsLeft && lastSurviverSurvivedTooLong;
        }

        private Character GetCharacter(string characterName)
        {
            var character = charactersParty.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            return character;
        }
    }
}