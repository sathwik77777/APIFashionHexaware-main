using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionHexa.Entities
{
    [Table("Brands")]
    public class Brand
    {
        [Key]
        
        public int BrandId { get; set; }

        [Required]
        [StringLength(50)]
        [Column("BrandName",TypeName ="varchar")]
        public string? BrandName { get; set;}
        [Required]
        [StringLength(200)]
        [Column("Description" ,TypeName="varchar")]
        public string? Description { get; set;}  

    }
}
