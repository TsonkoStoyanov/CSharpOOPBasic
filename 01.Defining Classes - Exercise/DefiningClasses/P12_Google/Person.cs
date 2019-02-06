using System;
using System.Collections.Generic;
using System.Text;

namespace P12_Google
{
    public class Person
    {
        public Person(string name)
        {
            Name = name;
            Pokemons = new List<Pokemon>();
            Parents = new List<Parent>();
            Childrens = new List<Children>();
        }

        public string Name { get; set; }

        public Company Company { get; set; }

        public List<Pokemon> Pokemons { get; set; }

        public List<Parent> Parents { get; set; }

        public List<Children> Childrens { get; set; }

        public Car Car { get; set; }


        public void AddPokemon(Pokemon pokemon)
        {
            Pokemons.Add(pokemon);
        }

        public void AddParent(Parent parent)
        {
            Parents.Add(parent);
        }

        public void AddChildren(Children children)
        {
            Childrens.Add(children);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(Name);

            builder.AppendLine("Company:");
            if (Company != null)
            {
                builder.AppendLine(Company.ToString());
            }

            builder.AppendLine("Car:");
            if (Car != null)
            {
                builder.AppendLine(Car.ToString());
            }

            builder.AppendLine("Pokemon:");
            this.Pokemons.ForEach(p => builder.AppendLine(p.ToString()));

            builder.AppendLine("Parents:");
            this.Parents.ForEach(p => builder.AppendLine(p.ToString()));

            builder.AppendLine("Children:");
            this.Childrens.ForEach(ch => builder.AppendLine(ch.ToString()));

            return builder.ToString();

        }

        internal void AddCompany(string companyName, string department, decimal salary)
        {
            Company company = new Company(companyName, department, salary);

            this.Company = company;
        }

        internal void AddCar(string carModel, int carSpeed)
        {
            Car car = new Car(carModel, carSpeed);
            this.Car = car;
        }
    }
}