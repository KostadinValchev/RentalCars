namespace RentalCars.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BookingViewModel
    {
        public int CarId { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
    }
}
