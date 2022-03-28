using AutoMapper;
using Infrastructure.Interfaces;
using UseCases.Base.Commands.Create;
using UseCases.Account.Dto;

namespace UseCases.Account.Commands.Create
{
    public class CreateAccountCommandHandler : CreateEntityCommandHandler<CreateAccountCommand, CreateAccountDto, AccountDto, Entities.Models.Account>
    {
        public CreateAccountCommandHandler(IDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
