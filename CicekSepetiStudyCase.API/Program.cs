using CicekSepetiStudyCase.Infrastructure.Database.MongoDB;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CicekSepetiStudyCase.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
			var host = CreateHostBuilder(args).Build();
			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				var loggerFactory = services.GetRequiredService<ILoggerFactory>();
				try
				{
					var context = services.GetRequiredService<IECommerceContext>();
					//Adding sample product data
					await ECommerceContextSeed.SeedAsync(context, loggerFactory);
				}
				catch (Exception ex)
				{
					var logger = loggerFactory.CreateLogger<Program>();
					logger.LogError(ex, "Error when making seed data");
				}
			}

			await host.RunAsync();
		}

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
