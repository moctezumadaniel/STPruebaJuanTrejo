using PruebaSTJuanTrejo.Entities;

namespace PruebaSTJuanTrejo.Data.Repositories.Items
{
    public class ItemsRepository: IItemsRepository
    {
        private readonly DataContext _dataContext;
        public ItemsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Item InsertItem(Item item)
        {
            item.Id = Guid.NewGuid();
            _dataContext.Items.Add(item);
            _dataContext.SaveChanges();
            return item;
        }

        public Item? EditItem(Item item)
        {
            var itemFound = _dataContext.Items.SingleOrDefault(c => c.Id == item.Id);
            if (itemFound != null)
            {
                itemFound.Stock = item.Stock;
                itemFound.Price = item.Price;
                itemFound.Code = item.Code;
                itemFound.Description = item.Description;
                itemFound.StoreId = item.StoreId;
            }
            _dataContext.SaveChanges();
            return itemFound;
        }

        public Item? DeleteItem(Guid guid)
        {
            var itemFound = _dataContext.Items.SingleOrDefault(c => c.Id == guid);
            if (itemFound != null)
            {
                _dataContext.Items.Remove(itemFound);
                _dataContext.SaveChanges();
            }
            return itemFound;
        }

        public IEnumerable<Item> ReadItems(int limit)
        {
            var items =
                (from item in _dataContext.Items
                 select item)
                .Take(limit);

            return items;
        }

        public Item? GetCustomerByGuid(Guid id)
        {
            var item = _dataContext.Items.FirstOrDefault(c => c.Id == id);

            return item;
        }

        public void AddItemToCustomerCart(Guid itemId, Guid customerId)
        {
            var cartRelation = _dataContext.ItemToCustomers
                .FirstOrDefault(i => i.ItemId == itemId && i.CustomerId == customerId);
            if(cartRelation == null)
            {
                var cartItem = new ItemToCustomer
                {
                    Id = Guid.NewGuid(),
                    CustomerId = customerId,
                    ItemId = itemId
                };
                _dataContext.ItemToCustomers.Add(cartItem);
                _dataContext.SaveChanges();
            }
        }
    }
}
