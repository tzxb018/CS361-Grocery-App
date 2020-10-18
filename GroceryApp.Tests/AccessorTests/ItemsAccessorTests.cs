using _361Example.Accessors;
using _361Example.Engines;
using _361Example.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
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

        [TestMethod]
        public void ItemsAccessor_GetAllItems()
        {
            var expected = new List<Item>
            {
                new Item
                {
                    Id = 1,
                    Name = "Bread",
                    Checkoff = false,
                    Date = DateTime.Parse("2020-09-29")
                },
                new Item
                {
                    Id = 2,
                    Name = "Milk",
                    Checkoff = false,
                    Date = DateTime.Parse("2020-09-14")
                },
                new Item
                {
                    Id = 3,
                    Name = "Toilet Paper",
                    Checkoff = false,
                    Date = DateTime.Parse("2020-09-06")
                },
                new Item
                {
                    Id = 4,
                    Name = "Butter",
                    Checkoff = false,
                    Date = DateTime.Parse("2020-09-02")
                },
                new Item
                {
                    Id = 5,
                    Name = "Bagels",
                    Checkoff = false,
                    Date = DateTime.Parse("2020-09-16")
                },
                new Item
                {
                    Id = 6,
                    Name = "Lettuce",
                    Checkoff = false,
                    Date = DateTime.Parse("2020-09-18")
                },
                new Item
                {
                    Id = 7,
                    Name = "Apples",
                    Checkoff = false,
                    Date = DateTime.Parse("2020-09-22")
                },
                new Item
                {
                    Id = 8,
                    Name = "Carrots",
                    Checkoff = false,
                    Date = DateTime.Parse("2020-09-24")
                }
            };

            var list = itemsAccessor.GetAllItems();

            for (int i = 0; i < 8; i++)
            {
                Assert.AreEqual(expected.ElementAt(i).Name, list.ElementAt(i).Name, "The ItemList name was retrieved incorrectly.");
                Assert.AreEqual(expected.ElementAt(i).Date, list.ElementAt(i).Date, "The ItemList date was retrieved incorrectly.");
                Assert.AreEqual(expected.ElementAt(i).Checkoff, list.ElementAt(i).Checkoff, "The ItemList checkoff was retrieved incorrectly.");
                Assert.AreEqual(expected.ElementAt(i).Id, list.ElementAt(i).Id, "The ItemList id was retrieved incorrectly.");
            }
        }


    }

}
