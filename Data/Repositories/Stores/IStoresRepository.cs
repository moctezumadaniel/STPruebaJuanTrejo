using PruebaSTJuanTrejo.Entities;

namespace PruebaSTJuanTrejo.Data.Repositories.Stores
{
    public interface IStoresRepository
    {


        Store InsertStore(Store store);

        Store? EditStore(Store store);

        Store? DeleteStores(Guid guid);

        IEnumerable<Store> ReadStores(int limit);

        Store? GetStoreByGuid(Guid id);
    }
}

