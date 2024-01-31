using FashionHexa.Entities;
using FashionHexa.Database;

namespace FashionHexa.Services
{
    public class AvailabilityService : IAvailabilityService
    {
        private readonly MyContext context;

        public AvailabilityService(MyContext Context)
        {
            context = Context;
        }

        public void AddAvailability(Availability availability)
        {
            try
            {
                context.Availabilities.Add(availability);
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Availability GetAvailabilityById(int availabilityId)
        {
            try
            {
                return context.Availabilities.FirstOrDefault(a => a.AvailabilityId == availabilityId);

                
                
                /*Availability availability = context.Availabilities.SingleOrDefault(p => p.AvailabilityId == availabilityId);
                return availability;*/
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Availability> GetAvailabilityList()
        {
            try
            {
                return context.Availabilities.ToList(); //ToList() return all products in the form of List
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RemoveAvailability(int availabilityId)
        {
            try
            {

                Availability availability = context.Availabilities.SingleOrDefault(p => p.AvailabilityId == availabilityId);
                if(availability != null)
                {
                    context.Availabilities.Remove(availability);
                    context.SaveChanges();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateAvailability(Availability availability)
        {
            try
            {
                context.Availabilities.Update(availability);
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
