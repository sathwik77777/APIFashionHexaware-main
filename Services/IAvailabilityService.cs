using FashionHexa.Entities;
namespace FashionHexa.Services
{
    public interface IAvailabilityService
    {
        List<Availability> GetAvailabilityList();  //Done
        Availability GetAvailabilityById(int availabilityId); //Done
        void UpdateAvailability(Availability availability);
        void AddAvailability(Availability availability);
        void RemoveAvailability(int availabilityId);
    }
}
