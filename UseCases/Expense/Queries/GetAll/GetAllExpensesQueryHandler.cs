using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Expense.Dto;

namespace UseCases.Expense.Queries.GetAll
{
    public class GetAllExpensesQueryHandler : IRequestHandler<GetAllExpensesQuery, ExpenseDto[]>
    {
        readonly IDbContext _dbContext;
        readonly IMapper _mapper;

        public GetAllExpensesQueryHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ExpenseDto[]> Handle(GetAllExpensesQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Expenses
                .ProjectTo<ExpenseDto>(_mapper.ConfigurationProvider)
                .ToArrayAsync(cancellationToken);
        }
    }
}
