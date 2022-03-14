using AutoMapper;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Category.Commands.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, byte[]?>
    {
        readonly IDbContext _dbContext;
        readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<byte[]?> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var item = await _dbContext.Categories.FindAsync(new object[] { request.Id }, cancellationToken);
            if (item == null)
                return null;
            _mapper.Map(request.Dto, item);
            try {
                await _dbContext.SaveChangesAsync(cancellationToken);
                return item.Timestamp;
            } catch {
                return null;
            }
        }
    }
}
