using Infrastructure.Interfaces.DataAccess;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Exceptions;
using Z.EntityFramework.Plus;

namespace UseCases.Category.Commands.MoveExpenses
{
    public class MoveCategoryExpensesCommandHandler : AsyncRequestHandler<MoveCategoryExpensesCommand>
    {
        readonly IDbContext _dbContext;

        public MoveCategoryExpensesCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override async Task Handle(MoveCategoryExpensesCommand request, CancellationToken cancellationToken)
        {
            var nUpdated = await _dbContext.Expenses.Where(x => x.CategoryId == request.Dto.FromId)
                .UpdateAsync(x => new Entities.Models.Expense { CategoryId = request.Dto.ToId }, cancellationToken);

            if (nUpdated == 0)
                throw new EntityNotFoundException();
        }
    }
}
