using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IDbContext
    {
        public DbSet<Expense> Expenses { get; }
        public DbSet<Category> Categories { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}