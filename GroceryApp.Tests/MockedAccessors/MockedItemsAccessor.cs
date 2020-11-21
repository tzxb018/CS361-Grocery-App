using System.Collections.Generic;
using System.Linq;
using _361Example.Accessors;
using _361Example.Models;

namespace GroceryApp.Tests.MockedAccessors
{
    /**
     * The purpose of this class is to act as a Mock Accessor to be used in the ItemsEngine during unit testing
     * in the ItemsEngineTests class.
     * The MockedItemsAccessor implements the IItemsAccessor, so it can be passed as an argument in the
     * ItemsEngine constructor.
     * The MockedItemsAccessor uses a List of Items to act in place of the database in the regular ItemsAccessor.
     **/
    public class MockedItemsAccessor : IItemAccessor
    {

        private List<Item> items;

        public MockedItemsAccessor()
        {
            items = new List<Item>();
        }

        //Returns all Items
        public IEnumerable<Item> GetAllItems()
        {
            return items;
        }

        //Returns all Items for a specific grocery list
        public IEnumerable<Item> GetItems(int groceryListId)
        {
            return items.FindAll(it => it.GroceryListId == groceryListId);
        }

        //Returns the Item with the specified id
        public Item Find(int id)
        {
            return items.FirstOrDefault(it => it.Id == id);
        }

        //Inserts the specified Item into the List of Items
        public Item Insert(Item item)
        {
            var max = items.Max(it => it.Id);
            item.Id = max + 1;
            items.Add(item);
            return item;
        }

        //Updates the specified Item by removing the original and adding the new Item
        public void Update(Item item)
        {
            items.RemoveAll(it => it.Id == item.Id);
            items.Add(item);
        }

        //Deletes the Item with the specified id from the List of Items
        public Item Delete(int id)
        {
            var item = Find(id);
            items.Remove(item);
            return item;
        }

        //Returns true if the Item with the specified id exists within the List of Items, and false if it does not
        public bool Exists(int id)
        {
            return items.Any(it => it.Id == id);
        }

        //Method is required by the IItemsAccessor; in the regular accessor, saves changes made to the database
        public int SaveChanges()
        {
            return 0;
        }

        //Helper method for the MockedItemsAccessor that sets the List of Items to a new specified state
        public void SetState(List<Item> newState)
        {
            items = newState;
        }

        //Helper method for the MockedItemsAccessor that returns the List of Items
        public List<Item> GetState()
        {
            return items;
        }

    }
}
