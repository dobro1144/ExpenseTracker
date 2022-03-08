using AutoMapper;
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
            _dbContext.Categories.Remove(new Entities.Models.Category { Id = request.Id });
            try {
                var nUpdated = await _dbContext.SaveChangesAsync(cancellationToken);
                return nUpdated > 0;
            } catch {
                return false;
            }
        }
    }
}
