﻿using System;
using System.Collections.Generic;
using P08_MilitaryElite.Contracts;
using P08_MilitaryElite.Enums;

namespace P08_MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps) : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = new List<IRepair>();
        }


        public ICollection<IRepair> Repairs { get; set; }


        public override string ToString()
        {

            return base.ToString() + $"\nRepairs:" + $"{(this.Repairs.Count > 0 ? "\n  " : "")}{ string.Join("\n  ", this.Repairs)}";
        }
    }
}