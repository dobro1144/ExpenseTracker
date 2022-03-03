using MediatR;

namespace UseCases.Category.Commands.Update
{
    public class UpdateCategoryCommand : IRequest<bool>
    {
        public Entities.Models.Category Category { get; set; }
    }
}
