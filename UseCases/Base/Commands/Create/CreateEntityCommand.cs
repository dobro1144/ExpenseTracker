using MediatR;

namespace UseCases.Base.Commands.Create
{
    public abstract class CreateEntityCommand<TRequestDto, TResponeDto> : IRequest<TResponeDto>
        where TRequestDto : class
        where TResponeDto : class
    {
        public TRequestDto Dto { get; set; } = null!;
    }
}
