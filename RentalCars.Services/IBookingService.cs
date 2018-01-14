namespace RentalCars.Services
{
    using RentalCars.Services.Models.Booking;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBookingService
    {
        Task CreateAsync(DateTime startDate, DateTime returnDate, string userId, int carId);

        Task<TModel> Details<TModel>(int id) where TModel : class;

        Task<IEnumerable<BookingDetailsModel>> FindAllBookings<TModel>(string id) where TModel : class;

        Task<TModel> FindLastBooking<TModel>(string id) where TModel : class;
    }
}
