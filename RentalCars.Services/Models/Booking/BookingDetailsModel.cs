namespace RentalCars.Services.Models.Booking
{
    using RentalCars.Common.Mapping;
    using RentalCars.Data.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;

    public class BookingDetailsModel : IMapFrom<RentalOrder>
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }

        public decimal Price { get; set; }

        public int RentDays { get; set; }

        public Agency Agency { get; set; }

        public Image AgencyLogo { get; set; }

        public Image Image { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }
    }
}
