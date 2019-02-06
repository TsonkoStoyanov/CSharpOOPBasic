using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    public class RawData
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = parameters[0];

                int engineSpeed = int.Parse(parameters[1]);
                int enginePower = int.Parse(parameters[2]);

                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(parameters[3]);
                string cargoType = parameters[4];

                Cargo cargo = new Cargo(cargoWeight, cargoType);

                for (int j = 0; j < 8; j += 2)
                {
                    double tire1Pressure = double.Parse(parameters[5 + j]);
                    int tire1age = int.Parse(parameters[6 + j]);
                }



            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.cargoType == "fragile" && x.tires.Any(y => y.Key < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.cargoType == "flamable" && x.enginePower > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }
    }
}