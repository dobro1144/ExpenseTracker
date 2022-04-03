using FluentValidation;
using UseCases.Account.Dto;

namespace Server.Validators.Account
{
    public class MoveAccountEntriesDtoValidator : AbstractValidator<MoveAccountEntriesDto>
    {
        public MoveAccountEntriesDtoValidator()
        {
            RuleFor(x => x.FromId).NotNull().GreaterThan(0);
            RuleFor(x => x.ToId).NotNull().GreaterThan(0);
            RuleFor(x => x.FromId)
                .Must((model, fromId) => fromId != model.ToId)
                .WithMessage("'FromId' must not equal to 'ToId'");
        }
    }
}
