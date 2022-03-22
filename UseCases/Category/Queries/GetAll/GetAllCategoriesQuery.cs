using MediatR;
using UseCases.Category.Dto;

namespace UseCases.Category.Queries.GetAll
{
    public class GetAllCategoriesQuery : IRequest<CategoryDto[]>
    {
        public GetAllCategoriesQueryDto Dto { get; set; } = null!;
    }
}
