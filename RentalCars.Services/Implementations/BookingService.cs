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
    using static ServiceConstants;

    public class BookingService : IBookingService
    {
        private readonly RentalCarsDbContext db;

        public BookingService(RentalCarsDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(DateTime startDate, DateTime returnDate, string phoneNumber, string userId, int carId)
        {
            var user = await this.db.Users.SingleOrDefaultAsync(u => u.Id == userId);
            var car = await this.db.Cars.SingleOrDefaultAsync(c => c.Id == carId);

            TimeSpan bookingDays = (returnDate - startDate);

            if (user != null && car != null)
            {
                var rentOrder = new RentalOrder()
                {
                    StartDate = startDate,
                    ReturnDate = returnDate,
                    User = user,
                    Car = car,
                    RentDays = bookingDays.Days
                };
                if (user.PhoneNumber == null)
                {
                    user.PhoneNumber = phoneNumber;
                    this.db.Update(user);
                }
                car.IsReserved = true;
                car.ReturnDate = returnDate;
                rentOrder.Price = car.Price * rentOrder.RentDays;
                car.BookingCount++;

                this.db.RentalOrders.Add(rentOrder);
                this.db.Cars.Update(car);
                await this.db.SaveChangesAsync();
            }
        }

        public async Task<TModel> Details<TModel>(int id) where TModel : class
      => await this.db.RentalOrders
          .Where(u => u.Id == id)
          .ProjectTo<TModel>()
          .FirstOrDefaultAsync();

        public async Task<IEnumerable<BookingDetailsModel>> FindAllBookings<TModel>(string id, int page = 1) where TModel : class
            => await this.db.RentalOrders
            .Where(u => u.UserId == id)
            .OrderBy(o => o.Id)
            .Skip((page - 1) * OrdersUserHistoryPageSize)
            .Take(OrdersUserHistoryPageSize)
            .ProjectTo<BookingDetailsModel>()
            .ToListAsync();

        public async Task<TModel> FindLastBooking<TModel>(string id) where TModel : class
        => await this.db.RentalOrders
            .Where(u => u.UserId == id)
            .OrderByDescending(o => o.Id)
            .ProjectTo<TModel>()
            .FirstOrDefaultAsync();

        public Task<int> TotalBookingAsync(string id)
        => this.db.RentalOrders.Where(u => u.UserId == id).CountAsync();
    }
}