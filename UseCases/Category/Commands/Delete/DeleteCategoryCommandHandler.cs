using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Category.Commands.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        readonly IDbContext _dbContext;

        public DeleteCategoryCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var item = await _dbContext.Categories.FindAsync(new object[] { request.Id }, cancellationToken);
            if (item == null)
                return false;
            _dbContext.Categories.Remove(item);
            try {
                await _dbContext.SaveChangesAsync(cancellationToken);
                return true;
            } catch {
                return false;
            }
        }
    }
}
