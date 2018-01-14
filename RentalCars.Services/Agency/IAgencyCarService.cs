namespace RentalCars.Services.Agency
{
    using RentalCars.Data.Models;
    using RentalCars.Services.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAgencyCarService
    {
        Task CreateAsync(string make,
            string model,
            Category category,
            decimal price,
            FuelType fueltype,
            bool airConditioner,
            bool navigation,
            bool abs,
            bool asp,
            bool mp3Player,
            int agencyId,
            int cityId,
            string img);

        Task<bool> DeleteAsync(int id);

        Task Edit(
           int id,
           string make,
           string model,
           Category category,
           decimal price,
           FuelType fueltype,
           bool airConditioner,
           bool navigation,
           bool abs,
           bool asp,
           bool mp3Player,
           int cityId);

        Task<IEnumerable<CitiesModel>> GetCitiesAsync();

        Task<IEnumerable<CarDetailsServiceModel>> AllCarsAsync(string agencyName);

        Task<IEnumerable<CarDetailsServiceModel>> AllReturnedCarsAsync(string agencyName);

        Task<bool> PublishAgain(int id);

        Task<CarCrudModel> FindByIdAsync(int id);
    }
}
