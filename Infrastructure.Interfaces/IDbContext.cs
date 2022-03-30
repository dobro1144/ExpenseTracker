using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IDbContext
    {
        DbSet<User> Users { get; }
        DbSet<Account> Accounts { get; }
        DbSet<Category> Categories { get; }
        DbSet<Income> Incomes { get; }
        DbSet<Expense> Expenses { get; }
        DbSet<T> DbSet<T>() where T : Entity;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}