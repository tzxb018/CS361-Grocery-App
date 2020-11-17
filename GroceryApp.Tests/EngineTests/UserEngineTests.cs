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
            //arrange:
            SeedItems();
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

            //act:
            List<User> results = _userEngine.GetAllUsers().ToList();

            //Assert:
            for(int i=0; i<3; i++)
            {
                Assert.AreEqual(expected[i].Id, results[i].Id, "Users were retrieved Incorrectly: Wrong Id");
                Assert.AreEqual(expected[i].Email, results[i].Email, "Users were retrieved Incorrectly: Wrong email");
                Assert.AreEqual(expected[i].Password, results[i].Password, "Users were retrieved Incorrectly: Wrong password");
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
                Assert.AreEqual(expected[i].Email, results[i].Email, "User " + i + " was retrieved Incorrectly: Wrong email");
                Assert.AreEqual(expected[i].Password, results[i].Password, "User " + i + " was retrieved Incorrectly: Wrong password");
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

            //act:
            List<User> results = new List<User>();
            for (int i = 0; i < 3; i++)
            {
                results.Add(_userEngine.VerifyUser(expected[i].Email, expected[i].Password));
            }

            //Assert:
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(expected[i].Id, results[i].Id, "User " + i + " was retrieved Incorrectly: Wrong Id");
                Assert.AreEqual(expected[i].Email, results[i].Email, "User " + i + " was retrieved Incorrectly: Wrong email");
                Assert.AreEqual(expected[i].Password, results[i].Password, "User " + i + " was retrieved Incorrectly: Wrong password");
            }

        }

        [TestMethod]
        public void UserEngine_InsertUser()
        {
            //arrange:
            SeedItems();
            User user = new User { Email = "newUser@gmail.com", Password = "userthatisnew" };

            //act:
            User result = _userEngine.InsertUser(user);

            //assert:
            Assert.AreEqual(4, result.Id, "User was inserted Incorrectly: Wrong Id");
            Assert.AreEqual(user.Email, result.Email, "User was inserted Incorrectly: Wrong email");
            Assert.AreEqual(user.Password, result.Password, "User was inserted Incorrectly: Wrong password");
        }

        [TestMethod]
        public void UserEngine_UpdateUser()
        {
            //Arrange:
            User user = new User { Id = 1, Email = "updatedEmail@gmail.com", Password = "updatedPassword" };

            //Act:
            User result = _userEngine.UpdateUser(user);

            //Assert:
            Assert.AreEqual(user.Id, result.Id, "User was updated Incorrectly: Wrong Id");
            Assert.AreEqual(user.Email, result.Email, "User was updated Incorrectly: Wrong email");
            Assert.AreEqual(user.Password, result.Password, "User was updated Incorrectly: Wrong password");
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
                Assert.AreEqual(expected[i].Email, results[i].Email, "User " + i + " was deleted Incorrectly: Wrong email");
                Assert.AreEqual(expected[i].Password, results[i].Password, "User " + i + " was deleted Incorrectly: Wrong password");
            }
        }

        [TestMethod]
        public void UserEngine_GetUserEmail()
        {
            List<String> emails = new List<String> { "nobody@nothing.com", "useremail@gmail.com", "groceryguy@hotmail.com" };
        }
    }

}
