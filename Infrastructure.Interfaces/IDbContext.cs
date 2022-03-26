using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IDbContext
    {
        DbSet<Expense> Expenses { get; }
        DbSet<Category> Categories { get; }
        DbSet<T> DbSet<T>() where T : Entity;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}