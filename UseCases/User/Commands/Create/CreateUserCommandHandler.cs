using AutoMapper;
using Infrastructure.Interfaces;
using UseCases.Base.Commands.Create;
using UseCases.User.Dto;

namespace UseCases.User.Commands.Create
{
    public class CreateUserCommandHandler : CreateEntityCommandHandler<CreateUserCommand, CreateUserDto, UserDto, Entities.Models.User>
    {
        public CreateUserCommandHandler(IDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
