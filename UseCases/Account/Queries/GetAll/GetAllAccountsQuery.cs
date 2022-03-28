using UseCases.Base.Queries.GetAll;
using UseCases.Account.Dto;

namespace UseCases.Account.Queries.GetAll
{
    public class GetAllAccountsQuery : GetAllEntitiesQuery<GetAllAccountsQueryDto, AccountDto>
    {
    }
}
