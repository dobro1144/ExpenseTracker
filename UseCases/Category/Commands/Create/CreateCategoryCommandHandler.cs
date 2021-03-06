using AutoMapper;
using Infrastructure.Interfaces.DataAccess;
using UseCases.Base.Commands.Create;
using UseCases.Category.Dto;

namespace UseCases.Category.Commands.Create
{
    public class CreateCategoryCommandHandler : CreateEntityCommandHandler<CreateCategoryCommand, CreateCategoryDto, CategoryDto, Entities.Models.Category>
    {
        public CreateCategoryCommandHandler(IDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
