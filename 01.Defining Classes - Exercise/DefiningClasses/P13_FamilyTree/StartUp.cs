using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace P13_FamilyTree
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string personToCreate = input;

            List<Person> persons = new List<Person>();

            List<string> relationships = new List<string>();

            while ((input = Console.ReadLine()) != "End")
            {
                if (!input.Contains('-'))
                {
                    string[] inputArgs = input.Split(" ");

                    string name = inputArgs[0] + " " + inputArgs[1];
                    string birthday = inputArgs[2];

                    Person person = new Person(name, birthday);

                    persons.Add(person);
                }
                else
                {
                    relationships.Add(input);
                }
            }


            foreach (var relationship in relationships)
            {
                string[] inputArgs = relationship.Split(" - ");

                Person parent = GetPerson(inputArgs[0], persons);
                Person child = GetPerson(inputArgs[1], persons);

                if (!parent.Childrens.Contains(child))
                {
                    parent.Childrens.Add(child);
                }

                if (!child.Parents.Contains(parent))
                {
                    child.Parents.Add(parent);
                }
            }
            Print(personToCreate, persons);

        }

        private static void Print(string personToCreate, List<Person> persons)
        {
            Person person = GetPerson(personToCreate, persons);

            Console.WriteLine(person);
            Console.WriteLine($"Parents:");
            person.Parents.ForEach(p => Console.WriteLine(p));
            Console.WriteLine($"Children:");
            person.Childrens.ForEach(p => Console.WriteLine(p));

        }

        private static Person GetPerson(string info, List<Person> persons)
        {
            if (info.Contains('/'))
            {
                return persons.FirstOrDefault(p => p.Birthday == info);
            }

            return persons.FirstOrDefault(p => p.Name == info);

        }
    }
}
