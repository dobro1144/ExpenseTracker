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
    public class ExpenseController : Controller
    {
        private readonly ILogger<ExpenseController> logger;
        private readonly ExpenseContext context;

        public ExpenseController(ILogger<ExpenseController> logger, ExpenseContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Expense>> GetAsync()
        {
            return await context.Expenses.ToArrayAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Expense>> GetAsync(int id)
        {
            var item = await context.Expenses.FindAsync(id);
            if (item == null)
                return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Expense>> PostAsync(Expense item)
        {
            await context.Expenses.AddAsync(item);
            try {
                await context.SaveChangesAsync();
            } catch {
                return BadRequest();
            }
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Expense updateItem)
        {
            if (id != updateItem.Id)
                return BadRequest();

            var item = await context.Expenses.FindAsync(id);
            if (item == null)
                return NotFound();
            item.CategoryId = updateItem.CategoryId;
            item.Amount = updateItem.Amount;
            item.Commentary = updateItem.Commentary;
            try {
                await context.SaveChangesAsync();
            } catch {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var item = await context.Expenses.FindAsync(id);
            if (item == null)
                return NotFound();

            context.Expenses.Remove(item);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
