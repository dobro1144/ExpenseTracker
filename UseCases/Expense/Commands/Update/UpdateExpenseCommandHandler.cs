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
            var item = await _dbContext.Expenses.FindAsync(new object[] { request.Id }, cancellationToken);
            if (item == null)
                return false;
            _mapper.Map(request.Dto, item);
            try {
                await _dbContext.SaveChangesAsync(cancellationToken);
                return true;
            } catch {
                return false;
            }
        }
    }
}
