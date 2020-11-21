using _361Example.Accessors;
using _361Example.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryApp.Tests.AccessorTests
{
    /**
     * The purpose of this class is the unit testing of the methods within the ItemsAccessor class.
     * This class tests that the ItemsAccessor is able to effectively read and write data to the
     * GroceryWebApp database.
     * These tests are designed to pass in the case that the test data
     * from GroceryWebApp_TestData_InsertionScript.sql is within the database.
     * This test class uses Microsoft.VisualStudio.TestTools.UnitTesting.
     **/
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
            //Arrange: Database is seeded with data from the SQL script
     

            //Act: Calls the ItemsAccessor Exists() method for two Item IDs within the DB and one not in the DB
            var shouldBeTrue = itemsAccessor.Exists(1);
            var shouldBeTrueAlso = itemsAccessor.Exists(3);
            var shouldBeFalse = itemsAccessor.Exists(-1);


            //Assert: Checks whether the Exists() method returned true or false correctly for the given IDs
            Assert.IsTrue(shouldBeTrue, "Method incorrectly returns that User with ID = 1 is not within the DB.");
            Assert.IsTrue(shouldBeTrueAlso, "Method incorrectly returns that User with ID = 3 is not within the DB.");
            Assert.IsFalse(shouldBeFalse, "Method incorrectly returns that User with ID = -1 is within the DB.");
        }


        [TestMethod]
        public void ItemsAccessor_Find_WithId()
        {
            //Arrange: Creating the expected Item objects of some Items in the database (the database is seeded with data from SQL script)
            var expected1 = new Item { 
                Id = 1, 
                Name = "Bread", 
                Date = DateTime.Parse("2020-09-29"), 
                Checkoff = false, 
                Quantity = 3,
                GroceryListId = 1
            };
            var expected2 = new Item { 
                Id = 2, 
                Name = "Milk", 
                Date = DateTime.Parse("2020-09-14"), 
                Checkoff = false, 
                Quantity = 1,
                GroceryListId = 1
            };
            var expected3 = new Item { 
                Id = 7, 
                Name = "Apples", 
                Date = DateTime.Parse("2020-09-22"), 
                Checkoff = true, 
                Quantity = 6,
                GroceryListId = 3
            };
            var expected4 = new Item { 
                Id = 8, 
                Name = "Carrots", 
                Date = DateTime.Parse("2020-09-24"), 
                Checkoff = true, 
                Quantity = 2,
                GroceryListId = 4
            };


            //Act: Retrieves the Items from the database by their IDs using the ItemsAccessor Find() method
            var result1 = itemsAccessor.Find(1);
            var result2 = itemsAccessor.Find(2);
            var result3 = itemsAccessor.Find(7);
            var result4 = itemsAccessor.Find(8);


            //Assert: Using their Item names and dates, check to see if the database returned the expected results
            Assert.AreEqual(expected1, result1, $"Item with ID = {expected1.Id}, Name = {expected1.Name} was expected. " +
                $"Item with ID = {result1.Id}, Name = {result1.Name} was returned.");
            Assert.AreEqual(expected2, result2, $"Item with ID = {expected2.Id}, Name = {expected2.Name} was expected. " +
               $"Item with ID = {result2.Id}, Name = {result2.Name} was returned.");
            Assert.AreEqual(expected3, result3, $"Item with ID = {expected3.Id}, Name = {expected3.Name} was expected. " +
               $"Item with ID = {result3.Id}, Name = {result3.Name} was returned.");
            Assert.AreEqual(expected4, result4, $"Item with ID = {expected4.Id}, Name = {expected4.Name} was expected. " +
                $"Item with ID = {result4.Id}, Name = {result4.Name} was returned.");
        }


        [TestMethod]
        public void ItemsAccessor_Find_WithId_ElementDoesntExist()
        {
            //Arrange: The expected result should be null, since there is no Item with ID = 100000 in the DB


            //Act: Calls the ItemsAccessor Find() method on an Item that doesn't exist in the DB
            var result = itemsAccessor.Find(100000);


            //Assert: Checks if the result is null
            Assert.IsNull(result, $"An Item was incorrectly returned.");
        }


        [TestMethod]
        public void ItemsAccessor_GetAllItems()
        {
            //Arrange: Creates an expected list of Items (the Items are within the DB due to the SQL script)
            var expected = new List<Item>
            {
                new Item
                {
                    Id = 1,
                    Name = "Bread",
                    Checkoff = false,
                    Date = DateTime.Parse("2020-09-29"),
                    Quantity = 3,
                    GroceryListId = 1
                },
                new Item
                {
                    Id = 2,
                    Name = "Milk",
                    Checkoff = false,
                    Date = DateTime.Parse("2020-09-14"),
                    Quantity = 1,
                    GroceryListId = 1
                },
                new Item
                {
                    Id = 3,
                    Name = "Toilet Paper",
                    Checkoff = false,
                    Date = DateTime.Parse("2020-09-06"),
                    Quantity = 1,
                    GroceryListId = 1
                },
                new Item
                {
                    Id = 4,
                    Name = "Butter",
                    Checkoff = false,
                    Date = DateTime.Parse("2020-09-02"),
                    Quantity = 2,
                    GroceryListId = 1
                },
                new Item
                {
                    Id = 5,
                    Name = "Bagels",
                    Checkoff = true,
                    Date = DateTime.Parse("2020-09-16"),
                    Quantity = 2,
                    GroceryListId = 2
                },
                new Item
                {
                    Id = 6,
                    Name = "Lettuce",
                    Checkoff = true,
                    Date = DateTime.Parse("2020-09-18"),
                    Quantity = 4,
                    GroceryListId = 2
                },
                new Item
                {
                    Id = 7,
                    Name = "Apples",
                    Checkoff = true,
                    Date = DateTime.Parse("2020-09-22"),
                    Quantity = 6,
                    GroceryListId = 3
                },
                new Item
                {
                    Id = 8,
                    Name = "Carrots",
                    Checkoff = true,
                    Date = DateTime.Parse("2020-09-24"),
                    Quantity = 2,
                    GroceryListId = 4
                }
            };


            //Act: Calls the ItemsAccessor GetAllItems() method to retrieve all Items from the DB
            var result = itemsAccessor.GetAllItems().ToList();


            //Assert: Checks whether each Item in the expected and result list are equal
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected.ElementAt(i), result.ElementAt(i), $"Item with id = {i + 1} was not retrieved correctly.");
            }
        }


        [TestMethod]
        public void ItemsAccessor_Delete()
        {
            //Arrange: The Item to be deleted is put into the database         
            var item = new Item { 
                Name = "Cabbage", 
                Date = DateTime.Parse("2020-09-29"), 
                Checkoff = false, 
                Quantity = 1, 
                GroceryListId = 1
            };
            var removable = itemsAccessor.Add(item).Entity;
            itemsAccessor.SaveChanges();


            //Act: Calls the ItemsAccessor Delete() method to delete the Item from the database
            var result = itemsAccessor.Delete(removable.Id);


            //Assert: Checks that the correct Item was deleted
            Assert.AreEqual(removable, result, "The incorrect Item was deleted.");
        }


        [TestMethod]
        public void ItemsAccessor_Delete_ItemNotInDB()
        {
            //Arrange: The Item with ID = 0 is not within the database


            //Act: Calls the ItemsAccessor Delete() method to delete the Item with ID = 0 from the database
            var result = itemsAccessor.Delete(0);


            //Assert: Checks that null was returned
            Assert.IsNull(result, "An Item was unexpectedly deleted from the DB.");
        }


        [TestMethod]
        public void ItemsAccessor_Insert()
        {
            //Arrange: Create new Item to be inserted into the DB
            Item expected = new Item
            {
                Name = "Water Bottles",
                Checkoff = false,
                Date = DateTime.Parse("2020-10-06"),
                Quantity = 10,
                GroceryListId = 1
            };


            //Act: Insert the Item into the database by calling the ItemsAccessor Insert() method
            var result = itemsAccessor.Insert(expected);
            itemsAccessor.Remove(result);
            itemsAccessor.SaveChanges();


            //Assert: Checks whether the expected and result Item are equal
            Assert.AreEqual(expected, result, "The Item was not inserted correctly.");
        }


        [TestMethod]
        public void ItemsAccessor_GetItems()
        {
            //Arrange: Creates an expected list of Items with GroceryListId = 2
            var expected = new List<Item>
            {
                new Item
                {
                    Id = 5,
                    Name = "Bagels",
                    Checkoff = true,
                    Date = DateTime.Parse("2020-09-16"),
                    Quantity = 2,
                    GroceryListId = 2
                },
                new Item
                {
                    Id = 6,
                    Name = "Lettuce",
                    Checkoff = true,
                    Date = DateTime.Parse("2020-09-18"),
                    Quantity = 4,
                    GroceryListId = 2
                }
            };


            //Act: Calls the ItemAccessor GetItems() method to retrieve the Items with GroceryListId = 2
            var result = itemsAccessor.GetItems(2).ToList();


            //Assert: Checks that only the Items with GroceryListId = 2 were retrieved
            CollectionAssert.AreEquivalent(expected, result, "An Item without GroceryListId = 2 was retrieved.");
        }


        [TestMethod]
        public void ItemsAccessor_GetItems_InvalidGroceryListId()
        {
            //Arrange: No Items exist in the DB with the GroceryListId = 0


            //Act: Calls the ItemAccessor GetItems() method to retrieve the Items with GroceryListId = 0
            var result = itemsAccessor.GetItems(0).ToList();


            //Assert: Checks that the retrieved list is empty
            Assert.AreEqual(0, result.Count, "Items were retrieved from the database.");
        }

    }
}
