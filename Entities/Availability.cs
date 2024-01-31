using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FashionHexa.Entities
{
    [Table("Availability")]
    public class Availability
    {
        [Key]
        
        public int  AvailabilityId {  get; set; }
        public int ProductId { get; set; }
        [Required]
        public int? Quantity { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
    }
}
