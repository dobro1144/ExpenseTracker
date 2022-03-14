using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
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
        readonly ISender _sender;

        public ExpenseController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ExpenseDto[]> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _sender.Send(new GetAllExpensesQuery(), cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseDto>> GetAsync([FromRoute]int id, CancellationToken cancellationToken)
        {
            var item = await _sender.Send(new GetExpenseByIdQuery { Id = id }, cancellationToken);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<ExpenseDto>> CreateAsync([FromBody]CreateExpenseDto dto, CancellationToken cancellationToken)
        {
            var item = await _sender.Send(new CreateExpenseCommand { Dto = dto }, cancellationToken);
            if (item == null)
                return BadRequest();
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute]int id, [FromBody]UpdateExpenseDto updateItem, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new UpdateExpenseCommand { Id = id, Dto = updateItem }, cancellationToken);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]int id, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new DeleteExpenseCommand { Id = id }, cancellationToken);
            if (!result)
                return NotFound();
            return Ok();
        }
    }
}
