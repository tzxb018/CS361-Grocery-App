using _361Example.Accessors;
using _361Example.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryApp.Tests.AccessorTests
{
    /**
     * The purpose of this class is the unit testing of the methods within the GListAccessor class.
     * This class tests that the GListAccessor is able to effectively read and write data to the
     * GroceryWebApp database.
     * These tests are designed to pass in the case that the test data
     * from GroceryWebApp_TestData_InsertionScript.sql is within the database.
     * This test class uses Microsoft.VisualStudio.TestTools.UnitTesting.
     **/
    [TestClass]
    public class GListAccessorTests
    {

        private readonly GListAccessor gListAccessor;

        public GListAccessorTests()
        {
            gListAccessor = new GListAccessor();
        }


        [TestMethod]
        public void GListAccessor_Exists()
        {
            //Arrange: Database is seeded with data from the SQL script


            //Act: Calls the GListAccessor Exists() method for two GList IDs within the DB and one not in the DB
            var shouldBeTrue = gListAccessor.Exists(1);
            var shouldBeTrueAlso = gListAccessor.Exists(3);
            var shouldBeFalse = gListAccessor.Exists(-1);


            //Assert: Checks whether the Exists() method returned true or false correctly for the given IDs
            Assert.IsTrue(shouldBeTrue, "DB was analyzed incorrectly");
            Assert.IsTrue(shouldBeTrueAlso, "DB was analyzed incorrectly");
            Assert.IsFalse(shouldBeFalse, "DB was analyzed incorrectly");
        }


        [TestMethod]
        public void GListAccessor_Find_WithId()
        {
            //Arrange: Creates the expected GList objects of some of the GLists in the database (the database is seeded with data from SQL script)
            var expected1 = new GList { ListName = "First List", Id = 1, AccountId = 1};
            var expected2 = new GList { ListName = "Sunday List", Id = 2, AccountId = 1};
            var expected3 = new GList { Id = 3, ListName = "Groceries", AccountId = 2};
            var expected4 = new GList { Id = 4, ListName = "Food", AccountId = 3};


            //Act: Retrieves the GLists from the database by their IDs using the GListAccessor Find() method
            var result1 = gListAccessor.Find(1);
            var result2 = gListAccessor.Find(2);
            var result3 = gListAccessor.Find(3);
            var result4 = gListAccessor.Find(4);


            //Assert: Using their GList names and id, check to see if the database returned the expected results
            Assert.AreEqual(expected1, result1, $"GList with ID = {expected1.Id}, ListName = {expected1.ListName} was expected." +
                $"GList with ID = {result1.Id}, ListName = {result1.ListName} was returned.");
            Assert.AreEqual(expected2, result2, $"GList with ID = {expected2.Id}, ListName = {expected2.ListName} was expected." +
                $"GList with ID = {result2.Id}, ListName = {result2.ListName} was returned.");
            Assert.AreEqual(expected3, result3, $"GList with ID = {expected3.Id}, ListName = {expected3.ListName} was expected." +
                $"GList with ID = {result3.Id}, ListName = {result3.ListName} was returned.");
            Assert.AreEqual(expected4, result4, $"GList with ID = {expected4.Id}, ListName = {expected4.ListName} was expected." +
                $"GList with ID = {result4.Id}, ListName = {result4.ListName} was returned.");
        }


        [TestMethod]
        public void GListAccessor_Find_WithId_ElementDoesntExist()
        {
            //Arrange: The expected result should be null, since there is no list with ID = 0


            //Act: Calls the GListAccessor Find() for a GList with ID = 0
            var result = gListAccessor.Find(0);


            //Assert: Checks if the result is null
            Assert.IsNull(result, $"GList that was returned is not null.");
        }


        [TestMethod]
        public void GListAccessor_Delete()
        {
            //Arrange: The GList to be deleted is within the database
            GList gList = new GList { ListName = "MY LIST", Date = DateTime.Parse("2020-09-29"), AccountId = 1 };
            GList removable = gListAccessor.Insert(gList);


            //Act: Calls the GListAccessor Delete() method to delete the GList from the database
            var result = gListAccessor.Delete(removable.Id);


            //Assert: Checks that the correct GList was returned
            Assert.AreEqual(gList, result, "The incorrect GList was deleted.");
        }


        [TestMethod]
        public void GListAccessor_Delete_GListNotInDB()
        {
            //Arrange: The GList with ID = -1 is not within the database


            //Act: Calls the GListAccessor Delete() method to delete the GList from the database
            var result = gListAccessor.Delete(-1);


            //Assert: Checks that null was returned
            Assert.IsNull(result, "A GList was unexpectedly deleted.");
        }


        [TestMethod]
        public void GListAccessor_GetAllGLists()
        {
            //Arrange: Creates an expected list of GLists that match (the GLists are within the DB due to the SQL script)
            var expected = new List<GList>
            {
                new GList
                {
                    Id = 1,
                    ListName = "First List"
                },
                 new GList
                {
                    Id = 2,
                    ListName = "Sunday List"
                },
                 new GList
                {
                    Id = 3,
                    ListName = "Groceries"
                },
                 new GList
                {
                    Id = 4,
                    ListName = "Food"
                }
            };


            //Act: Calls the GListAccessor GetAllGLists() method to retrieve all GLists from the DB
            var result = gListAccessor.GetAllGLists();


            //Assert: Checks that each expected and result GList has the same name and id
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected.ElementAt(i).ListName, result.ElementAt(i).ListName, "The GList was retrieved incorrectly.");
                Assert.AreEqual(expected.ElementAt(i).Id, result.ElementAt(i).Id, "The GList was retrieved incorrectly.");
            }
        }


        [TestMethod]
        public void GListAccessor_Insert()
        {
            //Arrange: Create a new GList to be inserted into the DB 
            GList expected = new GList { ListName = "Inserted List", Date = DateTime.Parse("2020-09-29"), AccountId = 1 };
            

            //Act: Insert the GList into the DB using the GListAccessor Insert() method
            var result = gListAccessor.Insert(expected);
            gListAccessor.Delete(result.Id);


            //Assert: Checks that the expected GList was inserted correctly by comparing the expected and result GLists
            Assert.AreEqual(expected, result, "The grocery list was inserted incorrectly");
        }


        [TestMethod]
        public void GListAccessor_Update_NewTimestamp()
        {
            //Arrange: Create a new updated GList to replace the original GList
            DateTime dateTime = DateTime.UtcNow;
            GList expected = new GList { ListName = "First List", AccountId = 1, Id = 1, Date = dateTime };

            //Act: Call the GListAccessor Update() method to update the GList in the DB
            gListAccessor.Update(expected);
            var result = gListAccessor.Find(1);

            //Assert: Checks that the GList was correctly updated
            Assert.AreEqual(expected, result, "The grocery list was updated incorrectly.");
        }


        [TestMethod]
        public void GListAccessor_GetGLists()
        {
            //Arrange: Creates an expected list of GLists with AccountId = 3
            var expected = new List<GList>
            {
                new GList
                {
                    Id = 4,
                    ListName = "Food",
                    Date = DateTime.Parse("2020-10-12"),
                    AccountId = 3
                },
                new GList
                {
                    Id = 5,
                    ListName = "Another List",
                    Date = DateTime.Parse("2020-10-10"),
                    AccountId = 3
                }
            };


            //Act: Calls the GListAccessor GetGLists() method to retrieve the GLists with AccountId = 3
            var result = gListAccessor.GetGLists(3).ToList();


            //Assert: Checks that only the GLists with AccountId = 3 were retrieved
            CollectionAssert.AreEquivalent(expected, result, "A GList without AccountId = 3 was retrieved.");
        }


        [TestMethod]
        public void GListAccessor_GetGLists_InvalidUserId()
        {
            //Arrange: No GLists exist in the DB with AccountId = 0


            //Act: Calls the GListAccessor GetGLists() method to retrieve the GLists with AccountId = 0
            var result = gListAccessor.GetGLists(0).ToList();


            //Assert: Checks that the retrieved list is empty
            Assert.AreEqual(0, result.Count, "GLists were retrieved from the database.");
        }

    }
}
