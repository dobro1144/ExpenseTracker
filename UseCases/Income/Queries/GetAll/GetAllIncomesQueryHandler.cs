using AutoMapper;
using Infrastructure.Interfaces;
using System;
using System.Linq;
using UseCases.Base.Queries.GetAll;
using UseCases.Income.Dto;

namespace UseCases.Income.Queries.GetAll
{
    public class GetAllIncomesQueryHandler : GetAllEntitiesQueryHandler<GetAllIncomesQuery, GetAllIncomesQueryDto, IncomeDto, Entities.Models.Income>
    {
        public GetAllIncomesQueryHandler(IReadDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        protected override void DecorateQuery(ref IQueryable<Entities.Models.Income> query, GetAllIncomesQuery request)
        {
            if (request.Dto.Accounts != null)
                query = query.Where(x => request.Dto.Accounts.Contains(x.AccountId));
            if (request.Dto.AmountMin.HasValue)
                query = query.Where(x => x.Amount >= request.Dto.AmountMin.Value);
            if (request.Dto.AmountMax.HasValue)
                query = query.Where(x => x.Amount <= request.Dto.AmountMax.Value);
            if (request.Dto.FromDate.HasValue)
                query = query.Where(x => x.CreatedAtUtc >= request.Dto.FromDate.Value);
            if (request.Dto.ToDate.HasValue)
                query = query.Where(x => x.CreatedAtUtc <= request.Dto.ToDate.Value);
            if (request.Dto.Comment != null)
                query = query.Where(x => x.Comment != null && x.Comment.ToLower().Contains(request.Dto.Comment.ToLower()));
        }
    }
}
