using Infrastructure.Interfaces.DataAccess;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Exceptions;
using Z.EntityFramework.Plus;

namespace UseCases.Account.Commands.MoveEntries
{
    public class MoveAccountEntriesCommandHandler : AsyncRequestHandler<MoveAccountEntriesCommand>
    {
        readonly IDbContext _dbContext;

        public MoveAccountEntriesCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override async Task Handle(MoveAccountEntriesCommand request, CancellationToken cancellationToken)
        {
            var nExpensesUpdated = await _dbContext.Expenses.Where(x => x.AccountId == request.Dto.FromId)
                .UpdateAsync(x => new Entities.Models.Expense { AccountId = request.Dto.ToId }, cancellationToken);
            var nIncomesUpdated = await _dbContext.Incomes.Where(x => x.AccountId == request.Dto.FromId)
                .UpdateAsync(x => new Entities.Models.Income { AccountId = request.Dto.ToId }, cancellationToken);

            if (nExpensesUpdated + nIncomesUpdated == 0)
                throw new EntityNotFoundException();
        }
    }
}
