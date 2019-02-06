using System.Collections.Generic;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Play:Procedure
    {
        private const int fitnessHappines = 12;
        private const int playEnergyRemove = 6;

    

        public override void DoService(IAnimal animal, int procedureTime)
        {
            IsEnoughTime(animal, procedureTime);

            animal.ProcedureTime -= procedureTime;
            animal.Happiness += fitnessHappines;
            animal.Energy -= playEnergyRemove;

            this.procedureHistory.Add(animal);
        }
    }
}