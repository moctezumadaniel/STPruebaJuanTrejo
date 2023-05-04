using PruebaSTJuanTrejo.Entities;

namespace PruebaSTJuanTrejo.Business.Services.Stores
{
    public interface IStoresService
    {
        Store CreateStore(Store store);
        Store? UpdateStore(Store store);
        Store? DeleteStore(Guid guid);
        IEnumerable<Store> GetStores(int limit);
        Store? GetStoreByGuid(Guid id);
            
    }
}
