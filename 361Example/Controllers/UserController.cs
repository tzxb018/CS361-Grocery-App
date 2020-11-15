//using Microsoft.AspNetCore.Mvc;
using _361Example.Engines;
using _361Example.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace _361Example.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserEngine _userEngine;
  
        public UserController(IUserEngine userEngine)
        {
            _userEngine = userEngine;

        }

        // GET: api/users
        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return _userEngine.GetAllUsers().ToArray();
        }

        // POST: api/users
        [Route("")]
        [HttpPost]
        public void PostItem(User user)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }

            _userEngine.InsertUser(user);

            //return item;
        }

    }
}

