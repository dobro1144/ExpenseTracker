using AutoMapper;
using UseCases.Category.Dto;

namespace UseCases.Category.Utils
{
    public class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile()
        {
            CreateMap<CreateCategoryDto, Entities.Models.Category>();
        }
    }
}
