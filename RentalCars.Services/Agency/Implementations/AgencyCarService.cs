namespace RentalCars.Services.Agency.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using RentalCars.Data;
    using RentalCars.Data.Models;
    using RentalCars.Services.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using static ServiceConstants;

    public class AgencyCarService : IAgencyCarService
    {
        private readonly RentalCarsDbContext db;

        public AgencyCarService(RentalCarsDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CarDetailsServiceModel>> AllCarsAsync(string agencyName, int page = 1)
        => await this.db
            .Cars
            .Where(c => c.Agency.Name == agencyName)
            .OrderBy(c => c.Price)
            .Skip((page - 1) * CarsAgencyPageSize)
            .Take(CarsAgencyPageSize)
            .ProjectTo<CarDetailsServiceModel>()
            .ToListAsync();

        public async Task<IEnumerable<CarDetailsServiceModel>> AllReturnedCarsAsync(string agencyName, int page = 1)
        => await this.db
                .Cars
                .Where(c =>
                c.Agency.Name == agencyName
                && c.ReturnDate < DateTime.UtcNow
                && c.IsReserved == true)
                .OrderBy(c => c.Id)
                .Skip((page - 1) * CarsAgencyPageSize)
                .Take(CarsAgencyPageSize)
                .ProjectTo<CarDetailsServiceModel>()
                .ToListAsync();

        public async Task CreateAsync(string make,
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
            Image img)
        {
            var car = new Car()
            {
                Make = make,
                Model = model,
                Category = category,
                Price = price,
                FuelType = fueltype,
                AirConditioner = airConditioner,
                Navigation = navigation,
                Abs = abs,
                Asp = asp,
                Mp3Player = mp3Player,
                AgencyId = agencyId,
                CityId = cityId,
                Image = img,
            };

            this.db.Cars.Add(car);
            await this.db.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var car = await this.db.Cars.FirstOrDefaultAsync(c => c.Id == id);

            if (car == null)
            {
                return false;
            }

            this.db.Cars.Remove(car);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task Edit(
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
            int cityId)
        {
            var car = await this.db.Cars.FirstOrDefaultAsync(c => c.Id == id);

            if (car != null && car.Id == id)
            {
                car.Make = make;
                car.Model = model;
                car.Category = category;
                car.Price = price;
                car.FuelType = fueltype;
                car.AirConditioner = airConditioner;
                car.Navigation = navigation;
                car.Abs = abs;
                car.Asp = asp;
                car.Mp3Player = mp3Player;
                car.CityId = cityId;
            }

            this.db.Cars.Update(car);
            await this.db.SaveChangesAsync();
        }

        public async Task<CarCrudModel> FindByIdAsync(int id)
       => await this.db
            .Cars
            .Where(c => c.Id == id)
            .ProjectTo<CarCrudModel>()
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<CitiesModel>> GetCitiesAsync()
        {
            var cities = await this.db.Cities.ProjectTo<CitiesModel>().ToListAsync();
            return cities;
        }

        public async Task<int> TotalAsync()
       => await this.db.Cars.CountAsync();

        public async Task<bool> PublishAgain(int id)
        {
            var car = await this.db
             .Cars
             .Where(c => c.Id == id)
             .SingleOrDefaultAsync();

            if (car == null)
            {
                return false;
            }

            car.IsReserved = false;

            await this.db.SaveChangesAsync();

            return true;
        }
    }
}