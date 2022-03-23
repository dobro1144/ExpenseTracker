using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IDbContext<T>
        where T : Entity
    {
        DbSet<T> Set { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}