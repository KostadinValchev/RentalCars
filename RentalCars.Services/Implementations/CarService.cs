namespace RentalCars.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using RentalCars.Data;
    using RentalCars.Services.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using static ServiceConstants;

    public class CarService : ICarService
    {
        private readonly RentalCarsDbContext db;

        public CarService(RentalCarsDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CarDetailsServiceModel>> AllAsync(int page = 1)
        => await this.db
            .Cars
            .Where(c => c.IsReserved == false)
            .OrderBy(c => c.Price)
            .Skip((page - 1) * CarsHomeIndexPageSize)
            .Take(CarsHomeIndexPageSize)
            .ProjectTo<CarDetailsServiceModel>()
            .ToListAsync();

        public async Task<int> TotalAsync()
        => await this.db.Cars.Where(c => c.IsReserved == false).CountAsync();

        public async Task<TModel> ByIdAsync<TModel>(int id) where TModel : class
        => await this.db
            .Cars
            .Where(c => c.Id == id)
            .ProjectTo<TModel>()
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<CarDetailsServiceModel>> FindCarByCityAsync(string searchText)
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