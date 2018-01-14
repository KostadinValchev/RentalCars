namespace RentalCars.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class City
    {
        public int Id { get; set; }

        [Required]
        [MinLength(CityNameMinLength)]
        [MaxLength(CityNameMaxLength)]
        public string Name { get; set; }

        public List<AgencyCity> Agencies { get; set; } = new List<AgencyCity>();

        public List<Car> Cars { get; set; } = new List<Car>();
    }
}
