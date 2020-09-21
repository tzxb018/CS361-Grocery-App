using _361Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _361Example.Accessors
{
    interface IUserAccessor
    {
        IEnumerable<GroceryList> GetGroceryLists();
        GroceryList Find(int id);
        GroceryList Insert(GroceryList groceryList);
        void Update(GroceryList groceryList);
        GroceryList Delete(GroceryList groceryList);
        bool ListExists(int id);
    }
}
