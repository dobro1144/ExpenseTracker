using AutoMapper;
using Infrastructure.Interfaces.DataAccess;
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

        protected override void DecorateQuery(ref IQueryable<Entities.Models.Category> query, GetAllCategoriesQuery request)
        {
            if (request.Dto.Users != null)
                query = query.Where(x => request.Dto.Users.Contains(x.UserId));
            if (request.Dto.Name != null)
                query = query.Where(x => x.Name.ToLower().Contains(request.Dto.Name.ToLower()));
        }
    }
}
