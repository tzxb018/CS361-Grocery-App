using _361Example.Accessors;
using _361Example.Engines;
using _361Example.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GroceryApp.Tests
{
    [TestClass]
    public class GListAccessorTests
    {

        private readonly GListAccessor gListAccessor;
        private object expected;

        public GListAccessorTests()
        {
            gListAccessor = new GListAccessor();

        }

        [TestMethod]
        public void GListAccessor_Exists()
        {
            var expectedOne = true;
            var expectedThree = true;
            var expectedFive = false;

            var one = gListAccessor.Exists(1);
            var three = gListAccessor.Exists(3);
            var five = gListAccessor.Exists(5);

            Assert.AreEqual(expectedOne, one, "DB was analyzed incorrectly");
            Assert.AreEqual(expectedThree, three, "DB was analyzed incorrectly");
            Assert.AreEqual(expectedFive, five, "DB was analyzed incorrectly");
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

       
    }

}
