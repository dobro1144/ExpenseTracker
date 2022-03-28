using Entities.Models;
using System.Linq;

namespace Infrastructure.Interfaces
{
    public interface IReadDbContext
    {
        IQueryable<User> Users { get; }
        IQueryable<Account> Accounts { get; }
        IQueryable<Category> Categories { get; }
        IQueryable<Income> Incomes { get; }
        IQueryable<Expense> Expenses { get; }
        IQueryable<T> DbSet<T>() where T : Entity;
    }
}