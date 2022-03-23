using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Category.Dto;

namespace UseCases.Category.Queries.GetAll
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, CategoryDto[]>
    {
        readonly IReadDbContext<Entities.Models.Category> _dbContext;
        readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(IReadDbContext<Entities.Models.Category> dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CategoryDto[]> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Set;
            if (request.Dto.Name != null)
                query = query.Where(x => x.Name.ToLower().Contains(request.Dto.Name.ToLower()));

            return await query.ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                .ToArrayAsync(cancellationToken);
        }
    }
}
