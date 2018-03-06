namespace RentalCars.Services
{
    using RentalCars.Services.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICarService
    {
        Task<CarDetailsServiceModel> ByIdAsync(int id);

        Task<IEnumerable<CarDetailsServiceModel>> AllAsync(int page = 1);

        Task<IEnumerable<CarDetailsServiceModel>> FindCarByCityAsync(string searchText);

        Task<int> TotalAsync();
    }
}