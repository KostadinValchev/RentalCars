namespace RentalCars.Services
{
    using RentalCars.Services.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICarService
    {
        Task<TModel> ByIdAsync<TModel>(int id) where TModel : class;

        Task<IEnumerable<CarDetailsServiceModel>> AllAsync();

        Task<IEnumerable<CarDetailsServiceModel>> FindAsync(string searchText);
    }
}