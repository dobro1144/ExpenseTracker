using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Exceptions;

namespace UseCases.Category.Commands.Delete
{
    public class DeleteCategoryCommandHandler : AsyncRequestHandler<DeleteCategoryCommand>
    {
        readonly IDbContext<Entities.Models.Category> _dbContext;

        public DeleteCategoryCommandHandler(IDbContext<Entities.Models.Category> dbContext)
        {
            _dbContext = dbContext;
        }

        protected override async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var item = new Entities.Models.Category {
                Id = request.Id,
                Timestamp = request.Timestamp
            };
            _dbContext.Set.Remove(item);
            var nUpdated = await _dbContext.SaveChangesAsync(cancellationToken);
            if (nUpdated == 0)
                throw new EntityNotFoundException();
        }
    }
}
