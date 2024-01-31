using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FashionHexa.Entities
{
    [Table("UserRatings")]
    public class UserRatings
    {
        [Key]
        
        public int UserRatingsId { get; set; }

        [Required]
        public int ? Ratings {  get; set; }

        public DateTime RatedAt { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User? User { get; set; }
        public int ProductId { get; internal set; }
    }
}
