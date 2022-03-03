using AutoMapper;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Expense.Dto;

namespace UseCases.Expense.Commands.Create
{
    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, ExpenseDto>
    {
        readonly IDbContext _dbContext;
        readonly IMapper _mapper;

        public CreateExpenseCommandHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ExpenseDto> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = _mapper.Map<Entities.Models.Expense>(request.Dto);
            await _dbContext.Expenses.AddAsync(expense);
            try {
                await _dbContext.SaveChangesAsync();
            } catch {
                return null;
            }
            return _mapper.Map<ExpenseDto>(expense);
        }
    }
}
