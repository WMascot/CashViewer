using CashViewer_backend.DAL.Entities;
using CashViewer_backend.DAL.Interfaces;
using CashViewer_backend.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CashViewer_backend.BAL.Extensions
{
    public static class RepositoriesRegister
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) =>
            services.AddScoped<IRepository<Bill>, BillsRepository>()
                    .AddScoped<IRepository<BillProduct>, BillProductsRepository>()
                    .AddScoped<IRepository<Product>, ProductsRepository>()
                    .AddScoped<IRepository<Shop>, ShopsRepository>()
                    .AddScoped<IRepository<ShopType>, ShopTypesRepository>()
            ;
    }
}
