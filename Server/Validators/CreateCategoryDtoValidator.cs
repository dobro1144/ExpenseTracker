﻿using FluentValidation;
using UseCases.Category.Dto;

namespace Server.Validators
{
    public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(450);
        }
    }
}
