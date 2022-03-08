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
            var item = await _dbContext.Categories.FindAsync(new object[] { request.Id }, cancellationToken);
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
