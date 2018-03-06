namespace RentalCars.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RentalCars.Services;
    using RentalCars.Services.Models;
    using RentalCars.Web.Models.HomeViewModels;
    using System.Threading.Tasks;

    public class CarsController : Controller
    {
        private readonly ICarService cars;

        public CarsController(ICarService cars)
        {
            this.cars = cars;
        }

        public async Task<IActionResult> Details (int id)
        {
            var model =await this.cars.ByIdAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        public async Task<IActionResult> TopPopularCars(int page = 1)
        => View(new HomeIndexViewModel
        {
            Cars = await this.cars.AllAsync(page),
            TotalCars = await this.cars.TotalAsync(),
            CurrentPage = page
        });
    }
}
