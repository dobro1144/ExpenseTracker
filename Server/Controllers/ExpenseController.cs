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
        public async Task<ActionResult<ExpenseDto[]>> GetAllAsync([FromQuery]GetAllExpensesQueryDto dto, CancellationToken cancellationToken)
        {
            var items = await _sender.Send(new GetAllExpensesQuery { Dto = dto }, cancellationToken);
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseDto>> GetAsync([FromRoute]int id, CancellationToken cancellationToken)
        {
            var item = await _sender.Send(new GetExpenseByIdQuery { Id = id }, cancellationToken);
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<ExpenseDto>> CreateAsync([FromBody]CreateExpenseDto dto, CancellationToken cancellationToken)
        {
            var item = await _sender.Send(new CreateExpenseCommand { Dto = dto }, cancellationToken);
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<byte[]>> UpdateAsync([FromRoute]int id, [FromBody]UpdateExpenseDto updateItem, CancellationToken cancellationToken)
        {
            var timestamp = await _sender.Send(new UpdateExpenseCommand { Id = id, Dto = updateItem }, cancellationToken);
            return Ok(timestamp);
        }

        [HttpDelete("{id}/{timestamp}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]int id, [FromRoute]string timestamp, CancellationToken cancellationToken)
        {
            await _sender.Send(new DeleteExpenseCommand { Id = id, Timestamp = timestamp }, cancellationToken);
            return NoContent();
        }
    }
}
