using FluentValidation;
using UseCases.Category.Dto;

namespace Server.Validators
{
    public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(450);
        }
    }
}
