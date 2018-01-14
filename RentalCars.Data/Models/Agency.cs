namespace RentalCars.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class Agency
    {
        public int Id { get; set; }

        [Required]
        [MinLength(AgencyNameMinLenght)]
        [MaxLength(AgencyNameMaxLenght)]
        public string Name { get; set; }

        public List<Car> Cars { get; set; } = new List<Car>();

        public List<AgencyCity> Cities { get; set; } = new List<AgencyCity>();

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
