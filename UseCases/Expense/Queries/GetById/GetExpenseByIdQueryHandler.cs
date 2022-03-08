using AutoMapper;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Expense.Dto;

namespace UseCases.Expense.Queries.GetById
{
    public class GetExpenseByIdQueryHandler : IRequestHandler<GetExpenseByIdQuery, ExpenseDto?>
    {
        readonly IDbContext _dbContext;
        readonly IMapper _mapper;

        public GetExpenseByIdQueryHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ExpenseDto?> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
        {
            var expense = await _dbContext.Expenses.FindAsync(new object[] { request.Id }, cancellationToken);
            if (expense == null)
                return null;
            return _mapper.Map<ExpenseDto>(expense);
        }
    }
}
