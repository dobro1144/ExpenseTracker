using MediatR;
using UseCases.Category.Dto;

namespace UseCases.Category.Commands.Create
{
    public class CreateCategoryCommand : IRequest<CategoryDto?>
    {
        public CreateCategoryDto Dto { get; set; } = null!;
    }
}
