namespace RentalCars.Web.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using RentalCars.Data.Models;
    using RentalCars.Services;
    using RentalCars.Services.Agency;
    using RentalCars.Services.Models;
    using RentalCars.Services.Models.Booking;
    using System.Threading.Tasks;

    public class UsersController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IUserService users;
        private readonly IBookingService bookings;
        private readonly IAgencyService agencies;


        public UsersController(
            UserManager<User> userManager,
            IUserService users,
            IBookingService bookings,
            IAgencyService agencies)
        {
            this.userManager = userManager;
            this.users = users;
            this.bookings = bookings;
            this.agencies = agencies;
        }

        public async Task<IActionResult> BookingHistory()
        {
            var userId = userManager.GetUserId(User);

            var user = await this.users.ByIdAsync<UserHistoryServiceModel>(userId);
            user.Orders = await this.bookings.FindAllBookings<BookingDetailsModel>(userId);

            return View(user);
        }
    }
}
