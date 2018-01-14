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

        public async Task<IActionResult> Search(SearchFormModel model)
        {
            var viewModel = new SearchViewModel
            {
                SearchText = model.SearchText
            };

            if (model.SearchInCity)
            {
                viewModel.Cars = await this.cars.FindAsync(model.SearchText);
            }

            return View(viewModel);
        }
        public async Task<IActionResult> Index()
        => View(new HomeIndexViewModel
        {
            Cars =await this.cars.AllAsync()
        });

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
