namespace RentalCars.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RentalCars.Services.Admin;
    using RentalCars.Web.Areas.Admin.Models;
    using RentalCars.Web.Controllers;
    using RentalCars.Web.Infrastructure.Extensions;
    using System.Threading.Tasks;

    public class CityController : BaseController
    {
        private const string CitySuccessMessage = "City is Successfully added!";
        private readonly IAdminCityService cities;

        public CityController(IAdminCityService cities)
        {
            this.cities = cities;
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CityFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await this.cities.CreateAsync(
                 model.Name
                 );


            TempData.AddSuccessMessage(CitySuccessMessage);
            return RedirectToAction(
               nameof(HomeController.Index),
               "Home",
               new { area = string.Empty });
        }
    }
}
