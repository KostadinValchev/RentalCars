namespace RentalCars.Web.Areas.Agency.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using RentalCars.Data.Models;
    using RentalCars.Services.Agency;
    using RentalCars.Services.Models;
    using RentalCars.Web.Areas.Agency.Models;
    using RentalCars.Web.Controllers;
    using RentalCars.Web.Infrastructure.Extensions;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using static WebConstants;

    [Area(AgencyArea)]
    [Authorize(Roles = AgencyRole)]
    public class CarsController : Controller
    {
        private const string CarSuccessMessage = "Successfully added your car!";
        private const string CarDeleteMessage = "Successfully deleted your car!";
        private const string CarEditMessage = "Successfully edit!";
        private const string CarPublishAgainMessage = "Successfully published your car!";


        private readonly IAgencyService agencies;
        private readonly IAgencyCarService cars;
        private readonly UserManager<User> userManager;

        public CarsController(UserManager<User> userManager,
            IAgencyCarService cars,
            IAgencyService agencies)
        {
            this.userManager = userManager;
            this.cars = cars;
            this.agencies = agencies;
        }

        public async Task<IActionResult> All()
        {
            var userId = userManager.GetUserId(User);
            var agencyName = await this.agencies.FindAgencyNameAsync(userId);
            var cars = await this.cars.AllCarsAsync(agencyName);

            return this.View(cars);
        }

        public async Task<IActionResult> AllReturnedCars()
        {
            var userId = userManager.GetUserId(User);
            var agencyName = await this.agencies.FindAgencyNameAsync(userId);
            var cars = await this.cars.AllReturnedCarsAsync(agencyName);

            return this.View(cars);
        }

        public async Task<IActionResult> Create()
        {
            return View(new CarFormViewModel
            {
                Cities = await GetCities()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarFormViewModel carModel)
        {

            var userId = userManager.GetUserId(User);
            var agencyId = await this.agencies.FindAgencyByIdAsync(userId);

            if (!ModelState.IsValid)
            {
                carModel.Cities = await GetCities();
                return View(carModel);
            }

            await this.cars.CreateAsync(
                  carModel.Make,
                  carModel.Model,
                  carModel.Category,
                  carModel.Price,
                  carModel.FuelType,
                  carModel.AirConditioner,
                  carModel.Navigation,
                  carModel.Abs,
                  carModel.Asp,
                  carModel.Mp3Player,
                  agencyId,
                  carModel.CitiesId,
                  carModel.ImgUrl);

            TempData.AddSuccessMessage(CarSuccessMessage);
            return RedirectToAction(
                nameof(HomeController.Index),
                "Home",
                new { area = string.Empty });
        }

        [HttpPost]
        public async Task<IActionResult> Confirm(int id)
        {
            var success = await this.cars.DeleteAsync(id);

            if (!success)
            {
                return NotFound();
            }

            TempData.AddSuccessMessage(CarDeleteMessage);
            return RedirectToAction(
               nameof(CarsController.All),
               "Cars",
               new { area = "Agency" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var carModel = await this.cars.FindByIdAsync(id);
            carModel.Cities = await GetCities();


            return View(carModel);
        }

        private async Task<IEnumerable<SelectListItem>> GetCities()
        {
            var cities = await this.cars.GetCitiesAsync();

            var citiesListItems = cities
                .Select(t => new SelectListItem()
                {
                    Value = t.Id.ToString(),
                    Text = t.Name
                })
                .ToList();

            return citiesListItems;
        }

        public async Task<IActionResult> Edit(int id)
        {
            var carModel = await this.cars.FindByIdAsync(id);
            carModel.Cities = await GetCities();

            return View(carModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CarCrudModel carModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(
                nameof(CarsController.Edit),
                "Cars",
                new { area = "Agency" });
            }

            await this.cars.Edit(
                  carModel.Id,
                  carModel.Make,
                  carModel.Model,
                  carModel.Category,
                  carModel.Price,
                  carModel.FuelType,
                  carModel.AirConditioner,
                  carModel.Navigation,
                  carModel.Abs,
                  carModel.Asp,
                  carModel.Mp3Player,
                  carModel.CitiesId);

            TempData.AddSuccessMessage(CarEditMessage);
            return RedirectToAction(
               nameof(CarsController.All),
               "Cars",
               new { area = "Agency" });

        }

        [HttpPost]
        public async Task<IActionResult> PublishAgain(int id)
        {
            var success = await this.cars.PublishAgain(id);

            if (!success)
            {
                return NotFound();
            }

            TempData.AddSuccessMessage(CarDeleteMessage);
            return RedirectToAction(
               nameof(CarsController.AllReturnedCars),
               "Cars",
               new { area = "Agency" });
        }
    }
}
