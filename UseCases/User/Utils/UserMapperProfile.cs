using AutoMapper;
using UseCases.User.Dto;

namespace UseCases.User.Utils
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<Entities.Models.User, UserDto>();
            CreateMap<CreateUserDto, Entities.Models.User>();
            CreateMap<UpdateUserDto, Entities.Models.User>();
        }
    }
}
