//using Microsoft.AspNetCore.Mvc;
using _361Example.Engines;
using _361Example.Models;
using System.Linq;
using System.Web.Http;

namespace _361Example.Controllers
{
    [RoutePrefix("api/glists")]
    public class GListController : ApiController
    {
        private readonly IGListEngine _gListEngine;
        public GListController(IGListEngine gListEngine)
        {
            _gListEngine = gListEngine;
        }

        // GET: api/glists
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAllLists()
        {
            return Ok(_gListEngine.GetAllLists());
        }

        // GET: api/glist/5
        [System.Web.Http.Route("{id}")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetList(string id)
        {
            var parsedId = int.Parse(id);
            GList glist = _gListEngine.GetList(parsedId);

            if (glist == null)
            {
                return NotFound();
            }

            return Ok(glist);
        }


        // POST: api/glists
        [Route("")]
        [HttpPost]
        public IHttpActionResult PostList(GList glist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _gListEngine.InsertList(glist);

            return Ok(glist);
        }

        // PUT: api/glists/5
        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult PutList(string id, GList glist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var parsedId = int.Parse(id);

            if (parsedId != glist.Id)
            {
                return BadRequest();
            }

            _gListEngine.UpdateList(parsedId, glist);


            return Ok();
        }



        // DELETE: api/glists/5
        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteList(string id)
        {
            var parsedId = int.Parse(id);

            GList glist = _gListEngine.GetList(parsedId);
            if (glist == null)
            {
                return NotFound();
            }
            _gListEngine.DeleteList(glist.Id);

            return Ok(glist);
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
