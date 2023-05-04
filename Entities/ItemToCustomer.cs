using System.ComponentModel.DataAnnotations;

namespace PruebaSTJuanTrejo.Entities
{
    public class ItemToCustomer
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid ItemId { get; set; }
        [Required]
        public Guid CustomerId { get; set; }
        public DateTime Date { get; set; }

    }
}
