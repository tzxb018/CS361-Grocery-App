using _361Example.Engines;
using _361Example.Models;
using GroceryApp.Tests.MockedAccessors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GroceryApp.Tests.EngineTests
{

    [TestClass]
    public class UserEngineTests
    {
        private readonly IUserEngine _userEngine;
        private readonly MockedUserAccessor _mockedUserAccessor;

        public UserEngineTests()
        {
            _mockedUserAccessor = new MockedUserAccessor();
            _userEngine = new UserEngine(_mockedUserAccessor);
        }

        public void SeedItems()
        {
            _mockedUserAccessor.SetState(new List<User>
            {
                new User
                {
                    Id = 1,
                    email = "nobody@nothing.com",
                    password = "asdf"
                },
                 new User
                {
                    Id = 2,
                    email = "useremail@gmail.com",
                    password = "jkly123"
                },
                 new User
                {
                    Id = 3,
                    email = "groceryguy@hotmail.com",
                    password = "qwerty"
                }
            });
        }

        [TestMethod]
        public void UserEngine_GetAllUsers()
        {
            //arrange:
            SeedItems();
            List<User> expected = new List<User>
            {
                new User
                {
                    Id = 1,
                    email = "nobody@nothing.com",
                    password = "asdf"
                },
                 new User
                {
                    Id = 2,
                    email = "useremail@gmail.com",
                    password = "jkly123"
                },
                 new User
                {
                    Id = 3,
                    email = "groceryguy@hotmail.com",
                    password = "qwerty"
                }
            };

            //act:
            List<User> results = _userEngine.GetAllUsers().ToList();

            //Assert:
            for(int i=0; i<3; i++)
            {
                Assert.AreEqual(expected[i].Id, results[i].Id, "Users were retrieved Incorrectly: Wrong Id");
                Assert.AreEqual(expected[i].email, results[i].email, "Users were retrieved Incorrectly: Wrong email");
                Assert.AreEqual(expected[i].password, results[i].password, "Users were retrieved Incorrectly: Wrong password");
            }
        }

        [TestMethod]
        public void UserEngine_GetUser()
        {
            //arrange:
            SeedItems();
            List<User> expected = new List<User>
            {
                new User
                {
                    Id = 1,
                    email = "nobody@nothing.com",
                    password = "asdf"
                },
                 new User
                {
                    Id = 2,
                    email = "useremail@gmail.com",
                    password = "jkly123"
                },
                 new User
                {
                    Id = 3,
                    email = "groceryguy@hotmail.com",
                    password = "qwerty"
                }
            };

            //act:
            List<User> results = new List<User>();
            for(int i=1; i<=3; i++)
            {
                results.Add(_userEngine.GetUser(i));
            }

            //Assert:
            for (int i=0; i<3; i++)
            {
                Assert.AreEqual(expected[i].Id, results[i].Id, "User " + i + " was retrieved Incorrectly: Wrong Id");
                Assert.AreEqual(expected[i].email, results[i].email, "User " + i + " was retrieved Incorrectly: Wrong email");
                Assert.AreEqual(expected[i].password, results[i].password, "User " + i + " was retrieved Incorrectly: Wrong password");
            }
        }

        [TestMethod]
        public void UserEngine_VerifyUser()
        {
            //arrange:
            SeedItems();
            List<User> expected = new List<User>
            {
                new User
                {
                    Id = 1,
                    email = "nobody@nothing.com",
                    password = "asdf"
                },
                 new User
                {
                    Id = 2,
                    email = "useremail@gmail.com",
                    password = "jkly123"
                },
                 new User
                {
                    Id = 3,
                    email = "groceryguy@hotmail.com",
                    password = "qwerty"
                }
            };

            //act:
            List<User> results = new List<User>();
            for (int i = 0; i < 3; i++)
            {
                results.Add(_userEngine.VerifyUser(expected[i].email, expected[i].password));
            }

            //Assert:
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(expected[i].Id, results[i].Id, "User " + i + " was retrieved Incorrectly: Wrong Id");
                Assert.AreEqual(expected[i].email, results[i].email, "User " + i + " was retrieved Incorrectly: Wrong email");
                Assert.AreEqual(expected[i].password, results[i].password, "User " + i + " was retrieved Incorrectly: Wrong password");
            }

        }

        [TestMethod]
        public void UserEngine_InsertUser()
        {
            //arrange:
            SeedItems();
            User user = new User { email = "newUser@gmail.com", password = "userthatisnew" };

            //act:
            User result = _userEngine.InsertUser(user);

            //assert:
            Assert.AreEqual(4, result.Id, "User was inserted Incorrectly: Wrong Id");
            Assert.AreEqual(user.email, result.email, "User was inserted Incorrectly: Wrong email");
            Assert.AreEqual(user.password, result.password, "User was inserted Incorrectly: Wrong password");
        }

        [TestMethod]
        public void UserEngine_UpdateUser()
        {
            //Arrange:
            User user = new User { Id = 1, email = "updatedEmail@gmail.com", password = "updatedPassword" };

            //Act:
            User result = _userEngine.UpdateUser(user);

            //Assert:
            Assert.AreEqual(user.Id, result.Id, "User was updated Incorrectly: Wrong Id");
            Assert.AreEqual(user.email, result.email, "User was updated Incorrectly: Wrong email");
            Assert.AreEqual(user.password, result.password, "User was updated Incorrectly: Wrong password");
        }

        [TestMethod]
        public void UserEngine_DeleteUser()
        {
            //arrange:
            SeedItems();
            List<User> expected = new List<User>
            {
                new User
                {
                    Id = 1,
                    email = "nobody@nothing.com",
                    password = "asdf"
                },
                 new User
                {
                    Id = 2,
                    email = "useremail@gmail.com",
                    password = "jkly123"
                },
                 new User
                {
                    Id = 3,
                    email = "groceryguy@hotmail.com",
                    password = "qwerty"
                }
            };

            //act:
            List<User> results = new List<User>();
            for (int i = 0; i < 3; i++)
            {
                results.Add(_userEngine.DeleteUser(expected[i]));
            }

            //Assert:
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(expected[i].Id, results[i].Id, "User " + i + " was deleted Incorrectly: Wrong Id");
                Assert.AreEqual(expected[i].email, results[i].email, "User " + i + " was deleted Incorrectly: Wrong email");
                Assert.AreEqual(expected[i].password, results[i].password, "User " + i + " was deleted Incorrectly: Wrong password");
            }
        }

        [TestMethod]
        public void UserEngine_GetUserEmail()
        {
            List<String> emails = new List<String> { "nobody@nothing.com", "useremail@gmail.com", "groceryguy@hotmail.com" };
        }
    }

}
