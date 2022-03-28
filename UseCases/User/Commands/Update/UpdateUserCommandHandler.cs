using AutoMapper;
using Infrastructure.Interfaces;
using UseCases.Base.Commands.Update;
using UseCases.User.Dto;

namespace UseCases.User.Commands.Update
{
    public class UpdateUserCommandHandler : UpdateEntityCommandHandler<UpdateUserCommand, UpdateUserDto, Entities.Models.User>
    {
        public UpdateUserCommandHandler(IDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
