using _361Example.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _361Example.Engines
{
    interface IUserEngine
    {
        IEnumerable<GroceryList> GetGroceryLists();
        IEnumerable<GroceryList> SortGroceryLists();
        GroceryList GetList(int id);
        GroceryList InsertList(GroceryList groceryList);
        void UpdateList(int id, GroceryList groceryList);
        GroceryList Delete(int id);
        bool ListExists(int id);
    }
}
