using DataAccess.MsSql;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace Tests
{
    public class UserControllerTests
    {
        [Fact]
        public void AddUser()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "expensetracker.test")
                .Options;

            //var controller = new UserController();

            using var context = new AppDbContext(options);

            var user = new User {
                Name = "Test user",
                Email = "xxx@yyy.zzz",
                Timestamp = new byte[] { 0xF1, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }
            };
            context.Users.Add(new User { Name = "Test user", Email = "xxx@yyy.zzz", Timestamp = new byte[] { 0xF1, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF } });
            context.SaveChanges();

            Assert.NotNull(context.Users.FirstOrDefault(x => x.Name == user.Name && x.Email == user.Email && x.Timestamp != null && x.Timestamp.SequenceEqual(user.Timestamp) ));
        }
    }
}