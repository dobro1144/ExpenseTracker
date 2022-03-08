using MediatR;
using UseCases.Category.Dto;

namespace UseCases.Category.Queries.GetById
{
    public class GetCategoryByIdQuery : IRequest<CategoryDto?>
    {
        public int Id { get; set; }
    }
}
