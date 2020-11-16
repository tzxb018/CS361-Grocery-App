using _361Example.Accessors;
using _361Example.Models;
using System.Collections.Generic;
using System.Linq;

namespace _361Example.Engines
{
    public class ItemsEngine : IItemsEngine
    {

        private readonly IItemAccessor _itemsAccessor;

        public ItemsEngine(IItemAccessor itemAccessor)
        {
            _itemsAccessor = itemAccessor;
        }

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

        //The next four methods (excluding UpdateItem) will return null if unsuccessful
        public Item GetItem(int id)
        {
            if (_itemsAccessor.Exists(id))
            {
                return _itemsAccessor.Find(id);
            }
            return null;
        }

        public Item InsertItem(Item item)
        {
            _itemsAccessor.Insert(item);
            _itemsAccessor.SaveChanges();

            return item;
        }

        public Item UpdateItem(int id, Item item)
        {
            _itemsAccessor.Update(item);
            _itemsAccessor.SaveChanges();

            return item;
        }

        public Item DeleteItem(int id)
        {
            return _itemsAccessor.Delete(id);
        }


    }
}
