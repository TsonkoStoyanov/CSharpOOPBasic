using System;
using System.Linq;
using System.Reflection;
using DungeonsAndCodeWizards.Characters;
using DungeonsAndCodeWizards.Enums;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string type, string name)
        {
            var characterType = this.GetType()
                .Assembly
                .GetTypes()
                .FirstOrDefault(t => typeof(Character).IsAssignableFrom(t) && !t.IsAbstract && t.Name == type);

            bool isValidFaction = Enum.TryParse(faction, out Faction validFaction);

            if (!isValidFaction)
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }

            if (characterType == null)
            {
                throw new ArgumentException($"Invalid character type \"{type}\"!");
            }

            try
            {
                var character = (Character)Activator.CreateInstance(characterType, name, validFaction);
                return character;
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }

        }

    }
}