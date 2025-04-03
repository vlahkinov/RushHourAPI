using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Prime.RushHourAPI.Data;

namespace Prime.RushHourAPI.Api.Extenions
{
    public static class ServiceColletionExtensions
    {
        public static IServiceCollection AddRushHourAPIDbContext(
            this IServiceCollection services, string connString) 
            => services.AddDbContext<RushHourAPIDbContext>(
                options => options.UseSqlServer(connString));

        public static IServiceCollection AddRushHourAPIAutomapper(this IServiceCollection services) 
            => services.AddAutoMapper(mc =>
                {
                    mc.AddExpressionMapping();
                    mc.AddProfile(new Mapper.MapperProfile());
                    mc.AddProfile(new Data.Mapper.MapperProfile());
                });

        public static IServiceCollection AddRushHourAPISwagger(this IServiceCollection services)
            => services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RushHourAPI API", Version = "v1" });
            });
    }
}
