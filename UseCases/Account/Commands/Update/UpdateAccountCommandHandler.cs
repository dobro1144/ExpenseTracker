using AutoMapper;
using Infrastructure.Interfaces;
using UseCases.Base.Commands.Update;
using UseCases.Account.Dto;

namespace UseCases.Account.Commands.Update
{
    public class UpdateAccountCommandHandler : UpdateEntityCommandHandler<UpdateAccountCommand, UpdateAccountDto, Entities.Models.Account>
    {
        public UpdateAccountCommandHandler(IDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
