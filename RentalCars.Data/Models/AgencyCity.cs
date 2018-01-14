namespace RentalCars.Data.Models
{
    public class AgencyCity
    {
        public int AgencyId { get; set; }

        public Agency Agency { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }
    }
}
