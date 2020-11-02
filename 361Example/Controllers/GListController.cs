//using Microsoft.AspNetCore.Mvc;
using _361Example.Engines;
using _361Example.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace _361Example.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class GListController : ControllerBase
    {
        private readonly IGListEngine _gListEngine;
        public GListController(IGListEngine gListEngine)
        {
            _gListEngine = gListEngine;
        }

        // GET: api/glist
        [HttpGet]
        public IEnumerable<GList> GetAllLists()
        {
            return _gListEngine.GetAllLists().ToArray();
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
                //return NotFound();
            }
            _gListEngine.DeleteList(glist.Id);

            //return Ok(glist);
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
