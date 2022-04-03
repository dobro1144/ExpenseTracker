using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using UseCases.User.Commands.Create;
using UseCases.User.Commands.Delete;
using UseCases.User.Commands.Update;
using UseCases.User.Dto;
using UseCases.User.Queries.GetAll;
using UseCases.User.Queries.GetById;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        readonly ISender _sender;

        public UserController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult<UserDto[]>> GetAllAsync([FromQuery] GetAllUsersQueryDto dto, CancellationToken cancellationToken)
        {
            var items = await _sender.Send(new GetAllUsersQuery { Dto = dto }, cancellationToken);
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetAsync([FromRoute] int id, CancellationToken cancellationToken)
        {
            var item = await _sender.Send(new GetUserByIdQuery { Id = id }, cancellationToken);
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateAsync([FromBody] CreateUserDto dto, CancellationToken cancellationToken)
        {
            var item = await _sender.Send(new CreateUserCommand { Dto = dto }, cancellationToken);
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<byte[]>> UpdateAsync([FromRoute] int id, [FromBody] UpdateUserDto updateItem, CancellationToken cancellationToken)
        {
            var timestamp = await _sender.Send(new UpdateUserCommand { Id = id, Dto = updateItem }, cancellationToken);
            return Ok(timestamp);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id, [FromBody] string timestamp, CancellationToken cancellationToken)
        {
            await _sender.Send(new DeleteUserCommand { Id = id, Timestamp = timestamp }, cancellationToken);
            return NoContent();
        }
    }
}