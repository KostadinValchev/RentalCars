namespace RentalCars.Services
{
    using RentalCars.Services.Models.Booking;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBookingService
    {
        Task CreateAsync(DateTime startDate, DateTime returnDate, string phoneNumber, string userId, int carId);

        Task<BookingDetailsModel> Details(int id);

        Task<IEnumerable<BookingDetailsModel>> FindAllBookings(string id, int page = 1);

        Task<BookingDetailsModel> FindLastBooking(string id);

        Task<int> TotalBookingAsync(string id);
    }
}
