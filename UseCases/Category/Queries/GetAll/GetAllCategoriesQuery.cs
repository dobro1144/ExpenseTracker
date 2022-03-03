using MediatR;
using System.Collections.Generic;

namespace UseCases.Category.Queries.GetAll
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<Entities.Models.Category>>
    {
    }
}
