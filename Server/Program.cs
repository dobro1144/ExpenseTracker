using DataAccess.MsSql;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UseCases.Category.Queries.GetById;
using UseCases.Category.Utils;
using UseCases.Expense.Utils;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(new[] { typeof(CategoryMapperProfile), typeof(ExpenseMapperProfile) });
            builder.Services.AddMediatR(typeof(GetCategoryByIdQuery));
            builder.Services.AddDbContext<IDbContext, AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings")["MsSql"]));
            builder.Services.AddDbContext<IReadDbContext, AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings")["MsSql"]));
            builder.Services.AddRouting(options => options.LowercaseUrls = true);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
