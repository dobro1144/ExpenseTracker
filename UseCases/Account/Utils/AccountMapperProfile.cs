using AutoMapper;
using UseCases.Account.Dto;

namespace UseCases.Account.Utils
{
    public class AccountMapperProfile : Profile
    {
        public AccountMapperProfile()
        {
            CreateMap<Entities.Models.Account, AccountDto>();
            CreateMap<CreateAccountDto, Entities.Models.Account>();
            CreateMap<UpdateAccountDto, Entities.Models.Account>();
        }
    }
}
