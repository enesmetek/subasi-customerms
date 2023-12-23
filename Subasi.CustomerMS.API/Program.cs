using MediatR;
using Microsoft.EntityFrameworkCore;
using Subasi.CustomerMS.API.Core.Application.Interface;
using Subasi.CustomerMS.API.Core.Application.Interfaces;
using Subasi.CustomerMS.API.Core.Application.Mappings.AutoMapper.ProfileHelper;
using Subasi.CustomerMS.API.Core.Application.Middlewares;
using Subasi.CustomerMS.API.Core.Application.ValidationRules.DependencyResolver;
using Subasi.CustomerMS.API.Persistance.Context;
using Subasi.CustomerMS.API.Persistance.Repositories;
using System.Reflection;

namespace Subasi.CustomerMS.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDependencies(builder.Configuration);
            builder.Services.AddControllers().AddNewtonsoftJson(opt =>
            {
                // *** Reference Loop Handling ***
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // *** Database Connection ***
            builder.Services.AddDbContext<SubasiCustomerMSDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Local"));
            });

            // *** Services ***
            builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped(typeof(ICustomerRepository), typeof(CustomerRepository));
            builder.Services.AddScoped(typeof(IAddressRepository), typeof(AddressRepository));
            builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

            // *** AutoMapper Profiles ***
            builder.Services.AddAutoMapper(opt =>
            {
                opt.AddProfiles(ProfileHelper.GetProfiles());  
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            // Global Exception Handling Middleware
            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}