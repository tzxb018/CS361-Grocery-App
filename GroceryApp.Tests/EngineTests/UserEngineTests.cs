using _361Example.Engines;
using _361Example.Models;
using GroceryApp.Tests.MockedAccessors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;

namespace GroceryApp.Tests
{
    [TestClass]
    public class UserEngineTests
    {

        private readonly IUserEngine userEngine;
        private readonly MockedUserAccessor mockedUserAccessor;
        private object expected;

        public UserEngineTests()
        {
            mockedUserAccessor = new MockedUserAccessor();
            userEngine = new UserEngine(mockedUserAccessor);
        }


        public void SeedItems()
        {
            mockedUserAccessor.SetState(new List<Item>
            {
                new User
                {
                    Id = 1,
                    Username = "harrypotter@gmail.com"
                },
                 new User
                {
                    Id = 2,
                    Username = "remuslupin@gmail.com"
                },
                 new Item
                {
                    Id = 3,
                    Username = "ronweasley@yahoo.com"
                }
            });
        }

       
    }

}
