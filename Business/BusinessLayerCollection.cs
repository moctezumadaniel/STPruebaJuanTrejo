using PruebaSTJuanTrejo.Business.Services.Auth;
using PruebaSTJuanTrejo.Business.Services.Customers;
using PruebaSTJuanTrejo.Business.Services.Items;
using PruebaSTJuanTrejo.Business.Services.Stores;

namespace PruebaSTJuanTrejo.Business
{
    public static class BusinessLayerCollection
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IStoresService, StoresService>();
            services.AddScoped<IItemsService, ItemsService>();
            services.AddScoped<ICustomersService, CustomersService>();
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
