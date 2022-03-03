using AutoMapper;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Category.Commands.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Entities.Models.Category>
    {
        readonly IDbContext _dbContext;
        readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Entities.Models.Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Entities.Models.Category>(request.Dto);
            if (await _dbContext.Categories.AnyAsync(x => x.Name == category.Name))
                return null;
            await _dbContext.Categories.AddAsync(category);
            try {
                await _dbContext.SaveChangesAsync();
            } catch {
                return null;
            }
            return category;
        }
    }
}
