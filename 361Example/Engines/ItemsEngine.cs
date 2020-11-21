using _361Example.Accessors;
using _361Example.Models;
using System.Collections.Generic;
using System.Linq;

namespace _361Example.Engines
{
    /**
     * The ItemsEngine class handles the business logic for
     * calling the methods of an IItemsAccessor to access the database's Items.
     **/
    public class ItemsEngine : IItemsEngine
    {

        private readonly IItemAccessor _itemsAccessor;

        public ItemsEngine(IItemAccessor itemAccessor)
        {
            _itemsAccessor = itemAccessor;
        }

        //Returns all Items
        public IEnumerable<Item> GetAllItems()
        {
            return _itemsAccessor.GetAllItems().ToList();
        }

        //Used for obtaining all of the items attributed to a specific grocery list
        //Returns List of items if successful, null if not
        public IEnumerable<Item> GetListItems(int groceryListId)
        {
            return _itemsAccessor.GetItems(groceryListId);
        }

        //Returns the Item with the given id, or null if no such Item exists
        public Item GetItem(int id)
        {
            if (_itemsAccessor.Exists(id))
            {
                return _itemsAccessor.Find(id);
            }
            return null;
        }

        //Inserts item into the database and returns the inserted Item
        //Returns null if unsuccessful
        public Item InsertItem(Item item)
        {
            _itemsAccessor.Insert(item);
            _itemsAccessor.SaveChanges();

            return item;
        }

        //Updates an Item in the database with the given item
        public Item UpdateItem(int id, Item item)
        {
            _itemsAccessor.Update(item);
            _itemsAccessor.SaveChanges();

            return item;
        }

        //Deletes the Item with the given id
        //Returns null if unsuccessful
        public Item DeleteItem(int id)
        {
            return _itemsAccessor.Delete(id);
        }

    }
}
