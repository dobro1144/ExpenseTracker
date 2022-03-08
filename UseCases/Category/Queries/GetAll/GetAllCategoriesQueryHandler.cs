using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Category.Dto;

namespace UseCases.Category.Queries.GetAll
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, CategoryDto[]>
    {
        readonly IDbContext _dbContext;
        readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CategoryDto[]> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Categories
                .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                .ToArrayAsync(cancellationToken);
        }
    }
}
