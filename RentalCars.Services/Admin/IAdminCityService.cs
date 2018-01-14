namespace RentalCars.Services.Admin
{
    using System.Threading.Tasks;

    public interface IAdminCityService
    {
        Task CreateAsync(string name);
    }
}
