namespace RentalCars.Web.Areas.Agency.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;

    public class AgencyFormModel
    {
        [Required]
        [MinLength(AgencyNameMinLenght)]
        [MaxLength(AgencyNameMaxLenght)]
        [Display(Name = "Agency Name")]
        public string Name { get; set; }
    }
}
