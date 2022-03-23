using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.MsSql
{
    public class CategoryDbContext : BaseDbContext<Category>
    {
        public CategoryDbContext(DbContextOptions<CategoryDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().Property(x => x.Timestamp).IsRowVersion();
            modelBuilder.Entity<Category>().HasIndex(x => x.Name).IsUnique();
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
