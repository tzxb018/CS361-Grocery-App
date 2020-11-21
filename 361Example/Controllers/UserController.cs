using _361Example.Engines;
using _361Example.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace _361Example.Controllers
{
    /**
     * The UserController class handles the workflow for account-related actions in the application,
     * such as creating a new account.
     **/
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserEngine _userEngine;
  
        // using dependency injection to use the methods in IUserEngine
        public UserController(IUserEngine userEngine)
        {
            _userEngine = userEngine;

        }

        // function to get all users in the database (primarily used for testing purposes)
        // GET: api/users
        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return _userEngine.GetAllUsers().ToArray();
        }

        // function for adding a new user into the database
        // POST: api/users
        [Route("")]
        [HttpPost]
        public void PostItem(User user)
        {
            _userEngine.InsertUser(user);
        }

    }
}

