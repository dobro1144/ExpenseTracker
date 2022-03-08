using MediatR;
using UseCases.Category.Dto;

namespace UseCases.Category.Commands.Update
{
    public class UpdateCategoryCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public UpdateCategoryDto Dto { get; set; } = null!;
    }
}
