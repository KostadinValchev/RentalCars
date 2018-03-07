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

        public async Task<BookingDetailsModel> Details(int id)
        {
          var result =  await this.db.RentalOrders
            .Where(u => u.Id == id)
            .ProjectTo<BookingDetailsModel>()
            .FirstOrDefaultAsync();

            if (result != null)
            {
                var carId = result.CarId;
                var agencyId = result.Car.AgencyId;

                var image = this.db.Images.SingleOrDefaultAsync(i => i.CarId == carId).Result;
                var logo = this.db.Images.SingleOrDefaultAsync(i => i.AgencyId == agencyId).Result;

                result.Image = image;
                result.AgencyLogo = logo;
            }

            return result;
        }
        public async Task<IEnumerable<BookingDetailsModel>> FindAllBookings(string id, int page = 1)
        {
            var result = await this.db.RentalOrders
               .Where(u => u.UserId == id)
               .OrderBy(o => o.Id)
               .Skip((page - 1) * OrdersUserHistoryPageSize)
               .Take(OrdersUserHistoryPageSize)
               .ProjectTo<BookingDetailsModel>()
               .ToListAsync();

            if (result != null)
            {
                foreach (var item in result)
                {
                    var carId = item.CarId;
                    var car = this.db.Cars.SingleOrDefaultAsync(c => c.Id == carId).Result;
                    var agency = this.db.Agencies.SingleOrDefaultAsync(a => a.Id == car.AgencyId).Result;
                    var carImage = this.db.Images.SingleOrDefaultAsync(i => i.CarId == carId).Result;
                    var agencyLogo = this.db.Images.SingleOrDefaultAsync(i => i.AgencyId == agency.Id).Result;
                    item.Image = carImage;
                    item.AgencyLogo = agencyLogo;
                }
            }
            return result;
        }

        public async Task<BookingDetailsModel> FindLastBooking(string id)
        {
            var result = await this.db.RentalOrders
             .Where(u => u.UserId == id)
             .OrderByDescending(o => o.Id)
             .ProjectTo<BookingDetailsModel>()
             .FirstOrDefaultAsync();

            if (result != null)
            {
                var carId = result.CarId;
                var agencyId = result.Car.AgencyId;

                var image = this.db.Images.SingleOrDefaultAsync(i => i.CarId == carId).Result;
                var logo = this.db.Images.SingleOrDefaultAsync(i => i.AgencyId == agencyId).Result;

                result.Image = image;
                result.AgencyLogo = logo;
            }

            return result;
        }

        public Task<int> TotalBookingAsync(string id)
        => this.db.RentalOrders.Where(u => u.UserId == id).CountAsync();
    }
}