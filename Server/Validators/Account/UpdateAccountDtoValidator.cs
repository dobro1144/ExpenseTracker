using FluentValidation;
using UseCases.Account.Dto;

namespace Server.Validators.Account
{
    public class UpdateAccountDtoValidator : AbstractValidator<UpdateAccountDto>
    {
        public UpdateAccountDtoValidator()
        {
            RuleFor(x => x.UserId).NotNull().GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(450);
        }
    }
}
