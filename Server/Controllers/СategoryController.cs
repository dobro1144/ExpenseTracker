using Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
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
    public class ÑategoryController : ControllerBase
    {
        readonly ILogger<ÑategoryController> _logger;
        readonly ISender _sender;

        public ÑategoryController(ILogger<ÑategoryController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> GetAsync()
        {
            return await _sender.Send(new GetAllCategoriesQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetAsync(int id)
        {
            var item = await _sender.Send(new GetCategoryByIdQuery { Id = id });
            if (item == null)
                return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Category>> PostAsync([FromBody]CreateCategoryDto dto)
        {
            var item = await _sender.Send(new CreateCategoryCommand { Dto = dto });
            if (item == null)
                return BadRequest();
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]Category updateItem)
        {
            var result = await _sender.Send(new UpdateCategoryCommand { Category = updateItem });
            if (!result)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _sender.Send(new DeleteCategoryCommand { Id = id });
            if (!result)
                return NotFound();
            return Ok();
        }
    }
}