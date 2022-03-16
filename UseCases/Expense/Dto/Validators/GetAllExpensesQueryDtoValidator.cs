using FluentValidation;
using System;

namespace UseCases.Expense.Dto.Validators
{
    public class GetAllExpensesQueryDtoValidator : AbstractValidator<GetAllExpensesQueryDto>
    {
        public GetAllExpensesQueryDtoValidator()
        {
            RuleForEach(x => x.Categories).NotEmpty().GreaterThan(0).When(x => x.Categories != null);
            RuleFor(x => x.AmountMin).GreaterThanOrEqualTo(0).When(x => x.AmountMin.HasValue);
            RuleFor(x => x.AmountMax).GreaterThanOrEqualTo(0).When(x => x.AmountMax.HasValue);
            RuleFor(x => x.AmountMin)
                .Must((model, amountMin) => amountMin <= model.AmountMax)
                .When(x => x.AmountMin.HasValue && x.AmountMax.HasValue);
            RuleFor(x => x.FromDate).GreaterThanOrEqualTo(DateTime.MinValue).When(x => x.FromDate.HasValue);
            RuleFor(x => x.ToDate).LessThanOrEqualTo(DateTime.MaxValue).When(x => x.ToDate.HasValue);
            RuleFor(x => x.FromDate)
                .Must((model, fromDate) => fromDate <= model.ToDate)
                .When(x => x.FromDate.HasValue && x.ToDate.HasValue);
            RuleFor(x => x.Comment).MaximumLength(450).When(x => x.Comment != null);
        }
    }
}
