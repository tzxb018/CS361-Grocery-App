using _361Example.Accessors;
using _361Example.Engines;
using _361Example.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Security.Cryptography;

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

        [TestMethod]
        public void UserAccessor_GetAllUsers()
        {
            var expected = new List<User>
            {
                new User
                {
                    Id = 1,
                    email = "johnsmith@gmail.com",
                    password = "dlka3jgd45"
                },
                  new User
                {
                    Id = 2,
                    email = "johndoe@hotmail.com",
                    password = "sdjdsbf"
                },
                  new User
                {
                    Id = 3,
                    email = "helloworld@cse.edu",
                    password = "jfioseufho"
                },
            };

            var list = userAccessor.GetAllUsers();

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(expected.ElementAt(i).email, list.ElementAt(i).email, "The user list email was retrieved incorrectly.");
                Assert.AreEqual(expected.ElementAt(i).Id, list.ElementAt(i).Id, "The user list id was retrieved incorrectly.");
                Assert.AreEqual(expected.ElementAt(i).password, list.ElementAt(i).password, "The user list password was retrieved incorrectly.");
            }
        }



    }

}
