using UseCases.Account.Dto;
using MediatR;

namespace UseCases.Account.Queries.GetAll
{
    public class GetAllAccountsQuery : IRequest<AccountBalanceDto[]>
    {
    }
}
