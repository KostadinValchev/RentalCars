namespace RentalCars.Web.Models.HomeViewModels
{
    using RentalCars.Services;
    using RentalCars.Services.Models;
    using System;
    using System.Collections.Generic;

    public class SearchViewModel
    {
        public IEnumerable<CarDetailsServiceModel> Cars { get; set; }
           = new List<CarDetailsServiceModel>();

        public string SearchText { get; set; }

        public int TotalCars { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalCars / ServiceConstants.CarsHomeIndexPageSize);

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == this.TotalPages
            ? this.TotalPages
            : this.CurrentPage + 1;
    }
}
