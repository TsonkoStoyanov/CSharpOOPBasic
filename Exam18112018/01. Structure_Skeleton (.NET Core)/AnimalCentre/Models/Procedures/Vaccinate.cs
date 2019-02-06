using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Vaccinate : Procedure
    {
        private const int VaccinateEnergyRemove = 8;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            IsEnoughTime(animal, procedureTime);

            if (animal.IsVaccinated != true)
            {
                animal.ProcedureTime -= procedureTime;

                animal.Energy -= VaccinateEnergyRemove;

                animal.IsVaccinated = true;

                this.procedureHistory.Add(animal);
            }

        }
    }
}