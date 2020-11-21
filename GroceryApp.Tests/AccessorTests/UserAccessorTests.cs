using _361Example.Accessors;
using _361Example.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GroceryApp.Tests.AccessorTests
{
    /**
     * The purpose of this class is the unit testing of the methods within the UserAccessor class.
     * This class tests that the UserAccessor is able to effectively read and write data to the
     * GroceryWebApp database.
     * These tests are designed to pass in the case that the test data
     * from GroceryWebApp_TestData_InsertionScript.sql is within the database.
     * This test class uses Microsoft.VisualStudio.TestTools.UnitTesting.
     **/
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
            //Arrange: Database is seeded with data from SQL script


            //Act: Calls the UserAccessor Exists() method for two user IDs within the DB and one not in the DB
            var shouldBeTrue = userAccessor.Exists(1);
            var shouldBeTrueAlso = userAccessor.Exists(2);
            var shouldBeFalse = userAccessor.Exists(-1);


            //Assert: Checks whether the Exists() method returned true or false correctly for the given IDs
            Assert.IsTrue(shouldBeTrue, "Method incorrectly returns that User with ID = 1 is not in the DB.");
            Assert.IsTrue(shouldBeTrueAlso, "Method incorrectly returns that User with ID = 2 is not in the DB.");
            Assert.IsFalse(shouldBeFalse, "Method incorrectly returns that User with ID = -1 is in the DB.");
        }


        [TestMethod]
        public void UserAccessor_Find_WithId()
        {
            //Arrange: Creating the User objects of the expected Users in the database (the database is seeded with data from the SQL script)
            var expected1 = new User { 
                Id = 1, 
                Email = "johnsmith@gmail.com", 
                Password = "dlka3jgd45" 
            };
            var expected2 = new User { 
                Id = 2, 
                Email = "johndoe@hotmail.com", 
                Password = "sdjdsbf" 
            };
            var expected3 = new User { 
                Id = 3, 
                Email = "helloworld@cse.edu", 
                Password = "jfioseufho" 
            };


            //Act: Calls the UserAccessor Find() method to get the users from the database by their IDs
            var result1 = userAccessor.Find(1);
            var result2 = userAccessor.Find(2);
            var result3 = userAccessor.Find(3);


            //Assert: Using their emails and passwords, check to see if the database returned the expected results
            Assert.AreEqual(expected1, result1, $"User with ID = {expected1.Id}, email = {expected1.Email} was expected." +
                $" User with ID = {result1.Id}, email = {result1.Email} was returned.");
            Assert.AreEqual(expected2, result2, $"User with ID = {expected2.Id}, email = {expected2.Email} was expected." +
                $" User with ID = {result2.Id}, email = {result2.Email} was returned.");
            Assert.AreEqual(expected3, result3, $"User with ID = {expected3.Id}, email = {expected3.Email} was expected." +
                $" User with ID = {result3.Id}, email = {result3.Email} was returned.");
        }


        [TestMethod]
        public void UserAccessor_Find_WithId_ElementDoesNotExist()
        {
            //Arrange: The expected result should be null, since there is no user with ID = 0


            //Act: Calls the userAccessor Find() method on a User that doesn't exist
            var result = userAccessor.Find(0);


            //Assert: Checks if the result is null
            Assert.IsNull(result, "A User was incorrectly returned.");
        }


        [TestMethod]
        public void UserAccessor_Delete()
        {
            //Arrange: The User to be deleted is put into the database
            User temp = new User { 
                Email = "insertuser@gmail.com", 
                Password = "asdfghjkl"
            };
            User removable = userAccessor.Insert(temp);
            

            //Act: Calls the UserAccessor Delete() method to delete the User from the database
            var result = userAccessor.Delete(removable.Id);


            //Assert: Checks that the correct account was returned
            Assert.AreEqual("insertuser@gmail.com", result.Email, "The incorrect user was deleted.");
            Assert.AreEqual("asdfghjkl", result.Password, "The incorrect user was deleted.");
        }


        [TestMethod]
        public void UserAccessor_Delete_AccountNotInDB()
        {
            //Arrange: The User with ID = -1 is not within the database


            //Act: Calls the UserAccessor Delete() method to delete the account from the database
            var result = userAccessor.Delete(-1);


            //Assert: Checks that null was returned
            Assert.IsNull(result, "A user was unexpectedly deleted.");
        }


        [TestMethod]
        public void UserAccessor_GetAllUsers()
        {
            //Arrange: Creates an expected list of Users that should match what is retrieved from the DB
            var expected = new List<User>
            {
                new User
                {
                    Id = 1,
                    Email = "johnsmith@gmail.com",
                    Password = "dlka3jgd45"
                },
                new User
                {
                    Id = 2,
                    Email = "johndoe@hotmail.com",
                    Password = "sdjdsbf"
                },
                new User
                {
                    Id = 3,
                    Email = "helloworld@cse.edu",
                    Password = "jfioseufho"
                },
                new User
                {
                    Id = 4,
                    Email = "ihavenolists@gmail.com",
                    Password = "sfljrred2"
                }
            };


            //Act: Calls the UserAccessor GetAllUsers() method to retrieve all Users from the DB
            var result = userAccessor.GetAllUsers().ToList();


            //Assert: Checks that each User in the expected and result list are equal
            Assert.AreEqual(expected.Count, result.Count, "The list sizes are unequal.");
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected.ElementAt(i), result.ElementAt(i), $"The User for Id = {i + 1} was retrieved incorrectly.");
            }
        }


        [TestMethod]
        public void UserAccessor_Insert()
        {
            //Arrange: Create a new User to be inserted into the DB
            User expected = new User { Email = "insertuser@gmail.com", Password = "asdfghjkl" };


            //Act: Insert the User into the DB using the UserAccessor Insert() method
            var result = userAccessor.Insert(expected);
            userAccessor.Delete(result.Id);


            //Assert: Checks that the expected User is the same as the inserted User
            Assert.AreEqual(expected, result, "The user was inserted incorrectly");
        }


        [TestMethod]
        public void UserAccessor_GetUserByEmail()
        {
            //Arrange: Creates an expected User which should be returned from the DB
            var expected = new User { 
                Id = 1, 
                Email = "johnsmith@gmail.com", 
                Password = "dlka3jgd45"
            };


            //Act: Retrieves the User from the DB by calling the UserAccessor GetUserByEmail() method with the email
            var result = userAccessor.GetUserByEmail("johnsmith@gmail.com");


            //Assert: Checks that the expected and result Users are equal
            Assert.AreEqual(expected, result, "The User was retrieved incorrectly.");
        }


        [TestMethod]
        public void UserAccessor_Find_WithUsernameAndPassword_Successful()
        {
            //Arrange: Creates username and password strings that are already within the DB
            string username = "johnsmith@gmail.com";
            string password = "dlka3jgd45";


            //Act: Calls the UserAccessor Find() method to find the User based on the given username and password
            var result = userAccessor.Find(username, password);


            //Assert: Checks that the User was returned correctly
            Assert.AreEqual(1, result.Id, "User not found");
        }


        [TestMethod]
        public void UserAccessor_Find_WithUsernameAndPassword_Unsuccessful()
        {
            //Arrange: Creates username and password strings that are not within the DB
            string username = "thisemaildoesntexist@gmail.com";
            string password = "asdfghjkl";


            //Act: Calls the UserAccessor Find() method, which should return null since no User has the specified username and password
            var result = userAccessor.Find(username, password);


            //Assert: Checks that the result of the Find() method is null
            Assert.IsNull(result, "A User was found when no Users had the specified login credentials");
        }

    }
 }

