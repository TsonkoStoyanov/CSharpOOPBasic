﻿using System;
using System.Collections.Generic;
using P08_MilitaryElite.Contracts;

namespace P08_MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) : base(id, firstName,
            lastName, salary)
        {
            this.Privates = new List<IPrivate>();
        }

        public ICollection<IPrivate> Privates { get; set; }

        public override string ToString()
        {

            return base.ToString() + $"\nPrivates:" + $"{(this.Privates.Count > 0 ? "\n  " : "")}{string.Join("\n  ", this.Privates)}";
        }
    }
}
