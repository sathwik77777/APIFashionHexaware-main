using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FashionHexa.Entities
{
    [Table("Notiications")]
    public class Notification
    {
        [Key]
       
        public int NotiicationId { get; set; }

        [Required]
        [StringLength(50)]
        [Column("Content",TypeName = "varchar")]
        public string? Notiication { get; set;}

        public DateTime NotificationTime { get; set; }

    }
}
