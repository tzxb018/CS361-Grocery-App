using _361Example.Engines;
using _361Example.Models;
using System.Linq;
using System.Web.Http;


namespace _361Example.Controllers
{
    [RoutePrefix("api/items")]
    public class ItemsController : ApiController
    {
        private readonly IItemsEngine _itemsEngine;
        public ItemsController(IItemsEngine itemsEngine)
        {
            _itemsEngine = itemsEngine;
        }

        // GET: api/items
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAllItems()
        {
            return Ok(_itemsEngine.GetAllItems());
        }

        // GET: api/items/5
        [System.Web.Http.Route("{id}")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetItem(string id)
        {
            var parsedId = int.Parse(id);
            Item item = _itemsEngine.GetItem(parsedId);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }


        // POST: api/items
        [Route("")]
        [HttpPost]
        public IHttpActionResult PostItem(Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _itemsEngine.InsertItem(item);

            return Ok(item);
        }

        // PUT: api/items/5
        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult PutList(string id, Item item)
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

            _itemsEngine.UpdateItem(parsedId, item);


            return Ok();
        }



        // DELETE: api/items/5
        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteItem(string id)
        {
            var parsedId = int.Parse(id);

            Item item = _itemsEngine.GetItem(parsedId);
            if (item == null)
            {
                return NotFound();
            }
            _itemsEngine.DeleteItem(item.Id);

            return Ok(item);
        }

        private bool ItemExists(int id)
        {
            return _itemsEngine.GetAllItems().Count(e => e.Id == id) > 0;
        }
    }
}
