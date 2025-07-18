using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Application.Interfaces.Clients;
using WebApp.Application.Interfaces.Repositories;
using WebApp.Infrastructure.Contexts;
using WebApp.Infrastructure.Clients;
using WebApp.Infrastructure.Repositories;

namespace WebApp.Infrastructure.Configuration
{
    public static class InfrastructureConfig
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            
            AddDatabaseSetup(config, services);

            services.AddScoped<ITransactionsRepository, TransactionsRepository>();

            services.AddHttpClient<IDubailandExternalApiClient, DubailandExternalApiClient>(client =>
            {
                client.BaseAddress = new Uri("https://gateway.dubailand.gov.ae/open-data/");
            });

            return services;
        }

        private static void AddDatabaseSetup(IConfiguration config, IServiceCollection services)
        {
            var connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<AppDbContext>(options => 
                options.UseNpgsql(connectionString, options => options.MigrationsAssembly("WebApp.Infrastructure")));
        }
    }
}
