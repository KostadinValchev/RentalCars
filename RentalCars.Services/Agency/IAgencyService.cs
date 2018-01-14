namespace RentalCars.Services.Agency
{
    using RentalCars.Data.Models;
    using System.Threading.Tasks;

    public interface IAgencyService
    {
        Task CreateAsync(string name, string userId);

        Task<string> FindAgencyNameAsync(string id);

        Task<int> FindAgencyByIdAsync(string id);

        Task<string> FindAgencyNameByCarAsync(Car car);
    }
}