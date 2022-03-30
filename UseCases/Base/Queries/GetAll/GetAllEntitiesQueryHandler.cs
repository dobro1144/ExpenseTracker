using AutoMapper;
using AutoMapper.QueryableExtensions;
using Entities.Models;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Base.Queries.GetAll
{
    public class GetAllEntitiesQueryHandler<TCommand, TRequestDto, TResponseDto, TEntity> : IRequestHandler<TCommand, TResponseDto[]>
        where TCommand : GetAllEntitiesQuery<TRequestDto, TResponseDto>
        where TRequestDto : class
        where TResponseDto : class
        where TEntity : Entity
    {
        readonly IReadDbContext _dbContext;
        readonly IMapper _mapper;

        protected GetAllEntitiesQueryHandler(IReadDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<TResponseDto[]> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var query = _dbContext.DbSet<TEntity>();
            DecorateQuery(ref query, request);

            return await query.ProjectTo<TResponseDto>(_mapper.ConfigurationProvider)
                .ToArrayAsync(cancellationToken);
        }

        protected virtual void DecorateQuery(ref IQueryable<TEntity> query, TCommand request)
        {
        }
    }
}
