using _361Example.Engines;
using _361Example.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace _361Example.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemsEngine _itemsEngine;
        public ItemController(IItemsEngine itemsEngine)
        {
            _itemsEngine = itemsEngine;
        }

        // GET: api/items
        [HttpGet]
        public IEnumerable<Item> GetAllItems()
        {
            return _itemsEngine.GetAllItems().ToArray();
        }

        [Route("{id}")]
        [HttpGet]
        public IEnumerable<Item> GetListItems(string id)
        {
            var parsedId = int.Parse(id);
            return _itemsEngine.GetListItems(parsedId);
        }

        // GET: api/items/5
        //[Route("{id}")]
        //[HttpGet]
        //public Item GetItem(string id)
        //{
        //    var parsedId = int.Parse(id);
        //    Item item = _itemsEngine.GetItem(parsedId);

        //    if (item == null)
        //    {
        //        return null;
        //    }

        //    return item;
        //}


        // POST: api/items
        [Route("")]
        [HttpPost]
        public void PostItem(Item item)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }

            _itemsEngine.InsertItem(item);

            //return item;
        }

        // PUT: api/items/5
        [Route("{id}")]
        [HttpPut]
        public void PutList(string id, Item item)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }
            var parsedId = int.Parse(id);

            if (parsedId != item.Id)
            {
                //return BadRequest();
            }

            _itemsEngine.UpdateItem(parsedId, item);


            //return Ok();
        }



        // DELETE: api/items/5
        [Route("{id}")]
        [HttpDelete]
        public void DeleteItem(string id)
        {
            var parsedId = int.Parse(id);

            Item item = _itemsEngine.GetItem(parsedId);
            if (item == null)
            {
                //return NotFound();
            }
            _itemsEngine.DeleteItem(item.Id);

            //return Ok(item);
        }

        private bool ItemExists(int id)
        {
            return _itemsEngine.GetAllItems().Count(e => e.Id == id) > 0;
        }
    }
}
