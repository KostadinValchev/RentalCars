namespace RentalCars.Services.Models.Booking
{
    using RentalCars.Common.Mapping;
    using RentalCars.Data.Models;
    using System;

    public class BookingDetailsServiceModel : IMapFrom<RentalOrder>
    {
        public DateTime StartDate { get; set; }

        public DateTime ReturnDate { get; set; }
    }
}
