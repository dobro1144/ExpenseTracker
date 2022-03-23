using AutoMapper;
using Infrastructure.Interfaces;
using System.Linq;
using UseCases.Base.Queries.GetAll;
using UseCases.Category.Dto;

namespace UseCases.Category.Queries.GetAll
{
    public class GetAllCategoriesQueryHandler : GetAllEntitiesQueryHandler<GetAllCategoriesQuery, GetAllCategoriesQueryDto, CategoryDto, Entities.Models.Category>
    {
        public GetAllCategoriesQueryHandler(IReadDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        protected override IQueryable<Entities.Models.Category> DecorateQuery(GetAllCategoriesQuery request, IQueryable<Entities.Models.Category> incomingQuery)
        {
            if (request.Dto.Name != null)
                incomingQuery = incomingQuery.Where(x => x.Name.ToLower().Contains(request.Dto.Name.ToLower()));
            return incomingQuery;
        }
    }
}
