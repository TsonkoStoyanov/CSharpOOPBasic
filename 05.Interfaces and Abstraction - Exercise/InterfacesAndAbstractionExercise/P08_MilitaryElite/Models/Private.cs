﻿using P08_MilitaryElite.Contracts;

namespace P08_MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        private decimal salary;

        public Private(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary
        {
            get => salary; 
            
            private set
            {
               salary = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $" Salary: {this.Salary:f2}";
        }
    }
}