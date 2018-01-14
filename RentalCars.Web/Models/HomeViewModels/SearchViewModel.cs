namespace RentalCars.Web.Models.HomeViewModels
{
    using RentalCars.Services.Models;
    using System.Collections.Generic;

    public class SearchViewModel
    {
        public IEnumerable<CarDetailsServiceModel> Cars { get; set; }
           = new List<CarDetailsServiceModel>();

        public string SearchText { get; set; }
    }
}
