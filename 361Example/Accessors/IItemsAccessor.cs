using _361Example.Models;
using System.Collections.Generic;

namespace _361Example.Accessors
{
    /**
     * The IItemsAccessor interface contains the method declarations for methods that must be defined
     * in any class whose purpose is to access Items. Likewise, any class that implements IItemsAccessor
     * should be fully capable of accessing Items.
     **/
    public interface IItemAccessor
    {
        //Retrieves all Items
        IEnumerable<Item> GetAllItems();

        //Retrieves all Items belonging to a certain grocery list
        IEnumerable<Item> GetItems(int groceryListId);

        //Finds and returns the Item with the given id, or null if no such Item exists
        Item Find(int id);

        //Inserts item into the database and returns the inserted Item
        Item Insert(Item item);

        //Updates the Item in the database with the same id as item to be the new version
        void Update(Item item);

        //Deletes the Item with the given id from the database and returns the deleted Item
        Item Delete(int id);

        //Returns true if an Item with the given id exists in the database, or false if not
        bool Exists(int id);

        //Saves any changes made to the database
        int SaveChanges();
    }
}
