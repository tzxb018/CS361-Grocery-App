using _361Example.Accessors;
using _361Example.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace GroceryApp.Tests
{
    [TestClass]
    public class ItemsAccessorTests
    {

        private readonly ItemsAccessor itemsAccessor;
        private object expected;

        public ItemsAccessorTests()
        {
            itemsAccessor = new ItemsAccessor();
        }

        [TestMethod]
        public void ItemsAccessor_Exists()
        {
            var expectedOne = true;
            var expectedThree = true;
            var expectedTen = false;

            var one = itemsAccessor.Exists(1);
            var three = itemsAccessor.Exists(3);
            var ten = itemsAccessor.Exists(10);

            Assert.AreEqual(expectedOne, one, "DB was analyzed incorrectly");
            Assert.AreEqual(expectedThree, three, "DB was analyzed incorrectly");
            Assert.AreEqual(expectedTen, ten, "DB was analyzed incorrectly");
        }

        [TestMethod]
        public void ItemsAccessor_GetItem()
        {
            // Arrange: setting the objects of all the expected lists in the database (the database is seeded with data from SQL script)
            var expected1 = new Item { Id = 1, Name = "Bread", Date = DateTime.Parse("2020-09-29"), Checkoff = false };
            var expected2 = new Item { Id = 2, Name = "Milk", Date = DateTime.Parse("2020-09-14"), Checkoff = false };
            var expected3 = new Item { Id = 7, Name = "Apples", Date = DateTime.Parse("2020-09-22"), Checkoff = true };
            var expected4 = new Item { Id = 8, Name = "Carrots", Date = DateTime.Parse("2020-09-24"), Checkoff = true };

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
            var result = itemsAccessor.Find(10);

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
                    Date = DateTime.Parse("2020-09-29")
                },
                new Item
                {
                    Id = 2,
                    Name = "Milk",
                    Checkoff = false,
                    Date = DateTime.Parse("2020-09-14")
                },
                new Item
                {
                    Id = 3,
                    Name = "Toilet Paper",
                    Checkoff = false,
                    Date = DateTime.Parse("2020-09-06")
                },
                new Item
                {
                    Id = 4,
                    Name = "Butter",
                    Checkoff = false,
                    Date = DateTime.Parse("2020-09-02")
                },
                new Item
                {
                    Id = 5,
                    Name = "Bagels",
                    Checkoff = true,
                    Date = DateTime.Parse("2020-09-16")
                },
                new Item
                {
                    Id = 6,
                    Name = "Lettuce",
                    Checkoff = true,
                    Date = DateTime.Parse("2020-09-18")
                },
                new Item
                {
                    Id = 7,
                    Name = "Apples",
                    Checkoff = true,
                    Date = DateTime.Parse("2020-09-22")
                },
                new Item
                {
                    Id = 8,
                    Name = "Carrots",
                    Checkoff = true,
                    Date = DateTime.Parse("2020-09-24")
                }
            };
        }

        [TestMethod]
        public void ItemsAccessor_Delete()
        {
            //Arrange: The item to be deleted is within the database
            var item = new Item { Id = 9, Name = "Cabbage", Date = DateTime.Parse("2020-09-29"), Checkoff = false };

            //Act: Calls the UserAccessor Delete() method to delete the account from the database
            var result = itemsAccessor.Delete(1);

            //Assert: Checks that the correct account was returned
            Assert.AreEqual(item, result, "The incorrect item was deleted.");

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
                Date = DateTime.Parse("2020-10-06")
            };

            //Act: Insert the item into the database
            var result = itemsAccessor.Insert(expected);

            //Assert:
            Assert.AreEqual(expected, result, "The item was not inserted correctly");
        }
    }

}
