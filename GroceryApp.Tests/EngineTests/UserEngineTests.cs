using _361Example.Engines;
using _361Example.Models;
using GroceryApp.Tests.MockedAccessors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace GroceryApp.Tests.EngineTests
{
    /**
     * The purpose of this class is the unit testing of the methods within the UserEngine class.
     * This test class utilizes a MockedUserAccessor in order to test only the code within the UserEngine
     * and not the methods within the UserAccessor class.
     * This test class uses Microsoft.VisualStudio.TestTools.UnitTesting.
     **/
    [TestClass]
    public class UserEngineTests
    {

        private readonly IUserEngine userEngine;
        private readonly MockedUserAccessor mockedUserAccessor;

        //The UserEngineTests() constructor creates the MockedUserAccessor and passes it as the IUserAccessor argument into the UserEngine constructor
        public UserEngineTests()
        {
            mockedUserAccessor = new MockedUserAccessor();
            userEngine = new UserEngine(mockedUserAccessor);
        }


        //Seeds the Mocked Accessor with test data using the SetState() method
        public void SeedUsers()
        {
            mockedUserAccessor.SetState(new List<User>
            {
                new User
                {
                    Id = 1,
                    Email = "nobody@nothing.com",
                    Password = "asdf"
                },
                new User
                {
                    Id = 2,
                    Email = "useremail@gmail.com",
                    Password = "jkly123"
                },
                new User
                {
                    Id = 3,
                    Email = "groceryguy@hotmail.com",
                    Password = "qwerty"
                }
            });
        }


        [TestMethod]
        public void UserEngine_GetAllUsers()
        {
            //Arrange: Seed Mocked Accessor's list of Users and creates an expected list of Users
            SeedUsers();
            List<User> expected = new List<User>
            {
                new User
                {
                    Id = 1,
                    Email = "nobody@nothing.com",
                    Password = "asdf"
                },
                new User
                {
                    Id = 2,
                    Email = "useremail@gmail.com",
                    Password = "jkly123"
                },
                new User
                {
                    Id = 3,
                    Email = "groceryguy@hotmail.com",
                    Password = "qwerty"
                }
            };


            //Act: Calls the UserEngine GetAllUsers() method to return all Users
            List<User> results = userEngine.GetAllUsers().ToList();


            //Assert: Checks whether the expected and result lists are exactly the same
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected.ElementAt(i), results.ElementAt(i), $"User {i} was retrieved incorrectly");
            }
        }


        [TestMethod]
        public void UserEngine_GetUser()
        {
            //Arrange: Seed Mocked Accessor's list of Users and creates an expected list of Users
            SeedUsers();
            List<User> expected = new List<User>
            {
                new User
                {
                    Id = 1,
                    Email = "nobody@nothing.com",
                    Password = "asdf"
                },
                new User
                {
                    Id = 2,
                    Email = "useremail@gmail.com",
                    Password = "jkly123"
                },
                new User
                {
                    Id = 3,
                    Email = "groceryguy@hotmail.com",
                    Password = "qwerty"
                }
            };


            //Act: Creates a results list and adds the return User from the UserEngine GetUser() method to the list
            List<User> results = new List<User>();
            for(int i = 1; i <= mockedUserAccessor.GetState().Count; i++)
            {
                results.Add(userEngine.GetUser(i));
            }


            //Assert: Checks that each User in the expected and results list are equal
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected.ElementAt(i), results.ElementAt(i), $"User {i} was retrieved incorrectly.");
            }
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void UserEngine_GetUser_EmptyList()
        {
            //Arrange: Seed the Mocked Accessor with an empty list of Users
            mockedUserAccessor.SetState(new List<User> { null });


            //Act: Calls the UserEngine GetUser() method on the empty list
            userEngine.GetUser(2);


            //Assert: Handled by the ExpectedException attribute on the test method
        }


        [TestMethod]
        public void UserEngine_VerifyUser()
        {
            //Arrange: Seed the Mocked Accessor's lists of Users and creates an expected list of Users
            SeedUsers();
            List<User> expected = new List<User>
            {
                new User
                {
                    Id = 1,
                    Email = "nobody@nothing.com",
                    Password = "asdf"
                },
                new User
                {
                    Id = 2,
                    Email = "useremail@gmail.com",
                    Password = "jkly123"
                },
                new User
                {
                    Id = 3,
                    Email = "groceryguy@hotmail.com",
                    Password = "qwerty"
                }
            };


            //Act: Creates a result list and adds the return value of the UserEngine VerifyUser() method to the list
            List<User> results = new List<User>();
            for (int i = 0; i < mockedUserAccessor.GetState().Count; i++)
            {
                var user = userEngine.VerifyUser(expected.ElementAt(i).Email, expected.ElementAt(i).Password);
                results.Add(user);
            }


            //Assert: Checks whether each User in the expected and results lists are equal
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected.ElementAt(i), results.ElementAt(i), $"User {i} was retrieved incorrectly.");
            }
        }


        [TestMethod]
        public void UserEngine_InsertUser()
        {
            //Arrange: Seed the Mocked Accessor with a list of Users and creates a User to be inserted
            SeedUsers();
            User user = new User {
                Id = 4,
                Email = "newUser@gmail.com", 
                Password = "userthatisnew"
            };


            //Act: Calls the UserEngine InsertUser() method to insert the created User object
            var result = userEngine.InsertUser(user);


            //Assert: Checks whether the expected User and the inserted User are equal, and that the inserted User is within the list
            Assert.AreEqual(user, result, "User was inserted incorrectly.");
            CollectionAssert.Contains(mockedUserAccessor.GetState(), result, "The user was not inserted into the list.");
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void UserEngine_InsertUser_ExpectNullException()
        {
            //Arrange: Seed the Mocked Accessor with a list of Users
            SeedUsers();


            //Act: Calls the UserEngine InsertUser() with a null User
            userEngine.InsertUser(null);


            //Arrange: Handled by the ExpectedException attribute 
        }


        [TestMethod]
        [ExpectedException(typeof(DuplicateNameException))]
        public void UserEngine_InsertUser_DuplicateEmailException()
        {
            //Arrange: Seed the Mocked Accessor with a list of Users and a User with a duplicate email to be inserted
            SeedUsers();
            var user = new User
            {
                Id = 8,
                Email = "useremail@gmail.com"
            };


            //Act: Calls the UserEngine InsertUser() with a User that has a duplicate email
            userEngine.InsertUser(user);


            //Arrange: Handled by the ExpectedException attribute 
        }


        [TestMethod]
        public void UserEngine_UpdateUser()
        {
            //Arrange: Seed the Mocked Accessor with a list of Users and creates an updated User object
            SeedUsers();
            User user = new User { 
                Id = 1, 
                Email = "updatedEmail@gmail.com", 
                Password = "updatedPassword"
            };


            //Act: Calls the UserEngine UpdateUser() method to update User with id = 1 to the new version
            User result = userEngine.UpdateUser(user);


            //Assert: Checks that the updated User was returned correctly and that the list of Users contains the updated User
            Assert.AreEqual(user, result, "User was updated incorrectly.");
            CollectionAssert.Contains(mockedUserAccessor.GetState(), user);
        }


        [TestMethod]
        public void UserEngine_DeleteUser()
        {
            //Arrange: Seed the Mocked Accessor with a list of Users and creates and expected list of Users
            SeedUsers();
            List<User> expected = new List<User>
            {
                new User
                {
                    Id = 1,
                    Email = "nobody@nothing.com",
                    Password = "asdf"
                },
                new User
                {
                    Id = 2,
                    Email = "useremail@gmail.com",
                    Password = "jkly123"
                },
                new User
                {
                    Id = 3,
                    Email = "groceryguy@hotmail.com",
                    Password = "qwerty"
                }
            };


            //Act: Deletes each User from the list of Users using the UserEngine DeleteUser() method
            int originalSize = mockedUserAccessor.GetState().Count;
            List<User> results = new List<User>();
            for (int i = 0; i < originalSize; i++)
            {
                var user = userEngine.DeleteUser(expected.ElementAt(i));
                results.Add(user);
            }


            //Assert: Checks whether the correct Users were deleted and that the list of Users is empty
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected.ElementAt(i), results.ElementAt(i), $"User {i} was deleted incorrectly.");
                CollectionAssert.DoesNotContain(mockedUserAccessor.GetState(), expected.ElementAt(i), $"User {i} is still within the list of Users.");
            }
        }


        [TestMethod]
        public void UserEngine_DeleteUser_InvalidId()
        {
            //Arrange: Seeds the Mocked Accessor's list of Users, stores its size, and creates a User to be deleted
            SeedUsers();
            var count = mockedUserAccessor.GetState().Count;
            var user = new User { 
                Id = 4,
                Email = "joe123@hotmail.com",
                Password = "dsklfje"
            };


            //Act: Calls the UserEngine DeleteUser() method with a User that is not in the list
            var result = userEngine.DeleteUser(user);


            //Assert: Checks that the DeleteUser() method returned null and that no Users were deleted from the list
            Assert.IsNull(result, "The User returned from the method is not null.");
            Assert.AreEqual(count, mockedUserAccessor.GetState().Count, "A User was incorrectly deleted from the list of Users.");
        }


        [TestMethod]
        public void UserEngine_GetUserEmail()
        {
            //Arrange: Seed the Mocked Accessor with a list of Users and creates a list of emails to use as arguments in GetUserEmail()
            SeedUsers();
            List<string> emails = new List<string> { 
                "nobody@nothing.com", 
                "useremail@gmail.com", 
                "groceryguy@hotmail.com" 
            };


            //Act: Retrieves each User in the list of Users using their email as an argument in the UserEngine GetUserEmail() method
            List<User> results = new List<User>();
            for (int i = 0; i < emails.Count; i++)
            {
                var user = userEngine.GetUserEmail(emails.ElementAt(i));
                results.Add(user);
            }


            //Assert: Checks whether the Users were retrieved correctly by asserting that they are equal to the Users in the list of Users
            for (int i = 0; i < mockedUserAccessor.GetState().Count; i++)
            {
                var user = mockedUserAccessor.GetState().ElementAt(i);
                Assert.AreEqual(user, results.ElementAt(i), $"User {i} was retrieved incorrectly.");
            }
        }


        [TestMethod]
        public void UserEngine_GetUserEmail_NullEmail()
        {
            //Arrange: Seed the Mocked Accessor with a list of Users
            SeedUsers();


            //Act: Calls the UserEngine GetUserEmail() method with a null email
            var result = userEngine.GetUserEmail(null);


            //Assert: Checks that a null User was returned
            Assert.IsNull(result, "A non-null User was returned by passing in a null email.");
        }

    }
}
