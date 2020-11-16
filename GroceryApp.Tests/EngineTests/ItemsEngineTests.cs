using _361Example.Engines;
using _361Example.Models;
using GroceryApp.Tests.MockedAccessors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GroceryApp.Tests
{
    [TestClass]
    public class ItemsEngineTests
    {

        private readonly IItemsEngine itemsEngine;
        private readonly MockedItemsAccessor mockedItemsAccessor;

        public ItemsEngineTests()
        {
            mockedItemsAccessor = new MockedItemsAccessor();
            itemsEngine = new ItemsEngine(mockedItemsAccessor);
        }


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
            IEnumerable<Item> result = itemsEngine.GetAllItems();


            //Assert: Checks whether the expected and result lists are the exact same
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(expected.ElementAt(i).Name, result.ElementAt(i).Name, "The Item was retrieved incorrectly.");
                Assert.AreEqual(expected.ElementAt(i).Id, result.ElementAt(i).Id, "The Item was retrieved incorrectly.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ItemsEngine_GetAllItems_ExpectNullException()
        {
            //Arrange: Seed the Mocked Accessor's list of Items with a null list
            SeedItems();
            mockedItemsAccessor.SetState(null);



            //Act: Calls the itemsEngine GetAllItems() method
            var result = itemsEngine.GetAllItems();

            //Assert is handled by the ExpectedException attribute since no items should get returned

        }




        [TestMethod]
        public void ItemsEngine_DeleteItem()
        {

            //Arrange: Seeds the Mocked Accessor's list of Items
            SeedItems();
            var expected = new Item { Id = 3, Name = "Trash Bags", GroceryListId = 2 };

            //Act: Calls the itemsEngine DeleteItem() method, which should delete the item with the given id from the lists of Items
            var deletedItem = itemsEngine.DeleteItem(3);

            //Assert: Checks if the item deleted was returned, and if the list of Items no longer contains the deleted item
            Assert.AreEqual(expected, deletedItem, "An incorrect item was returned or no list was returned.");
            CollectionAssert.DoesNotContain(mockedItemsAccessor.GetState(), deletedItem, "The list still contains the item that needed to be deleted.");

        }


        [TestMethod]
        public void ItemsEngine_DeleteList_InvalidId()
        {

            //Arrange: Seeds the Mocked Accessor's list of Items
            SeedItems();

            //Act: Calls the itemsEngine DeleteItem() method with a given id for a non-existent item
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

            //Act: Calls the ItemsEngine GetListItems() method which returns a list of all items
            IEnumerable<Item> result = itemsEngine.GetListItems(groceryListId);


            //Assert: Checks whether the expected and result lists contain the same amount of lists and then if they are the same
            Assert.AreEqual(expected.Count(), result.Count(), "More than two results were returned");
            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(expected.ElementAt(i).Name, result.ElementAt(i).Name, "The Item was retrieved incorrectly.");
                Assert.AreEqual(expected.ElementAt(i).Id, result.ElementAt(i).Id, "The Item was retrieved incorrectly.");
            }
        }


        [TestMethod]
        public void ItemsEngine_GetItem()
        {
            // Arrange: Seeds the Mocked Accessor's list of Items and sets the expected list
            SeedItems();
            var expected = new Item { Id = 2, Name = "Juice", GroceryListId = 1 };

            // Act: Calls the ItemsEngine GetItem() method
            var result = itemsEngine.GetItem(2);

            // Assert: Checks whether expected and result list are the same
            Assert.AreEqual(expected.Name, result.Name, result.Id + " was returned. " + expected.Id + " was expected.");
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ItemsEngine_GetItem_ItemDoesntExist()
        {
            //Arrange: Seed the Mocked Accessor's list of items to be null
            SeedItems();

            // Act: Calls the GListEngine GetList() method
            var result = itemsEngine.GetItem(7);

            // Assert checks that the result is null and is handled by the ExpectedException attribute on the test method
            Assert.AreEqual(null, result.Name, "the result is not null");

        }

        [TestMethod]
        public void ItemsEngine_UpdateItem()
        {
            //Arrange: Seed the Mocked Accessor's list of items and create an updated version of Juice
            SeedItems();
            var expected = new Item()
            {
                Id = 2,
                Name = "Cranberry Juice",

            };

            //Act: mockedGListAccessor.gLists isn't accessible outside of the class so a simple method from MockedGListAccessor is employed
            //to grab the GLists after they're updated.
            itemsEngine.UpdateItem(2, expected);
            List<Item> results = mockedItemsAccessor.GetAllItems().ToList();

            //Assert: Checks if the Name was successfully updated
            Assert.AreEqual(expected.Name, results.ElementAt(2).Name, "The GList wasn't updated correctly.");
        }





        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ItemsEngine_InsertItem_ExpectNullException()
        {
            //Arrange: Seeds the Mocked Accessors
            SeedItems();

            //Act: Insert a null list
            var result = itemsEngine.InsertItem(null);

            //Assert: Handled by the Expected Exception attribute
        }

        [TestMethod]
        public void ItemsEngine_InsertItem()
        {
            //Arrange: Seeds the Mocked Accessors
            SeedItems();
            Item item = new Item() { Id = 4, Name = "Vanilla Ice Cream" };


            //Act: Insert list with duplicate name and retrieve the list of lists
            var result = itemsEngine.InsertItem(item);

            //Assert: Checks whether the Brand New List has been added to the list of lists
            Assert.AreEqual(item.Name, result.Name, "The item wasn't inserted.");
        }
    }

}
