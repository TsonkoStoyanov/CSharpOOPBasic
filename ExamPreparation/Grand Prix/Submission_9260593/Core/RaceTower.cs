using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private Track track;

    private string currentWeather = "Sunny";

    private const double BoxTime = 20;

    private DriverFactory driverFactory;

    private TyreFactory tyreFactory;

    private int currentLap = 0;


    List<Driver> drivers;
    List<Driver> dnfDrivers;

    public bool HasEnd;

    public RaceTower()
    {
        drivers = new List<Driver>();
        driverFactory = new DriverFactory();
        tyreFactory = new TyreFactory();
        dnfDrivers = new List<Driver>();
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        track = new Track(lapsNumber, trackLength);
    }
    public void RegisterDriver(List<string> commandArgs)
    {
        string type = commandArgs[0];
        string name = commandArgs[1];
        int hp = int.Parse(commandArgs[2]);
        double fuelAmount = double.Parse(commandArgs[3]);

        commandArgs = commandArgs.Skip(4).ToList();

        var tyre = tyreFactory.CreateTyre(commandArgs);

        Car car = new Car(hp, fuelAmount, tyre);

        var driver = driverFactory.CreateDriver(type, name, car);

        drivers.Add(driver);

    }

    public Driver GetWiner()
    {
        var driver = drivers.OrderBy(d => d.TotalTime).First();

        return driver;
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string type = commandArgs[0];
        string driverName = commandArgs[1];
        var driver = drivers.FirstOrDefault(d => d.Name == driverName);

        if (type == "Refuel")
        {
            double fuelAmount = double.Parse(commandArgs[2]);
            driver.Refuel(fuelAmount);

        }
        else if (type == "ChangeTyres")
        {
            commandArgs = commandArgs.Skip(2).ToList();

            Tyre tyre = tyreFactory.CreateTyre(commandArgs);

            driver.Car.ChangeTyre(tyre);

        }

        driver.AddTime(BoxTime);
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        StringBuilder sb = new StringBuilder();

        int numbersOfLap = int.Parse(commandArgs[0]);

        if (numbersOfLap - currentLap > track.LapsNumber)
        {
            throw new ArgumentException($"There is no time! On lap {currentLap}.");
        }

        for (int i = 0; i < numbersOfLap; i++)
        {

            foreach (var driver in drivers)
            {
                driver.CompleteLap(track.LapLenght);

                if (driver.IsRacing == false)
                {
                    dnfDrivers.Add(driver);
                }
            }

            RemoveDnf();

            currentLap++;

            drivers = drivers.OrderBy(t => t.TotalTime).ToList();

            for (int j = 0; j < drivers.Count - 1; j++)
            {
                Driver frontDriver = drivers[j];
                Driver behindDriver = drivers[j + 1];

                var diffrence = Math.Abs(frontDriver.TotalTime - behindDriver.TotalTime);

                if (diffrence > 3 || !frontDriver.IsRacing || !behindDriver.IsRacing)
                {
                    continue;
                }

                if (frontDriver.GetType().Name == "AgressiveDriver" && frontDriver.Car.Tyre.GetType().Name == "UltrasoftTyre" &&
                    currentWeather == "Foggy" && diffrence <= 3)
                {
                    frontDriver.Crash();
                    dnfDrivers.Add(frontDriver);
                    continue;
                }

                if (frontDriver.GetType().Name == "EnduranceDriver" && frontDriver.Car.Tyre.GetType().Name == "HardTyre" &&
                        currentWeather == "Rainy" && diffrence <= 3)
                {
                    frontDriver.Crash();
                    dnfDrivers.Add(frontDriver);
                    continue;
                }

                if (diffrence < 2)
                {
                    sb.AppendLine($"{behindDriver.Name} has overtaken {frontDriver.Name} on lap {currentLap}.");
                    frontDriver.AddTime(2);
                    behindDriver.AddTime(-2);
                }

            }

            RemoveDnf();

            if (currentLap == track.LapsNumber)
            {
                HasEnd = true;
            }
        }


        return sb.ToString().TrimEnd();
    }



    public string GetLeaderboard()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Lap {currentLap}/{track.LapsNumber}");

        int position = 1;

        foreach (var driver in drivers.OrderBy(t => t.TotalTime))
        {
            sb.AppendLine($"{position++} {driver.Name} {driver.TotalTime:f3}");
        }

        foreach (var driver in Enumerable.Reverse(dnfDrivers))
        {
            sb.AppendLine($"{position++} {driver.Name} {driver.Dnf}");
        }

        return sb.ToString().TrimEnd();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        string wheather = commandArgs[0];

        currentWeather = wheather;
    }

    private void RemoveDnf()
    {
        drivers.RemoveAll(x => x.IsRacing == false);
    }


}
