using FluentValidation;
using UseCases.Category.Dto;

namespace Server.Validators.Category
{
    public class MoveCategoryExpensesDtoValidator : AbstractValidator<MoveCategoryExpensesDto>
    {
        public MoveCategoryExpensesDtoValidator()
        {
            RuleFor(x => x.FromId).NotNull().GreaterThan(0);
            RuleFor(x => x.ToId).NotNull().GreaterThan(0);
            RuleFor(x => x.FromId)
                .Must((model, fromId) => fromId != model.ToId)
                .WithMessage("'FromId' must not equal to 'ToId'");
        }
    }
}
