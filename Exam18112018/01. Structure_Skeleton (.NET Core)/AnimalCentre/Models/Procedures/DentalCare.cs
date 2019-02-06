using System;
using System.Collections.Generic;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class DentalCare : Procedure
    {
        private const int dentalCareHappines = 12;
        private const int dentalCareEnergy = 10;

      

        public override void DoService(IAnimal animal, int procedureTime)
        {

            IsEnoughTime(animal, procedureTime);

            animal.ProcedureTime -= procedureTime;
            animal.Happiness += dentalCareHappines;
            animal.Energy += dentalCareEnergy;

            this.procedureHistory.Add(animal);
        }
    }
}