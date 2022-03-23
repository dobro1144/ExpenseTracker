using MediatR;

namespace UseCases.Base.Commands.Update
{
    public abstract class UpdateEntityCommand<TRequestDto> : IRequest<byte[]>
        where TRequestDto : class
    {
        public int Id { get; set; }
        public TRequestDto Dto { get; set; } = null!;
    }
}
