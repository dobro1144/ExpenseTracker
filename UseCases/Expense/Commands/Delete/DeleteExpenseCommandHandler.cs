using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Expense.Commands.Delete
{
    public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand, bool>
    {
        readonly IDbContext _dbContext;

        public DeleteExpenseCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            var item = await _dbContext.Expenses.FindAsync(new object[] { request.Id }, cancellationToken);
            if (item == null)
                return false;
            _dbContext.Expenses.Remove(item);
            try {
                await _dbContext.SaveChangesAsync(cancellationToken);
                return true;
            } catch {
                return false;
            }
        }
    }
}
