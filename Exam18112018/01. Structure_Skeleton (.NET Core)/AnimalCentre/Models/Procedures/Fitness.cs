using System.Collections.Generic;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Fitness:Procedure
    {
        private const int fitnessHappinesRemove = 3;
        private const int fitnessEnergy = 10;

   

        public override void DoService(IAnimal animal, int procedureTime)
        {
            IsEnoughTime(animal, procedureTime);

            animal.ProcedureTime -= procedureTime;
            animal.Happiness -= fitnessHappinesRemove;
            animal.Energy += fitnessEnergy;

            this.procedureHistory.Add(animal);
        }
    }
}