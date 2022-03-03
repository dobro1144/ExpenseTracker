using AutoMapper;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Category.Commands.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        readonly IDbContext _dbContext;
        readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var item = await _dbContext.Categories.FindAsync(request.Category.Id);
            if (item == null)
                return false;
            item.Name = request.Category.Name;
            try {
                await _dbContext.SaveChangesAsync();
            } catch {
                return false;
            }
            return true;
        }
    }
}
