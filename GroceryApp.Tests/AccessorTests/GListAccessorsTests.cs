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

       
    }

}
