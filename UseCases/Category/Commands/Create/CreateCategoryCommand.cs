using MediatR;
using UseCases.Category.Dto;

namespace UseCases.Category.Commands.Create
{
    public class CreateCategoryCommand : IRequest<Entities.Models.Category>
    {
        public CreateCategoryDto Dto { get; set; }
    }
}
