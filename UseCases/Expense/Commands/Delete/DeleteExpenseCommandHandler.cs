using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Exceptions;

namespace UseCases.Expense.Commands.Delete
{
    public class DeleteExpenseCommandHandler : AsyncRequestHandler<DeleteExpenseCommand>
    {
        readonly IDbContext _dbContext;

        public DeleteExpenseCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override async Task Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            var item = await _dbContext.Expenses
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (item == null)
                throw new EntityNotFoundException();
            _dbContext.Expenses.Remove(item);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
