using _361Example.Models;
using System.Collections.Generic;

namespace _361Example.Engines
{
    /**
     * The IItemsEngine interface contains the method declarations for methods that
     * must be defined by any class whose purpose is using an IItemsAccessor to access
     * the database's Items and including business logic to access appropriately.
     **/
    public interface IItemsEngine
    {
        //Returns all Items
        IEnumerable<Item> GetAllItems();

        //Returns all Items for a given groceryListId
        IEnumerable<Item> GetListItems(int groceryListId);

        //Returns the Item with the given id
        Item GetItem(int id);

        //Inserts item, and returns the inserted Item
        Item InsertItem(Item item);

        //Updates the Item with the same id as item to be the new version item, and returns the updated Item
        Item UpdateItem(int id, Item item);

        //Deletes the Item with the given id, and returns the deleted Item
        Item DeleteItem(int id);
    }
}
