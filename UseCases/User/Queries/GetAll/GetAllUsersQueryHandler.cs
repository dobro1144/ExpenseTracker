using AutoMapper;
using Infrastructure.Interfaces.DataAccess;
using System.Linq;
using UseCases.Base.Queries.GetAll;
using UseCases.User.Dto;

namespace UseCases.User.Queries.GetAll
{
    public class GetAllUsersQueryHandler : GetAllEntitiesQueryHandler<GetAllUsersQuery, GetAllUsersQueryDto, UserDto, Entities.Models.User>
    {
        public GetAllUsersQueryHandler(IReadDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        protected override void DecorateQuery(ref IQueryable<Entities.Models.User> query, GetAllUsersQuery request)
        {
            if (request.Dto.Email != null)
                query = query.Where(x => x.Email.ToLower().Contains(request.Dto.Email.ToLower()));
            if (request.Dto.Name != null)
                query = query.Where(x => x.Name.ToLower().Contains(request.Dto.Name.ToLower()));
        }
    }
}
