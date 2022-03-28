using UseCases.Base.Commands.Create;
using UseCases.Account.Dto;

namespace UseCases.Account.Commands.Create
{
    public class CreateAccountCommand : CreateEntityCommand<CreateAccountDto, AccountDto>
    {
    }
}
