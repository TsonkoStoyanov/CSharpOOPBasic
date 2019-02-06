using System.Collections.Generic;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storages
{
    public class DistributionCenter : Storage
    {

        private const int capacity = 2;
        private const int garageSlots = 5;
        private static readonly Vehicle[] vehicles =
        {
            new Van(), new Van(), new Van()
        };

        public DistributionCenter(string name) : base(name, capacity, garageSlots, vehicles)
        {
        }
    }
}