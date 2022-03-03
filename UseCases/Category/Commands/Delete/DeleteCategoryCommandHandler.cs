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
        readonly IMapper _mapper;

        public DeleteCategoryCommandHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var item = await _dbContext.Categories.FindAsync(request.Id);
            if (item == null)
                return false;
            _dbContext.Categories.Remove(item);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
