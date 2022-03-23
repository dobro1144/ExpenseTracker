using UseCases.Base.Queries.GetAll;
using UseCases.Category.Dto;

namespace UseCases.Category.Queries.GetAll
{
    public class GetAllCategoriesQuery : GetAllEntitiesQuery<GetAllCategoriesQueryDto, CategoryDto>
    {
    }
}
