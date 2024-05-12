using Microsoft.Extensions.DependencyInjection;
using EmployeeControlWebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeControlWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SQLitePCL.Batteries.Init();

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<EmployeeControlWebAPIContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("EmployeeControlWebAPIContext") ?? throw new InvalidOperationException("Connection string 'EmployeeControlWebAPIContext' not found.")));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
