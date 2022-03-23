using MediatR;

namespace UseCases.Base.Commands.Delete
{
    public abstract class DeleteEntityCommand : IRequest
    {
        public int Id { get; set; }
        public string Timestamp { get; set; } = null!;
    }
}
