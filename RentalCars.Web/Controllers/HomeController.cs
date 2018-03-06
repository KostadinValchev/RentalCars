namespace RentalCars.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RentalCars.Services;
    using RentalCars.Web.Models;
    using RentalCars.Web.Models.HomeViewModels;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        private readonly ICarService cars;

        public HomeController(ICarService cars)
        {
            this.cars = cars;
        }

        public async Task<IActionResult> Search(SearchFormModel model, int page = 1)
        {
            var viewModel = new SearchViewModel
            {
                SearchText = model.SearchText,
                Cars = await this.cars.AllAsync(page),
                TotalCars = await this.cars.TotalAsync(),
                CurrentPage = page
            };
            
            if (model.SearchInCity)
            {
                viewModel.Cars = await this.cars.FindCarByCityAsync(model.SearchText);
            }

            return View(viewModel);
        }
        public async Task<IActionResult> Index(int page = 1)
        => View(new HomeIndexViewModel
        {
            Cars = await this.cars.AllAsync(page),
            TotalCars = await this.cars.TotalAsync(),
            CurrentPage = page
        });

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
