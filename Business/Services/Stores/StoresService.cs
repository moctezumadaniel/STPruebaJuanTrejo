using PruebaSTJuanTrejo.Data.Repositories.Stores;
using PruebaSTJuanTrejo.Entities;
using System.Collections.Generic;

namespace PruebaSTJuanTrejo.Business.Services.Stores
{
    public class StoresService : IStoresService
    {
        private readonly IStoresRepository _storesRepository;
        public StoresService(IStoresRepository storesRepository)
        {
            _storesRepository = storesRepository;
        }
        public Store CreateStore(Store store)
        {
            store.Id = Guid.NewGuid();
            var result = _storesRepository.InsertStore(store);
            return result;
        }

        public Store? DeleteStore(Guid guid)
        {
            var result = _storesRepository.DeleteStores(guid);
            return result;
        }

        public Store? GetStoreByGuid(Guid id)
        {
            var result = _storesRepository.GetStoreByGuid(id);
            return result;
        }

        public IEnumerable<Store> GetStores(int limit)
        {
            var result = _storesRepository.ReadStores(limit);
            return result;
        }

        public Store? UpdateStore(Store store)
        {
            var result = _storesRepository.EditStore(store);
            return result;
        }
    }
}
