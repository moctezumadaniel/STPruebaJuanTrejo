namespace PruebaSTJuanTrejo.Entities
{
    public class Store
    {
        public Guid Id { get; set; }
        public string Branch { get; set; } = "";
        public string Address { get; set; } = "";
        public ICollection<Item>? Items { get; set; }
    }

    public class StoreToCreate
    {
        public string Branch { get; set; } = "";
        public string Address { get; set; } = "";
    }
}
