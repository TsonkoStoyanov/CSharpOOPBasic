using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_FamilyTree
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var familyTree = new List<Person>();
            var relationships = new List<string>();

            string personToCreate = Console.ReadLine();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "End")
            {

                if (!input.Contains('-'))
                {
                    string[] inputArgs = input.Split(" ");

                    string name = inputArgs[0] + " " + inputArgs[1];
                    string birthday = inputArgs[2];

                    Person person = new Person(name, birthday);

                    familyTree.Add(person);
                }
                else
                {
                    relationships.Add(input);
                }
                
            }

            foreach (var relationship in relationships)
            {
                string[] inputArgs = relationship.Split(" - ");

                Person parent = GetPerson(inputArgs[0], familyTree);
                Person child = GetPerson(inputArgs[1], familyTree);

                if (!parent.Childrens.Contains(child))
                {
                    parent.Childrens.Add(child);
                }

                if (!child.Parents.Contains(parent))
                {
                    child.Parents.Add(parent);
                }
            }

            Print(personToCreate, familyTree);
        }

        private static void Print(string personToCreate, List<Person> familyTree)
        {
            Person person = GetPerson(personToCreate, familyTree);

            Console.WriteLine(person);
            Console.WriteLine($"Parents:");
            person.Parents.ForEach(p => Console.WriteLine(p));
            Console.WriteLine($"Children:");
            person.Childrens.ForEach(p => Console.WriteLine(p));

        }

        private static Person GetPerson(string input, List<Person> persons)
        {
            if (input.Contains('/'))
            {
                return persons.FirstOrDefault(p => p.Birthday == input);
            }

            return persons.FirstOrDefault(p => p.Name == input);

        }


    }
}
