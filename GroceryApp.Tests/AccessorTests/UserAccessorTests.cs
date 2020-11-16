using _361Example.Accessors;
using _361Example.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryApp.Tests
{
    [TestClass]
    public class UserAccessorTests
    {
        private readonly UserAccessor userAccessor;

        public UserAccessorTests()
        {
            userAccessor = new UserAccessor();

        }

        [TestMethod]
        public void UserAccessor_Exists()
        {
            var expectedOne = true;
            var expectedTwo = true;
            var expectedFalse = false;

            var one = userAccessor.Exists(1);
            var two = userAccessor.Exists(2);
            var _false = userAccessor.Exists(-1);

            Assert.AreEqual(expectedOne, one, "DB was analyzed incorrectly");
            Assert.AreEqual(expectedTwo, two, "DB was analyzed incorrectly");
            Assert.AreEqual(expectedFalse, _false, "DB was analyzed incorrectly");
        }

        [TestMethod]
        public void UserAccessor_GetUser()
        {
            // Arrange: setting the objects of all the expected users in the database (the database is seeded with data from SQL script)
            var expected1 = new User { Id = 1, email = "johnsmith@gmail.com", password = "dlka3jgd45" };
            var expected2 = new User { Id = 2, email = "johndoe@hotmail.com", password = "sdjdsbf" };
            var expected3 = new User { Id = 3, email = "helloworld@cse.edu", password = "jfioseufho" };

            // Act: get the users from the database by their IDs
            var result1 = userAccessor.Find(1);
            var result2 = userAccessor.Find(2);
            var result3 = userAccessor.Find(3);

            // Assert: using their user names and passwords, we check to see if the database returned the expected results
            Assert.AreEqual(expected1, result1, expected1.Id + " " + expected1.email + " was expected. " + result1.Id + " " + result1.email + " was returned.");
            Assert.AreEqual(expected2, result2, expected2.Id + " " + expected2.email + " was expected. " + result2.Id + " " + result2.email + " was returned.");
            Assert.AreEqual(expected3, result3, expected3.Id + " " + expected3.email + " was expected. " + result3.Id + " " + result3.email + " was returned.");
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void UserAccessor_GetList_ElementDoesntExist()
        {
            // Arrange: The expected result should be null, since there is no user with ID = 10


            // Act: Calls the userAccessor Find() method on a user that doesn't exist
            var result = userAccessor.Find(10);

            // Assert checks if the result is null
            Assert.AreEqual(null, result, result.Id + " was returned. ");

        }

        [TestMethod]
        public void UserAccessor_Delete()
        {
            //Arrange: The account to be deleted is within the database
            User temp = new User { email = "insertuser@gmail.com", password = "asdfghjkl" };
            User removable = userAccessor.Insert(temp);
            

            //Act: Calls the UserAccessor Delete() method to delete the account from the database
            var result = userAccessor.Delete(removable.Id);

            //Assert: Checks that the correct account was returned
            Assert.AreEqual("insertuser@gmail.com", result.email, "The incorrect user was deleted.");
            Assert.AreEqual("asdfghjkl", result.password, "The incorrect user was deleted.");

        }

        [TestMethod]
        public void UserAccessor_Delete_AccountNotInDB()
        {
            //Arrange: The account id 0 is not within the database

            //Act: Calls the UserAccessor Delete() method to delete the account from the database
            var result = userAccessor.Delete(-1);

            //Assert: Checks that null was returned
            Assert.IsNull(result, "A user was unexpectedly deleted.");

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

        [TestMethod]
        public void UserAccessor_Insert()
        {
            //Arrange: Create a new user to be inserted
            User expected = new User { email = "insertuser@gmail.com", password = "asdfghjkl" };

            //Act: Insert the User
            var result = userAccessor.Insert(expected);
            userAccessor.Delete(result.Id);

            //Assert
            Assert.AreEqual(expected, result, "The user was inserted incorrectly");
        }

        [TestMethod]
        public void UserAccessor_GetUserEmail()
        {
            var expected = new User { Id = 1, email = "johnsmith@gmail.com", password = "dlka3jgd45" };

            //Act: Insert the User
            var result = userAccessor.GetUserEmail("johnsmith@gmail.com");

            //Assert
            Assert.AreEqual(expected, result, "The user was inserted incorrectly");

        }

        [TestMethod]
        public void UserAccessor_Find_successful()
        {
            //Arrange
            String username = "insertuser@gmail.com";
            String password = "asdfghjkl";

            //Act
            var result = userAccessor.Find(username, password);

            //Assert
            Assert.AreEqual(5, result.Id, "User not found");

        }

    }
}


