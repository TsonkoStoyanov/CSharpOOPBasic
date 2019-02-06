using System;
using P08_MilitaryElite.Contracts;
using P08_MilitaryElite.Enums;

namespace P08_MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, Corps corps) : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public Corps Corps { get; }

        public override string ToString()
        {
            return base.ToString() + $"{Environment.NewLine}Corps: {this.Corps}";
        }
    }
}