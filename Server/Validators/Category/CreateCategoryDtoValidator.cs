using FluentValidation;
using UseCases.Category.Dto;

namespace Server.Validators.Category
{
    public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryDtoValidator()
        {
            RuleFor(x => x.UserId).NotNull().GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(450);
        }
    }
}
