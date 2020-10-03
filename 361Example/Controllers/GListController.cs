//using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Web.Http;

namespace _361Example.Controllers
{
    [RoutePrefix("api/glist")]
    public class GListController : ApiController
    {
        private readonly IGListEngine _gListEngine;
        public GListController(IGListEngine gListEngine)
        {
            _gListEngine = gListEngine;
        }

        // GET: api/glist
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAllItems()
        {
            return Ok(_gListEngine.GetAllItems());
        }

        // GET: api/glist/5
        [System.Web.Http.Route("{id}")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult getItem(string id)
        {
            var parsedId = int.Parse(id);
            Item item = _gListEngine.GetItem(parsedId);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }


        // POST: api/Contacts
        [Route("")]
        [HttpPost]
        public IHttpActionResult PostContact(Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _gListEngine.InsertItem(item);

            return Ok(item);
        }

        // PUT: api/Contacts/5
        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult PutContact(string id, Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var parsedId = int.Parse(id);

            if (parsedId != item.Id)
            {
                return BadRequest();
            }

            _gListEngine.UpdateItem(parsedId, item);


            return Ok();
        }



        // DELETE: api/Contacts/5
        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteContact(string id)
        {
            var parsedId = int.Parse(id);

            Item item = _gListEngine.GetItem(parsedId);
            if (item == null)
            {
                return NotFound();
            }
            _gListEngine.DeleteItem(item.Id);

            return Ok(item);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool ItemExists(int id)
        {
            return _gListEngine.GetAllItems().Count(e => e.Id == id) > 0;
        }

    }
}
