using FluentValidation;

namespace UseCases.Expense.Dto.Validators
{
    public class CreateExpenseDtoValidator : AbstractValidator<CreateExpenseDto>
    {
        public CreateExpenseDtoValidator()
        {
            RuleFor(x => x.CategoryId).NotNull().GreaterThan(0);
            RuleFor(x => x.Amount).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x => x.Comment).MaximumLength(450).When(x => x.Comment != null);
        }
    }
}
