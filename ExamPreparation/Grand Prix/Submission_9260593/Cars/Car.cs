using System;


public class Car
{
    private const double tankMaximumCapacity = 160;

    private int hp;

    private double fuelAmount;

    private Tyre tyre;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        Hp = hp;
        FuelAmount = fuelAmount;
        Tyre = tyre;
    }

    public int Hp
    {
        get
        {
            return hp;
        }
        protected set
        {
            hp = value;
        }
    }

    public double FuelAmount
    {
        get
        {
            return fuelAmount;
        }

        set
        {

            fuelAmount = Math.Min(value, tankMaximumCapacity);
        }
    }
    public Tyre Tyre
    {
        get
        {
            return tyre;
        }

        protected set
        {
            tyre = value;
        }
    }

    internal void ChangeTyre(Tyre tyre)
    {
        this.Tyre = tyre;
    }
}

