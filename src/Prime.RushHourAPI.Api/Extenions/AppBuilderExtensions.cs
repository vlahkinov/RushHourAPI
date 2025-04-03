using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Prime.RushHourAPI.Data;

namespace Prime.RushHourAPI.Api.Extenions
{
    public static class AppBuilderExtensions
    {
        public static void UpdateDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<RushHourAPIDbContext>();
            context.Database.Migrate();
        }
    }
}
