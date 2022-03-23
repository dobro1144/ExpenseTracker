using AutoMapper;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Exceptions;
using UseCases.Expense.Dto;

namespace UseCases.Expense.Queries.GetById
{
    public class GetExpenseByIdQueryHandler : IRequestHandler<GetExpenseByIdQuery, ExpenseDto>
    {
        readonly IReadDbContext<Entities.Models.Expense> _dbContext;
        readonly IMapper _mapper;

        public GetExpenseByIdQueryHandler(IReadDbContext<Entities.Models.Expense> dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ExpenseDto> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
        {
            var expense = await _dbContext.Set
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (expense == null)
                throw new EntityNotFoundException();
            return _mapper.Map<ExpenseDto>(expense);
        }
    }
}
