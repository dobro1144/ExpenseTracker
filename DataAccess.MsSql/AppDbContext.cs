using Entities.Models;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.MsSql
{
    public class AppDbContext : DbContext, IDbContext, IReadDbContext
    {
        public DbSet<Expense> Expenses { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<T> DbSet<T>() where T : Entity => base.Set<T>();

        IQueryable<Expense> IReadDbContext.Expenses => Expenses.AsNoTracking();
        IQueryable<Category> IReadDbContext.Categories => Categories.AsNoTracking();
        IQueryable<T> IReadDbContext.DbSet<T>() => base.Set<T>().AsNoTracking();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().Property(x => x.Timestamp).IsRowVersion();
            modelBuilder.Entity<Expense>().Property(x => x.Timestamp).IsRowVersion();
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