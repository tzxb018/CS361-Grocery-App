using _361Example.Engines;
using _361Example.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace _361Example.Controllers
{
    /**
     * The ItemController class handles the workflow for item-related actions in the application,
     * such as retrieving an item, adding an item, updating an item, and deleting an item.
     **/
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemsEngine _itemsEngine;

        // using dependency injection to use the methods in IItemsEngine
        public ItemController(IItemsEngine itemsEngine)
        {
            _itemsEngine = itemsEngine;
        }

        // function to get all items in the database (primarily used for testing)
        // GET: api/items
        [HttpGet]
        public IEnumerable<Item> GetAllItems()
        {
            return _itemsEngine.GetAllItems().ToArray();
        }

        // function to get items in the database for a given grocery list
        [Route("glist{id}")]
        [HttpGet]
        public IEnumerable<Item> GetListItems(string id)
        {
            var parsedId = int.Parse(id);
            return _itemsEngine.GetListItems(parsedId);
        }

        // adding a new item to the database
        // POST: api/items
        [Route("")]
        [HttpPost]
        public void PostItem(Item item)
        {
            _itemsEngine.InsertItem(item);
        }

        // editing a specific item based on id
        // PUT: api/items/5
        [Route("{id}")]
        [HttpPut]
        public void PutList(string id, Item item)
        {
            var parsedId = int.Parse(id);

            _itemsEngine.UpdateItem(parsedId, item);
        }

        // deleting a specific item based on id
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
