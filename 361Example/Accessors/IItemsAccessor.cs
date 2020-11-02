using _361Example.Models;
using System.Collections.Generic;

namespace _361Example.Accessors
{
    public interface IItemAccessor
    {
        IEnumerable<Item> GetAllItems();
        IEnumerable<Item> GetItems(int groceryListId);
        Item Find(int id);
        Item Insert(Item item);
        void Update(Item item);
        Item Delete(int id);
        bool Exists(int id);
        int SaveChanges();
    }
}
