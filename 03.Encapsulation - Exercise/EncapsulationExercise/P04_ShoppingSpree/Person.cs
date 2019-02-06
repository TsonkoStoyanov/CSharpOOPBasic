using System;
using System.Collections.Generic;

namespace P04_ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;

        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value)||string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public decimal Money
        {
            get => money;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }

        public IReadOnlyCollection<Product> BagOfProducts
        {
            get
            {
                return bagOfProducts;
            }
        }

        internal void BuyProduct(Product product)
        {
            if (money - product.Cost < 0)
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
            else
            {
                Console.WriteLine($"{name} bought {product.Name}");
                money -= product.Cost;
                bagOfProducts.Add(product);
            }

        }
    }
}