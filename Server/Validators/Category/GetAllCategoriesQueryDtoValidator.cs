using FluentValidation;
using UseCases.Category.Dto;

namespace Server.Validators.Category
{
    public class GetAllCategoriesQueryDtoValidator : AbstractValidator<GetAllCategoriesQueryDto>
    {
        public GetAllCategoriesQueryDtoValidator()
        {
            RuleForEach(x => x.Users).NotNull().GreaterThan(0).When(x => x.Users != null);
            RuleFor(x => x.Name).MaximumLength(450).When(x => x.Name != null);
        }
    }
}
