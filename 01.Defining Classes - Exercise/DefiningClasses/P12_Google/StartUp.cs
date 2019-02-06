using System;
using System.Collections.Generic;
using System.Linq;

namespace P12_Google
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();



            string input = String.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split();

                string name = inputArgs[0];
                string command = inputArgs[1];

                Person person = people.FirstOrDefault(x => x.Name == name);

                if (person == null)
                {
                    person = new Person(name);
                    people.Add(person);
                }

                switch (command)
                {
                    case "company":
                        string companyName = inputArgs[2];
                        string department = inputArgs[3];
                        decimal salary = decimal.Parse(inputArgs[4]);
                        person.AddCompany(companyName, department, salary);

                        break;
                    case "pokemon":
                        Pokemon pokemon = new Pokemon(inputArgs[2], inputArgs[3]);
                        person.AddPokemon(pokemon);
                        break;
                    case "parents":
                        Parent parent = new Parent(inputArgs[2], inputArgs[3]);
                        person.AddParent(parent);
                        break;
                    case "children":
                        Children children = new Children(inputArgs[2], inputArgs[3]);
                        person.AddChildren(children);
                        break;
                    case "car":
                        string CarModel = inputArgs[2];
                        int CarSpeed = int.Parse(inputArgs[3]);
                        person.AddCar(CarModel, CarSpeed);
                        break;
                }

            }

            input = Console.ReadLine();

            Person personToPrint = people.FirstOrDefault(x => x.Name == input);

            Console.WriteLine(personToPrint);

        }
    }
}
