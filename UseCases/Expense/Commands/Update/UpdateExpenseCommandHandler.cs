using AutoMapper;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Expense.Commands.Update
{
    public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand, bool>
    {
        readonly IDbContext _dbContext;
        readonly IMapper _mapper;

        public UpdateExpenseCommandHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
        {
            var item = await _dbContext.Expenses.FindAsync(request.Expense.Id);
            if (item == null)
                return false;
            item.CategoryId = request.Expense.CategoryId;
            item.Amount = request.Expense.Amount;
            item.Commentary = request.Expense.Commentary;
            try {
                await _dbContext.SaveChangesAsync();
            } catch {
                return false;
            }
            return true;
        }
    }
}
