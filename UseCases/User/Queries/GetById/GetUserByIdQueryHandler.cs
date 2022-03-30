using AutoMapper;
using Infrastructure.Interfaces;
using UseCases.Base.Queries.GetById;
using UseCases.User.Dto;

namespace UseCases.User.Queries.GetById
{
    public class GetUserByIdQueryHandler : GetEntityByIdQueryHandler<GetUserByIdQuery, UserDto, Entities.Models.User>
    {
        public GetUserByIdQueryHandler(IReadDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
