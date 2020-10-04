using _361Example.Models;
using System.Collections.Generic;

namespace _361Example.Accessors
{
    public interface IItemAccessor
    {
        IEnumerable<Item> GetAllItems();
        Item Find(int id);
        Item Insert(Item item);
        void Update(Item item);
        Item Delete(Item item);
        bool Exists(int id);
        int saveChanges();
    }
}
