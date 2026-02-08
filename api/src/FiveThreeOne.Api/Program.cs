
using FiveThreeOne.Infrastructure.Persistence;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

namespace FiveThreeOne
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add Infrastructure - PostgreSQL Configuration
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));

            // Add Application Layer - MediatR & Validation
            // This scans the Application assembly for all Handlers and Validators
            var applicationAssembly = typeof(FiveThreeOne.Application.AssemblyReference).Assembly;

            builder.Services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(applicationAssembly));

            builder.Services.AddValidatorsFromAssembly(applicationAssembly);

            // Add API Concerns - Controllers & CORS
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            // Configure CORS for your Angular app
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AngularApp", policy =>
                {
                    policy.WithOrigins("http://localhost:4200") // Default Angular port
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            // Swagger Configuration
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FiveThreeOne API", Version = "v1" });
            });

            var app = builder.Build();

            // Configure the HTTP Request Pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Apply the CORS policy
            app.UseCors("AngularApp");

            app.UseAuthorization();

            app.MapControllers();

            // Automatic Migrations
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                if (db.Database.GetPendingMigrations().Any())
                {
                    db.Database.Migrate();
                }
            }

            app.Run();

            // Commented out original code
            //var builder = WebApplication.CreateBuilder(args);

            //// Add services to the container.

            //builder.Services.AddControllers();
            //// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            //builder.Services.AddOpenApi();

            //var app = builder.Build();

            //// Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.MapOpenApi();
            //}

            //app.UseHttpsRedirection();

            //app.UseAuthorization();


            //app.MapControllers();

            //app.Run();
        }
    }
}
