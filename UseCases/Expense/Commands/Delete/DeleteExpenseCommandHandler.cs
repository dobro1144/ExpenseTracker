﻿using Infrastructure.Interfaces;
using MediatR;
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
            var item = new Entities.Models.Expense {
                Id = request.Id,
                Timestamp = request.Timestamp
            };
            _dbContext.Expenses.Remove(item);
            var nUpdated = await _dbContext.SaveChangesAsync(cancellationToken);
            if (nUpdated == 0)
                throw new EntityNotFoundException();
        }
    }
}
