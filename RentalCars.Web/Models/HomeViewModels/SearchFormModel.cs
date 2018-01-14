namespace RentalCars.Web.Models.HomeViewModels
{
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;

    public class SearchFormModel
    {
        public string SearchText { get; set; }

        [Display(Name = "Search In City")]
        public bool SearchInCity { get; set; } = true;
    }
}
