using System;



public abstract class Tyre
{
    private const double DefaultStartDegradation = 100;

    private string name;

    private double hardness;

    private double degradation;

    protected Tyre(string name, double hardness)
    {
        Name = name;
        Hardness = hardness;
        Degradation = DefaultStartDegradation;
    }

    public string Name
    {
        get
        {
            return name;
        }

        protected set
        {
            name = value;
        }
    }
    public double Hardness
    {
        get
        {
            return hardness;
        }

        protected set
        {
            hardness = value;
        }
    }
    public virtual double Degradation
    {
        get
        {
            return degradation;
        }

        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Blown Tyre");
            }
            degradation = value;
        }
    }
}
