using FluentValidation;
using UseCases.Income.Dto;

namespace Server.Validators.Income
{
    public class CreateIncomeDtoValidator : AbstractValidator<CreateIncomeDto>
    {
        public CreateIncomeDtoValidator()
        {
            RuleFor(x => x.AccountId).NotNull().GreaterThan(0);
            RuleFor(x => x.Amount).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x => x.Comment).MaximumLength(450).When(x => x.Comment != null);
        }
    }
}
