namespace RentalCars.Web.Areas.Agency.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using RentalCars.Data.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;

    public class CarCrudModel
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

        public FuelType FuelType { get; set; }

        public bool AirConditioner { get; set; }

        public bool Navigation { get; set; }

        public bool Abs { get; set; }

        public bool Asp { get; set; }

        public bool Mp3Player { get; set; }

        public int CitiesId { get; set; }

        public IEnumerable<SelectListItem> Cities { get; set; }
    }
}
