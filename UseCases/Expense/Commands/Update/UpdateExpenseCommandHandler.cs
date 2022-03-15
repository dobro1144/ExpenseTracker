using AutoMapper;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Exceptions;

namespace UseCases.Expense.Commands.Update
{
    public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand, byte[]>
    {
        readonly IDbContext _dbContext;
        readonly IMapper _mapper;

        public UpdateExpenseCommandHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<byte[]> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
        {
            var item = await _dbContext.Expenses
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (item == null)
                throw new EntityNotFoundException();
            _mapper.Map(request.Dto, item);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return item.Timestamp;
        }
    }
}
