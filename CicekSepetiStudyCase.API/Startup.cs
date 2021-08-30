using CicekSepetiStudyCase.API.Extensions;
using CicekSepetiStudyCase.Manager.Mapping;
using CicekSepetiStudyCase.Infrastructure.Database.MongoDB.Settings;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;

namespace CicekSepetiStudyCase.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
         
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
 
            services.AddControllers().AddFluentValidation();

            services.Configure<DatabaseSettings>(_configuration.GetSection("DatabaseSettings"));
            services.AddSingleton<IDatabaseSettings>(provider =>
            {
                return provider.GetRequiredService<IOptions<DatabaseSettings>>().Value;
            });

            services.AddSingleton<IConnectionMultiplexer>(x =>
            {
                var configuration = ConfigurationOptions.Parse(_configuration.GetConnectionString("RedisHost"), true);

                return ConnectionMultiplexer.Connect(configuration);
            });

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddApplicationServices();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CicekSepetiStudyCase.API", Version = "v1" });
            });

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
        }
         
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
 
            app.ConfigureCustomExceptionMiddleware(); 

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CicekSepetiStudyCase.API v1"));

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseRouting();

            app.UseCors("CorsPolicy");
              
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
