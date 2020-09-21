using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _361Example.Controllers
{
    public interface IGListAccessor
    {
        IEnumerable<Item> GetAllItems();
        Item Find(int id);
        Item Insert(Item item);
        void Update(Item item);
        Item Delete(Item item);
        bool Exists(int id);
    }
}
