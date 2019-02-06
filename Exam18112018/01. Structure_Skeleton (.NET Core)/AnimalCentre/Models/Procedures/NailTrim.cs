using System.Collections.Generic;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class NailTrim : Procedure
    {
        private const int NailTrimHappinesRemove = 7;

     

        public override void DoService(IAnimal animal, int procedureTime)
        {
            IsEnoughTime(animal, procedureTime);

            animal.ProcedureTime -= procedureTime;
            animal.Happiness -= NailTrimHappinesRemove;

            this.procedureHistory.Add(animal);
        }
    }
}