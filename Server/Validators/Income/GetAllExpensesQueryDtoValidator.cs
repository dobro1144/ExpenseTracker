using FluentValidation;
using System;
using UseCases.Income.Dto;

namespace Server.Validators.Income
{
    public class GetAllIncomesQueryDtoValidator : AbstractValidator<GetAllIncomesQueryDto>
    {
        public GetAllIncomesQueryDtoValidator()
        {
            RuleForEach(x => x.Accounts).NotNull().GreaterThan(0).When(x => x.Accounts != null);
            RuleFor(x => x.AmountMin).GreaterThanOrEqualTo(0).When(x => x.AmountMin.HasValue);
            RuleFor(x => x.AmountMax).GreaterThanOrEqualTo(0).When(x => x.AmountMax.HasValue);
            RuleFor(x => x.AmountMin)
                .Must((model, amountMin) => amountMin <= model.AmountMax)
                .When(x => x.AmountMin.HasValue && x.AmountMax.HasValue)
                .WithMessage("'AmountMin' must be less than or equal to 'AmountMax'");
            RuleFor(x => x.FromDate).GreaterThanOrEqualTo(DateTime.MinValue).When(x => x.FromDate.HasValue);
            RuleFor(x => x.ToDate).LessThanOrEqualTo(DateTime.MaxValue).When(x => x.ToDate.HasValue);
            RuleFor(x => x.FromDate)
                .Must((model, fromDate) => fromDate <= model.ToDate)
                .When(x => x.FromDate.HasValue && x.ToDate.HasValue)
                .WithMessage("'FromDate' must be less than or equal to 'ToDate'");
            RuleFor(x => x.Comment).MaximumLength(450).When(x => x.Comment != null);
        }
    }
}
