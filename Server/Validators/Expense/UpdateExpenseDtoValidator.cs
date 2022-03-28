using FluentValidation;
using UseCases.Expense.Dto;

namespace Server.Validators.Expense
{
    public class UpdateExpenseDtoValidator : AbstractValidator<UpdateExpenseDto>
    {
        public UpdateExpenseDtoValidator()
        {
            RuleFor(x => x.AccountId).NotNull().GreaterThan(0);
            RuleFor(x => x.CategoryId).NotNull().GreaterThan(0);
            RuleFor(x => x.Amount).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x => x.Comment).MaximumLength(450).When(x => x.Comment != null);
        }
    }
}
