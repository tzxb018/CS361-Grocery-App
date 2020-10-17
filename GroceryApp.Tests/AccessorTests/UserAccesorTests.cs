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
    public class UserAccessorTests
    {
        private readonly UserAccessor userAccessor;
        private object expected;

        public UserAccessorTests()
        {
            userAccessor = new UserAccessor();

        }

        [TestMethod]
        public void UserAccessor_Exists()
        {
            var expectedOne = true;
            var expectedTwo = true;
            var expectedFive = false;

            var one = userAccessor.Exists(1);
            var two = userAccessor.Exists(2);
            var five = userAccessor.Exists(5);

            Assert.AreEqual(expectedOne, one, "DB was analyzed incorrectly");
            Assert.AreEqual(expectedTwo, two, "DB was analyzed incorrectly");
            Assert.AreEqual(expectedFive, five, "DB was analyzed incorrectly");
        }



    }

}
