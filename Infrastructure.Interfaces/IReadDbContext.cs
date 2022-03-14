using Entities.Models;
using System.Linq;

namespace Infrastructure.Interfaces
{
    public interface IReadDbContext
    {
        public IQueryable<Expense> Expenses { get; }
        public IQueryable<Category> Categories { get; }
    }
}