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
    public class GListController : ControllerBase
    {
        private readonly IGListEngine _gListEngine;
        private readonly IItemsEngine _itemsEngine;
        public GListController(IGListEngine gListEngine, IItemsEngine itemsEngine)
        {
            _gListEngine = gListEngine;
            _itemsEngine = itemsEngine;
        }

        // GET: api/glist
        [HttpGet]
        public IEnumerable<GList> GetAllLists()
        {
            return _gListEngine.GetAllLists().ToArray();
        }

        [Route("user{id}")]
        [HttpGet]
        public IEnumerable<GList> GetUserGLists(string id)
        {
            var parsedId = int.Parse(id);

            return _gListEngine.GetUserLists(parsedId);
        }

        // GET: api/glist/5
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


        // POST: api/glist
        [Route("")]
        [HttpPost]
        public void PostList(GList glist)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }

            _gListEngine.InsertList(glist);

            //return Ok(glist);
        }

        // PUT: api/glist/5
        [Route("{id}")]
        [HttpPut]
        public void PutList(string id, GList glist)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }
            var parsedId = int.Parse(id);

            if (parsedId != glist.Id)
            {
                //return BadRequest();
            }

            _gListEngine.UpdateList(parsedId, glist);


            //return Ok();
        }



        // DELETE: api/glists/5
        [Route("{id}")]
        [HttpDelete]
        public void DeleteList(string id)
        {
            var parsedId = int.Parse(id);

            GList glist = _gListEngine.GetList(parsedId);
            if (glist == null)
            {

            }

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

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool ListExists(int id)
        {
            return _gListEngine.GetAllLists().Count(e => e.Id == id) > 0;
        }

    }
}
