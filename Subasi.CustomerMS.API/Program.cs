using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Subasi.CustomerMS.API.Core.Application.Interface;
using Subasi.CustomerMS.API.Core.Application.Interfaces;
using Subasi.CustomerMS.API.Core.Application.Mappings.AutoMapper.ProfileHelper;
using Subasi.CustomerMS.API.Core.Application.Middlewares;
using Subasi.CustomerMS.API.Core.Application.ValidationRules.DependencyResolver;
using Subasi.CustomerMS.API.Infrastructure.Services;
using Subasi.CustomerMS.API.Infrastructure.Tools;
using Subasi.CustomerMS.API.Persistance.Context;
using Subasi.CustomerMS.API.Persistance.Repositories;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Text;

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
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = JWTDefaults.ValidIssuer,
                        ValidAudience = JWTDefaults.ValidAudience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTDefaults.Key))
                    };
                });
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
            builder.Services.AddScoped(typeof(IAppUserService), typeof(AppUserService));
            builder.Services.AddHttpContextAccessor();
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
            //app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}