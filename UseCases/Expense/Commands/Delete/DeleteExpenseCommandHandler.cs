using AutoMapper;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Expense.Commands.Delete
{
    public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand, bool>
    {
        readonly IDbContext _dbContext;
        readonly IMapper _mapper;

        public DeleteExpenseCommandHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            var item = await _dbContext.Expenses.FindAsync(request.Id);
            if (item == null)
                return false;
            _dbContext.Expenses.Remove(item);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
