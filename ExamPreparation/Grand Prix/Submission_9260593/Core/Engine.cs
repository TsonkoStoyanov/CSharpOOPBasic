using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private RaceTower raceTower;
    
    public Engine()
    {
        raceTower = new RaceTower();
    }

    internal void Run()
    {
        int numberOflaps = int.Parse(Console.ReadLine());
        int lengthOfTrack = int.Parse(Console.ReadLine());
        

        while (true)
        {
            string input = Console.ReadLine();

            try
            {
                raceTower.SetTrackInfo(numberOflaps, lengthOfTrack);
                CommandParser(input);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (raceTower.HasEnd)
            {
                break;
            }
        }

        Driver winer = raceTower.GetWiner();
        Console.WriteLine($"{winer.Name} wins the race for {winer.TotalTime:f3} seconds.");

    }

    private void CommandParser(string input)
    {
        string[] inputArgs = input.Split();

        string command = inputArgs[0];

        List<string> commandArgs = inputArgs.Skip(1).ToList();

        switch (command)
        {
            case "RegisterDriver":
                raceTower.RegisterDriver(commandArgs);
                break;

            case "Leaderboard":
                Console.WriteLine(raceTower.GetLeaderboard());
                break;

            case "CompleteLaps":

              var result = raceTower.CompleteLaps(commandArgs);

                if (result != string.Empty)
                {
                    Console.WriteLine(result);
                }
                break;

            case "Box":
                raceTower.DriverBoxes(commandArgs);
                break;

            case "ChangeWeather":
                raceTower.ChangeWeather(commandArgs);
                break;


        }
    }
}

