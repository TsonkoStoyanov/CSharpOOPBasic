namespace P01_Vehicles.Vehicles
{
    public class Car : Vehicle
    {
        private const double airConditioner = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption = fuelConsumption += airConditioner;

        }
    }
}