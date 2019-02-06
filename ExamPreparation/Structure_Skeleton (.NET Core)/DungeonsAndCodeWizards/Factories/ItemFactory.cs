using System;
using System.Linq;
using System.Reflection;
using DungeonsAndCodeWizards.Characters;
using DungeonsAndCodeWizards.Items;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string type)
        {
            var itemType = this.GetType()
                .Assembly
                .GetTypes()
                .FirstOrDefault(t => typeof(Item).IsAssignableFrom(t) && !t.IsAbstract && t.Name == type);

            if (itemType == null)
            {
                throw new ArgumentException($"Invalid item \"{type}\"!");
            }

            try
            {
                var item = (Item)Activator.CreateInstance(itemType);
                return item;
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }
        }
    }
}