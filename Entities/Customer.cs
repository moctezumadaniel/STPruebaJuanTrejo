using System.ComponentModel.DataAnnotations;

namespace PruebaSTJuanTrejo.Entities
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = "";
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = "";
        [Required]
        [StringLength(150)]
        public string Address { get; set; } = "";

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string EmailAddress { get; set; } = "";

        [Required]
        [StringLength(50)]
        public string Password { get; set; } = "";

    }

    public class CustomerToCreate
    {
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = "";
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = "";
        [Required]
        [StringLength(150)]
        public string Address { get; set; } = "";

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string EmailAddress { get; set; } = "";

        [Required]
        [StringLength(50)]
        public string Password { get; set; } = "";

    }
}
