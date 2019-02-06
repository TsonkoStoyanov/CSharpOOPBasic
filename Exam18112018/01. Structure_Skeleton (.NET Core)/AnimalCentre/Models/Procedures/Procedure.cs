using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Hotels;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected List<IAnimal> procedureHistory;

        public Procedure()
        {
            this.procedureHistory = new List<IAnimal>();
        }

        public abstract void DoService(IAnimal animal, int procedureTime);

        public string History()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.GetType().Name);

            foreach (var animal in procedureHistory)
            {
                sb.AppendLine(animal.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        protected void IsEnoughTime(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime - procedureTime < 0)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }

        }
    }
}