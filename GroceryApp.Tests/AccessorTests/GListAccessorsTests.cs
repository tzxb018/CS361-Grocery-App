using _361Example.Accessors;
using _361Example.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryApp.Tests
{
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
            var expectedOne = true;
            var expectedThree = true;
            var expectedFalse = false;

            var one = gListAccessor.Exists(1);
            var three = gListAccessor.Exists(3);
            var _false = gListAccessor.Exists(-1);

            Assert.AreEqual(expectedOne, one, "DB was analyzed incorrectly");
            Assert.AreEqual(expectedThree, three, "DB was analyzed incorrectly");
            Assert.AreEqual(expectedFalse, _false, "DB was analyzed incorrectly");
        }

        [TestMethod]
        public void GListAccessor_GetList()
        {
            // Arrange: setting the objects of all the expected lists in the database (the database is seeded with data from SQL script)
            var expected1 = new GList { ListName = "First List", Id = 1 };
            var expected2 = new GList { ListName = "Sunday List", Id = 2 };
            var expected3 = new GList { Id = 3, ListName = "Groceries" };
            var expected4 = new GList { Id = 4, ListName = "Food" };

            // Act: get the lists from the database by their IDs
            var result1 = gListAccessor.Find(1);
            var result2 = gListAccessor.Find(2);
            var result3 = gListAccessor.Find(3);
            var result4 = gListAccessor.Find(4);

            // Assert: using their list names and id, we check to see if the database returned the expected results
            Assert.AreEqual(expected1.ListName, result1.ListName, expected1.Id + " " + expected1.ListName + " was expected. " + result1.Id + " " + result1.ListName + " was returned.");
            Assert.AreEqual(expected2.ListName, result2.ListName, expected2.Id + " " + expected2.ListName + " was expected. " + result2.Id + " " + result2.ListName + " was returned.");
            Assert.AreEqual(expected3.ListName, result3.ListName, expected3.Id + " " + expected3.ListName + " was expected. " + result3.Id + " " + result3.ListName + " was returned.");
            Assert.AreEqual(expected4.ListName, result4.ListName, expected4.Id + " " + expected4.ListName + " was expected. " + result4.Id + " " + result4.ListName + " was returned.");

        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GListAccessor_GetList_ElementDoesntExist()
        {
            // Arrange: The expected result should be null, since there is no list with ID = 5


            // Act: Calls the GListAccessor to find an list with an ID = 5
            var result = gListAccessor.Find(5);

            // Assert checks if the result is null
            Assert.AreEqual(null, result.ListName, result.Id + " was returned. ");

        }

        [TestMethod]
        public void GListAccessor_Delete()
        {
            //Arrange: The GList to be deleted is within the database
            GList glist = new GList { ListName = "MY LIST", Date = DateTime.Parse("2020-09-29"), AccountId = 1 };
            GList removable = gListAccessor.Insert(glist);

            //Act: Calls the GListAccessor Delete() method to delete the GList from the database
            var result = gListAccessor.Delete(removable.Id);

            //Assert: Checks that the correct GList was returned
            Assert.AreEqual(glist.ListName, result.ListName, "The incorrect GList was deleted.");

        }

        [TestMethod]
        public void GListAccessor_Delete_GListNotInDB()
        {
            //Arrange: The GList id 0 is not within the database

            //Act: Calls the GListAccessor Delete() method to delete the GList from the database
            var result = gListAccessor.Delete(-1);

            //Assert: Checks that null was returned
            Assert.IsNull(result, "A GList was unexpectedly deleted.");

        }

        [TestMethod]
        public void GListAccessor_GetAllGLists()
        {
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

            var list = gListAccessor.GetAllGLists();

            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(expected.ElementAt(i).ListName, list.ElementAt(i).ListName, "The GList was retrieved incorrectly.");
                Assert.AreEqual(expected.ElementAt(i).Id, list.ElementAt(i).Id, "The GList was retrieved incorrectly.");
            }

        }

        [TestMethod]
        public void GListAccessor_Insert()
        {
            //Arrange: Create a new list to be inserted
            GList expected = new GList { ListName = "Inserted List", Date = DateTime.Parse("2020-09-29"), AccountId = 1, };

            //Act: Insert the list
            var result = gListAccessor.Insert(expected);
            gListAccessor.Delete(result.Id);

            //Assert:
            Assert.AreEqual(result, expected, "The grocery list was inserted incorrectly");
        }

    }

}


