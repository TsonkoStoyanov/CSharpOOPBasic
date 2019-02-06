using System;
using System.Transactions;
using P01_Vehicles.Vehicles.Contracts;

namespace P01_Vehicles.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get
            {
                return fuelQuantity;
            }
            set
            {
                if (value > TankCapacity)
                {
                    value = 0;
                }

                fuelQuantity = value;
            }
        }
        public double FuelConsumption
        {
            get
            {
                return fuelConsumption;
            }
            set
            {
                fuelConsumption = value;
            }
        }

        public double TankCapacity
        {
            get
            {
                return tankCapacity;
            }
            set
            {
                tankCapacity = value;
            }
        }

        public bool IsVehicleEmpty { get; set; }

        public virtual void Drive(double distance)
        {
            double fuelNeed = distance * fuelConsumption;

            if (FuelQuantity <= fuelNeed)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= fuelNeed;

            Console.WriteLine($"{GetType().Name} travelled {distance} km");
        }


        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.FuelQuantity + fuel > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += fuel;
            }

        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}