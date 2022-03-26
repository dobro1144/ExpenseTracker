﻿using AutoMapper;
using Entities.Models;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Exceptions;

namespace UseCases.Base.Queries.GetById
{
    public class GetEntityByIdQueryHandler<TCommand, TResponseDto, TEntity> : IRequestHandler<TCommand, TResponseDto>
        where TCommand : GetEntityByIdQuery<TResponseDto>
        where TResponseDto : class
        where TEntity : Entity
    {
        readonly IReadDbContext _dbContext;
        readonly IMapper _mapper;

        public GetEntityByIdQueryHandler(IReadDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<TResponseDto> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.DbSet<TEntity>()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (entity == null)
                throw new EntityNotFoundException();
            return _mapper.Map<TResponseDto>(entity);
        }
    }
}