﻿namespace RentalCars.Web.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using RentalCars.Data.Models;
    using RentalCars.Services;
    using RentalCars.Services.Agency;
    using RentalCars.Services.Models.Booking;
    using RentalCars.Web.Models;
    using System;
    using System.Threading.Tasks;

    public class BookingController : Controller
    {
        private const string BookingSuccessMessage = "Successfully booking";

        private readonly UserManager<User> userManager;
        private readonly IBookingService booking;
        private readonly ICarService cars;

        public BookingController(
            UserManager<User> userManager,
            IBookingService booking,
            ICarService cars)
        {
            this.userManager = userManager;
            this.booking = booking;
            this.cars = cars;
        }

        public IActionResult Create(int id)
       => this.View(new BookingViewModel
       {
           CarId = id,
           StartDate = DateTime.UtcNow,
           ReturnDate = DateTime.UtcNow.AddDays(1)
       });

        [HttpPost]
        public async Task<IActionResult> Create(BookingViewModel model)
        {
            var userId = userManager.GetUserId(User);

            if (!ModelState.IsValid)
            {
                return this.View(new BookingViewModel
                {
                    CarId = model.CarId,
                    StartDate = DateTime.UtcNow,
                    ReturnDate = DateTime.UtcNow.AddDays(1)
                });
            }

            await this.booking.CreateAsync(
                 model.StartDate,
                 model.ReturnDate,
                 userId,
                 model.CarId);

           

            return RedirectToAction(
                nameof(BookingController.UserLastBooking),
                "Booking",
                new { area = string.Empty });
        }

        public async Task<IActionResult> BookingDetails(int id)
        {
            var bookingModel = await this.booking.Details<BookingDetailsModel>(id);

            return View(bookingModel);
        }

        public async Task<IActionResult> UserLastBooking()
        {
            var userId = this.userManager.GetUserId(User);
            var bookingModel = await this.booking.FindLastBooking<BookingDetailsModel>(userId);

            return View(bookingModel);
        }
    }
}