using AutoMapper;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Category.Dto;

namespace UseCases.Category.Queries.GetById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto?>
    {
        readonly IDbContext _dbContext;
        readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CategoryDto?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category =  await _dbContext.Categories.FindAsync(new object[] { request.Id }, cancellationToken);
            if (category == null)
                return null;
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
