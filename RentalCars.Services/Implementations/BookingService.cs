namespace RentalCars.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using RentalCars.Data;
    using RentalCars.Data.Models;
    using RentalCars.Services.Models.Booking;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BookingService : IBookingService
    {
        private readonly RentalCarsDbContext db;

        public BookingService(RentalCarsDbContext db)
        {
            this.db = db;
        }
        public async Task CreateAsync(DateTime startDate, DateTime returnDate, string userId, int carId)
        {

            TimeSpan bookingDays = (returnDate - startDate);

            var rentOrder = new RentalOrder()
            {
                StartDate = startDate,
                ReturnDate = returnDate,
                UserId = userId,
                CarId = carId,
                RentDays = bookingDays.Days
            };


            var car = this.db.Cars.Find(carId);
            car.IsReserved = true;
            car.ReturnDate = returnDate;
            car.BookingCount++;
            rentOrder.Price = car.Price * rentOrder.RentDays;

            this.db.RentalOrders.Add(rentOrder);
            this.db.Cars.Update(car);
            await this.db.SaveChangesAsync();
        }

        public async Task<TModel> Details<TModel>(int id) where TModel : class
      => await this.db.RentalOrders
          .Where(u => u.Id == id)
          .ProjectTo<TModel>()
          .FirstOrDefaultAsync();

        public async Task<IEnumerable<BookingDetailsModel>> FindAllBookings<TModel>(string id) where TModel : class
            => await this.db.RentalOrders
            .Where(u => u.UserId == id)
            .OrderBy(o => o.Id)
            .ProjectTo<BookingDetailsModel>()
            .ToListAsync();

        public async Task<TModel> FindLastBooking<TModel>(string id) where TModel : class
        => await this.db.RentalOrders
            .Where(u => u.UserId == id)
            .OrderByDescending(o => o.Id)
            .ProjectTo<TModel>()
            .FirstOrDefaultAsync();


    }
}