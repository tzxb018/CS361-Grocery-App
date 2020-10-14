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

        [ExpectedException]

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

       //Test comment
       //Test comment
    }
}
