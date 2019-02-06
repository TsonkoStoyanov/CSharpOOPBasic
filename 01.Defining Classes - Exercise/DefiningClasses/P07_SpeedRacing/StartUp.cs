using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_SpeedRacing
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<Car> cars = new HashSet<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();

                string model = inputArgs[0];

                double fuelAmount = double.Parse(inputArgs[1]);

                double fuelPerKm = double.Parse(inputArgs[2]);

                Car car = new Car(model, fuelAmount, fuelPerKm);

                cars.Add(car);
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] args = input.Split();

                //Drive BMW-M2 56

                Car car = cars.FirstOrDefault(x => x.Model == args[1]);
                int distanceTotravel = int.Parse(args[2]);

                if (car != null)
                {
                    car.Drive(distanceTotravel);
                }

            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

    }
}
