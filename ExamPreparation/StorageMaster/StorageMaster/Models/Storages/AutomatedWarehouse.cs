using System.Collections.Generic;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storages
{
    public class AutomatedWarehouse : Storage
    {
        private const int capacity = 1;
        private const int garageSlots = 2;

        private static readonly Vehicle[] vehicles =
        {
            new Truck()
        };


        public AutomatedWarehouse(string name) 
            : base(name, capacity, garageSlots, vehicles)
        {
        }
    }
}