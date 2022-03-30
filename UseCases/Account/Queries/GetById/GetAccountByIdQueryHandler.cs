using AutoMapper;
using UseCases.Base.Queries.GetById;
using UseCases.Account.Dto;
using Infrastructure.Interfaces.DataAccess;

namespace UseCases.Account.Queries.GetById
{
    public class GetAccountByIdQueryHandler : GetEntityByIdQueryHandler<GetAccountByIdQuery, AccountDto, Entities.Models.Account>
    {
        public GetAccountByIdQueryHandler(IReadDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
