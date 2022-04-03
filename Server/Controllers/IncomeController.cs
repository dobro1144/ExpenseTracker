using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Income.Commands.Create;
using UseCases.Income.Commands.Delete;
using UseCases.Income.Commands.Update;
using UseCases.Income.Dto;
using UseCases.Income.Queries.GetAll;
using UseCases.Income.Queries.GetById;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncomeController : Controller
    {
        readonly ISender _sender;

        public IncomeController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult<IncomeDto[]>> GetAllAsync([FromQuery] GetAllIncomesQueryDto dto, CancellationToken cancellationToken)
        {
            var items = await _sender.Send(new GetAllIncomesQuery { Dto = dto }, cancellationToken);
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IncomeDto>> GetAsync([FromRoute] int id, CancellationToken cancellationToken)
        {
            var item = await _sender.Send(new GetIncomeByIdQuery { Id = id }, cancellationToken);
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<IncomeDto>> CreateAsync([FromBody] CreateIncomeDto dto, CancellationToken cancellationToken)
        {
            var item = await _sender.Send(new CreateIncomeCommand { Dto = dto }, cancellationToken);
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<byte[]>> UpdateAsync([FromRoute] int id, [FromBody] UpdateIncomeDto updateItem, CancellationToken cancellationToken)
        {
            var timestamp = await _sender.Send(new UpdateIncomeCommand { Id = id, Dto = updateItem }, cancellationToken);
            return Ok(timestamp);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id, [FromBody] string timestamp, CancellationToken cancellationToken)
        {
            await _sender.Send(new DeleteIncomeCommand { Id = id, Timestamp = timestamp }, cancellationToken);
            return NoContent();
        }
    }
}
