namespace RentalCars.Web.Areas.Agency.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using RentalCars.Data.Models;
    using RentalCars.Services;
    using RentalCars.Services.Agency;
    using RentalCars.Web.Areas.Agency.Models;
    using RentalCars.Web.Controllers;
    using RentalCars.Web.Infrastructure.Extensions;
    using System.Threading.Tasks;
    using static WebConstants;

    [Authorize(Roles = AgencyRole)]
    [Area(AgencyArea)]
    public class AgencyController : Controller
    {
        private const string AgencySuccessMessage = "Agency is Successfully added!";

        private readonly IAgencyService agencies;
        private readonly UserManager<User> userManager;
        private readonly IImageService images;

        public AgencyController(
            IAgencyService agencies,
            UserManager<User> userManager,
            IImageService images)
        {
            this.agencies = agencies;
            this.userManager = userManager;
            this.images = images;
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(AgencyFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var userId = this.userManager.GetUserId(User);

            var image = await this.images.CreateImageInDatabaseAsync(model.Image);

            await this.agencies.CreateAsync(
                   model.Name,
                   userId,
                   image
                   );

            TempData.AddSuccessMessage(AgencySuccessMessage);

            return RedirectToAction(
                nameof(HomeController.Index),
                "Home",
                new { area = string.Empty });
        }
    }
}

