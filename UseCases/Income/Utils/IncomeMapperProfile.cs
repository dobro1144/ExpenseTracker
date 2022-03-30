using AutoMapper;
using UseCases.Income.Dto;

namespace UseCases.Income.Utils
{
    public class IncomeMapperProfile : Profile
    {
        public IncomeMapperProfile()
        {
            CreateMap<Entities.Models.Income, IncomeDto>();
            CreateMap<CreateIncomeDto, Entities.Models.Income>();
            CreateMap<UpdateIncomeDto, Entities.Models.Income>();
        }
    }
}
