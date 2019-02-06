using System;
using System.Collections.Generic;
using P08_MilitaryElite.Contracts;
using P08_MilitaryElite.Enums;

namespace P08_MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps) : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<IMission>();
        }

        public ICollection<IMission> Missions { get; set; }


        public override string ToString()
        {
            return base.ToString() + $"\nMissions:" + $"{(this.Missions.Count > 0 ? "\n  " : "")}{ string.Join("\n  ", this.Missions)}";
        }
    }
}