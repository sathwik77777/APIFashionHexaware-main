using FashionHexa.Entities;
namespace FashionHexa.Services

{
    public interface IBrandService
    {
        List<Brand> GetAllBrands(); //Done
        Brand BrandById(int brandId); //Done
        void AddBrand(Brand brand); //Done
        void UpdateBrand(Brand brand); //Done
        void DeleteBrand(int brandId); //Done
    }

}
