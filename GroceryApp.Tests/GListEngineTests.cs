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
    public class GListEngineTests
    {

        private readonly IGListEngine gListEngine;
        private readonly MockedGListAccessor mockedGListAccessor;
        private object expected;

        public GListEngineTests()
        {
            mockedGListAccessor = new MockedGListAccessor();
            gListEngine = new GListEngine(mockedGListAccessor);
        }


        [TestMethod]
        public void GListEngine_SortLists()
        {
            //Arrange: Seeds the Mocked Accessor's list of GLists and creates an expected list of GLists
            SeedGLists();
            var expected = new List<GList>
            {
                new GList
                {
                    Id = 3,
                    ListName = "MyList"
                },
                 new GList
                {
                    Id = 1,
                    ListName = "Sunday Groceries"
                },
                 new GList
                {
                    Id = 2,
                    ListName = "Wednesday Groceries"
                }
            };

            //Act: Calls the GListEngine SortLists() method and converts the return value to a list
            var result = gListEngine.SortLists().ToList();


            //Assert: Checks whether the expected and result lists are ordered the same
            Assert.AreEqual(expected.ElementAt(0).ListName, result.ElementAt(0).ListName, "The GList was sorted incorrectly.");
            Assert.AreEqual(expected.ElementAt(1).ListName, result.ElementAt(1).ListName, "The GList was sorted incorrectly.");
            Assert.AreEqual(expected.ElementAt(2).ListName, result.ElementAt(2).ListName, "The GList was sorted incorrectly.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GListEngine_SortLists_ExpectArgumentNullException()
        {
            //Arrange: Seed the Mocked Accessor's list of GLists with a null-named list
            mockedGListAccessor.SetState(new List<GList>
            {
                new GList
                {
                    Id = 1,
                    ListName = null
                }
            });

            //Act: Calls the GListEngine SortLists() method
            var result = gListEngine.SortLists();

            //Assert is handled by the ExpectedException attribute on the test method
        }

        [TestMethod]
        public void GListEngine_GetAllGLists()
        {
            //Arrange: Seeds the Mocked Accessor's list of GLists and creates an expected list of GLists
            SeedGLists();
            var expected = new List<GList>
            {


                new GList
                {
                    Id = 1,
                    ListName = "Sunday Groceries"
                },
                new GList
                {
                    Id = 2,
                    ListName = "Wednesday Groceries"
                },
                new GList
                {
                    Id = 3,
                    ListName = "MyList"
                }

        };

            //Act: Calls the GListEngine GetAllLists() method and converts the return value to a list
            var result = gListEngine.GetAllLists();


            //Assert: Checks whether the expected and result lists are the exact same
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(expected.ElementAt(i).ListName, result.ElementAt(i).ListName, "The GList was retrieved incorrectly.");
                Assert.AreEqual(expected.ElementAt(i).Id, result.ElementAt(i).Id, "The GList was retrieved incorrectly.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GListEngine_GetAllLists_ExpectNullException()
        {
            //Arrange: Seed the Mocked Accessor's list of GLists with a null list
            SeedGLists();
            mockedGListAccessor.SetState(null);



            //Act: Calls the GListEngine GetAllLists() method
            var result = gListEngine.GetAllLists();

            //Assert is handled by the ExpectedException attribute on the test method

        }

        public void SeedGLists()
        {
            mockedGListAccessor.SetState(new List<GList>
            {
                new GList
                {
                    Id = 1,
                    ListName = "Sunday Groceries"
                },
                new GList
                {
                    Id = 2,
                    ListName = "Wednesday Groceries"
                },
                new GList
                {
                    Id = 3,
                    ListName = "MyList"
                }
            });
        }



        [TestMethod]
        public void GListEngine_DeleteList()
        {

            //Arrange: Seeds the Mocked Accessor's list of GLists
            SeedGLists();

            //Act: Calls the GListEngine DeleteList() method, which should delete the GList with the given id from the lists of GLists
            var deletedList = gListEngine.DeleteList(3);

            //Assert: Checks if a GList was deleted, if the correct GList was returned, and if the list of GLists does not contain the deleted GList
            Assert.IsNotNull(deletedList, "The deleted list is null.");
            Assert.AreEqual(2, mockedGListAccessor.GetState().Count(), "A GList was not deleted from the list of GLists.");
            Assert.AreEqual(3, deletedList.Id, "An incorrect list was returned or no list was returned.");
            Assert.AreEqual("MyList", deletedList.ListName, "An incorrect list was returned or no list was returned.");
            CollectionAssert.DoesNotContain(mockedGListAccessor.GetState(), deletedList, "The list still contains the GList that needed to be deleted.");

        }


        [TestMethod]
        public void GListEngine_DeleteList_InvalidId()
        {

            //Arrange: Seeds the Mocked Accessor's list of GLists
            SeedGLists();

            //Act: Calls the GListEngine DeleteList() method with a given id for a non-existent GList
            var deletedList = gListEngine.DeleteList(0);

            //Assert: Checks that no GLists were deleted from the list of GLists
            Assert.IsNull(deletedList, "The deleted list is not null.");
            Assert.AreEqual(3, mockedGListAccessor.GetState().Count(), "A GList was deleted from the list of GLists.");

        }


        [TestMethod]
        public void GListEngine_GetList()
        {
            // Arrange: Seeds the Mocked Accessor's list of GLists and retrives the expected list
            SeedGLists();
            var expected = new GList { Id = 2, ListName = "Wednesday Groceries" };

            // Act: Calls the GList Engine GetList() method
            var result = gListEngine.GetList(2);

            // Assert: Checks whether expected and result list are the same
            Assert.AreEqual(expected.ListName, result.ListName, result.Id + " was returned. " + expected.Id + " was expected.");
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GListEngine_GetList_EmptyList()
        {
            //Arrange: Seed the Mocked Accessor's list of GLists
            mockedGListAccessor.SetState(new List<GList> { null });

            // Act: Calls the GListEngine GetList() method
            var result = gListEngine.GetList(3);

            // Assert is handled by the ExpectedException attribute on the test method

        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GListEngine_GetList_ElementDoesntExist()
        {
            // Arrange: Seeds the Mocked Accessor's list of GLists
            SeedGLists();

            // Act: Calls the GList Engine GetList() method on a GList that doesn't exist
            var result = gListEngine.GetList(5);

            // Assert checks if the result is null
            Assert.AreEqual(null, result.ListName, result.Id + " was returned. ");

        }

        // Implemeted by Noah
        [TestMethod]
        public void GListEngine_UpdateList()
        {
            //Arrange
            SeedGLists();
            var expected = new GList()
            {
                Id = 2,
                ListName = "Updated"
            };

            //Act: mockedGListAccessor.gLists isn't accessible outside of the class so a simple method from MockedGListAccessor is employed
            //to grab the GLists after they're updated.
            gListEngine.UpdateList(2, expected);
            List<GList> results = mockedGListAccessor.GetAllGLists().ToList();

            //Assert: Checks if the Name was successfully updated
            Assert.AreEqual(expected.ListName, results.ElementAt(2).ListName, "The GList wasn't updated correctly.");
        }





        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GListEngine_InsertList_ExpectNullException()
        {
            //Arrange: Seeds the Mocked Accessors
            SeedGLists();

            //Act: Insert a null list
            var result = gListEngine.InsertList(null);
            //  gListEngine.Insert(null);

            //Assert: Handled by the Expected Exception attribute
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateNameException))]
        public void GListEngine_InsertList_DuplicateNameException()
        {
            //Arrange: Seeds the Mocked Accessors
            SeedGLists();
            GList gListNameDup = new GList() { Id = 4, ListName = "MyList" };

            //Act: Insert list with duplicate name
            var result = gListEngine.InsertList(gListNameDup);


            //Assert: Handled by the Expected Exception attribute
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GListEngine_InsertList_DuplicateIdException()
        {
            //Arrange: Seeds the Mocked Accessors
            SeedGLists();
            GList gListIdDup = new GList() { Id = 3, ListName = "DuplicateIdList" };

            //Act: Insert list with duplicate name
            var result = gListEngine.InsertList(gListIdDup);

            //Assert: Handled by the Expected Exception attribute
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateNameException))]
        public void GListEngine_InsertList_DuplicateListException()
        {
            //Arrange: Seeds the Mocked Accessors
            SeedGLists();
            GList gListDup = new GList() { Id = 3, ListName = "MyList" };

            //Act: Insert list with duplicate name
            var result = gListEngine.InsertList(gListDup);

            //Assert: Handled by the Expected Exception attribute
        }

        [TestMethod]
        public void GListEngine_InsertList()
        {
            //Arrange: Seeds the Mocked Accessors
            SeedGLists();
            GList gList = new GList() { Id = 4, ListName = "Brand New List" };
            var expected = gList;


            //Act: Insert list with duplicate name and retrieve the list of lists
            var result = gListEngine.InsertList(gList);

            //Assert: Checks whether the Brand New List has been added to the list of lists
            Assert.AreEqual(expected.ListName, result.ListName, "The item wasn't inserted.");
        }
    }

}
