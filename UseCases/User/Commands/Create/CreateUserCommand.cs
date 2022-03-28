using UseCases.Base.Commands.Create;
using UseCases.User.Dto;

namespace UseCases.User.Commands.Create
{
    public class CreateUserCommand : CreateEntityCommand<CreateUserDto, UserDto>
    {
    }
}
