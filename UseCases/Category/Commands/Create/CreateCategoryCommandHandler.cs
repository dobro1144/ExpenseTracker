﻿using AutoMapper;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Category.Dto;

namespace UseCases.Category.Commands.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        readonly IDbContext _dbContext;
        readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Entities.Models.Category>(request.Dto);
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
