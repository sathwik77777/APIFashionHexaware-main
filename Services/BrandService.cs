using FashionHexa.Database;
using FashionHexa.DTO;
using FashionHexa.Entities;

namespace FashionHexa.Services


{
    public class BrandService : IBrandService
    {
        private readonly MyContext context;
        public BrandService(MyContext Context)
        {
            context = Context;
        }

        public void AddBrand(Brand brand)
        {
            context.Brands.Add(brand);
            context.SaveChanges();
            
        }

        public void DeleteBrand(int brandId) 
        {
            Brand brand = context.Brands.SingleOrDefault(b=>b.BrandId == brandId);
            if(brand != null)
            {
                context.Brands.Remove(brand);
                context.SaveChanges();
            }

            
        }

        public List<Brand> GetAllBrands()
        {
            return context.Brands.ToList();
        }

        public Brand BrandById(int brandId)
        {
            Brand brand = context.Brands.SingleOrDefault(b => b.BrandId == brandId);
            return brand;
        }

        public void UpdateBrand(Brand brand)
        {
            try
            {
                context.Brands.Update(brand);
                context.SaveChanges();
            }
            catch(Exception )
            {
                throw;
            }
        }

     
    }
}
