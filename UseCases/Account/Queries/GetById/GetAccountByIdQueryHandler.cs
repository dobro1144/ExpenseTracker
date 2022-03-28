using AutoMapper;
using Infrastructure.Interfaces;
using UseCases.Base.Queries.GetById;
using UseCases.Account.Dto;

namespace UseCases.Account.Queries.GetById
{
    public class GetAccountByIdQueryHandler : GetEntityByIdQueryHandler<GetAccountByIdQuery, AccountDto, Entities.Models.Account>
    {
        public GetAccountByIdQueryHandler(IReadDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
