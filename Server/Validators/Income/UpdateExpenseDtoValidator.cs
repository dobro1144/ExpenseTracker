using FluentValidation;
using UseCases.Income.Dto;

namespace Server.Validators.Income
{
    public class UpdateIncomeDtoValidator : AbstractValidator<UpdateIncomeDto>
    {
        public UpdateIncomeDtoValidator()
        {
            RuleFor(x => x.AccountId).NotNull().GreaterThan(0);
            RuleFor(x => x.Amount).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x => x.Comment).MaximumLength(450).When(x => x.Comment != null);
        }
    }
}
