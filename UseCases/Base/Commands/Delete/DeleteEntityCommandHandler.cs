using Entities.Models;
using Infrastructure.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Exceptions;

namespace UseCases.Base.Commands.Delete
{
    public abstract class DeleteEntityCommandHandler<TCommand, TEntity> : AsyncRequestHandler<TCommand>
        where TCommand : DeleteEntityCommand
        where TEntity : Entity, new()
    {
        readonly IDbContext _dbContext;

        protected DeleteEntityCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override async Task Handle(TCommand request, CancellationToken cancellationToken)
        {
            var timestampBytes = Convert.FromBase64String(request.Timestamp);
            var entity = new TEntity { Id = request.Id, Timestamp = timestampBytes };

            _dbContext.DbSet<TEntity>().Remove(entity);
            var nUpdated = await _dbContext.SaveChangesAsync(cancellationToken);
            if (nUpdated == 0)
                throw new EntityNotFoundException();
        }
    }
}
