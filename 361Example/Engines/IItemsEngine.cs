using _361Example.Models;
using System.Collections.Generic;

namespace _361Example.Engines
{
    public interface IItemsEngine
    {
        IEnumerable<Item> GetAllItems();

        Item GetItem(int id);

        Item InsertItem(Item item);

        Item UpdateItem(int id, Item item);
        Item DeleteItem(int id);

    }
}
