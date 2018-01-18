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

        public UsersController(
            UserManager<User> userManager,
            IUserService users,
            IBookingService bookings)
        {
            this.userManager = userManager;
            this.users = users;
            this.bookings = bookings;
        }

        public async Task<IActionResult> BookingHistory(int page = 1)
        {
            var userId = userManager.GetUserId(User);

            var userHistory = await this.users.ByIdAsync<UserHistoryServiceModel>(userId);
            userHistory.Orders = await this.bookings.FindAllBookings<BookingDetailsModel>(userId, page);
            userHistory.TotalOrders = await this.bookings.TotalBookingAsync(userId);
            userHistory.CurrentPage = page;

            return View(userHistory);
        }
    }
}
