using PruebaSTJuanTrejo.Entities;

namespace PruebaSTJuanTrejo.Data.Repositories.Items
{
    public interface IItemsRepository
    {

        Item InsertItem(Item item);

        Item? EditItem(Item item);

        Item? DeleteItem(Guid guid);

        IEnumerable<Item> ReadItems(int limit);

        Item? GetCustomerByGuid(Guid id);

        void AddItemToCustomerCart(Guid itemId, Guid customerId);
    }
}
