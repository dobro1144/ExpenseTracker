using AutoMapper;
using Infrastructure.Interfaces.DataAccess;
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

        protected override void DecorateQuery(ref IQueryable<Entities.Models.Expense> query, GetAllExpensesQuery request)
        {
            if (request.Dto.Accounts != null)
                query = query.Where(x => request.Dto.Accounts.Contains(x.AccountId));
            if (request.Dto.Categories != null)
                query = query.Where(x => request.Dto.Categories.Contains(x.CategoryId));
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
