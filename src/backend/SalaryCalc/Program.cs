using MediatR;
using SalaryCalc.Filters;
using Services.DIConfiguration;

namespace SalaryCalc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(new GlobalExceptionHandlingFilter());
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.RegisterTypes(builder.Configuration);

            builder.Services.AddMediatR(typeof(DependencyResolver).Assembly);

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}