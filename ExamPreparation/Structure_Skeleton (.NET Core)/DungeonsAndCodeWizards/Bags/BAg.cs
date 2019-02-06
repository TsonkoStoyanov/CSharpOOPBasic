using System;
using System.Collections.Generic;
using System.Linq;
using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Items;

namespace DungeonsAndCodeWizards.Bags
{
    public abstract class Bag : IBag
    {
        private int capacity;

        private readonly List<Item> items;

        protected Bag(int capacity)
        {
            Capacity = capacity;
            this.items = new List<Item>();
        }



        public int Load => this.Items.Sum(x => x.Weight);

        public int Capacity { get => capacity; protected set => capacity = value; }

        public IReadOnlyCollection<Item> Items
        {
            get
            {
                return this.items.AsReadOnly();
            }

        }

        public void AddItem(Item item)
        {
            if (item.Weight + this.Load > this.Capacity)
            {
                throw new InvalidOperationException($"Bag is full!");
            }
            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (Items.Count < 1)
            {
                throw new InvalidOperationException($"Bag is empty!");
            }

            Item item = Items.FirstOrDefault(i => i.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            items.Remove(item);

            return item;
        }
    }

}