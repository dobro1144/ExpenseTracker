using DataAccess.MsSql;
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
            builder.Services.AddAutoMapper(typeof(CategoryMapperProfile));
            builder.Services.AddMediatR(typeof(GetCategoryByIdQuery));
            var connectionString = builder.Configuration.GetSection("ConnectionStrings")["MsSql"];
            builder.Services.AddDbContext<IDbContext, AppDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddDbContext<IReadDbContext, AppDbContext>(options => options.UseSqlServer(connectionString));
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
