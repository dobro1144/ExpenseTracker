using FluentValidation;
using UseCases.Account.Dto;

namespace Server.Validators.Account
{
    public class GetAllAccountsQueryDtoValidator : AbstractValidator<GetAllAccountsQueryDto>
    {
        public GetAllAccountsQueryDtoValidator()
        {
            RuleForEach(x => x.Users).NotNull().GreaterThan(0).When(x => x.Users != null);
            RuleFor(x => x.Name).MaximumLength(450).When(x => x.Name != null);
        }
    }
}
