using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace P13_FamilyTree
{
    public class Person
    {
        public Person(string name, string birthday)
        {
            Name = name;
            Birthday = birthday;
            Parents = new List<Person>();
            Childrens = new List<Person>();
        }

        public List<Person> Parents { get; set; }
        public List<Person> Childrens { get; set; }


        public string Name { get; set; }
        public string Birthday { get; set; }


        public override string ToString()
        {
            return $"{this.Name} {this.Birthday}";
        }
    }
}