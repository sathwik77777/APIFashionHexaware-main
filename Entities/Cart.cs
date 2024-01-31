using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FashionHexa.Entities
{
    public class Cart
    {

        [Key]
        public int CartId { get; set; }
        [Required]
        public int UserId {  get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public int ProductId {  get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [Required]
        public int Quantity {  get; set; }
    }
}
