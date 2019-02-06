using System;
using System.Collections.Generic;
using System.Linq;

namespace P08_RawData
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
    
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                List<Tire> tires = new List<Tire>();

                string[] input = Console.ReadLine().Split();

                string model = input[0];

                int engineSpeed = int.Parse(input[1]);

                int enginePower = int.Parse(input[2]);

                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];

                Cargo cargo = new Cargo(cargoWeight, cargoType);

                for (int j = 5; j < input.Length - 1; j += 2)
                {
                    double tirePressure = double.Parse(input[j]);
                    int tireAge = int.Parse(input[j + 1]);

                    Tire tire = new Tire(tirePressure, tireAge);

                    tires.Add(tire);
                }

                Car car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            string type = Console.ReadLine();
            
            List<Car> result = new List<Car>();

            if (type == "fragile")
            {
                result = cars.Where(x => x.Cargo.CargoType == type && x.Tires.Any(s=>s.TirePressure < 1)).ToList();
            }
            else
            {
                result = cars.Where(x => x.Cargo.CargoType == type && x.Engine.EnginePower > 250).ToList();
            }

            foreach (var car in result)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
