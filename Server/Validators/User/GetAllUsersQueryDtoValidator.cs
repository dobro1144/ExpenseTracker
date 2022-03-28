using FluentValidation;
using UseCases.User.Dto;

namespace Server.Validators.User
{
    public class GetAllUsersQueryDtoValidator : AbstractValidator<GetAllUsersQueryDto>
    {
        public GetAllUsersQueryDtoValidator()
        {
            RuleFor(x => x.Name).EmailAddress().MaximumLength(450).When(x => x.Name != null);
            RuleFor(x => x.Name).MaximumLength(450).When(x => x.Name != null);
        }
    }
}
