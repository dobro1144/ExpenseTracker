using DataAccess.MsSql;
using FluentValidation.AspNetCore;
using Infrastructure.Interfaces.DataAccess;
using Infrastructure.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Server.Services;
using Server.Utils;
using Server.Validators.Category;
using System;
using System.IO;
using UseCases.Category.Queries.GetById;
using UseCases.Category.Utils;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("LOGDIR", Path.Combine(AppContext.BaseDirectory, "Logs"));

            var builder = WebApplication.CreateBuilder(args);

            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .Filter.ByExcluding(x => x.Properties.TryGetValue("Method", out var value) && value?.ToString() == "\"GET\"")
                .CreateLogger();

            builder.Host.UseSerilog(logger);

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
            builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

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
            app.UseSerilogRequestLogging();
            app.Run();
        }
    }
}
