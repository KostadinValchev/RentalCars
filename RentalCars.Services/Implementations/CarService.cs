namespace RentalCars.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using RentalCars.Data;
    using RentalCars.Data.Models;
    using RentalCars.Services.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CarService : ICarService
    {
        private readonly RentalCarsDbContext db;

        public CarService(RentalCarsDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CarDetailsServiceModel>> AllAsync()
        => await this.db
            .Cars
            .OrderBy(c => c.Price)
            .ProjectTo<CarDetailsServiceModel>()
            .ToListAsync();

        public async Task<TModel> ByIdAsync<TModel>(int id) where TModel : class
        => await this.db
            .Cars
            .Where(c => c.Id == id)
            .ProjectTo<TModel>()
            .FirstOrDefaultAsync();
      
        public async Task<IEnumerable<CarDetailsServiceModel>> FindAsync(string searchText)
        {
            searchText = searchText ?? string.Empty;

            return await this.db.Cars
                .OrderBy(c => c.Price)
                .Where(c => c.City.Name.ToLower().Contains(searchText.ToLower()))
                .ProjectTo<CarDetailsServiceModel>()
                .ToListAsync();
        }
    }
}