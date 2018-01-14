namespace RentalCars.Services.Models
{
    using RentalCars.Common.Mapping;
    using RentalCars.Data.Models;
    using System.Collections.Generic;

    public class CarsServiceModel : IMapFrom<Car>
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public Category Category { get; set; }

        public decimal Price { get; set; }

        public int BookingCount { get; set; }

        public FuelType FuelType { get; set; }

        public bool AirConditioner { get; set; }

        public bool Navigation { get; set; }

        public bool Abs { get; set; }

        public bool Asp { get; set; }

        public bool Mp3Player { get; set; }

        public IEnumerable<City> Cities { get; set; }

        public int AgencyId { get; set; }
    }
}
