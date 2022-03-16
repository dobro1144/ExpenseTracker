using FluentValidation;

namespace UseCases.Category.Dto.Validators
{
    public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(450);
        }
    }
}
