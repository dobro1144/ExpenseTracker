using AutoMapper;
using Infrastructure.Interfaces.DataAccess;
using UseCases.Base.Queries.GetById;
using UseCases.Income.Dto;

namespace UseCases.Income.Queries.GetById
{
    public class GetIncomeByIdQueryHandler : GetEntityByIdQueryHandler<GetIncomeByIdQuery, IncomeDto, Entities.Models.Income>
    {
        public GetIncomeByIdQueryHandler(IReadDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
