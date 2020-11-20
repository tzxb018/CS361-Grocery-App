using _361Example.Engines;
using _361Example.Models;
using GroceryApp.Tests.MockedAccessors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GroceryApp.Tests.EngineTests
{
    /**
     * The purpose of this class is the unit testing of the methods within the GListEngine class.
     * This test class utilizes a MockedGListAccessor in order to test only the code within the GListEngine
     * and not the methods within the GListAccessor class.
     * This test class uses Microsoft.VisualStudio.TestTools.UnitTesting.
     **/
    [TestClass]
    public class GListEngineTests
    {

        private readonly IGListEngine gListEngine;
        private readonly MockedGListAccessor mockedGListAccessor;

        //The GListEngineTests() constructor creates the MockedGListAccessor and passes it as the IGListAccessor argument into the GListEngine constructor
        public GListEngineTests()
        {
            mockedGListAccessor = new MockedGListAccessor();
            gListEngine = new GListEngine(mockedGListAccessor);
        }


        //Seeds the Mocked Accessor with test data using the SetState() method
        public void SeedGLists()
        {
            mockedGListAccessor.SetState(new List<GList>
            {
                new GList
                {
                    Id = 1,
                    ListName = "Sunday Groceries",
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

        //Seeds the Mocked Accessor with test data including AccountId using the SetState() method
        public void SeedGListsWithAccountId()
        {
            mockedGListAccessor.SetState( new List<GList> {
                new GList {
                    Id = 1,
                    ListName = "Joe's First List",
                    AccountId = 3
                },
                new GList
                {
                    Id = 2,
                    ListName = "Sally's List",
                    AccountId = 6
                },
                new GList{
                    Id = 3,
                    ListName = "Another Joe List",
                    AccountId = 3
                }
            });
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


            //Act: Calls the GListEngine SortLists() method to sort the GLists according to name
            var result = gListEngine.SortLists().ToList();


            //Assert: Checks whether the expected and result lists are ordered the same
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected.ElementAt(i), result.ElementAt(i), $"The GList at index {i} was sorted incorrectly.");
            }
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GListEngine_SortLists_ExpectArgumentNullException()
        {
            //Arrange: Seed the Mocked Accessor's list of GLists with a null-named list using the SetState() method
            mockedGListAccessor.SetState(new List<GList>
            {
                new GList
                {
                    Id = 1,
                    ListName = null
                }
            });


            //Act: Calls the GListEngine SortLists() method on a list of GLists with a null-named list
            gListEngine.SortLists();


            //Assert: Handled by the ExpectedException attribute on the test method
        }


        [TestMethod]
        public void GListEngine_GetAllLists()
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


            //Act: Calls the GListEngine GetAllLists() method to return all GLists
            var result = gListEngine.GetAllLists();


            //Assert: Checks whether each GList in the expected and result lists are equal
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected.ElementAt(i), result.ElementAt(i), $"The GList at index {i} was retrieved incorrectly.");
            }
        }


        [TestMethod]
        public void GListEngine_DeleteList()
        {
            //Arrange: Seeds the Mocked Accessor's list of GLists
            SeedGLists();
            var expected = new GList { 
                Id = 3,
                ListName = "MyList"
            };

            //Act: Calls the GListEngine DeleteList() method, which should delete the GList with the given id from the lists of GLists
            var deletedList = gListEngine.DeleteList(3);


            //Assert: Checks if a GList was deleted, if the correct GList was returned, and if the list of GLists does not contain the deleted GList
            Assert.IsNotNull(deletedList, "The deleted list is null.");
            Assert.AreEqual(2, mockedGListAccessor.GetState().Count(), "A GList was not deleted from the list of GLists.");
            Assert.AreEqual(expected, deletedList, "An incorrect list was returned or no list was returned.");
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
            Assert.AreEqual(3, mockedGListAccessor.GetState().Count(), "A GList was incorrectly deleted from the list of GLists.");
        }


        [TestMethod]
        public void GListEngine_GetList()
        {
            //Arrange: Seeds the Mocked Accessor's list of GLists and creates the expected list
            SeedGLists();
            var expected = new GList { 
                Id = 2, 
                ListName = "Wednesday Groceries"
            };


            //Act: Calls the GListEngine GetList() method with the id for the "Wednesday Groceries" list
            var result = gListEngine.GetList(2);


            //Assert: Checks whether expected and result GList are the same
            Assert.AreEqual(expected, result, $"GList {result.Id} was returned. GList {expected.Id} was expected.");
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GListEngine_GetList_EmptyList()
        {
            //Arrange: Seeds the Mocked Accessor with an empty list of GLists
            mockedGListAccessor.SetState(new List<GList> { null });


            //Act: Calls the GListEngine GetList() method on the empty list
            gListEngine.GetList(3);


            //Assert: Handled by the ExpectedException attribute on the test method
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GListEngine_GetList_ElementDoesntExist()
        {
            //Arrange: Seeds the Mocked Accessor's list of GLists
            SeedGLists();


            //Act: Calls the GListEngine GetList() method on a GList that doesn't exist
            var result = gListEngine.GetList(5);


            //Assert: Checks if the result is null
            Assert.AreEqual(null, result, $"GList {result.Id} was incorrectly returned. ");
        }


        // Implemeted by Noah
        [TestMethod]
        public void GListEngine_UpdateList()
        {
            //Arrange: Seeds the Mocked Accessor's list of GLists and creates an updated GList
            SeedGLists();
            var expected = new GList()
            {
                Id = 2,
                ListName = "Updated"
            };


            //Act: Calls the GListEngine UpdateList() and uses the GetState() method to retrieve the Mocked Accessor's list
            gListEngine.UpdateList(2, expected);
            List<GList> results = mockedGListAccessor.GetState();


            //Assert: Checks if the GList's name was successfully updated
            Assert.AreEqual(expected.ListName, results.ElementAt(2).ListName, "The GList wasn't updated correctly.");
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GListEngine_InsertList_ExpectNullException()
        {
            //Arrange: Seeds the Mocked Accessor's list of GLists
            SeedGLists();


            //Act: Insert a null GList using the GListEngine InsertList() method
            gListEngine.InsertList(null);


            //Assert: Handled by the Expected Exception attribute
        }


        [TestMethod]
        [ExpectedException(typeof(DuplicateNameException))]
        public void GListEngine_InsertList_DuplicateNameException()
        {
            //Arrange: Seeds the Mocked Accessor's list of GLists and creates an expected GList
            SeedGListsWithAccountId();
            GList gListNameDup = new GList() {
                Id = 3,
                ListName = "Another Joe List",
                AccountId = 3
            };


            //Act: Insert GList with duplicate name using the GListEngine InsertList() method
            gListEngine.InsertList(gListNameDup);


            //Assert: Handled by the Expected Exception attribute
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GListEngine_InsertList_DuplicateIdException()
        {
            //Arrange: Seeds the Mocked Accessor's list of GLists and creates an expected GList
            SeedGLists();
            GList gListIdDup = new GList() { 
                Id = 3, 
                ListName = "DuplicateIdList"
            };


            //Act: Insert GList with duplicate Id using the GListEngine InsertList() method
            gListEngine.InsertList(gListIdDup);


            //Assert: Handled by the Expected Exception attribute
        }


        [TestMethod]
        [ExpectedException(typeof(DuplicateNameException))]
        public void GListEngine_InsertList_DuplicateGListException()
        {
            //Arrange: Seeds the Mocked Accessor's list of GLists and creates an expected GList
            SeedGLists();
            GList gListDup = new GList() { 
                Id = 3, 
                ListName = "MyList"
            };


            //Act: Insert a duplicate GList using the GListEngine InsertList() method
            gListEngine.InsertList(gListDup);


            //Assert: Handled by the Expected Exception attribute
        }


        [TestMethod]
        public void GListEngine_InsertList()
        {
            //Arrange: Seeds the Mocked Accessor's list of GLists and creates an expected GList
            SeedGLists();
            GList gList = new GList() { 
                Id = 4, 
                ListName = "Brand New List" 
            };
            var expected = gList;


            //Act: Insert GList using the GListEngine InsertList() method
            var result = gListEngine.InsertList(gList);


            //Assert: Checks whether the GList added is equal to the expected GList
            Assert.AreEqual(expected, result, "The GList was not returned correctly.");
            CollectionAssert.Contains(mockedGListAccessor.GetState(), gList, "The list of GLists does not contain the inserted GList.");
        }


        [TestMethod]
        public void GListEngine_GetUserLists()
        {
            //Arrange: Seeds the Mocked Accessor's list of GLists and creates an expected list of GLists
            SeedGListsWithAccountId();
            var expected = new List<GList>
            {
                new GList
                {
                    Id = 1,
                    ListName = "Joe's First List",
                    AccountId = 3
                },
                new GList
                {
                    Id = 3,
                    ListName = "Another Joe List",
                    AccountId = 3
                }
            };


            //Act: Calls the GListEngine GetUserLists() method to return the GLists for the User with id = 3
            var result = gListEngine.GetUserLists(3).ToList();


            //Assert: Checks whether the expected and result list contain the same elements; only the GLists with AccountId = 3
            Assert.IsFalse(expected.Count < result.Count, $"The result list contains {result.Count} GLists, but should only contain {expected.Count} GLists.");
            Assert.IsFalse(expected.Count > result.Count, $"The result list contains only {result.Count} GLists, but should contain {expected.Count} GLists.");
            CollectionAssert.AreEquivalent(expected, result, "The expected and result list have (an) unequal GList(s).");
        }


        [TestMethod]
        public void GListEngine_GetUserLists_NoGListsReturned()
        {
            //Arrange: Seeds the Mocked Accessor's list of GLists
            SeedGListsWithAccountId();


            //Act: Calls the GListEngine GetUserLists() with an AccountId that should return an empty list of GLists
            var result = gListEngine.GetUserLists(0).ToList();


            //Assert: Checks that the result is an empty list
            Assert.AreEqual(0, result.Count, "More than zero GLists were returned.");
        }

    }
}
