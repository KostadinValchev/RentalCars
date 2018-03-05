namespace RentalCars.Web.Areas.Agency.Models
{
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;

    public class AgencyFormModel
    {
        [Required]
        [MinLength(AgencyNameMinLenght)]
        [MaxLength(AgencyNameMaxLenght)]
        [Display(Name = "Agency Name")]
        public string Name { get; set; }

        public ICollection<IFormFile> Image { get; set; }
    }
}
