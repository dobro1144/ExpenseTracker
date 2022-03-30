using AutoMapper;
using System.Linq;
using UseCases.Base.Queries.GetAll;
using UseCases.Account.Dto;
using Infrastructure.Interfaces.DataAccess;

namespace UseCases.Account.Queries.GetAll
{
    public class GetAllAccountsQueryHandler : GetAllEntitiesQueryHandler<GetAllAccountsQuery, GetAllAccountsQueryDto, AccountDto, Entities.Models.Account>
    {
        public GetAllAccountsQueryHandler(IReadDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        protected override void DecorateQuery(ref IQueryable<Entities.Models.Account> query, GetAllAccountsQuery request)
        {
            if (request.Dto.Users != null)
                query = query.Where(x => request.Dto.Users.Contains(x.UserId));
            if (request.Dto.Name != null)
                query = query.Where(x => x.Name.ToLower().Contains(request.Dto.Name.ToLower()));
        }
    }
}
