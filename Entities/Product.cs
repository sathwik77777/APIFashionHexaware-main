using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FashionHexa.Entities
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Column("ProductName", TypeName = "varchar")]
        [StringLength(50)]
        [Required]
        public string? Name { get; set; }
        public double Price { get; set; }
        public Boolean Availabile { get; set; } = true;

        public int BrandId {  get; set; }
        //public string? BrandName { get; set; }

        public string image{  get; set; }
        
        
        

        
        [ForeignKey("BrandId")]
        
        public Brand? BrandName { get; set; }
    }
}
