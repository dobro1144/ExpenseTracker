using AutoMapper;
using Infrastructure.Interfaces;
using MediatR;
using System;
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
            expense.CreatedAtUtc = DateTime.UtcNow;
            _dbContext.Expenses.Add(expense);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ExpenseDto>(expense);
        }
    }
}
