﻿using _361Example.Models;
using System.Collections.Generic;

namespace _361Example.Engines
{
    public interface IUserEngine
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
