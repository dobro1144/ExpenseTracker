using AutoMapper;
using Entities.Models;
using Infrastructure.Interfaces.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Exceptions;

namespace UseCases.Base.Commands.Update
{
    public abstract class UpdateEntityCommandHandler<TCommand, TRequestDto, TEntity> : IRequestHandler<TCommand, byte[]>
        where TCommand : UpdateEntityCommand<TRequestDto>
        where TRequestDto : class
        where TEntity : Entity
    {
        readonly IDbContext _dbContext;
        readonly IMapper _mapper;

        protected UpdateEntityCommandHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<byte[]> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.DbSet<TEntity>()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (entity == null)
                throw new EntityNotFoundException();
            _mapper.Map(request.Dto, entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity.Timestamp;
        }
    }
}
