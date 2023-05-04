using System.ComponentModel.DataAnnotations;

namespace PruebaSTJuanTrejo.Entities
{
    public class ItemToStore
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid ItemId { get; set; }
        [Required]
        public Guid StoreId { get; set; }
        public DateTime Date { get; set; }

    }
}
