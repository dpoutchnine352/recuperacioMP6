using Microsoft.AspNetCore.Mvc;
using dpc.InternetSalesAPI;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dpc.InternetSalesAPI
{
  [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ItemService _itemService;

        public ItemController(ItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            var items = _itemService.GetItems();
            return Ok(items);
        }

        [HttpGet("{code}")]
        public ActionResult<Item> GetItem(string code)
        {
            var item = _itemService.GetItemByCode(code);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public ActionResult<Item> CreateItem(Item item)
        {
            _itemService.CreateItem(item);
            return CreatedAtAction(nameof(GetItem), new { code = item.Code }, item);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> UpdateItem(string code, [FromBody] Item item)
        {
            if (code != item.Code)
            {
                return BadRequest();
            }

            try
            {
                await _itemService.UpdateItemAsync(item);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{code}")]
        public IActionResult DeleteItem(string code)
        {
            var existingItem = _itemService.GetItemByCode(code);
            if (existingItem == null)
            {
                return NotFound();
            }

            _itemService.DeleteItem(code);
            return NoContent();
        }
    }
}
