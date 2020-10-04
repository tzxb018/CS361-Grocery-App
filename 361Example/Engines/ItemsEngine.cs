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
            _itemsAccessor.saveChanges();

            return item;
        }

        public Item UpdateItem(int id, Item item)
        {
            _itemsAccessor.Update(item);
            _itemsAccessor.saveChanges();

            return item;
        }

        public Item DeleteItem(int id)
        {
            var item = _itemsAccessor.Find(id);
            if (item != null)
            {
                _itemsAccessor.Delete(item);
                _itemsAccessor.saveChanges();
            }
            return item;
        }
    }
}
