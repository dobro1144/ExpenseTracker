using MediatR;

namespace UseCases.Category.Commands.Delete
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
