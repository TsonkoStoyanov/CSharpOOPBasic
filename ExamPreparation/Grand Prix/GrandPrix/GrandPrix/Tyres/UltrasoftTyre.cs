using System;


public class UltrasoftTyre : Tyre
{
    private double grip;

    public UltrasoftTyre(double hardness, double grip) : base("Ultrasoft", hardness)
    {
        this.Grip = grip;
    }

    public double Grip { get => grip; private set => grip = value; }


    public override double Degradation
    {
        get => Degradation;

        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException("Blown Tyre");
            }
            Degradation = value;
        }
    }
}
