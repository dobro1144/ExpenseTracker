using AutoMapper;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Exceptions;

namespace UseCases.Category.Commands.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, byte[]>
    {
        readonly IDbContext<Entities.Models.Category> _dbContext;
        readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IDbContext<Entities.Models.Category> dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<byte[]> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var item = await _dbContext.Set
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (item == null)
                throw new EntityNotFoundException();
            _mapper.Map(request.Dto, item);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return item.Timestamp;
        }
    }
}
