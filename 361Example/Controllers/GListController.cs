using _361Example.Engines;
using _361Example.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace _361Example.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GListController : ControllerBase
    {
        private readonly IGListEngine _gListEngine;
        private readonly IItemsEngine _itemsEngine;

        // using dependency injection to use engines' methods
        public GListController(IGListEngine gListEngine, IItemsEngine itemsEngine)
        {
            _gListEngine = gListEngine;
            _itemsEngine = itemsEngine;
        }

        // GET: api/glist
        // function to get all the grocery lists (primarily used for testing)
        [HttpGet]
        public IEnumerable<GList> GetAllLists()
        {
            return _gListEngine.GetAllLists().ToArray();
        }

        // GET: api/user{id}
        // gets all the glists for a specific user (defined by the user's id)
        [Route("user{id}")]
        [HttpGet]
        public IEnumerable<GList> GetUserGLists(string id)
        {
            var parsedId = int.Parse(id);

            return _gListEngine.GetUserLists(parsedId);
        }

        // GET: api/glist/5
        // getting a specific list based on the glist's id
        [Route("{id}")]
        [HttpGet]
        public GList GetList(string id)
        {
            var parsedId = int.Parse(id);
            GList glist = _gListEngine.GetList(parsedId);

            if (glist == null)
            {
                return null;
            }

            return glist;
        }


        // adding a new glist to the database
        // POST: api/glist
        [Route("")]
        [HttpPost]
        public void PostList(GList glist)
        {
            _gListEngine.InsertList(glist);

        }

        // editting a specific glist based on the id
        // PUT: api/glist/5
        [Route("{id}")]
        [HttpPut]
        public void PutList(string id, GList glist)
        {
            var parsedId = int.Parse(id);

            _gListEngine.UpdateList(parsedId, glist);


        }

        // deleting a specific glist based by ID
        // DELETE: api/glists/5
        [Route("{id}")]
        [HttpDelete]
        public void DeleteList(string id)
        {
            var parsedId = int.Parse(id);

            GList glist = _gListEngine.GetList(parsedId);

            // deletes each item in the grocery list before deleting the list itself to prevent SQL errors
            var itemsInGList = _itemsEngine.GetListItems(parsedId);

            // checks if there are any items in the list
            if (itemsInGList.Any())
            {
                // iterates through each item in the glist and deletes them by their Id's
                foreach (Item item in itemsInGList)
                {
                    _itemsEngine.DeleteItem(item.Id);
                }
            }

            // deleting the acutal list itself
            _gListEngine.DeleteList(glist.Id);

        }

    }
}
