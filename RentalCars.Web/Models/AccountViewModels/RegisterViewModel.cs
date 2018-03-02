namespace RentalCars.Web.Models.AccountViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;

    public class RegisterViewModel
    {
        [Required]
        [StringLength(50)]
        public virtual string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [MinLength(UserNameMinLength)]
        [MaxLength(UserNameMaxLength)]
        public string FirstName { get; set; }

        [MinLength(UserNameMinLength)]
        [MaxLength(UserNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "I'm Agency")]
        public bool IsAgency { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Birthdate { get; set; }
    }
}
