using PruebaSTJuanTrejo.Entities;

namespace PruebaSTJuanTrejo.Data.Repositories.Stores
{
    public class StoresRepository: IStoresRepository
    {
        private readonly DataContext _dataContext;
        public StoresRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Store InsertStore(Store store)
        {
            _dataContext.Stores.Add(store);
            _dataContext.SaveChanges();
            return store;
        }

        public Store? EditStore(Store store)
        {
            var storeFound = _dataContext.Stores.SingleOrDefault(c => c.Id == store.Id);
            if (storeFound != null)
            {
                storeFound.Address = store.Address;
                storeFound.Branch = store.Branch;
                _dataContext.SaveChanges();
            }
            return storeFound;
        }

        public Store? DeleteStores(Guid guid)
        {
            var storeFound = _dataContext.Stores.SingleOrDefault(c => c.Id == guid);
            if (storeFound != null)
            {
                _dataContext.Stores.Remove(storeFound);
                _dataContext.SaveChanges();
            }
            return storeFound;
        }

        public IEnumerable<Store> ReadStores(int limit)
        {
            var stores =
                (from store in _dataContext.Stores
                 select store)
                .Take(limit);

            return stores;
        }

        public Store? GetStoreByGuid(Guid id)
        {
            var store = _dataContext.Stores.FirstOrDefault(c => c.Id == id);

            return store;
        }
    }
}

