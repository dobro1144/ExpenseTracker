using Entities.Models;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.MsSql
{
    public class GenericAppDbContext<T> : DbContext, IDbContext<T>, IReadDbContext<T>
        where T : Entity
    {
        public DbSet<T> Set { get; set; } = null!;

        IQueryable<T> IReadDbContext<T>.Set => Set.AsNoTracking();

        public GenericAppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}