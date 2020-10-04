
using _361Example.Engines;
using _361Example.Models;
using System.Linq;
using System.Web.Http;

namespace _361Example.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IUserEngine _userEngine;

        public UserController(IUserEngine userEngine)
        {
            _userEngine = userEngine;
        }

        // GET: api/user
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetGroceryLists()
        {
            return Ok(_userEngine.GetGroceryLists());
        }

        // GET: api/user/5
        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetList(string id)
        {
            var parsedId = int.Parse(id);
            GroceryList glist = _userEngine.GetList(parsedId);

            if (glist == null)
            {
                return NotFound();
            }

            return Ok(glist);
        }


        // POST: api/user
        [Route("")]
        [HttpPost]
        public IHttpActionResult PostList(GroceryList glist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _userEngine.InsertList(glist);

            return Ok(glist);
        }

        // PUT: api/users/5
        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult PutList(string id, GroceryList glist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var parsedId = int.Parse(id);

            if (parsedId != glist.AccountId)
            {
                return BadRequest();
            }

            _userEngine.UpdateList(parsedId, glist);


            return Ok();
        }



        // DELETE: api/users/5
        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteUser(string id)
        {
            var parsedId = int.Parse(id);

            GroceryList glist = _userEngine.GetList(parsedId);

            if (glist == null)
            {
                return NotFound();
            }

            _userEngine.Delete(glist.AccountId);


            return Ok(glist);
        }


        private bool ListExists(int id)
        {
            return _userEngine.GetGroceryLists().Count(e => e.AccountId == id) > 0;
        }

    }
}
