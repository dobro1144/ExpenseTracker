using MediatR;
using UseCases.Expense.Dto;

namespace UseCases.Base.Queries.GetById
{
    public class GetEntityByIdQuery<TResponeDto> : IRequest<TResponeDto>
        where TResponeDto : class
    {
        public int Id { get; set; }
    }
}
