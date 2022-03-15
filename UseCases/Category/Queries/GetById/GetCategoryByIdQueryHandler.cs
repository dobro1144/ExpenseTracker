using AutoMapper;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Category.Dto;
using UseCases.Exceptions;

namespace UseCases.Category.Queries.GetById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
    {
        readonly IReadDbContext _dbContext;
        readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(IReadDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category =  await _dbContext.Categories
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (category == null)
                throw new EntityNotFoundException();
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
