using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using PrimeHolding.EventManager.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper.Extensions.ExpressionMapping;

namespace PrimeHolding.EventManager.Api.ExtansionMethods
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEventManagerSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Event Manager Api", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
        }

        public static void AddEventManagerRepositories(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<EventManagerDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void AddEventManagerServices(this IServiceCollection services)
        {
            services.AddAutoMapper(mc =>
            {
                mc.AddExpressionMapping();
                mc.AddProfile(new Data.MapperProfile());
                mc.AddProfile(new Api.MapperProfile());
                mc.AddProfile(new Services.MapperProfile());
            });
        }
    }
}
