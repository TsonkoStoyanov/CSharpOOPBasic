using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storages
{
    public class Warehouse : Storage
    {
        private const int capacity = 10;
        private const int garageSlots = 10;

        private static readonly Vehicle[] vehicles =
        {
            new Semi(), new Semi(), new Semi()
        };

        public Warehouse(string name) : base(name, capacity, garageSlots, vehicles)
        {
        }
    }
}
