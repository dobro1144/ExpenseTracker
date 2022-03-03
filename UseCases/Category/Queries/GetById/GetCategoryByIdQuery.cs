using MediatR;

namespace UseCases.Category.Queries.GetById
{
    public class GetCategoryByIdQuery : IRequest<Entities.Models.Category>
    {
        public int Id { get; set; }
    }
}
