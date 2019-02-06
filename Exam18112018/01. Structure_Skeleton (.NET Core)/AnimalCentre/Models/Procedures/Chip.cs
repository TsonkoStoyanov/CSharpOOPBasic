using System;
using System.Collections.Generic;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Chip : Procedure
    {
        private const int chipHappinesRemove = 5;

     public override void DoService(IAnimal animal, int procedureTime)
        {

            IsEnoughTime(animal, procedureTime);

            if (animal.IsChipped)
            {
                throw new ArgumentException($"{animal.Name} is already chipped");
            }

            animal.IsChipped = true;

            animal.ProcedureTime -= procedureTime;
            animal.Happiness -= chipHappinesRemove;

            this.procedureHistory.Add(animal);
        }
    }
}