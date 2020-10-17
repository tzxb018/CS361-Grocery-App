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
    public class ItemsAccessorTests
    {

        private readonly ItemsAccessor itemsAccessor;
        private object expected;

        public ItemsAccessorTests()
        {
            itemsAccessor = new ItemsAccessor();
        }

        [TestMethod]
        public void ItemsAccessor_Exists()
        {
            var expectedOne = true;
            var expectedThree = true;
            var expectedTen = false;

            var one = itemsAccessor.Exists(1);
            var three = itemsAccessor.Exists(3);
            var ten = itemsAccessor.Exists(10);

            Assert.AreEqual(expectedOne, one, "DB was analyzed incorrectly");
            Assert.AreEqual(expectedThree, three, "DB was analyzed incorrectly");
            Assert.AreEqual(expectedTen, ten, "DB was analyzed incorrectly");
        }



    }

}
