namespace RentalCars.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class User : IdentityUser
    {

        [MinLength(UserNameMinLength)]
        [MaxLength(UserNameMaxLength)]
        public string FirstName { get; set; }

        [MinLength(UserNameMinLength)]
        [MaxLength(UserNameMaxLength)]
        public string LastName { get; set; }

        public DateTime? Birthdate { get; set; }

        public Agency Agency { get; set; }

        public List<RentalOrder> Orders { get; set; } = new List<RentalOrder>();
    }
}
