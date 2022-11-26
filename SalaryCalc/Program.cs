using MediatR;
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
						policy.WithOrigins("https://localhost:7115")
						.AllowAnyHeader()
						.AllowAnyMethod();
					});
			});

			builder.Logging.ClearProviders();
			builder.Logging.AddConsole();

			builder.Services.AddControllers();
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