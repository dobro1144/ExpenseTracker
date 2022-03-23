using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Expense.Dto;

namespace UseCases.Expense.Queries.GetAll
{
    public class GetAllExpensesQueryHandler : IRequestHandler<GetAllExpensesQuery, ExpenseDto[]>
    {
        readonly IReadDbContext<Entities.Models.Expense> _dbContext;
        readonly IMapper _mapper;

        public GetAllExpensesQueryHandler(IReadDbContext<Entities.Models.Expense> dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ExpenseDto[]> Handle(GetAllExpensesQuery request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Set;
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

            return await query.ProjectTo<ExpenseDto>(_mapper.ConfigurationProvider)
                .ToArrayAsync(cancellationToken);
        }
    }
}
