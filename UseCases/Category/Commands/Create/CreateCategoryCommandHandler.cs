using AutoMapper;
using Infrastructure.Interfaces;
using UseCases.Base.Commands.Create;
using UseCases.Category.Dto;

namespace UseCases.Category.Commands.Create
{
    public class CreateCategoryCommandHandler : CreateEntityCommandHandler<CreateCategoryCommand, CreateCategoryDto, CategoryDto, Entities.Models.Category>
    {
        public CreateCategoryCommandHandler(IDbContext<Entities.Models.Category> dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
