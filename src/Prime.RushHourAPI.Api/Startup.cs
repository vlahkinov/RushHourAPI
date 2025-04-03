using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Prime.RushHour.Domain.Validators;
using Prime.RushHourAPI.Api.Extenions;
using Prime.RushHourAPI.Data.Repositories;
using Prime.RushHourAPI.Domain.Abstractions.Repositories;
using Prime.RushHourAPI.Domain.Abstractions.Services;
using Prime.RushHourAPI.Domain.Dtos;
using Prime.RushHourAPI.Services;
using System.Text;

namespace Prime.RushHourAPI.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                var Key = Encoding.UTF8.GetBytes(Configuration["JWT:Key"]);
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JWT:Issuer"],
                    ValidAudience = Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Key)
                };
            });
            services.AddSingleton(new JWTSettingsDto
            {
                Key = Configuration["JWT:Key"],
                Issuer = Configuration["JWT:Issuer"],
                Audience = Configuration["JWT:Audience"],
                Expiration = Configuration["JWT:Expiration"]
            });
            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AccountDtoValidator>());
            services.AddRushHourAPIDbContext(Configuration.GetConnectionString("DefaultConnection"));
            services.AddRushHourAPIAutomapper();
            services.AddRushHourAPISwagger();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<JWTService>();
            services.AddScoped<IProviderService,ProviderService>();
            services.AddScoped<IEmployeeService,EmployeeService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IActivityService,ActivityService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IAppointmentRepository,AppointmentRepository>();
            services.AddScoped<IClientRepository,ClientRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
            });
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UpdateDatabase();
        }
    }
}
