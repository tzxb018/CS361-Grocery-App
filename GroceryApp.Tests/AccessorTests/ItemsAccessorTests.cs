using _361Example.Accessors;
using _361Example.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryApp.Tests
{
    [TestClass]
    public class ItemsAccessorTests
    {

        private readonly ItemsAccessor itemsAccessor;

        public ItemsAccessorTests()
        {
            itemsAccessor = new ItemsAccessor();
        }

        [TestMethod]
        public void ItemsAccessor_Exists()
        {
            var expectedOne = true;
            var expectedThree = true;
            var expectedFalse = false;

            var one = itemsAccessor.Exists(1);
            var three = itemsAccessor.Exists(3);
            var _false = itemsAccessor.Exists(-1);

            Assert.AreEqual(expectedOne, one, "DB was analyzed incorrectly");
            Assert.AreEqual(expectedThree, three, "DB was analyzed incorrectly");
            Assert.AreEqual(expectedFalse, _false, "DB was analyzed incorrectly");
        }

        [TestMethod]
        public void ItemsAccessor_GetItem()
        {
            // Arrange: setting the objects of all the expected lists in the database (the database is seeded with data from SQL script)
            var expected1 = new Item { Id = 1, Name = "Bread", Date = DateTime.Parse("2020-09-29"), Checkoff = false, Quantity = 3 };
            var expected2 = new Item { Id = 2, Name = "Milk", Date = DateTime.Parse("2020-09-14"), Checkoff = false, Quantity = 1 };
            var expected3 = new Item { Id = 7, Name = "Apples", Date = DateTime.Parse("2020-09-22"), Checkoff = true, Quantity = 6 };
            var expected4 = new Item { Id = 8, Name = "Carrots", Date = DateTime.Parse("2020-09-24"), Checkoff = true, Quantity = 2 };

            // Act: get the lists from the database by their IDs
            var result1 = itemsAccessor.Find(1);
            var result2 = itemsAccessor.Find(2);
            var result3 = itemsAccessor.Find(7);
            var result4 = itemsAccessor.Find(8);

            // Assert: using their item names and dates, we check to see if the database returned the expected results
            Assert.AreEqual(expected1, result1, expected1.Id + " " + expected1.Name + " was expected. " + result1.Id + " " + result1.Name + " was returned.");
            Assert.AreEqual(expected2, result2, expected2.Id + " " + expected2.Name + " was expected. " + result2.Id + " " + result2.Name + " was returned.");
            Assert.AreEqual(expected3, result3, expected3.Id + " " + expected3.Name + " was expected. " + result3.Id + " " + result3.Name + " was returned.");
            Assert.AreEqual(expected4, result4, expected4.Id + " " + expected4.Name + " was expected. " + result4.Id + " " + result4.Name + " was returned.");

        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ItemsAccessor_GetList_ElementDoesntExist()
        {
            // Arrange: The expected result should be null, since there is no item with ID = 10


            // Act: Calls the items Accessor Find() method on a item that doesn't exist
            var result = itemsAccessor.Find(1000000000);

            // Assert checks if the result is null
            Assert.AreEqual(null, result.Name, result.Id + " was returned. ");

        }

        [TestMethod]
        public void ItemsAccessor_GetAllItems()
        {
            var expected = new List<Item>
            {
                new Item
                {
                    Id = 1,
                    Name = "Bread",
                    Checkoff = false,
                    Date = DateTime.Parse("2020-09-29"),
                    Quantity = 3
                },
                new Item
                {
                    Id = 2,
                    Name = "Milk",
                    Checkoff = false,
                    Date = DateTime.Parse("2020-09-14"),
                    Quantity = 1
                },
                new Item
                {
                    Id = 3,
                    Name = "Toilet Paper",
                    Checkoff = false,
                    Date = DateTime.Parse("2020-09-06"),
                    Quantity = 1
                },
                new Item
                {
                    Id = 4,
                    Name = "Butter",
                    Checkoff = false,
                    Date = DateTime.Parse("2020-09-02"),
                    Quantity = 2
                },
                new Item
                {
                    Id = 5,
                    Name = "Bagels",
                    Checkoff = true,
                    Date = DateTime.Parse("2020-09-16"),
                    Quantity = 2
                },
                new Item
                {
                    Id = 6,
                    Name = "Lettuce",
                    Checkoff = true,
                    Date = DateTime.Parse("2020-09-18"),
                    Quantity = 4
                },
                new Item
                {
                    Id = 7,
                    Name = "Apples",
                    Checkoff = true,
                    Date = DateTime.Parse("2020-09-22"),
                    Quantity = 6
                },
                new Item
                {
                    Id = 8,
                    Name = "Carrots",
                    Checkoff = true,
                    Date = DateTime.Parse("2020-09-24"),
                    Quantity = 2
                }
            };

            var list = itemsAccessor.GetAllItems();

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected.ElementAt(i), list.ElementAt(i), $"Item with id = {i} was not retrieved correctly.");
            }

        }

        [TestMethod]
        public void ItemsAccessor_Delete()
        {
            //Arrange: The item to be deleted is within the database
<<<<<<< HEAD
            
            var item = new Item { Name = "Cabbage", Date = DateTime.Parse("2020-09-29"), Checkoff = false, Quantity = 1};
=======

            var item = new Item { Name = "Cabbage", Date = DateTime.Parse("2020-09-29"), Checkoff = false, Quantity = 1 };
>>>>>>> b2d212c1763d3d3ce6e6b419d3c640c41e214c96
            var removable = itemsAccessor.Insert(item);

            //Act: Calls the UserAccessor Delete() method to delete the account from the database
            var result = itemsAccessor.Delete(removable.Id);

            //Assert: Checks that the correct account was returned
            Assert.AreEqual(removable, result, "The incorrect item was deleted (ID should be " + removable.Id + ",not " + result.Id);

        }

        [TestMethod]
        public void ItemsAccessor_Delete_AccountNotInDB()
        {
            //Arrange: The item id 0 is not within the database

            //Act: Calls the ItemsAccessor Delete() method to delete the item from the database
            var result = itemsAccessor.Delete(0);

            //Assert: Checks that null was returned
            Assert.IsNull(result, "An item was unexpectedly deleted.");

        }

        [TestMethod]
        public void ItemsAccessor_Insert()
        {
            //Arrange: Create new Item to be inserted
            Item expected = new Item
            {
                Name = "Water Bottles",
                Checkoff = false,
                Date = DateTime.Parse("2020-10-06"),
                Quantity = 10
            };

            //Act: Insert the item into the database
            var result = itemsAccessor.Insert(expected);
            itemsAccessor.Remove(result);

            //Assert:
            Assert.AreEqual(expected, result, "The item was not inserted correctly");
        }


    }

}
