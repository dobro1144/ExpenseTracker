using System.Linq;
using UseCases.Account.Dto;
using Infrastructure.Interfaces.DataAccess;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Infrastructure.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace UseCases.Account.Queries.GetAll
{
    public class GetAllAccountsQueryHandler : IRequestHandler<GetAllAccountsQuery, AccountBalanceDto[]>
    {
        readonly IReadDbContext _dbContext;
        readonly ICurrentUserService _currentUserService;

        public GetAllAccountsQueryHandler(IReadDbContext dbContext, ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;
        }

        public async Task<AccountBalanceDto[]> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Accounts
                .Where(x => x.UserId == _currentUserService.Id)
                .Include(x => x.Incomes)
                .Include(x => x.Expenses)
                .Select(x => new AccountBalanceDto {
                    Id = x.Id,
                    UserId = x.UserId,
                    Name = x.Name,
                    Timestamp = x.Timestamp,
                    Balance = x.Incomes.Sum(x => x.Amount) - x.Expenses.Sum(x => x.Amount)
                })
                .ToArrayAsync();
        }
    }
}
