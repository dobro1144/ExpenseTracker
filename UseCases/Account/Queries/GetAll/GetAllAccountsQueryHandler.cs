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
            var accounts= await _dbContext.Accounts
                .Where(x => x.UserId == _currentUserService.Id)
                .ToListAsync(cancellationToken);
            var accountIds = accounts
                .Select(x => x.Id)
                .ToList();

            var expenses = _dbContext.Expenses
                .Where(x => accountIds.Contains(x.AccountId))
                .GroupBy(x => x.AccountId)
                .Select(x => new {
                    Id = x.Key,
                    AmountSum = -x.Select(x => x.Amount).Sum()
                });

            var incomes = _dbContext.Incomes
                .Where(x => accountIds.Contains(x.AccountId))
                .GroupBy(x => x.AccountId)
                .Select(x => new {
                    Id = x.Key,
                    AmountSum = x.Select(x => x.Amount).Sum()
                });

            var resultDtoList = await expenses.Concat(incomes)
                .GroupBy(x => x.Id)
                .Select(x => new AccountBalanceDto {
                    Id = x.Key,
                    UserId = _currentUserService.Id,
                    Balance = x.Select(x => x.AmountSum).Sum()
                })
                .ToListAsync(cancellationToken);

            foreach (var dto in resultDtoList)
                dto.Name = accounts.First(x => x.Id == dto.Id).Name;

            // accounts without any expenses and incomes
            foreach (var account in accounts.ExceptBy(resultDtoList.Select(x => x.Id), x => x.Id)) {
                resultDtoList.Add(new AccountBalanceDto {
                    Id = account.Id,
                    UserId = account.UserId,
                    Name = account.Name,
                    Balance = 0.0
                });
            }

            return resultDtoList.ToArray();
        }
    }
}
