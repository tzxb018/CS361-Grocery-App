using _361Example.Engines;
using _361Example.Models;
using GroceryApp.Tests.MockedAccessors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryApp.Tests.EngineTests
{
    /**
     * The purpose of this class is the unit testing of the methods within the ItemsEngine class.
     * This test class utilizes a MockedItemsAccessor in order to test only the code within the ItemsEngine
     * and not the methods within the ItemsAccessor class.
     * This test class uses Microsoft.VisualStudio.TestTools.UnitTesting.
     **/
    [TestClass]
    public class ItemsEngineTests
    {

        private readonly IItemsEngine itemsEngine;
        private readonly MockedItemsAccessor mockedItemsAccessor;

        //The ItemsEngineTests() constructor creates the MockedItemsAccessor and passes it as the IItemsAccessor argument into the ItemsEngine constructor
        public ItemsEngineTests()
        {
            mockedItemsAccessor = new MockedItemsAccessor();
            itemsEngine = new ItemsEngine(mockedItemsAccessor);
        }


        //Seeds the Mocked Accessor with test data using the SetState() method
        public void SeedItems()
        {
            mockedItemsAccessor.SetState(new List<Item>
            {
                new Item
                {
                    Id = 1,
                    Name = "Candy",
                    GroceryListId = 1
                },
                new Item
                {
                    Id = 2,
                    Name = "Juice",
                    GroceryListId = 1
                },
                new Item
                {
                    Id = 3,
                    Name = "Trash Bags",
                    GroceryListId = 2
                }
            });
        }


        [TestMethod]
        public void ItemsEngine_GetAllItems()
        {
            //Arrange: Seeds the Mocked Accessor's list of Items and creates the expected list of Items
            SeedItems();
            var expected = new List<Item>
            {
                new Item
                {
                    Id = 1,
                    Name = "Candy",
                    GroceryListId = 1
                },
                new Item
                {
                    Id = 2,
                    Name = "Juice",
                    GroceryListId = 1
                },
                new Item
                {
                    Id = 3,
                    Name = "Trash Bags",
                    GroceryListId = 2
                }
            };


            //Act: Calls the ItemsEngine GetAllItems() method which returns a list of all items
            var result = itemsEngine.GetAllItems().ToList();

          
            //Assert: Checks whether the expected and result lists are the exact same
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected.ElementAt(i), result.ElementAt(i), $"The Item at index {i} was retrieved incorrectly.");
            }
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ItemsEngine_GetAllItems_ExpectNullException()
        {
            //Arrange: Seed the Mocked Accessor's list of Items with a null list
            SeedItems();
            mockedItemsAccessor.SetState(null);


            //Act: Calls the ItemsEngine GetAllItems() method to return all Items
            itemsEngine.GetAllItems();


            //Assert: Handled by the ExpectedException attribute since no items should get returned
        }


        [TestMethod]
        public void ItemsEngine_DeleteItem()
        {
            //Arrange: Seeds the Mocked Accessor's list of Items
            SeedItems();
            var expected = new Item { 
                Id = 3, 
                Name = "Trash Bags", 
                GroceryListId = 2 
            };


            //Act: Calls the ItemsEngine DeleteItem() method, which should delete the item with the given id from the lists of Items
            var deletedItem = itemsEngine.DeleteItem(3);


            //Assert: Checks if the item deleted was returned, and if the list of Items no longer contains the deleted item
            Assert.AreEqual(expected, deletedItem, "An incorrect item was returned or no list was returned.");
            CollectionAssert.DoesNotContain(mockedItemsAccessor.GetState(), deletedItem, "The list still contains the item that needed to be deleted.");
        }


        [TestMethod]
        public void ItemsEngine_DeleteItem_InvalidId()
        {
            //Arrange: Seeds the Mocked Accessor's list of Items
            SeedItems();


            //Act: Calls the ItemsEngine DeleteItem() method with a given id for a non-existent item
            var deletedItem = itemsEngine.DeleteItem(0);


            //Assert: Checks that the returned item is null and no items were deleted from the list of items
            Assert.IsNull(deletedItem, "The deleted item is not null.");
            Assert.AreEqual(3, mockedItemsAccessor.GetState().Count(), "An item was deleted from the list of items.");
        }


        [TestMethod]
        public void ItemsEngine_GetListItems()
        {
            //Arrange: Seeds the Mocked Accessor's list of Items and creates the expected list of Items with shared GListId
            SeedItems();
            int groceryListId = 1;
            var expected = new List<Item>
            {
                new Item
                {
                    Id = 1,
                    Name = "Candy",
                    GroceryListId = 1
                },
                new Item
                {
                    Id = 2,
                    Name = "Juice",
                    GroceryListId = 1
                }
            };


            //Act: Calls the ItemsEngine GetListItems() method which returns a list of all items on a certain grocery list
            IEnumerable<Item> result = itemsEngine.GetListItems(groceryListId);


            //Assert: Checks whether the expected and result lists contain the same amount of lists and then if they are the same
            Assert.AreEqual(expected.Count(), result.Count(), "More than two results were returned");
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected.ElementAt(i), result.ElementAt(i), $"The Item at index {i} was retrieved incorrectly.");
            }
        }


        [TestMethod]
        public void ItemsEngine_GetItem()
        {
            //Arrange: Seeds the Mocked Accessor's list of Items and sets the expected list
            SeedItems();
            var expected = new Item { 
                Id = 2, 
                Name = "Juice", 
                GroceryListId = 1 
            };


            //Act: Calls the ItemsEngine GetItem() method to return the Item with id = 2
            var result = itemsEngine.GetItem(2);


            //Assert: Checks whether expected and result Item are the same
            Assert.AreEqual(expected, result, $"Item {result.Id} was returned. Item {expected.Id} was expected.");
        }


        [TestMethod]
        public void ItemsEngine_GetItem_ItemDoesntExist()
        {
            //Arrange: Seed the Mocked Accessor's list of Items
            SeedItems();


            //Act: Calls the GListEngine GetList() method with an Item Id not within the Mocked Accessor's list
            var result = itemsEngine.GetItem(7);


            //Assert: Checks that the result is null
            Assert.IsNull(result, "The result is not null.");
        }


        [TestMethod]
        public void ItemsEngine_UpdateItem()
        {
            //Arrange: Seed the Mocked Accessor's list of items and create an updated version of an Item
            SeedItems();
            var expected = new Item()
            {
                Id = 2,
                Name = "Cranberry Juice",
            };


            //Act: Calls the ItemsEngine UpdateItem() method and uses the GetState() method to retrieve the Mocked Accessor's list
            itemsEngine.UpdateItem(2, expected);
            List<Item> results = mockedItemsAccessor.GetState();


            //Assert: Checks if the Name for the Item was successfully updated
            Assert.AreEqual(expected.Name, results.ElementAt(2).Name, "The Item wasn't updated correctly.");
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ItemsEngine_InsertItem_ExpectNullException()
        {
            //Arrange: Seeds the Mocked Accessor's list of Items
            SeedItems();


            //Act: Insert a null Item using the ItemsEngine InsertItem() method
            itemsEngine.InsertItem(null);


            //Assert: Handled by the Expected Exception attribute
        }


        [TestMethod]
        public void ItemsEngine_InsertItem()
        {
            //Arrange: Seeds the Mocked Accessor's list of Items
            SeedItems();
            var item = new Item() { 
                Id = 4, 
                Name = "Vanilla Ice Cream"
            };


            //Act: Calls the ItemsEngine InsertItem() method to insert the "Vanilla Ice Cream" item
            var result = itemsEngine.InsertItem(item);


            //Assert: Checks whether the Item has been added to the list of Items
            Assert.AreEqual(item, result, "The item was not returned correctly.");
            CollectionAssert.Contains(mockedItemsAccessor.GetState(), item, "The list of Items does not contain the inserted Item.");
        }

    }
}
