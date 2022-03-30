using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Account.Commands.Create;
using UseCases.Account.Commands.Delete;
using UseCases.Account.Commands.Update;
using UseCases.Account.Dto;
using UseCases.Account.Queries.GetAll;
using UseCases.Account.Queries.GetById;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        readonly ISender _sender;

        public AccountController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult<AccountBalanceDto[]>> GetAllAsync(CancellationToken cancellationToken)
        {
            var items = await _sender.Send(new GetAllAccountsQuery(), cancellationToken);
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDto>> GetAsync([FromRoute]int id, CancellationToken cancellationToken)
        {
            var item = await _sender.Send(new GetAccountByIdQuery { Id = id }, cancellationToken);
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<AccountDto>> CreateAsync([FromBody] CreateAccountDto dto, CancellationToken cancellationToken)
        {
            var item = await _sender.Send(new CreateAccountCommand { Dto = dto }, cancellationToken);
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<byte[]>> UpdateAsync([FromRoute]int id, [FromBody] UpdateAccountDto updateItem, CancellationToken cancellationToken)
        {
            var timestamp = await _sender.Send(new UpdateAccountCommand { Id = id, Dto = updateItem }, cancellationToken);
            return Ok(timestamp);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]int id, [FromBody] string timestamp, CancellationToken cancellationToken)
        {
            await _sender.Send(new DeleteAccountCommand { Id = id, Timestamp = timestamp }, cancellationToken);
            return NoContent();
        }
    }
}