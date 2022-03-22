using MediatR;

namespace UseCases.Category.Commands.Delete
{
    public class DeleteCategoryCommand : IRequest
    {
        public int Id { get; set; }
        public byte[] Timestamp { get; set; } = null!;
    }
}
