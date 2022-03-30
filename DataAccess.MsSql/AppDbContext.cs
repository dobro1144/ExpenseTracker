using Entities.Models;
using Infrastructure.Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.MsSql
{
    public class AppDbContext : DbContext, IDbContext, IReadDbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Income> Incomes { get; set; } = null!;
        public DbSet<Expense> Expenses { get; set; } = null!;
        public DbSet<T> DbSet<T>() where T : Entity => base.Set<T>();

        IQueryable<User> IReadDbContext.Users => Users.AsNoTracking();
        IQueryable<Account> IReadDbContext.Accounts => Accounts.AsNoTracking();
        IQueryable<Category> IReadDbContext.Categories => Categories.AsNoTracking();
        IQueryable<Income> IReadDbContext.Incomes => Incomes.AsNoTracking();
        IQueryable<Expense> IReadDbContext.Expenses => Expenses.AsNoTracking();
        IQueryable<T> IReadDbContext.DbSet<T>() => base.Set<T>().AsNoTracking();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.Timestamp).IsRowVersion();
            modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Default user", Email = "default@user.info" }
            );

            modelBuilder.Entity<Account>().Property(x => x.Timestamp).IsRowVersion();
            modelBuilder.Entity<Account>().HasIndex(x => new { x.UserId, x.Name }).IsUnique();
            modelBuilder.Entity<Account>().HasData(
                new Account { Id = 1, UserId = 1, Name = "Main account" }
            );

            modelBuilder.Entity<Category>().Property(x => x.Timestamp).IsRowVersion();
            modelBuilder.Entity<Category>().HasIndex(x => new { x.UserId, x.Name }).IsUnique();
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, UserId = 1, Name = "Food" },
                new Category { Id = 2, UserId = 1, Name = "Transport" },
                new Category { Id = 3, UserId = 1, Name = "Phone" },
                new Category { Id = 4, UserId = 1, Name = "Internet" },
                new Category { Id = 5, UserId = 1, Name = "Entertainment" }
            );

            modelBuilder.Entity<Income>().Property(x => x.Timestamp).IsRowVersion();

            modelBuilder.Entity<Expense>().Property(x => x.Timestamp).IsRowVersion();

            base.OnModelCreating(modelBuilder);
        }
    }
}