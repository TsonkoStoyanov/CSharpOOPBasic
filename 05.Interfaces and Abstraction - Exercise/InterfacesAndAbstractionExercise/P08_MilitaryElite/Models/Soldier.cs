﻿using P08_MilitaryElite.Contracts;

namespace P08_MilitaryElite.Models
{
    public abstract class Soldier : ISoldier
    {
        private int id;

        private string firstName;

        private string lastName;

        public Soldier(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        
        public int Id { get => id; private set => id = value; }

        public string FirstName { get => firstName; private set => firstName = value; }

        public string LastName { get => lastName; private set => lastName = value; }


        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}";
        }
    }
}