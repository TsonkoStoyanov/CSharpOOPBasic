using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            List<Product> products = new List<Product>();

            string[] inputPersons = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] inputProducts = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            try
            {
                for (int i = 0; i < inputPersons.Length; i++)
                {
                    string[] currentPersonInfo = inputPersons[i].Split('=');
                    string name = currentPersonInfo[0];
                    decimal money = decimal.Parse(currentPersonInfo[1]);

                    Person person = new Person(name, money);
                    persons.Add(person);
                }

                for (int i = 0; i < inputProducts.Length; i++)
                {
                    string[] currentProductInfo = inputProducts[i].Split('=');
                    string name = currentProductInfo[0];
                    decimal cost = decimal.Parse(currentProductInfo[1]);

                    Product product = new Product(name, cost);
                    products.Add(product);
                }

                string input = String.Empty;

                while ((input = Console.ReadLine()) != "END")
                {
                    string[] inputArgs = input.Split(" ");

                    Person person = persons.FirstOrDefault(p => p.Name == inputArgs[0]);
                    Product product = products.FirstOrDefault(p => p.Name == inputArgs[1]);

                    person.BuyProduct(product);
                }

                foreach (var person in persons)
                {
                    string result = person.BagOfProducts.Count > 0 ? string.Join(", ", person.BagOfProducts) : "Nothing bought";

                    Console.WriteLine($"{person.Name} - {result}");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }


        }
    }
}
