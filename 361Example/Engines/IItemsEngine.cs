using _361Example.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace _361Example.Controllers
{
    public interface IGListEngine
    {
        IEnumerable<Item> GetAllItems();
        Item GetItem(int id);
        IEnumerable<GroceryList> SortLists();
        Item InsertItem(Item item);
        Item UpdateItem(int id, Item item);
        Item DeleteItem(int id);
    }
}
