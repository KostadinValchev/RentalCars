namespace RentalCars.Services
{
    using RentalCars.Services.Models.Booking;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBookingService
    {
        Task CreateAsync(DateTime startDate, DateTime returnDate, string phoneNumber, string userId, int carId);

        Task<BookingDetailsModel> DetailsAsync(int id);

        Task<IEnumerable<BookingDetailsModel>> FindAllBookingsAsync(string id, int page = 1);

        Task<BookingDetailsModel> FindLastBookingAsync(string id);

        Task<int> TotalBookingAsync(string id);
    }
}
