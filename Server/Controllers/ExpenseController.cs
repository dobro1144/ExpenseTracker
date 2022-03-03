using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using UseCases.Expense.Commands.Create;
using UseCases.Expense.Commands.Delete;
using UseCases.Expense.Commands.Update;
using UseCases.Expense.Dto;
using UseCases.Expense.Queries.GetAll;
using UseCases.Expense.Queries.GetById;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : Controller
    {
        private readonly ILogger<ExpenseController> _logger;
        private readonly ISender _sender;

        public ExpenseController(ILogger<ExpenseController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        [HttpGet]
        public async Task<IEnumerable<ExpenseDto>> GetAsync()
        {
            return await _sender.Send(new GetAllExpensesQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseDto>> GetAsync(int id)
        {
            var item = await _sender.Send(new GetExpenseByIdQuery { Id = id });
            if (item == null)
                return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<ExpenseDto>> PostAsync([FromBody]CreateExpenseDto dto)
        {
            var item = await _sender.Send(new CreateExpenseCommand { Dto = dto });
            if (item == null)
                return BadRequest();
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]ExpenseDto updateItem)
        {
            var result = await _sender.Send(new UpdateExpenseCommand { Expense = updateItem });
            if (!result)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _sender.Send(new DeleteExpenseCommand { Id = id });
            if (!result)
                return NotFound();
            return Ok();
        }
    }
}
