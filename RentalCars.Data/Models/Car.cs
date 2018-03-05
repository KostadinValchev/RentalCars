namespace RentalCars.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class Car
    {

        public int Id { get; set; }

        [Required]
        [MinLength(CarMakeMinLength)]
        [MaxLength(CarMakeMaxLength)]
        public string Make { get; set; }

        [MinLength(CarModelMinLength)]
        [MaxLength(CarModelMaxLength)]
        public string Model { get; set; }

        public Category Category { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public int BookingCount { get; set; }

        public FuelType FuelType { get; set; }

        public string ImgUrl { get; set; }

        public bool AirConditioner { get; set; }

        public bool Navigation { get; set; }

        public bool Abs { get; set; }

        public bool Asp { get; set; }

        public bool Mp3Player { get; set; }

        public bool IsReserved { get; set; }

        public DateTime ReturnDate { get; set; }

        public List<RentalOrder> Orders { get; set; } = new List<RentalOrder>();

        public int AgencyId { get; set; }

        public Agency Agency { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }

        public Image Image { get; set; }
    }
}
