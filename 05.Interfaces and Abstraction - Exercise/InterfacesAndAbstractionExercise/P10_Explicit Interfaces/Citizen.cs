using System;
using System.Collections.Generic;
using System.Text;

namespace P10_Explicit_Interfaces
{
    public class Citizen : IResident, IPerson
    {
        public Citizen(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Country { get; set; }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }

        string IPerson.GetName()
        {
            return this.Name;
        }
    }
}
