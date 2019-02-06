using System.Collections.Generic;
using DungeonsAndCodeWizards.Items;

namespace DungeonsAndCodeWizards.Contracts
{
    public interface IBag
    {
        int Capacity { get; }

        int Load { get; }

        IReadOnlyCollection<Item> Items { get; }

        void AddItem(Item item);

        Item GetItem(string name);

    }
}