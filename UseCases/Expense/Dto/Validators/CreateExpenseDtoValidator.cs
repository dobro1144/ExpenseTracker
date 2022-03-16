using FluentValidation;

namespace UseCases.Expense.Dto.Validators
{
    public class CreateExpenseDtoValidator : AbstractValidator<CreateExpenseDto>
    {
        public CreateExpenseDtoValidator()
        {
            RuleFor(x => x.CategoryId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Amount).NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(x => x.Comment).MinimumLength(450).When(x => x.Comment != null);
        }
    }
}
