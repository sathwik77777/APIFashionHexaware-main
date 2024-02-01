using FashionHexa.Entities;
using System.Security.Policy;

namespace FashionHexa.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
        public Boolean Available { get; set; } = true;
        public int  BrandId { get; set; }
        
        //public string BrandName { get; set; }
        public string image {  get; set; }
        //public int quantity {  get; set; }
        
    }

}
