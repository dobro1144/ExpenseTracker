using AutoMapper;
using Infrastructure.Interfaces;
using UseCases.Base.Queries.GetById;
using UseCases.Category.Dto;

namespace UseCases.Category.Queries.GetById
{
    public class GetCategoryByIdQueryHandler : GetEntityByIdQueryHandler<GetCategoryByIdQuery, CategoryDto, Entities.Models.Category>
    {
        public GetCategoryByIdQueryHandler(IReadDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
