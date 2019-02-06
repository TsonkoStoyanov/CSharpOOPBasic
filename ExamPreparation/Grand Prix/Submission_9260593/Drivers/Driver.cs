using System;

public abstract class Driver
{
    private string name;

    private double totalTime;

    private Car car;

    private double fuelConsumptionPerKm;

    private bool isRacing = true;

    private string dnf;

    protected Driver(string name, double fuelConsumptionPerKm, Car car)
    {
        Name = name;
        FuelConsumptionPerKm = fuelConsumptionPerKm;
        Car = car;

    }

    public string Name { get => name; protected set => name = value; }

    public double TotalTime { get => totalTime; protected set => totalTime = value; }

    public Car Car { get => car; protected set => car = value; }

    public double FuelConsumptionPerKm { get => fuelConsumptionPerKm; protected set => fuelConsumptionPerKm = value; }

    public string Dnf { get => dnf; set => dnf = value; }

    protected virtual double Speed => (this.Car.Hp + Car.Tyre.Degradation) / this.Car.FuelAmount;

    public bool IsRacing { get => isRacing; set => isRacing = value; }

    internal void Refuel(double fuelAmount)
    {
        this.Car.FuelAmount += fuelAmount;
    }

    internal void AddTime(double time)
    {
        this.TotalTime += time;
    }

    internal void CompleteLap(int lapLenght)
    {
        var time = 60 / (lapLenght / this.Speed);

        AddTime(time);

        DecreaseFuel(lapLenght);
        DegrateTyre();
    }

    private void DegrateTyre()
    {
        try
        {
            car.Tyre.DegradeTyre();

        }
        catch (ArgumentException ex)
        {
            this.Dnf = ex.Message;
            IsRacing = false;

        }

    }

    private void DecreaseFuel(int lapLenght)
    {
        this.Car.FuelAmount -= lapLenght * this.FuelConsumptionPerKm;

        if (car.FuelAmount < 0)
        {
            this.Dnf = "Out of fuel";
            IsRacing = false;
        }
    }

    internal void Crash()
    {
        this.Dnf = "Crashed";
        IsRacing = false;
    }
}
