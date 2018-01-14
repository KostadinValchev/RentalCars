namespace RentalCars.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RentalCars.Services;
    using RentalCars.Services.Models;
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
            var model =await this.cars.ByIdAsync<CarDetailsServiceModel>(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }
    }
}
