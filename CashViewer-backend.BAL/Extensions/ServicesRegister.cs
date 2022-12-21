using CashViewer_backend.BAL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CashViewer_backend.BAL.Extensions
{
    public static class ServicesRegister
    {
        public static IServiceCollection AddServices(this IServiceCollection services) =>
            services.AddScoped<ServiceShop>()
            ;
    }
}
