using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.MsSql
{
    public class ExpenseDbContext : GenericAppDbContext<Expense>
    {
        public ExpenseDbContext(DbContextOptions<GenericAppDbContext<Expense>> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>().Property(x => x.Timestamp).IsRowVersion();

            base.OnModelCreating(modelBuilder);
        }
    }
}
