namespace RentalCars.Web.Areas.Admin.Models
{

    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;

    public class CityFormViewModel
    {
        [Required]
        [MinLength(CityNameMinLength)]
        [MaxLength(CityNameMaxLength)]
        public string Name { get; set; }
    }
}
