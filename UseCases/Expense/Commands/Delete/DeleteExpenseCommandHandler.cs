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
            _dbContext.Expenses.Remove(new Entities.Models.Expense { Id = request.Id });
            try {
                var nUpdated = await _dbContext.SaveChangesAsync(cancellationToken);
                return nUpdated > 0;
            } catch {
                return false;
            }
        }
    }
}
