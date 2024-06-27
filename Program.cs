using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserPostApi.Data;
using UserPostApi.Services;
using Microsoft.EntityFrameworkCore;


namespace UserPostApi;

class Program
{
        public static void Main(string[] args) {

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddControllers();

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        if(string.IsNullOrEmpty(connectionString)) {
            throw new InvalidOperationException("Connection string 'DefaultConnection' Not found.");
        }

        builder.Services.AddDbContext<DataBaseContext>(options => 
                options.UseSqlServer(connectionString));
            
        builder.Services.AddScoped<IProviderService, ProviderService>();

        builder.Services.AddCors(options => {
            options.AddPolicy("AllowAll", builder => {
                    builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
            });
        });

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

        app.UseCors("AllowAll");

        app.MapControllers();

        app.UseAuthorization();

        app.Run();
    }
}