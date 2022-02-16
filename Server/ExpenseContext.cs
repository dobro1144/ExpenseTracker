using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server
{
    public class ExpenseContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ExpenseContext(DbContextOptions<ExpenseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasAlternateKey(x => x.Name);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Food" },
                new Category { Id = 2, Name = "Transport" },
                new Category { Id = 3, Name = "Phone" },
                new Category { Id = 4, Name = "Internet" },
                new Category { Id = 5, Name = "Entertainment" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
