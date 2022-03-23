using UseCases.Base.Commands.Create;
using UseCases.Category.Dto;

namespace UseCases.Category.Commands.Create
{
    public class CreateCategoryCommand : CreateEntityCommand<CreateCategoryDto, CategoryDto>
    {
    }
}
