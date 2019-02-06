
using System;

public abstract class Provider
{
    private double energyOutput;

    protected Provider(string id, double energyOutput)
    {
        Id = id;
        EnergyOutput = energyOutput;
    }

    public string Id { get; }

    public double EnergyOutput
    {
        get => energyOutput;

        protected set
        {
            if (value < 0 || value > 10000)
            {
                throw new ArgumentException();
            }
            energyOutput = value;
        }
    }
}
