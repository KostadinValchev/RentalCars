namespace RentalCars.Services.Agency.Implementations
{
    using Microsoft.EntityFrameworkCore;
    using RentalCars.Data;
    using RentalCars.Data.Models;
    using System.Threading.Tasks;

    public class AgencyService : IAgencyService
    {
        private readonly RentalCarsDbContext db;

        public AgencyService(RentalCarsDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string name, string userId, Image image)
        {
            var agency = new Agency()
            {
                Name = name,
                UserId = userId,
                Image = image,
            };

            if (agency != null)
            {
                this.db.Add(agency);
                await this.db.SaveChangesAsync();
            }
        }

        public async Task<int> FindAgencyByIdAsync(string id)
        {
            var agency = await this.db.Agencies.SingleOrDefaultAsync(a => a.UserId == id);

            return agency.Id;
        }

        public async Task<string> FindAgencyNameAsync(string id)
        {
            var agency = await this.db.Agencies.SingleOrDefaultAsync(a => a.UserId == id);

            return agency.Name;
        }

        public async Task<string> FindAgencyNameByCarAsync(Car car)
        {
            var agency = await this.db.Agencies.SingleOrDefaultAsync(a => a.Cars.Contains(car));

            return agency.Name;
        }
    }
}
