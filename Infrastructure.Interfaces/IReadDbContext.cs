using Entities.Models;
using System.Linq;

namespace Infrastructure.Interfaces
{
    public interface IReadDbContext
    {
        IQueryable<T> DbSet<T>() where T : Entity;
    }
}