namespace RentalCars.Web.Areas.Agency.Models
{
    using RentalCars.Services;
    using RentalCars.Services.Models;
    using System;
    using System.Collections.Generic;

    public class AllCarsAgencyViewModel
    {
        public IEnumerable<CarDetailsServiceModel> Cars { get; set; }

        public int TotalCars { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalCars / ServiceConstants.CarsAgencyPageSize);

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == this.TotalPages
            ? this.TotalPages
            : this.CurrentPage + 1;
    }
}
