using AutoMapper;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Category.Queries.GetById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Entities.Models.Category>
    {
        readonly IDbContext _dbContext;
        readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Entities.Models.Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Categories.FindAsync(request.Id);
        }
    }
}
