using Microsoft.EntityFrameworkCore;
using PruebaSTJuanTrejo.Data.Repositories.Customers;
using PruebaSTJuanTrejo.Data.Repositories.Items;
using PruebaSTJuanTrejo.Data.Repositories.Stores;
using System.Runtime.CompilerServices;

namespace PruebaSTJuanTrejo.Data
{
    public static class DataLayerCollection
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<IItemsRepository, ItemsRepository>();
            services.AddScoped<IStoresRepository, StoresRepository>();
            return services;
        }
    }
}
