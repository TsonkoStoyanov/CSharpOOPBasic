
using System;
using P01_Vehicles.Vehicles;
using P01_Vehicles.Vehicles.Contracts;

namespace P01_Vehicles.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();


            IVehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));

            IVehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));

            IVehicle bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));



            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] input = Console.ReadLine().Split();

                    if (input[0] == "Drive")
                    {
                        if (input[1] == "Car")
                        {
                            car.Drive(double.Parse(input[2]));
                        }
                        else if (input[1] == "Truck")
                        {
                            truck.Drive(double.Parse(input[2]));
                        }
                        else if (input[1] == "Bus")
                        {
                            bus.IsVehicleEmpty = false;
                            bus.Drive(double.Parse(input[2]));
                        }
                    }
                    else if (input[0] == "Refuel")
                    {
                        if (input[1] == "Car")
                        {
                            car.Refuel(double.Parse(input[2]));
                        }
                        else if (input[1] == "Truck")
                        {
                            truck.Refuel(double.Parse(input[2]));
                        }
                        else if (input[1] == "Bus")
                        {
                            bus.Refuel(double.Parse(input[2]));
                        }
                    }
                    else if (input[0] == "DriveEmpty")
                    {
                        bus.IsVehicleEmpty = true;
                        bus.Drive(double.Parse(input[2]));
                    }

                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);

        }
    }
}