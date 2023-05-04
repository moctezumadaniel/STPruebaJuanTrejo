using PruebaSTJuanTrejo.Data.Repositories.Items;
using PruebaSTJuanTrejo.Entities;

namespace PruebaSTJuanTrejo.Business.Services.Items
{
    public class ItemsService : IItemsService
    {
        private readonly IItemsRepository _itemsRepository;
        public ItemsService(IItemsRepository itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }
        public void AddItemToCart(Guid itemId, Guid customerId)
        {
            _itemsRepository.AddItemToCustomerCart(itemId, customerId);
        }

        public Item CreateItem(Item item)
        {
            var result = _itemsRepository.InsertItem(item);
            return item;
        }

        public Item? DeleteItem(Guid guid)
        {
            var result = _itemsRepository.DeleteItem(guid);
            return result;
        }

        public Item GetItemByGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems(int limit)
        {
            var result = _itemsRepository.ReadItems(limit);
            return result;
        }

        public Item? UpdateItem(Item item)
        {
            var result = _itemsRepository.EditItem(item);
            return result;
        }


    }
}
