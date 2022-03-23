using DataAccess.MsSql;
using Entities.Models;
using FluentValidation.AspNetCore;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Server.Utils;
using Server.Validators;
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
            builder.Services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateCategoryDtoValidator>());
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(new[] { typeof(CategoryMapperProfile), typeof(ExpenseMapperProfile) });
            builder.Services.AddMediatR(typeof(GetCategoryByIdQuery));
            var connectionString = builder.Configuration.GetSection("ConnectionStrings")["MsSql"];
            builder.Services.AddDbContext<IDbContext<Category>, CategoryDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddDbContext<IReadDbContext<Category>, CategoryDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddDbContext<IDbContext<Expense>, ExpenseDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddDbContext<IReadDbContext<Expense>, ExpenseDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddRouting(options => options.LowercaseUrls = true);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseExceptionHandlerMiddleware();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
