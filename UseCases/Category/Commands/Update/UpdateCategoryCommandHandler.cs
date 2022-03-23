using AutoMapper;
using Infrastructure.Interfaces;
using UseCases.Base.Commands.Update;
using UseCases.Category.Dto;

namespace UseCases.Category.Commands.Update
{
    public class UpdateCategoryCommandHandler : UpdateEntityCommandHandler<UpdateCategoryCommand, UpdateCategoryDto, Entities.Models.Category>
    {
        public UpdateCategoryCommandHandler(IDbContext<Entities.Models.Category> dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
