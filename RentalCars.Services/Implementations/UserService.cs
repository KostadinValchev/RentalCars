namespace RentalCars.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using RentalCars.Data;
    using RentalCars.Services.Models;
    using System.Linq;
    using System.Threading.Tasks;


    public class UserService : IUserService
    {
        private readonly RentalCarsDbContext db;

        public UserService(RentalCarsDbContext db)
        {
            this.db = db;
        }

        public async Task<TModel> ByIdAsync<TModel>(string id) where TModel : class
             => await this.db.Users
            .Where(u => u.Id == id)
            .ProjectTo<TModel>()
            .FirstOrDefaultAsync();
    }
}
