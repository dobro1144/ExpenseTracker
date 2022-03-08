using AutoMapper;
using UseCases.Category.Dto;

namespace UseCases.Category.Utils
{
    public class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile()
        {
            CreateMap<Entities.Models.Category, CategoryDto>();
            CreateMap<CreateCategoryDto, Entities.Models.Category>();
            CreateMap<UpdateCategoryDto, Entities.Models.Category>();
        }
    }
}
