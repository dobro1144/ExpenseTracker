using MediatR;

namespace UseCases.Base.Queries.GetAll
{
    public class GetAllEntitiesQuery<TRequestDto, TResponseDto> : IRequest<TResponseDto[]>
        where TRequestDto : class
        where TResponseDto : class
    {
        public TRequestDto Dto { get; set; } = null!;
    }
}
