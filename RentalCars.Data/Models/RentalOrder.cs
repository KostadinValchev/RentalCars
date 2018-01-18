namespace RentalCars.Data.Models
{
    using System;

    public class RentalOrder
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public decimal Price { get; set; }

        public int RentDays { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }
    }
}
