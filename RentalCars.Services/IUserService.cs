namespace RentalCars.Services
{
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<TModel> ByIdAsync<TModel>(string id) where TModel : class;
    }
}
