using Microsoft.Extensions.DependencyInjection;
using WebApp.Application.Interfaces.Services;
using WebApp.Application.Services;

namespace NewsPortalCMS.Application.Configuration
{
    public static class AppliactionLayerConfig
    {
        public static IServiceCollection AddAppliactionsServices(this IServiceCollection services)
        {
            services.AddScoped<ITransactionsService, TransactionsService>();

            return services;
        }
    }
}
