using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster.Models.Vehicles
{
    public abstract class Vehicle
    {
        private readonly List<Product> trunk;

        protected Vehicle(int capacity)
        {
            Capacity = capacity;

            this.trunk  = new List<Product>();
        }

        public int Capacity { get;}

        public IReadOnlyCollection<Product> Trunk
        {
            get => this.trunk.AsReadOnly();
        }

        public bool IsFull => this.Trunk.Sum(x => x.Weight) >= this.Capacity;

        public bool IsEmpty => !this.Trunk.Any();

        public void LoadProduct(Product product)
        {
            if (IsFull)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }

            trunk.Add(product);
        }

       public Product Unload()
       {
           if (IsEmpty)
           {
               throw new InvalidOperationException("No products left in vehicle!");
           }

            Product product = Trunk.Last();

           this.trunk.RemoveAt(this.trunk.Count - 1);

           return product;
       }

    }
}