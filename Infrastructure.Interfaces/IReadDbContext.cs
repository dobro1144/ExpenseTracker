using Entities.Models;
using System.Linq;

namespace Infrastructure.Interfaces
{
    public interface IReadDbContext
    {
        IQueryable<Expense> Expenses { get; }
        IQueryable<Category> Categories { get; }
        IQueryable<T> DbSet<T>() where T : Entity;
    }
}