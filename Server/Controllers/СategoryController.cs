using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ÑategoryController : ControllerBase
    {
        private readonly ILogger<ÑategoryController> logger;
        private readonly ExpenseContext context;

        public ÑategoryController(ILogger<ÑategoryController> logger, ExpenseContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> GetAsync()
        {
            return await context.Categories.ToArrayAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetAsync(int id)
        {
            var item = await context.Categories.FindAsync(id);
            if (item == null)
                return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Category>> PostAsync(Category item)
        {
            if (await context.Categories.AnyAsync(x => x.Name == item.Name))
                return Conflict();
            await context.Categories.AddAsync(item);
            try {
                await context.SaveChangesAsync();
            } catch {
                return BadRequest();
            }
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Category updateItem)
        {
            if (id != updateItem.Id)
                return BadRequest();

            var item = await context.Categories.FindAsync(id);
            if (item != null)
                context.Categories.Remove(item);
            else
                updateItem.Id = 0;
            context.Categories.Add(updateItem);
            try {
                await context.SaveChangesAsync();
            } catch {
                return BadRequest();
            }

            if (item == null)
                return CreatedAtAction("Get", new { id = updateItem.Id }, updateItem);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var item = await context.Categories.FindAsync(id);
            if (item == null)
                return NotFound();

            context.Categories.Remove(item);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}