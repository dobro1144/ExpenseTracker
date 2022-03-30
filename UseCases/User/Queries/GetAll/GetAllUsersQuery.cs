using UseCases.Base.Queries.GetAll;
using UseCases.User.Dto;

namespace UseCases.User.Queries.GetAll
{
    public class GetAllUsersQuery : GetAllEntitiesQuery<GetAllUsersQueryDto, UserDto>
    {
    }
}
