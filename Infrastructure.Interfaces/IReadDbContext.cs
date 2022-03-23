using Entities.Models;
using System.Linq;

namespace Infrastructure.Interfaces
{
    public interface IReadDbContext<T> where T : Entity
    {
        IQueryable<T> Set { get; }
    }
}