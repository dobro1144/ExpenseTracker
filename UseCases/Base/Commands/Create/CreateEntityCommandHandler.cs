using AutoMapper;
using Entities.Models;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Base.Commands.Create
{
    public abstract class CreateEntityCommandHandler<TCommand, TRequestDto, TResponseDto, TEntity> : IRequestHandler<TCommand, TResponseDto>
        where TCommand : CreateEntityCommand<TRequestDto, TResponseDto>
        where TEntity : Entity
        where TRequestDto : class
        where TResponseDto : class
    {
        readonly IDbContext<TEntity> _dbContext;
        readonly IMapper _mapper;

        public CreateEntityCommandHandler(IDbContext<TEntity> dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<TResponseDto> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(request.Dto);
            InitializeNewEntity(entity);

            _dbContext.Set.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<TResponseDto>(entity);
        }

        protected virtual void InitializeNewEntity(TEntity entity)
        {
        }
    }
}
