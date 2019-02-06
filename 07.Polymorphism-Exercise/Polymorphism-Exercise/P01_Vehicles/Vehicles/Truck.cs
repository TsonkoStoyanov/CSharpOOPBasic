using System;

namespace P01_Vehicles.Vehicles
{
    public class Truck : Vehicle
    {
        private const double airConditioner = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption = fuelConsumption += airConditioner;
        }


        public override void Refuel(double fuel)
        {

            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (fuel+this.FuelQuantity > TankCapacity )
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += fuel * 0.95;
            }
        }
    }
}