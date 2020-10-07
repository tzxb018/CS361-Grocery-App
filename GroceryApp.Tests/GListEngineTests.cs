using _361Example.Engines;
using _361Example.Models;
using GroceryApp.Tests.MockedAccessors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryApp.Tests
{
    [TestClass]
    public class GListEngineTests
    {

        private readonly IGListEngine gListEngine;
        private readonly MockedGListAccessor mockedGListAccessor;

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

    }
}
