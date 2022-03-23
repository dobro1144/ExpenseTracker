using AutoMapper;
using Infrastructure.Interfaces;
using System;
using System.Linq;
using UseCases.Base.Queries.GetAll;
using UseCases.Expense.Dto;

namespace UseCases.Expense.Queries.GetAll
{
    public class GetAllExpensesQueryHandler : GetAllEntitiesQueryHandler<GetAllExpensesQuery, GetAllExpensesQueryDto, ExpenseDto, Entities.Models.Expense>
    {
        public GetAllExpensesQueryHandler(IReadDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        protected override IQueryable<Entities.Models.Expense> DecorateQuery(GetAllExpensesQuery request, IQueryable<Entities.Models.Expense> incomingQuery)
        {
            if (request.Dto.Categories != null)
                incomingQuery = incomingQuery.Where(x => request.Dto.Categories.Contains(x.CategoryId));
            if (request.Dto.AmountMin.HasValue)
                incomingQuery = incomingQuery.Where(x => x.Amount >= request.Dto.AmountMin.Value);
            if (request.Dto.AmountMax.HasValue)
                incomingQuery = incomingQuery.Where(x => x.Amount <= request.Dto.AmountMax.Value);
            if (request.Dto.FromDate.HasValue)
                incomingQuery = incomingQuery.Where(x => x.CreatedAtUtc >= request.Dto.FromDate.Value);
            if (request.Dto.ToDate.HasValue)
                incomingQuery = incomingQuery.Where(x => x.CreatedAtUtc <= request.Dto.ToDate.Value);
            if (request.Dto.Comment != null)
                incomingQuery = incomingQuery.Where(x => x.Comment != null && x.Comment.ToLower().Contains(request.Dto.Comment.ToLower()));
            return incomingQuery;
        }
    }
}
