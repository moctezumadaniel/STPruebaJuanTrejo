using System.ComponentModel.DataAnnotations;

namespace PruebaSTJuanTrejo.Entities
{
    public class Item
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Code { get; set; } = "";
        [Required]
        [StringLength(100)]
        public string Description { get; set; } = "";
        public double Price { get; set; }
        public string Image { get; set; } = "";
        public int Stock { get; set; }
        public Guid StoreId { get; set; }
        public Store? Store { get; set; }
    }
    public class ItemToCreate
    {
        public string Code { get; set; } = "";
        public string Description { get; set; } = "";
        public double Price { get; set; }
        public int Stock { get; set; }
        [Required]
        public Guid StoreId { get; set; }
    }

}
