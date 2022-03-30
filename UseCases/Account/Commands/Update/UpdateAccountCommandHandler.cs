using AutoMapper;
using UseCases.Base.Commands.Update;
using UseCases.Account.Dto;
using Infrastructure.Interfaces.DataAccess;

namespace UseCases.Account.Commands.Update
{
    public class UpdateAccountCommandHandler : UpdateEntityCommandHandler<UpdateAccountCommand, UpdateAccountDto, Entities.Models.Account>
    {
        public UpdateAccountCommandHandler(IDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
