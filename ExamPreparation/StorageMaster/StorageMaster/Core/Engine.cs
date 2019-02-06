using System;
using System.Linq;

namespace StorageMaster
{
    public class Engine
    {
        private readonly StorageMaster storageMaster;

        public Engine()
        {
            this.storageMaster = new StorageMaster();
        }


        public void Run()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {

                try
                {
                    string result = this.ProcessCommand(input);
                    Console.WriteLine(result);
                }

                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");

                }
            }
        }

        private string ProcessCommand(string input)
        {
            string output = String.Empty;

            string[] InputArgs = input.Split();

            string command = InputArgs[0];
            string[] args = InputArgs.Skip(1).ToArray();

            switch (command)
            {
                case "AddProduct":
                {
                    var name = args[0];
                    var price = double.Parse(args[1]);

                    output = this.storageMaster.AddProduct(name, price);
                    break;
                }
                case "RegisterStorage":
                {
                    var type = args[0];
                    var name = args[1];

                    output = this.storageMaster.RegisterStorage(type, name);
                    break;
                }
                case "SelectVehicle":
                {
                    var storageName = args[0];
                    var garageSlot = int.Parse(args[1]);

                    output = this.storageMaster.SelectVehicle(storageName, garageSlot);
                    break;
                }
                case "LoadVehicle":
                {
                    var productNames = args;

                    output = this.storageMaster.LoadVehicle(productNames);
                    break;
                }
                case "SendVehicleTo":
                {
                    var sourceName = args[0];
                    var sourceGarageSlot = int.Parse(args[1]);
                    var destinationName = args[2];

                    output = this.storageMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName);
                    break;
                }
                case "UnloadVehicle":
                {
                    var sourceName = args[0];
                    var garageSlot = int.Parse(args[1]);

                    output = this.storageMaster.UnloadVehicle(sourceName, garageSlot);
                    break;
                }
                case "GetStorageStatus":
                {
                    var storageName = args[0];
                    output = this.storageMaster.GetStorageStatus(storageName);
                    break;
                }
            }

            return output;
        }
    }
}