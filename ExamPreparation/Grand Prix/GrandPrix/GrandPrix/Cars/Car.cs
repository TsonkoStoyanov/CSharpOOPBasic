using System;


public class Car
{
    private const int tankMaximumCapacity = 160;
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

        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }


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
}

