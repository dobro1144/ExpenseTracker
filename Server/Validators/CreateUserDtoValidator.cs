using FluentValidation;
using UseCases.User.Dto;

namespace Server.Validators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(450);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(450);
        }
    }
}
