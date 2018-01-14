namespace RentalCars.Web.Models.HomeViewModels
{
    using RentalCars.Services.Models;
    using System.Collections.Generic;

    public class HomeIndexViewModel : SearchFormModel
    {
        public IEnumerable<CarDetailsServiceModel> Cars { get; set; }
    }
}
