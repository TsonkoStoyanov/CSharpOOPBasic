using System;

namespace P01_Vehicles.Vehicles
{
    public class Bus : Vehicle
    {
        private const double airConditioner = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {


        }

        public override void Drive(double distance)
        {
            double currentConsumption = this.FuelConsumption;

            if (!IsVehicleEmpty)
            {
                currentConsumption += airConditioner;
            }

            double fuelNeed = distance * currentConsumption;

            if (FuelQuantity < fuelNeed)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= fuelNeed;

            Console.WriteLine($"{GetType().Name} travelled {distance} km");
        }
    }
}