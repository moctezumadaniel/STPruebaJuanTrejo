using PruebaSTJuanTrejo.Entities;

namespace PruebaSTJuanTrejo.Business.Services.Items
{
    public interface IItemsService
    {
        Item CreateItem(Item item);
        Item? UpdateItem(Item item);
        Item? DeleteItem(Guid item);
        IEnumerable<Item> GetItems(int limit);
        Item GetItemByGuid(Guid id);
        void AddItemToCart(Guid itemId, Guid customerId);
    }
}
