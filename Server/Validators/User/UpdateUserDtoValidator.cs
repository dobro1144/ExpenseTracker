using FluentValidation;
using UseCases.User.Dto;

namespace Server.Validators.User
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(450);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(450);
        }
    }
}
