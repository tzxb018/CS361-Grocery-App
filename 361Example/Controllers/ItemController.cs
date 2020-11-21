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

        [Route("glist{id}")]
        [HttpGet]
        public IEnumerable<Item> GetListItems(string id)
        {
            var parsedId = int.Parse(id);
            return _itemsEngine.GetListItems(parsedId);
        }

        // POST: api/items
        [Route("")]
        [HttpPost]
        public void PostItem(Item item)
        {
            _itemsEngine.InsertItem(item);
        }

        // PUT: api/items/5
        [Route("{id}")]
        [HttpPut]
        public void PutList(string id, Item item)
        {
            var parsedId = int.Parse(id);

            _itemsEngine.UpdateItem(parsedId, item);
        }

        // DELETE: api/items/5
        [Route("{id}")]
        [HttpDelete]
        public void DeleteItem(string id)
        {
            var parsedId = int.Parse(id);

            Item item = _itemsEngine.GetItem(parsedId);

            _itemsEngine.DeleteItem(item.Id);
        }

    }
}
