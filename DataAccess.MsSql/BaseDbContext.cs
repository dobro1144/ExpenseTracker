using Entities.Models;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.MsSql
{
    public abstract class BaseDbContext<T> : DbContext, IDbContext<T>, IReadDbContext<T>
        where T : Entity
    {
        public DbSet<T> Set { get; set; } = null!;

        IQueryable<T> IReadDbContext<T>.Set => Set.AsNoTracking();

        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}