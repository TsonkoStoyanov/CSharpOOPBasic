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

            while (numberOflaps-- > 0)
            {
                string input = Console.ReadLine();

                try
                {
                    raceTower.SetTrackInfo(numberOflaps, lengthOfTrack);
                    CommandParser(input);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            
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
                    Console.WriteLine(raceTower.CompleteLaps(commandArgs));
                    break;

                case "ChangeWeather":
                    raceTower.ChangeWeather(commandArgs);
                    break;

           
            }
        }
    }

