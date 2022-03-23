using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Category.Commands.Create;
using UseCases.Category.Commands.Delete;
using UseCases.Category.Commands.Update;
using UseCases.Category.Dto;
using UseCases.Category.Queries.GetAll;
using UseCases.Category.Queries.GetById;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        readonly ISender _sender;

        public CategoryController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<CategoryDto[]> GetAllAsync([FromQuery] GetAllCategoriesQueryDto dto, CancellationToken cancellationToken)
        {
            return await _sender.Send(new GetAllCategoriesQuery { Dto = dto }, cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetAsync([FromRoute]int id, CancellationToken cancellationToken)
        {
            var item = await _sender.Send(new GetCategoryByIdQuery { Id = id }, cancellationToken);
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateAsync([FromBody]CreateCategoryDto dto, CancellationToken cancellationToken)
        {
            var item = await _sender.Send(new CreateCategoryCommand { Dto = dto }, cancellationToken);
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<byte[]> UpdateAsync([FromRoute]int id, [FromBody]UpdateCategoryDto updateItem, CancellationToken cancellationToken)
        {
            return await _sender.Send(new UpdateCategoryCommand { Id = id, Dto = updateItem }, cancellationToken);
        }

        [HttpDelete("{id}/{timestamp}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]int id, [FromRoute] string timestamp, CancellationToken cancellationToken)
        {
            await _sender.Send(new DeleteCategoryCommand { Id = id, Timestamp = timestamp }, cancellationToken);
            return NoContent();
        }
    }
}