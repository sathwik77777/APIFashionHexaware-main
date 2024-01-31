using FashionHexa.Entities;

namespace FashionHexa.DTO
{
    public class AvailabilityDTO
    {
        public string? AvailabilityId { get; set; }
        public int? Quantity { get; set; }
        public Product? Product { get; set; }
    }
}
