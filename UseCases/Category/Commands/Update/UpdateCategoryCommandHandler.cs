using AutoMapper;
using Infrastructure.Interfaces.DataAccess;
using UseCases.Base.Commands.Update;
using UseCases.Category.Dto;

namespace UseCases.Category.Commands.Update
{
    public class UpdateCategoryCommandHandler : UpdateEntityCommandHandler<UpdateCategoryCommand, UpdateCategoryDto, Entities.Models.Category>
    {
        public UpdateCategoryCommandHandler(IDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
