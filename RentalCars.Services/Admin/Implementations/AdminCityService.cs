namespace RentalCars.Services.Admin.Implementations
{
    using RentalCars.Data;
    using RentalCars.Data.Models;
    using System.Threading.Tasks;

    public class AdminCityService : IAdminCityService
    {
        private readonly RentalCarsDbContext db;

        public AdminCityService(RentalCarsDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string name)
        {

            var city = new City() { Name = name };

            this.db.Add(city);
            await this.db.SaveChangesAsync();
        }
    }
}
