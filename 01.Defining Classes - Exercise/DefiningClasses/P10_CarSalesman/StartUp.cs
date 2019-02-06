using System;
using System.Collections.Generic;
using System.Linq;

namespace P10_CarSalesman
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            List<Engine> engines = new List<Engine>();

            int n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                string power = input[1];

                Engine engine = new Engine(model, power);

                if (input.Length >= 3)
                {
                    if (int.TryParse(input[2], out int result))
                    {
                        string displacement = input[2];
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        string efficiency = input[2];
                        engine.Efficiency = efficiency;
                    }
                    
                }
                if (input.Length == 4)
                {
                    string efficiency = input[3];
                    engine.Efficiency = efficiency;
                }

                engines.Add(engine);
            }

            n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                Engine engine = engines.FirstOrDefault(x => x.Model == input[1]);

                Car car = new Car(model, engine);

                if (input.Length >= 3)
                {
                    if (int.TryParse(input[2], out int result))
                    {
                        string weight = input[2];
                        car.Weight = weight;
                    }
                    else
                    {
                        string color = input[2];
                        car.Color = color;
                    }
                }
                if (input.Length == 4)
                {
                    string color = input[3];
                    car.Color = color;
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
