using System;

namespace P07_SpeedRacing
{
    public class Car
    {
        private string model;

        private double fuelAmount;

        private double fuelPerKm;

        private int traveledDistance;


        public Car(string model, double fuelAmount, double fuelPerKm)
        {
            this.model = model;
            this.fuelAmount = fuelAmount;
            this.fuelPerKm = fuelPerKm;
            this.traveledDistance = 0;

        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

      
        internal void Drive(int distanceTotravel)
        {
            double fuelNeed = distanceTotravel * this.fuelPerKm;

            if (fuelNeed <= fuelAmount)
            {
                this.traveledDistance += distanceTotravel;
                this.fuelAmount -= fuelNeed;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{this.Model} {this.fuelAmount:f2} {this.traveledDistance}";
        }
    }
}