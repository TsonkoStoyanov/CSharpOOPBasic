public abstract class Driver
{
    private string name;

    private double totalTime;

    private Car car;

    private double fuelConsumptionPerKm;



    protected Driver(string name, Car car)
    {
        Name = name;
        Car = car;

    }

    public string Name { get => name; protected set => name = value; }

    public double TotalTime { get => totalTime; protected set => totalTime = value; }

    public Car Car { get => car; protected set => car = value; }

    public double FuelConsumptionPerKm { get => fuelConsumptionPerKm; protected set => fuelConsumptionPerKm = value; }

    protected virtual double Speed => (this.Car.Hp + Car.Tyre.Degradation) / this.Car.FuelAmount;
}
