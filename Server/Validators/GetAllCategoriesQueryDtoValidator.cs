using FluentValidation;
using UseCases.Category.Dto;

namespace Server.Validators
{
    public class GetAllCategoriesQueryDtoValidator : AbstractValidator<GetAllCategoriesQueryDto>
    {
        public GetAllCategoriesQueryDtoValidator()
        {
            RuleFor(x => x.Name).MaximumLength(450).When(x => x.Name != null);
        }
    }
}
