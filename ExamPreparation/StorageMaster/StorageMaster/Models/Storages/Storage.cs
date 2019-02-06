using System;
using System.Collections.Generic;
using System.Linq;
using StorageMaster.Models.Vehicles;
namespace StorageMaster.Models.Storages
{
    public abstract class Storage
    {
        private readonly List<Product> products;
        private readonly Vehicle[] garage;

        public Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;

            this.garage = new Vehicle[garageSlots];
            this.products = new List<Product>();
            this.InitializeGarage(vehicles);
        }

        public string Name { get; }
        public int Capacity { get; }
        public int GarageSlots { get; }

        public bool IsFull => this.Products.Sum(x => x.Weight) >= this.Capacity;

        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();

        public IReadOnlyCollection<Vehicle> Garage => Array.AsReadOnly(this.garage);


        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= garage.Length)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }

            if (garage[garageSlot] == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            Vehicle vehicle = garage[garageSlot];



            return vehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = GetVehicle(garageSlot);

            if (!(deliveryLocation.garage.Any(x => x == null)))
            {
                throw new InvalidOperationException("No room in garage!");
            }

            garage[garageSlot] = null;


            int result = AddVehicle(vehicle, deliveryLocation);

            return result;

        }

        private int AddVehicle(Vehicle vehicle, Storage deliveryLocation)
        {
            int result = 0;

            for (int i = 0; i < deliveryLocation.garage.Length; i++)
            {
                if (deliveryLocation.garage[i] == null)
                {
                    deliveryLocation.garage[i] = vehicle;
                    result = i;
                    break;
                }

                if (result != 0)
                {
                    break;
                }
            }

            return result;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            var vehicle = GetVehicle(garageSlot);

            var unloadedProductCount = 0;
            while (!vehicle.IsEmpty && !this.IsFull)
            {
                var crate = vehicle.Unload();
                this.products.Add(crate);

                unloadedProductCount++;
            }

            return unloadedProductCount;
        }

        private void InitializeGarage(IEnumerable<Vehicle> vehicles)
        {
            var garageSlot = 0;

            foreach (var vehicle in vehicles)
            {
                this.garage[garageSlot++] = vehicle;
            }
        }

    }
}