using FluentValidation;
using UseCases.Account.Dto;

namespace Server.Validators.Account
{
    public class CreateAccountDtoValidator : AbstractValidator<CreateAccountDto>
    {
        public CreateAccountDtoValidator()
        {
            RuleFor(x => x.UserId).NotNull().GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(450);
        }
    }
}
