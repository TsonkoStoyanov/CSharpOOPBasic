using System;
using Minedraft.Models;

public abstract class Harvester : Unit
{
    private double oreOutput;

    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement) : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double OreOutput
    {
        get => oreOutput;

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }

            oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get => energyRequirement;

        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException();
            }
            energyRequirement = value;
        }
    }
}
