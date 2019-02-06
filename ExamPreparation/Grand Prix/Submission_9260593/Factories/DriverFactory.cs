
using System;
using System.Collections.Generic;
using System.Linq;

public class DriverFactory
{
    private Driver driver;

    public Driver CreateDriver(string type, string name, Car car)
    {
        if (type == "Aggressive")
        {
            driver = new AggressiveDriver(name, car);
        }
        else if (type == "Endurance")
        {
            driver = new EnduranceDriver(name, car);
        }
        else
        {
            throw new ArgumentException("Invalid driver type");
        }

        return driver;
    }

}

