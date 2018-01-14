namespace RentalCars.Services.Models
{
    using RentalCars.Common.Mapping;
    using RentalCars.Data.Models;
    using RentalCars.Services.Models.Booking;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;

    public class UserHistoryServiceModel : IMapFrom<User>
    {
        public string Id { get; set; }

        [MinLength(UserNameMinLength)]
        [MaxLength(UserNameMaxLength)]
        public string Name { get; set; }

        public Agency Agency { get; set; }

        public string AgencyName { get; set; }

        public IEnumerable<BookingDetailsModel> Orders { get; set; } = new List<BookingDetailsModel>();
    }
}
